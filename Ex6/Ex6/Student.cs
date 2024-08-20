namespace Ex6
{
    public class Student
    {
        private string _fullName;
        private int _age;
        private string _homeTown;

        public int Age { get
            {
                return _age;
            } }

        public string HomeTown
        {
            get
            {
                return _homeTown;
            }
        }

        private const string FULL_NAME_INFO = "Full name: ";
        private const string FULL_NAME_MESSAGE_ERROR = "Do not leave full name blank. Try again!!";

        private const string AGE_INFO = "Age: ";
        private const string AGE_MESSAGE_ERROR = "Invalid age. Try again!!";

        private const string HOMETOWN_INFO = "Hometown: ";
        private const string HOMETOWN_MESSAGE_ERROR = "Do not leave home town blank. Try again!!";

        public Student()
        {
        }

        public void GetDataFromInput()
        {
            _fullName = HandleInput.TypeString(FULL_NAME_INFO, FULL_NAME_MESSAGE_ERROR);
            _age = HandleInput.TypeNumber(AGE_INFO, AGE_MESSAGE_ERROR, (n) =>
            {
                if (n < 1 || n > 200) return false;
                return true;
            });
            _homeTown = HandleInput.TypeString(HOMETOWN_INFO, HOMETOWN_MESSAGE_ERROR);
        }

        public override string ToString()
        {
            return FULL_NAME_INFO + _fullName + ", " + AGE_INFO + _age + ", " + HOMETOWN_INFO + _homeTown;
        }
    }
}
