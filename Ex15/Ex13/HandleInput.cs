using Ex13.Exceptions;
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

        public static int TypeNumber(string info, string message, Predicate<int> conditions)
        {
            Console.WriteLine(info);
            var input = Console.ReadLine();
            int num = 0;
            if (int.TryParse(input, out num) && conditions(num))
            {
                return num;
            }
            Console.WriteLine(message);
            return TypeNumber(info, message, conditions);
        }

        public static string TypeDate(string info, string message, Predicate<string> conditions = null)
        {
            Console.WriteLine(info);
            var input = Console.ReadLine();

            return "";
        }
    }
}
