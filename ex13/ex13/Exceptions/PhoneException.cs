﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex13.Exceptions
{
    internal class PhoneException : Exception
    {
        public PhoneException() { }

        public PhoneException(string message) : base(message)
        {
        }
    }
}
