using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Exceptions
{
    public class RoleNotFoundException : Exception
    {
        public RoleNotFoundException()
        {
        }

        public RoleNotFoundException(string? message) : base(message)
        {
        }

        public RoleNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected RoleNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
