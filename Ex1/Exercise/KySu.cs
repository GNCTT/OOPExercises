using System;

namespace Exercise
{
    public class KySu : CanBo
    {
        public KySu() { }
        public KySu(string name) : base(name)
        {

        }
        public KySu(string name, string major) : base(name)
        {
            Major = major;
        }

        public string Major { get; set; }

        public override void Introduce()
        {
            System.Console.WriteLine("I'm Engineer with Major: " + Major);
        }

        public override void GetDataFromInput()
        {
            base.GetDataFromInput();
            TypeMajor();
        }

        private void TypeMajor()
        {
            Console.WriteLine("Major: ");
            string majorInput = Console.ReadLine();
            if (string.IsNullOrEmpty(majorInput))
            {
                Console.WriteLine("Wrong Major. Please try again");
                TypeMajor();
            } else
            {
                Major = majorInput;
            }
        }

        public override string ToString()
        {
            return "Engineer: " + base.ToString() + ", Major:" + Major;
        }
    }
}
