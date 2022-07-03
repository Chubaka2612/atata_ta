using ATATA.Auto.Project.Data.Models;
using ATATA.Auto.Project.PageObjects.Pages.Travelers;

namespace ATATA.Auto.Project.PageObjects.Steps
{
    public static class TravelerSteps
    {
        public static TravelerCreatePage OpenTravelerCreatePage(this TravelersPage travelersPage)
        {
           return travelersPage
                .EntityActionButton
                .ClickAndGo<TravelerCreatePage>();
        }

        public static TravelersPage CreateNewTraveler(this TravelersPage travelersPage, TravelerModel traveler)
        {
            var travelersCreatePage = travelersPage
             .OpenTravelerCreatePage()
             .FillNewTravelerInfo(traveler)
             .CancelButton
             .Focus()
             .WaitSeconds(1);
            return travelersCreatePage
                .CreateTravelerButton
                .ClickAndGo<TravelersPage>();
        }

        public static TravelerCreatePage FillNewTravelerInfo(this TravelerCreatePage travelerCreatePage, TravelerModel traveler)
        {
          return travelerCreatePage
                .FirstNameInput.Set(traveler.FirstName)
                .LastNameInput.Set(traveler.LastName)
                .EmailInput.Set(traveler.Email)
                .PhoneInputText.Set(traveler.Phone)
                .WaitSeconds(0.2); 
        }
    }
}