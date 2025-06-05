using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Exceptions
{
    public class InternalServerErrorException:Exception
    {
        public InternalServerErrorException(string message):base(message) { }
        public InternalServerErrorException(string message, string details):base(message)
        {
            Details = details;
        }
        public string Details { get;}
    }
}
