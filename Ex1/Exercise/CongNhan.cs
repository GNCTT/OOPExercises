using System;
using System.Security.AccessControl;

namespace Exercise
{
    public class CongNhan : CanBo
    {
        public CongNhan() { }

        public CongNhan(string name) : base(name)
        {

        }

        public CongNhan(string name, int level) : base(name)
        {
            Level = level;
        }
        public int Level { get; set; }

        public override void Introduce()
        {
            System.Console.WriteLine("I'm a Employee with level: " + Level);
        }

        public override void GetDataFromInput()
        {
            base.GetDataFromInput();
        }

        private void TypeLevel()
        {
            Console.WriteLine("Level: ");
            string levelInput = Console.ReadLine();
            if (ValidateLevelInput(levelInput))
            {
                Level = int.Parse(levelInput);
            } else
            {
                Console.WriteLine("Wrong Level Input. Please try again");
                TypeLevel();
            }
        }

        private bool ValidateLevelInput(string levelInput)
        {
            if (string.IsNullOrEmpty(levelInput)) return false;
            int level = 0;
            if (!int.TryParse(levelInput, out level)) return false;
            if (level < 1 || level > 10) return false;
            return true;
        }

        public override string ToString()
        {
            return "Worker: " + base.ToString() + ", Level: " + Level;
        }
    }
}
