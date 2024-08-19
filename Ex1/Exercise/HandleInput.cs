using System;
using System.Runtime.InteropServices;

namespace Exercise
{
    public class HandleInput
    {
        public string TypeName()
        {
            Console.WriteLine("Name: ");
            string nameInput = Console.ReadLine();
            if ( string.IsNullOrEmpty(nameInput))
            {
                Console.WriteLine("Wrong name format. Do not leave name empty!");
                return TypeName();
            }
            return nameInput;
        }

    }
}
