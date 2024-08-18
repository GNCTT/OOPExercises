namespace Exercise
{
    public class KySu : CanBo
    {
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
    }
}
