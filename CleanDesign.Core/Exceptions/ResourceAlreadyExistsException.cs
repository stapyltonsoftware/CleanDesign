using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDesign.Core.Exceptions
{
    public class ResourceAlreadyExistsException : Exception
    {
        public ResourceAlreadyExistsException()
        {
            
        }

        public ResourceAlreadyExistsException(string message) : base(message) 
        {
            
        }
    }
}
