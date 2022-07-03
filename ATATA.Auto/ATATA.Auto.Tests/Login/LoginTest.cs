using Atata;
using ATATA.Auto.Core.Meta;
using ATATA.Auto.Project.PageObjects.Pages;
using ATATA.Auto.Project.PageObjects.Steps;
using ATATA.Auto.Project.Utils;
using NUnit.Framework;

namespace ATATA.Auto.Tests.Login
{
    public class LoginTest: BaseTest
    {
        [Test]
        [Category(TestType.Smoke)]
        public void LoginWithValidCredentials()
        {
            Go.To<SignInPage>()
                .Login<OverviewPage>(ConfigurationHelper.CurrentUser)
                .OverviewDashboard.Should.Exist();
        }

        [Test]
        [Category(TestType.Smoke)]
        public void LoginWithInValidCredentials()
        {
            Go.To<SignInPage>()
                .Login<SignInPage>("not_exists@epam.com", "password")
                .Heading.Should.Contain("Guest Travel Manager")
                .Content.Should.Contain("Invalid sign-in attempt.");
        }
    }
}
