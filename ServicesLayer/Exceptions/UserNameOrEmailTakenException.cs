using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Exceptions
{
    public class UserNameOrEmailTakenException : Exception
    {
        public UserNameOrEmailTakenException()
        {
        }

        public UserNameOrEmailTakenException(string? message) : base(message)
        {
        }

        public UserNameOrEmailTakenException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UserNameOrEmailTakenException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
