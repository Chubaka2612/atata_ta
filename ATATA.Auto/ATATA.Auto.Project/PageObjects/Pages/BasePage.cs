using Atata;
using ATATA.Auto.Project.PageObjects.Elements;

namespace ATATA.Auto.Project.PageObjects.Pages
{
  
    public class BasePage<T> : Page<T> where T: Page<T>
    {
        [Name("Main Menu")]
        [FindByXPath("//div[@data-locator='main-menu']")]
        public MainMenu<T> MainMenu { get; set; }

        [Name("Create New")]
        [FindByXPath(".//button[@data-locator = 'create-button']")]
        public Button<T> EntityActionButton { get; set; }
    }
}
