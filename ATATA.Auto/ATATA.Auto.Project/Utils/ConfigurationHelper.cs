using System;
using System.Linq;
using Atata;
using ATATA.Auto.Core.Exceptions;
using ATATA.Auto.Core.Meta;

namespace ATATA.Auto.Project.Utils
{
    public static class ConfigurationHelper
    {
        private static AtataContextBuilder _configBuilder;

        private static string configFileName = "appsettings.json";

        public static AtataContextBuilder Configuration => GetConfiguration(configFileName);

        public static string MainUrl => Configuration.BuildingContext.BaseUrl;

        public static TimeSpan ElementFindTimeout => Configuration.BuildingContext.ElementFindTimeout;

        public static TimeSpan ElementFindRetryInterval => Configuration.BuildingContext.ElementFindRetryInterval;

        public static TimeSpan WaitingTimeout => Configuration.BuildingContext.WaitingTimeout;

        public static TimeSpan WaitingRetryInterval => Configuration.BuildingContext.WaitingRetryInterval;

        public static Browsers SelectedBrowser => Configuration.GetLaunchConfig().SelectedBrowser;

        public static bool IsRemoteLaunchMode => Configuration.GetLaunchConfig().IsRemoteLaunchMode;

        public static string SelectedUserRole => Configuration.GetLaunchConfig().SelectedUserRole;

        public static string DownloadsDirName => Configuration.GetLaunchConfig().DownloadsDirName;


        public static LaunchConfig.User CurrentUser = Configuration.GetLaunchConfig().Users.First(u => u.Role == SelectedUserRole);

        public static AtataContextBuilder GetConfiguration(string fileName)
        {
            if (_configBuilder != null)
            {
                return _configBuilder;
            }
            try
            {
                _configBuilder = AtataContext
                    .Configure()
                    .ApplyJsonConfig<LaunchConfig>(fileName);

                var r = LaunchConfig.Current.SelectedBrowser;
                return _configBuilder;
            }
            catch (Exception ex)
            {
                throw new InitializationException($"Can't load config file {fileName}:" + ex.Message);
            }
        }

        public static LaunchConfig GetLaunchConfig(this AtataContextBuilder atataContextBuilder)
        {
            GetConfiguration(configFileName);
            return LaunchConfig.Current;
        }
    }
}
