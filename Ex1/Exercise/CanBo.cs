namespace Exercise
{
    public class CanBo
    {
        public string HoTen { get; set; }
        public int Age { get; set; }
        public int Sex { get; set; }
        public string Address { get; set; }

        public CanBo(string hoTen)
        {
            HoTen = hoTen;
        }

        public virtual void Introduce()
        {

        }
    }
}
