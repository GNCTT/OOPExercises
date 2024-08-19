using System;

namespace Exercise
{
    public class NhanVien : CanBo
    {
        public NhanVien() { }
        public NhanVien(string name, string job) : base(name)
        {
            Job = job;
        }
        public string Job { get; set; }

        public override void Introduce()
        {
            System.Console.WriteLine("I'm a stuff with job: " + Job);
        }

        public override void GetDataFromInput()
        {
            base.GetDataFromInput();
            TypeJob();
        }

        private void TypeJob()
        {
            Console.WriteLine("Job: ");
            string jobInput = Console.ReadLine();
            if (string.IsNullOrEmpty(jobInput))
            {
                Console.WriteLine("Wrong jobInput. Please try again");
            } else
            {
                Job = jobInput;
            }
        }

        public override string ToString()
        {
            return "Stuff: " + base.ToString() + ", Job: " + Job;
        }
    }
}
