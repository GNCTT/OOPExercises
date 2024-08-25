using Ex15.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex15
{
    internal class School
    {
        private Dictionary<string, Department> _departments = new Dictionary<string, Department>();

        private const string DEPARTMENT_INFO = "Department: ";
        private const string DEPARTMENT_MESSAGE_ERROR = "Department name is invalid or not exits in school. Try again!!";
        private const string DEPARTMENT_NAME_INFO = "Current departments in school: ";

        public School() { }

        public void AddDepartment()
        {
            Department department = new Department();
            department.GetDataFromInput();
            _departments.Add(department.Name, department);
        }

        public void AddNewStudent()
        {
            Console.WriteLine("Press a to add part time student");
            Console.WriteLine("Press b to add full time student");
            string cmd = Console.ReadLine();
            switch (cmd)
            {
                case "a":
                    {
                        AddPartTimeStudent();
                        break;
                    }
                case "b":
                    {
                        AddFullTimeStudent();
                        break;
                    }
                default:
                    break;
            }
        }

        public void AddPartTimeStudent()
        {
            if (!AddedDepartment()) return;
            var departmentName = TypeDepartmentName();
            var department = _departments[departmentName];
            if (department == null)
            {
                Console.WriteLine("Please check departmentName");
                return;
            }
            Student student = new PartTimeStudent();
            student.GetDataFromInput();
            department.AddStudent(student);
        }

        public void AddFullTimeStudent()
        {
            if (!AddedDepartment()) return;
            var departmentName = TypeDepartmentName();
            var department = _departments[departmentName];
            if (department == null)
            {
                Console.WriteLine("Please check departmentName");
                return;
            }
            Student student = new FulltimeStudent();
            student.GetDataFromInput();
            department.AddStudent(student);
        }

        public void ShowFullTimeStudentById()
        {
            if (!AddedDepartment()) return;
            try
            {
                var id = HandleInput.TypeString("Id student: ", "Invalid id. Try again!!");
                var student = GetStudentById(id);
                if (student != null)
                {
                    student.ShowShortInfo();
                    return;
                }
                Console.WriteLine("Can not find student with id: " + id);
            } catch (InvalidIdException)
            {
                ShowFullTimeStudentById();
            }
        }

        private Student GetStudentById(string id)
        {
            var departments = _departments.Values;
            foreach (var department in departments)
            {
                if (department.GetStudentsById(id) != null)
                {
                    return department.GetStudentsById(id);
                }
            }
            return null;
        }

        public void ShowAveragePointOfStudentByIdAndTerm()
        {
            if (!AddedDepartment()) return;
            try
            {
                var id = HandleInput.TypeString("Id student: ", "Invalid id. Try again!!");
                var student = GetStudentById(id);
                if (student != null) 
                {
                    Console.WriteLine("Type term: ");
                    var year = HandleInput.TypeNumber<int>("Year: ", "Invalid year. Try again!!", (n) =>
                    {
                        if (n < 2000 || n > DateTime.Now.Year) return false;
                        return true;
                    }, int.Parse);

                    int term = HandleInput.TypeNumber("Term: ", "Term must be 1 or 2. Try again!!", (n) =>
                    {
                        if (n < 1 || n > 2) return false;
                        return true;
                    });
                    var score = student.GetScoreByTerm(year, term);
                    if (score < 0)
                    {
                        Console.WriteLine("Do not have data of student result about this term");
                    } else
                    {
                        Console.WriteLine("Student score: " + score);
                    }
                } else
                {
                    Console.WriteLine("Can not find student with id: " + id);
                }
            }
            catch (Exception ex)
            {
                if (ex is InvalidIdException || ex is InvalidNumberException)
                {
                    ShowAveragePointOfStudentByIdAndTerm();
                }
            }
        }

        public bool IsStudentType<T>(Student student) where T : Student
        {
            if (student as T != null) return true;
            return false;
        }

        private bool AddedDepartment()
        {
            if (_departments.Count == 0)
            {
                Console.WriteLine("You must add at lease one department first!!");
                return false;
            }
            return true;
        }

        public void ShowNumberOfFullTimeStudentsInDepartment()
        {
            var departmentName = TypeDepartmentName();
            var department = _departments[departmentName];
            if (department == null)
            {
                Console.WriteLine("Department is not exist. Try again!!");
                ShowNumberOfFullTimeStudentsInDepartment();
            }
            var num = department.GetCountStudentType<FulltimeStudent>();
            Console.WriteLine("Number of fulltime student in {0} department: {1}", departmentName, num);
        }

        public void ShowStudentsWithHighestEnrollScoreInDepartment()
        {
            var departmentName = TypeDepartmentName();
            var department = _departments[departmentName];
            if (department == null)
            {
                Console.WriteLine("Department is not exist. Try again!!");
                ShowStudentsWithHighestEnrollScoreInDepartment();
            }
            var students = department.GetStudentHighestEnrollScore();
            foreach (var student in students)
            {
                student.ShowShortInfo();
            }
        }

        public void ShowPartTimeStudentsInDepartmentByInstuation()
        {
            var departmentName = TypeDepartmentName();
            var department = _departments[departmentName];
            if (department == null)
            {
                Console.WriteLine("Department is not exist. Try again!!");
                ShowPartTimeStudentsInDepartmentByInstuation();
            }
            var instuationName = HandleInput.TypeString("Instuation: ", "Do not leave Instuation blank!!");
            var students = department.GetPartTimeStudentAt(instuationName);
            if (students.Count == 0)
            {
                Console.WriteLine("There are no students in " + instuationName);
            }
            else
            {
                foreach (var student in students)
                {
                    student.ShowShortInfo();
                }
            }
        }

        public void ShowStudentsAbove8PointLatestTermInDepartment()
        {
            var departmentName = TypeDepartmentName();
            var department = _departments[departmentName];
            if (department == null)
            {
                Console.WriteLine("Department is not exist. Try again!!");
                ShowStudentsAbove8PointLatestTermInDepartment();
            }
            var students = department.GetListStudentAboveEightScoreInLastTerm();
            if (students.Count == 0)
            {
                Console.WriteLine("There are no student above 8.0 point in latest term in " + departmentName);
            }
            foreach (var student in students)
            {
                student.ShowShortInfo();
            }
        }

        public void ShowStudentsHightesAverageScoreInDepartment()
        {
            var departmentName = TypeDepartmentName();
            var department = _departments[departmentName];
            if (department == null)
            {
                Console.WriteLine("Department is not exist. Try again!!");
                ShowStudentsHightesAverageScoreInDepartment();
            }
            var students = department.GetStudentsHighestAverageScore();
            foreach (var student in students)
            {
                student.ShowShortInfo();
            }
        }

        public void SortStudentsByDepartment()
        {
            var departmentName = TypeDepartmentName();
            var department = _departments[departmentName];
            if (department == null)
            {
                Console.WriteLine("Department is not exist. Try again!!");
                SortStudentsByDepartment();
            }
            department.Sort();
            Console.WriteLine("Sort student complete");
        }

        public void ShowNumberOfStudentsInDepartmentEnrollInYear()
        {
            var departmentName = TypeDepartmentName();
            var department = _departments[departmentName];
            if (department == null)
            {
                Console.WriteLine("Department is not exist. Try again!!");
                ShowNumberOfStudentsInDepartmentEnrollInYear();
            }
            try
            {
                int year = HandleInput.TypeNumber("Year: ", "Year must be from 2000 - 2024. Try again!!");
                var count = department.GetStudentsByYearEnroll(year);
                Console.WriteLine(year + ": " + count);
            }
            catch (InvalidNumberException)
            {
                Console.WriteLine("We have no data about this year");
            }
        }


        private string TypeDepartmentName()
        {
            try
            {
                var input = HandleInput.TypeString(DEPARTMENT_INFO, DEPARTMENT_MESSAGE_ERROR);
                var names = Department._departmentNames;
                foreach (var name in names)
                {
                    if (name.Equals(input)) return input;
                }
                Console.WriteLine(DEPARTMENT_NAME_INFO + Department.AllDepartmentsName());
                return TypeDepartmentName();
            }
            catch (BlankException)
            {
                Console.WriteLine(DEPARTMENT_NAME_INFO + Department.AllDepartmentsName());
                return TypeDepartmentName();
            }
        }
    }
}
