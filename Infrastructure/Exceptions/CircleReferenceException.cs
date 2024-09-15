using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Exceptions
{
    public class CircleReferenceException : Exception
    {
        public string Property { get; set; }
        public CircleReferenceException(string propertyName)
            : base($"Circle reference occured by {propertyName}")
        {
            this.Property = propertyName;
        }
    }
}
