
using Atata;

namespace ATATA.Auto.Project.PageObjects.Pages.Travelers
{
    [Url("/travelers/create-traveler")]
    [VerifyContent("New Traveler")]
    public class TravelerCreatePage : BasePage<TravelerCreatePage>
    {
        [Name("Cancel")]
        [FindByXPath( "//button[@data-locator='cancel-create-traveler-button']")]
        public Button<TravelerCreatePage> CancelButton { get; private set; }

        [Name("Create Traveler")]
        [FindByXPath("//button[@data-locator='create-traveler-button']")]
        public Button<TravelerCreatePage> CreateTravelerButton { get; private set; }

        [Name("First Name")]
        [FindByXPath("//div[@data-locator='input_traveler_first_name']")]
        public TextInput<TravelerCreatePage> FirstNameInput { get; private set; }

        [Name("Last Name")]
        [FindByXPath("//div[@data-locator='input_traveler_last_name']")]
        public TextInput<TravelerCreatePage> LastNameInput { get; private set; }

        [Name("Email")]
        [FindByXPath("//div[@data-locator='input_traveler_email']")]
        public TextInput<TravelerCreatePage> EmailInput { get; private set; }

        [Name("Phone Number")]
        [FindByXPath("//div[@data-locator='input_traveler_phone']//input")]
        public TextInput<TravelerCreatePage> PhoneInputText { get; private set; }
    }
}
