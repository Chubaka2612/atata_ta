using Allure.Commons;
using Atata;
using ATATA.Auto.Core.Exceptions;
using ATATA.Auto.Project.Utils;
using NUnit.Framework;

namespace ATATA.Auto.Tests
{
    [SetUpFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class GlobalSetup
    {

        [OneTimeSetUp]
        public void BeforeAll()
        {
            InitContext(); 
            AllureLifecycle.Instance.CleanupResultDirectory();
            //AtataContext.Current?.Log.Info("Tests execution started");
        }

        [OneTimeTearDown]
        public void AfterAll()
        {
            //AtataContext.Current?.Log.Info("Tests execution finished");
        }

        private void InitContext()
        {

            var browser = ConfigurationHelper.SelectedBrowser;

            var atataGlobalConfig = AtataContext
                .GlobalConfiguration;

            switch (browser)
            {
                case "Firefox":
                    atataGlobalConfig.UseFirefox();
                    break;
                case "Chrome":
                    atataGlobalConfig.UseChrome();
                    break;
                default:
                    throw new InitializationException($"Unknown '{browser}' driver type.");
            }

            atataGlobalConfig.UseBaseUrl(ConfigurationHelper.MainUrl)
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
                .AutoSetUpDriverToUse()
                ;
        }
    }

    [TestFixture]
    public class BaseTest
    {
        [SetUp]
        protected void BeforeEach()
        {
            SetUpDriver();
        }

        private void SetUpDriver()
        {
            string browser = ConfigurationHelper.SelectedBrowser;
            switch (browser)
            {
                case "Chrome":
                    AtataContext
                        .Configure()
                        .UseChrome()
                        .WithFixOfCommandExecutionDelay()
                        .WithArguments("--disable-notifications", "--no-sandbox", "disable-extensions")
                        .WithOptions(option =>
                        {
                            option.AddUserProfilePreference("download.default_directory", ConfigurationHelper.DownloadsDirName);
                            option.AddUserProfilePreference("intl.accept_languages", "nl");
                            option.AddUserProfilePreference("disable-popup-blocking", "true");
                        })
                        .Build();
                    break;
                case "Firefox":
                    AtataContext
                        .Configure()
                        .UseFirefox()
                        .WithFixOfCommandExecutionDelay()
                        .WithOptions(option => option.SetPreference("dom.webnotifications.enabled", false))
                        .Build();
                    break;
                default:
                    throw new InitializationException($"No such browser {browser}");
            }

            AtataContext.Current.Driver.Maximize();
        }

        [TearDown]
        public void AfterEach()
        {
            AtataContext
                .Current
                .Driver
                .Manage()
                .Cookies
                .DeleteAllCookies();

            AtataContext
                .Current?
                .CleanUp();
        }
    }
}