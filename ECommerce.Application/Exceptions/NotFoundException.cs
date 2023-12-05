using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key)
            :base($"{name} ({key}) was not found")
        {
                
        }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
