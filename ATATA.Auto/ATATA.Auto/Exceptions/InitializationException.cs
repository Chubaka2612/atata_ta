using System;

namespace ATATA.Auto.Core.Exceptions
{
    [Serializable]
    public class InitializationException: Exception
    {
        public InitializationException(string message) : base(message) { }
    }
}
