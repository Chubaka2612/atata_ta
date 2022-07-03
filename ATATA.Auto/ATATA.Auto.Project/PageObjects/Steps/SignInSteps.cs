using Atata;
using ATATA.Auto.Project.PageObjects.Pages;
using ATATA.Auto.Project.PageObjects.Pages.Project;
using ATATA.Auto.Project.Utils;
using NUnit.Allure.Attributes;

namespace ATATA.Auto.Project.PageObjects.Steps
{
    public static class SignInSteps
    {
        public static T Login<T>(this SignInPage page, string email, string password) where T: Page<T>
        {
            return page.EmailInput.Set(email)
                .WaitSeconds(0.1)
                .PasswordInput.Set(password)
                .RememberMe.Check()
                .SignInButton.ClickAndGo<T>();
        }
        
        public static T Login<T>(this SignInPage page, LaunchConfig.User currentUser) where T : Page<T>
        {
            return Login<T>(page, currentUser.Email, currentUser.Password);
        }

        public static ProjectsPage OpenReactUi<T>(this T page) where T : Page<T>
        {
            return Go.To<ProjectsPage>();   
        }
    }
}
