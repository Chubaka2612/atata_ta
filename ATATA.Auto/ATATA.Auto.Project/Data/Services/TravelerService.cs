using ATATA.Auto.Core.Utils;
using ATATA.Auto.Project.Data.Models;
using ATATA.Auto.Project.Data.Utils;

namespace ATATA.Auto.Project.Data.Services
{
    public static class TravelerService
    {
        public static string EmailPrefix => "gtmautotraveler";

        public static TravelerModel GenerateTraveler(string namePrefix = default)
        {
            namePrefix ??= RandomStringUtils.RandomString(4);
            return new TravelerModel()
            {
                FirstName = AutogenDataUtils.EntityPrefixName + namePrefix,
                LastName = "Traveler " + namePrefix,
                Email = AutogenDataUtils.GenerateEmail(EmailPrefix),
                Phone = RandomStringUtils.RandomNumeric(15)
            };
        }
    }
}
