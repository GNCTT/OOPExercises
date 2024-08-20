using System;

namespace Ex4
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
                return TypeString(info, message);
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
    }
}
