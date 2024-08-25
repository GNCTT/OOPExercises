namespace Exercise3
{
    public class Candidate
    {
        private int _id;
        private string _fullName;
        private string _address;
        private int _priority;
        protected string _group;

        public int ID { get
            {
                return _id;
            }
        }

        private const string ID_INFO = "Registration Number: ";
        private const string MESSAGE_ID_ERROR = "Wrong format number. Please try again!!";

        private const string NAME_INFO = "Full name: ";
        private const string MESSAGE_NAME_ERROR = "Wrong name format. Please try again!!";

        private const string ADRESS_INFO = "Adress: ";
        private const string MESSAGE_ADRESS_ERROR = "Wrong adress format. Please try again!!";

        private const string PRIORITY_INFO = "Priority: ";
        private const string MESSAGE_PRORITY_ERROR = "Wrong format priority. Please try again!!";
        private const int MINPRIORITY = 1;
        private const int MAXPRIORITY = 5;

        protected const string GROUPINFO = "Group: ";

        public Candidate()
        {
        }

        public virtual void GetDataFromInput()
        {
            _id = HandleInput.TypeNumber(ID_INFO, MESSAGE_ID_ERROR, (id) =>
            {
                return id > 0;
            });

            _fullName = HandleInput.TypeString(NAME_INFO, MESSAGE_NAME_ERROR);

            _address = HandleInput.TypeString(ADRESS_INFO, MESSAGE_ADRESS_ERROR);

            _priority = HandleInput.TypeNumber(PRIORITY_INFO, MESSAGE_PRORITY_ERROR, (priority) =>
            {
                if (priority < MINPRIORITY || priority > MAXPRIORITY) return false;
                return true;
            });
            
        }

        public virtual void ShowInfo()
        {
        }

        public override string ToString()
        {
            return ID_INFO + _id + ", " + NAME_INFO + _fullName + ", " + ADRESS_INFO + _address + ", " + PRIORITY_INFO + _priority + ", " + GROUPINFO + _group;
        }
    }
}
