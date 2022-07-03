using System.Collections.Generic;
using Atata.Configuration.Json;

namespace ATATA.Auto.Project.Utils
{
    public class LaunchConfig: JsonConfig<LaunchConfig>
    {
        public string SelectedBrowser { get; set; }

        public string SelectedUserRole { get; set; }

        public string DownloadsDirName { get; set; }

        public List<User> Users { get; set; }

        public class User
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Email { get; set; }

            public string Password { get; set; }

            public string Role { get; set; }
        }
    }
}
