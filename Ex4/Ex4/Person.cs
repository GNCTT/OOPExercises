using System.Collections.Generic;

namespace Ex4
{
    public class Person
    {
        private string _fullName;
        private int _age;
        private string _job;
        private string _id;

        private const string FULL_NAME_INFO = "Full name: ";
        private const string FULL_NAME_MESSAGE_ERROR = "Do not leave full name blank. Type again!!";

        private const string AGE_INFO = "Age: ";
        private const string AGE_MESSAGE_ERROR = "Invalid Age. Type again!!";

        private const string JOB_INFO = "Job: ";
        private const string JOB_MESSAGE_ERROR = "Do not leave job blank. Type again!!";

        private const string ID_INFO = "Id: ";
        private const string ID_MESSAGE_ERROR = "Invalid Id. Type again!!";

        public static List<string> IdCreateds = new List<string>();

        public Person()
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
            _job = HandleInput.TypeString(JOB_INFO, JOB_MESSAGE_ERROR);
            _id = HandleInput.TypeString(ID_INFO, ID_MESSAGE_ERROR, (id) =>
            {
                return !IdCreateds.Contains(id);
            });
            IdCreateds.Add(_id);
        }

        public override string ToString()
        {
            return FULL_NAME_INFO + _fullName + ", " + AGE_INFO + _age + ", " 
                + JOB_INFO + _job + ", " + ID_INFO + _id;
        }
    }
}
