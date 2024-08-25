using System;

namespace Exercise3
{
    public static class HandleInput
    {
        public static string TypeString(string info, string messageError)
        {
            Console.WriteLine(info);

            string input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                return input;
            }

            Console.WriteLine(messageError);
            return TypeString(info, messageError);
        }

        public static int TypeNumber(string info, string messageError, Predicate<int> condition)
        {
            Console.WriteLine(info);

            string input = Console.ReadLine();
            int number = 0;
            if (int.TryParse(input, out number) && condition(number))
            {
                return number;
            }

            Console.WriteLine(messageError);
            return TypeNumber(info, messageError, condition);
        }
    }
}
