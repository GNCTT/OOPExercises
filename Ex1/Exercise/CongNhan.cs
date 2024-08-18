namespace Exercise
{
    public class CongNhan : CanBo
    {

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
    }
}
