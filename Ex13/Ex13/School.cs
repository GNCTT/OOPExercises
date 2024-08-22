using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex15
{
    internal class School
    {
        private Dictionary<string, Department> _departments = new Dictionary<string, Department> ();

        private const string DEPARTMENT_INFO = "Department: ";
        private const string DEPARTMENT_MESSAGE_ERROR = "Department name is invalid or not exits in school. Try again!!";
        private const string DEPARTMENT_NAME_INFO = "Current departments in school: ";

        public School() { }

        public void AddDepartment(Department department)
        {
            _departments.Add(department);
        }

        public void AddPartTimeStudent()
        {
            if (!AddedDepartment()) return; 
            TypeDepartmentName();
            Student student = new ParttimeStudent();
            
        }

        public void AddFullTimeStudent()
        {
            if(!AddedDepartment()) return;
            TypeDepartmentName();
            Student student = new FulltimeStudent();
        }

        private bool AddedDepartment()
        {
            if (_departments.Count == 0)
            {
                Console.WriteLine("You must add at lease one department first!!");
                return true;
            }
            return false;
        }

        private string TypeDepartmentName()
        {
            try
            {
                return HandleInput.TypeString(DEPARTMENT_INFO, DEPARTMENT_MESSAGE_ERROR);
            }
            catch
            {
                Console.WriteLine(DEPARTMENT_NAME_INFO + Department.AllDepartmentsName());
                return TypeDepartmentName();
            }

        }
    }
}
