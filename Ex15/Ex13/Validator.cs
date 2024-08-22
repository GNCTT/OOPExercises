using Ex13.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ex13
{
    public static class Validator
    {
        public static bool ValidateId(string input)
        {
            string pattern = @"^\d+$";
            return Validate(input, pattern, new InvalidNameException());
        }

        public static bool ValidateName(string input)
        {
            string pattern = "^[A-Za-z]+(?: [A-Za-z]+)*$";
            return Validate(input, pattern, new InvalidNameException());
        }

        public static bool ValidateDate(string input)
        {
            string pattern = "^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/([0-9]{4})$";
            return Validate(input, pattern, new InvalidDateException());
        }

        private static bool Validate(string input, string pattern, Exception exception)
        {
            if (Regex.IsMatch(input, pattern)) return true;
            throw exception;
        }
    }
}
