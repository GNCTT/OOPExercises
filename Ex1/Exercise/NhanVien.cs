namespace Exercise
{
    public class NhanVien : CanBo
    {
        public NhanVien(string name) : base(name)
        {

        }

        public NhanVien(string name, string job) : base(name)
        {
            Job = job;
        }
        public string Job { get; set; }

        public override void Introduce()
        {
            System.Console.WriteLine("I'm a stuff with job: " + Job);
        }
    }
}
