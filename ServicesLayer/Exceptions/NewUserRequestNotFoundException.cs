using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Exceptions
{
    public class NewUserRequestNotFoundException : Exception
    {
        public NewUserRequestNotFoundException()
        {
        }

        public NewUserRequestNotFoundException(string? message) : base(message)
        {
        }

        public NewUserRequestNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NewUserRequestNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
