using Atata;
using ATATA.Auto.Project.PageObjects.Pages;
using ATATA.Auto.Project.PageObjects.Pages.HelpCenter;
using ATATA.Auto.Project.PageObjects.Pages.Profiles;
using ATATA.Auto.Project.PageObjects.Pages.Project;
using ATATA.Auto.Project.PageObjects.Pages.Travelers;
using ATATA.Auto.Project.PageObjects.Pages.Uploads;
using ATATA.Auto.Project.PageObjects.Pages.Users;

namespace ATATA.Auto.Project.PageObjects.Elements
{
    public class MainMenu<T> : Control<T>  where T : PageObject<T>
    {
        [FindByXPath("//div[normalize-space(.) = 'Overview']")]
        public ClickableDelegate<OverviewPage, T> Overview { get; private set; }

        [FindByXPath("//div[normalize-space(.) = 'Projects']")]
        public ClickableDelegate<ProjectsPage, T> Projects { get; private set; }

        [FindByXPath("//div[normalize-space(.) = 'Travelers']")]
        public ClickableDelegate<TravelersPage, T> Travelers { get; private set; }

        [FindByXPath("//div[normalize-space(.) = 'Users']")]
        public ClickableDelegate<UsersPage, T> Users { get; private set; }

        [FindByXPath("//div[normalize-space(.) = 'Profiles']")]
        public ClickableDelegate<ProfilesPage, T> Profiles { get; private set; }

        [FindByXPath("//div[normalize-space(.) = 'Uploads']")]
        public ClickableDelegate<UploadsPage, T> Uploads { get; private set; }

        [FindByXPath("//div[normalize-space(.) = 'Help center']")]
        public ClickableDelegate<HelpCenterPage, T> HelpCenter { get; private set; }
    }
}
