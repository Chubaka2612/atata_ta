using Atata;

namespace ATATA.Auto.Project.PageObjects.Pages
{
    [Url("overview")]
    [VerifyContent("Projects Distribution")]
    public class OverviewPage : Page<OverviewPage>
    {
        [Name("Overview Dashboard")]
        [FindById("react-overview")]
        public Control<OverviewPage> OverviewDashboard { get; set; }
    }
}
