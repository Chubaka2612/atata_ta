using Allure.Commons;
using Atata;
using ATATA.Auto.Core.Meta;
using ATATA.Auto.Project.PageObjects.Pages;
using ATATA.Auto.Project.PageObjects.Steps;
using ATATA.Auto.Project.Utils;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace ATATA.Auto.Tests.Login
{
    [AllureNUnit]
    [AllureSuite("User Management")]
    [AllureDisplayIgnored]
    public class LoginTest: BaseTest
    {
        [Test]
        [Category(TestType.Smoke)]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag(ComponentName.GTM_Login)]
        [AllureOwner(Author.ViktoriiaSkirko)]
        [AllureSubSuite("Login")]
        public void LoginWithValidCredentials()
        {
            Go.To<SignInPage>()
                .Login<OverviewPage>(ConfigurationHelper.CurrentUser)
                .OverviewDashboard.Should.Exist();
        }

        [Test]
        [Category(TestType.Smoke)]
        [AllureSeverity(SeverityLevel.trivial)]
        [AllureTag(ComponentName.GTM_Login)]
        [AllureOwner(Author.ViktoriiaSkirko)]
        [AllureSubSuite("Login")]
        public void LoginWithInValidCredentials()
        {
            Go.To<SignInPage>()
                .Login<SignInPage>("not_exists@epam.com", "password")
                .Heading.Should.Contain("Guest Travel Manager")
                .Content.Should.Contain("Invalid sign-in attempt.");
        }
    }
}
