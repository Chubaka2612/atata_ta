using System.Collections.Generic;
using Atata.Configuration.Json;
using ATATA.Auto.Core.Meta;

namespace ATATA.Auto.Project.Utils
{
    public class LaunchConfig: JsonConfig<LaunchConfig>
    {
        public Browsers SelectedBrowser { get; set; }

        public string SelectedUserRole { get; set; }

        public string DownloadsDirName { get; set; }

        public bool IsRemoteLaunchMode { get; set; }

        public SauceLabConfig SauceLab { get; set; }

        public List<User> Users { get; set; }

        public class User
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Email { get; set; }

            public string Password { get; set; }

            public string Role { get; set; }
        }

        public class SauceLabConfig
        {
            public string UserName { get; set; }

            public string AccessKey { get; set; }

            public string RemoteUri { get; set; }

            public string Platform { get; set; }

            public string BrowserVersion { get; set; }
        }
    }
}
