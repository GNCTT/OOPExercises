using Ex13.Exceptions;
using System.Collections.Generic;

namespace Ex15
{
    public class Department
    {
        private string _name;
        private List<Student> _students;

        public string Name
        {
             get { return _name; } 
        }

        private const string NAME_INFO = "Department name: ";
        private const string NAME_MESSAGE_ERROR = "Do not leave name blank. Type again!!";

        public static readonly List<string> _departmentNames = new List<string>();

        public Department()
        {

        }

        public void GetDataFromInput()
        {
            TypeName();
            _departmentNames.Add(_name);
        }

        private void TypeName()
        {
            try
            {
                _name = HandleInput.TypeString(NAME_INFO, NAME_MESSAGE_ERROR);
            } catch (BlankException)
            {
                TypeName();
            }
        }

        public static string AllDepartmentsName()
        {
            string output = "";
            foreach (var name in _departmentNames)
            {
                output += name;
            }
            return output;
        }
    }
}
