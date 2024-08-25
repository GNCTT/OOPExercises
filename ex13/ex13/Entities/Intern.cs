using System;

namespace ex13
{
    public class Intern : Employee
    {
        private string _major;
        private int _semester;
        private string _university;

        private const string MAJOR_INFO = "Major: ";
        private const string MAJOR_MESSAGE_ERROR = "Do not leave major blank. Try again!!";

        private const string SEMESTER_INFO = "Semester: ";
        private const string SEMESTER_MESSAGE_INFO = "Semester is number from 1 to 14. Try again!!";

        private const string UNIVERSITY_INFO = "University: ";
        private const string UNIVERSITY_MESSAGE_ERROR = "Do not leave university blank. Try again!!";

        public Intern()
        {
            _employeeType = EmployeeType.Intern;
        }

        public override void GetDataFromInput()
        {
            base.GetDataFromInput();
            _major = HandleInput.TypeString(MAJOR_INFO, MAJOR_MESSAGE_ERROR);
            _semester = HandleInput.TypeNumber(SEMESTER_INFO, SEMESTER_MESSAGE_INFO, (n) =>
            {
                if (n < 1 || n > 14) return false;
                return true;
            });
            _university = HandleInput.TypeString(UNIVERSITY_INFO, UNIVERSITY_MESSAGE_ERROR);
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine(MAJOR_INFO + _major);
            Console.WriteLine(SEMESTER_INFO + _semester);
            Console.WriteLine(UNIVERSITY_INFO + _university);
        }

        public override void EditData()
        {
            base.EditData();
            _major = HandleInput.TypeString(MAJOR_INFO, MAJOR_MESSAGE_ERROR);
            _semester = HandleInput.TypeNumber(SEMESTER_INFO, SEMESTER_MESSAGE_INFO, (n) =>
            {
                if (n < 1 || n > 14) return false;
                return true;
            });
            _university = HandleInput.TypeString(UNIVERSITY_INFO, UNIVERSITY_MESSAGE_ERROR);
        }
    }
}
