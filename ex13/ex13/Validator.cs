using ex13.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ex13
{
    public static class Validator
    {
        public static bool ValidateBirthDay(string input)
        {
            Regex regex = new Regex(@"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}$");
            if (!regex.IsMatch(input)) throw new BirthDayException(input); 
            return true;
        }

        public static bool ValidatePhoneNumber(string input)
        {
            Regex regex = new Regex(@"^\d+$");
            if (!regex.IsMatch(input)) throw new PhoneException(input); 
            return true;
        }

        public static bool ValidateEmail(string input)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(input)) throw new EmailException(input);
            return true; 
        }

        public static bool ValidateFullName(string input)
        {
            Regex regex = new Regex("^[a-z A-Z]+$");
            Regex regex1 = new Regex(@"\s{2,}");
            if (regex1.IsMatch(input) || !regex.IsMatch(input)) 
            {
                 throw new FullNameException(input);
            }
            return true;
        }
    }
}
    
