using Ex15.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Ex15
{
    public class Department
    {
        private string _name;
        private List<Student> _students = new List<Student>();

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

        public Department(string name)
        {
            _name = name;
        }

        public void GetDataFromInput()
        {
            TypeName();
            _departmentNames.Add(_name);
        }

        public void AddStudent(Student student)
        {
            _students.Add(student);
        }

        public Student GetStudentsById(string Id)
        {
            return _students.Find(s => s.Id == Id);
        }

        public int GetCountStudentType<T>() where T : Student
        {
            return _students.Count((s) =>
            {
                if (s as T != null) return true;
                return false;
            });
        }

        public List<Student> GetStudentHighestEnrollScore()
        {
            float highScore = _students.Max(s => s.EnrollScore);
            var students = _students.Where(s => s.EnrollScore == highScore).ToList();
            return students;
        }

        public List<PartTimeStudent> GetPartTimeStudentAt(string instuation)
        {
            List<PartTimeStudent> partTimeStudents = new List<PartTimeStudent>();
            foreach (var student in _students) {
                if (student as PartTimeStudent != null)
                {
                    partTimeStudents.Add(student as PartTimeStudent);
                }
            }
            var outs = partTimeStudents.Where(s => s.Instuations.Equals(instuation));
            return outs.ToList();
        }

        public List<Student> GetListStudentAboveEightScoreInLastTerm()
        {
            List<Student> students = new List<Student>();
            foreach (var student in _students)
            {
                if (student.GetLatestResult() != null)
                {
                    if (student.GetLatestResult().Score > 8.0f)
                    {
                        students.Add(student);
                    }
                }
            }
            return students;
        }

        public List<Student> GetStudentsHighestAverageScore()
        {
            float highScore = _students.Max(s => s.GetAverageScore());
            var students = _students.Where(s => s.GetAverageScore() == highScore).ToList();
            return students;
        }

        public void Sort()
        {
            _students.Sort();
        }

        public int GetStudentsByYearEnroll(int year)
        {
            return _students.Count(s => s.YearEnroll == year);
        }

        public void ShowListStudentInfo()
        {
            foreach (var student in _students)
            {
                student.ShowShortInfo();
            }
        }
             
        private void TypeName()
        {
            try
            {
                _name = HandleInput.TypeString(NAME_INFO, NAME_MESSAGE_ERROR);
                foreach (var name in _departmentNames)
                {
                    if (_name.Equals(name)) {
                        Console.WriteLine("Name is already taken. Try again");
                        TypeName();
                    }
                }
            }
            catch (BlankException)
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
