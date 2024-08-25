using Ex15.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex15
{
    public static class HandleInput
    {
        public static string TypeString(string info, string message)
        {
            Console.WriteLine(info);
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine(message);
                throw new BlankException();
            }
            return input;
        }

        public static string TypeString(string info, string message, Predicate<string> conditions)
        {
            string input = TypeString(info, message);
            if (conditions(input)) return input;
            Console.WriteLine(message);
            return TypeString(info, message, conditions);
        }

        public static T TypeNumber<T>(string info, string message, Predicate<T> conditions, Func<string, T> parse)
        {
            Console.WriteLine(info);
            var input = Console.ReadLine();
            T num;
            try
            {
                num = parse(input);
                if (conditions(num)) return num;
                throw new InvalidNumberException();
            } catch
            {
                Console.WriteLine(message);
                throw new InvalidNumberException();
            }
        }

        public static int TypeNumber(string info, string message, Predicate<int> conditions = null)
        {
            return TypeNumber<int>(info, message, conditions, int.Parse);
        }

        public static float TypeFloatNumber(string info, string message, Predicate<float> conditions)
        {
            return TypeNumber<float> (info, message, conditions, float.Parse);
        }

        public static DateTime TypeDate(string info, string message, Predicate<string> conditions = null)
        {
            Console.WriteLine(info);
            var input = Console.ReadLine();
            DateTime birthday;
            if (!Validator.ValidateDate(input))
            {
                Console.WriteLine(message);
                throw new InvalidDateException();
            }
            if (DateTime.TryParseExact(input, "dd/mm/yyyy", null, System.Globalization.DateTimeStyles.None, out birthday))
            {
                return birthday;
            }
            Console.WriteLine(message);
            throw new InvalidDateException();
        }
    }
}
