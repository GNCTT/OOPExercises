using System;

namespace ex13.Exceptions
{
    public class BirthDayException : Exception
    {
        public BirthDayException() { }

        public BirthDayException(string date) : base(date) { }
    }
}
