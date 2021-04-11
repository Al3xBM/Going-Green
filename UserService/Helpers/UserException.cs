using System;
using System.Globalization;
using System.Net.Cache;
using System.Runtime.Serialization;

namespace UserService.Helpers
{
    /// <summary>
    /// Custom exception class for throwing UserService specific exceptions
    /// </summary>
    [System.SerializableAttribute()]
    public class UserException : Exception
    {
        public UserException() : base()
        {
        }

        public UserException(string message) : base(message)
        {
        }

        public UserException(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }

        protected UserException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}