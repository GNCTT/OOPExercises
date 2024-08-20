using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Town town = new Town();
            town.GetDataFromInput();
            town.ShowInfo();
        }
    }
}
