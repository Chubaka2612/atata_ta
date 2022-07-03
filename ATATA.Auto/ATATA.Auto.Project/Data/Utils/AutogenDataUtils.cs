using System;

namespace ATATA.Auto.Project.Data.Utils
{
    public static class AutogenDataUtils
    {
        public static string EntityPrefixName => "EPAM Auto "; 

        public static string GenerateEmail(string prefix)
        {
            return new string($"{prefix}{DateTime.Now:hhmmssffff}{new Random().Next(1, 10)}@mailinator.com");
        }
    }
}
