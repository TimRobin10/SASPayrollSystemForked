using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Exceptions
{
    public class UserNameOrEmailTaken : Exception
    {
        public UserNameOrEmailTaken()
        {
        }

        public UserNameOrEmailTaken(string? message) : base(message)
        {
        }

        public UserNameOrEmailTaken(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UserNameOrEmailTaken(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
