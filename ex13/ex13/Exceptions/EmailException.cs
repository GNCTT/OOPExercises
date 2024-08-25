using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex13.Exceptions
{
    internal class EmailException : Exception
    {
        public EmailException() { }

        public EmailException(string message) : base(message)
        {
        }
    }
}
