using Atata;

namespace ATATA.Auto.Project.PageObjects.Pages
{
    [Url("SignIn")]
 // [VerifyTitle(Title)]
    public class SignInPage : Page<SignInPage>
    {
        public const string Title = "Sign in · Guest Travel Manager";

        public H1<SignInPage> Heading { get; private set; }

        [Name("Email")]
        [Term("Email")]
        public TextInput<SignInPage> EmailInput { get; private set; }

        [Name("Password")]
        [FindById("PasswordValue")]
        public PasswordInput<SignInPage> PasswordInput { get; private set; }

        [Name("SignIn")]
        [FindById("submit-signin-local")]
        public Button<OverviewPage, SignInPage> SignInButton { get; private set; }

        [Name("Remember Me")]
        [FindByLabel("Remember me")]
        public CheckBox<SignInPage> RememberMe { get; private set; }

    }
}
