namespace Ex15
{
    public class ParttimeStudent : Student
    {
        private string _institution;
        public ParttimeStudent() {
            _type = StudentType.PartTime;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj); 
        }
    }
}
