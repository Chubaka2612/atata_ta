using Allure.Commons;
using Atata;
using ATATA.Auto.Core.Exceptions;
using ATATA.Auto.Core.Meta;
using ATATA.Auto.Project.Utils;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;

namespace ATATA.Auto.Tests
{
    [SetUpFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class GlobalSetup
    {

        [OneTimeSetUp]
        public void BeforeAll()
        {
            AllureLifecycle.Instance.CleanupResultDirectory();
        }

        [OneTimeTearDown]
        public void AfterAll()
        {

        }
    }

    
    [TestFixture]
    public class BaseTest
    {
       private Browsers browser;
       private AtataContextBuilder atataBuilder;

        [SetUp]
        protected void BeforeEach()
        {
            InitContext();
        }

        private void SetUpDriver() 
        {
            if (ConfigurationHelper.IsRemoteLaunchMode)
            {
                SetRemoteLocalDriver();
            }
            else
            {
                SetUpLocalDriver();
            }

            atataBuilder.UseBaseUrl(ConfigurationHelper.MainUrl)
                .UseWaitingTimeout(ConfigurationHelper.WaitingTimeout)
                .UseElementFindTimeout(ConfigurationHelper.ElementFindTimeout)
                .UseWaitingRetryInterval(ConfigurationHelper.WaitingRetryInterval)
                .UseElementFindRetryInterval(ConfigurationHelper.ElementFindRetryInterval)
                .UseCulture("en-es")
                .UseAllNUnitFeatures()
                .TakeScreenshotOnNUnitError()
                .ScreenshotConsumers
                .AddFile()
                .WithDirectoryPath(() => $@"TestsResults\ScreenShots\{AtataContext.BuildStart:yyyy-MM-dd HH_mm_ss}")
                .WithFileName(screenshotInfo => $"{screenshotInfo.PageObjectName}_{AtataContext.Current.TestName}")
                ;
        }


        private void InitContext()
        {
            browser = ConfigurationHelper.SelectedBrowser;
            atataBuilder = AtataContext.Configure();

            SetUpDriver();
          
            atataBuilder.Build();
            AtataContext.Current.Driver.Maximize();
        }

        private void SetUpLocalDriver()
        {
            switch (browser)
            {
                case Browsers.Chrome:
                    atataBuilder
                        .UseChrome()
                        .WithFixOfCommandExecutionDelay()
                        .WithArguments("--disable-notifications", "--no-sandbox", "disable-extensions")
                        .WithOptions(option =>
                        {
                            option.AddUserProfilePreference("download.default_directory", ConfigurationHelper.DownloadsDirName);
                            option.AddUserProfilePreference("intl.accept_languages", "nl");
                            option.AddUserProfilePreference("disable-popup-blocking", "true");
                        }) ;
                    break;
                case Browsers.Firefox:
                    atataBuilder
                        .UseFirefox()
                        .WithFixOfCommandExecutionDelay()
                        .WithOptions(option => option.SetPreference("dom.webnotifications.enabled", false));
                    break;
                default:
                    throw new InitializationException($"No such browser {browser}");
            }
            atataBuilder.AutoSetUpDriverToUse();
        }

        private void SetRemoteLocalDriver()
        {
            DriverOptions browserOptions = browser switch
            {
                Browsers.Chrome => new ChromeOptions(),
                Browsers.Firefox => new FirefoxOptions(),
                _ => throw new InitializationException($"No such browser {browser}"),
            };
            browserOptions.AcceptInsecureCertificates = true;

            browserOptions.PlatformName = ConfigurationHelper.Configuration.GetLaunchConfig().SauceLab.Platform;
            browserOptions.BrowserVersion = ConfigurationHelper.Configuration.GetLaunchConfig().SauceLab.BrowserVersion;
            browserOptions.AddAdditionalOption("username", ConfigurationHelper.Configuration.GetLaunchConfig().SauceLab.UserName);
            browserOptions.AddAdditionalOption("accessKey", ConfigurationHelper.Configuration.GetLaunchConfig().SauceLab.AccessKey);
            var sauceOptions = new Dictionary<string, object>
            {
                { "name", TestContext.CurrentContext.Test.Name },
                { "build", "AtataBuid:" + DateTime.Now }
            };
            browserOptions.AddAdditionalOption("sauce:options", sauceOptions);

            var uri = new Uri(ConfigurationHelper.Configuration.GetLaunchConfig().SauceLab.RemoteUri);

            atataBuilder
                       .UseRemoteDriver()
                       .WithCapabilities(browserOptions.ToCapabilities())
                       .WithRemoteAddress(uri)
                       ;
        }

        [TearDown]
        public void AfterEach()
        {
            var passed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed;
            ((IJavaScriptExecutor)AtataContext.Current.Driver).ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));

            AtataContext
                .Current?
                .Driver?
                .Manage()
                .Cookies
                .DeleteAllCookies();

            AtataContext
                .Current?
                .CleanUp();
        }
    }
}