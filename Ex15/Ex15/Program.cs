using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var school = new School();
            while (true)
            {
                ShowFeature();
                var cmd = Console.ReadLine();
                switch (cmd)
                {
                    case "1":
                        {
                            school.AddDepartment();
                            Console.WriteLine("Add department complete");
                            break;
                        }
                    case "2":
                        {
                            school.AddNewStudent();
                            Console.WriteLine("Add new student complete!!");
                            Console.WriteLine();
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("List full time student: ");
                            school.ShowFullTimeStudentById();
                            Console.WriteLine();
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("Average point: ");
                            school.ShowAveragePointOfStudentByIdAndTerm();
                            Console.WriteLine();
                            break;
                        }
                    case "5":
                        {
                            school.ShowNumberOfFullTimeStudentsInDepartment();
                            Console.WriteLine();
                            break;
                        }
                    case "6":
                        {
                            Console.WriteLine("List highes enroll score student");
                            school.ShowStudentsWithHighestEnrollScoreInDepartment();
                            break;
                        }
                    case "7":
                        {
                            school.ShowPartTimeStudentsInDepartmentByInstuation();
                            break;
                        }
                    case "8":
                        {
                            school.ShowStudentsAbove8PointLatestTermInDepartment();
                            break;
                        }
                    case "9":
                        {
                            school.ShowStudentsHightesAverageScoreInDepartment();
                            break;
                        }
                    case "10":
                        {
                            school.SortStudentsByDepartment();
                            break;
                        }
                    case "11":
                        {
                            school.ShowNumberOfStudentsInDepartmentEnrollInYear();
                            break;
                        }
                    case "12":
                        {
                            Console.Clear();
                            break;
                        }
                    default:
                        break;
                }
                if (cmd == "13") break;
            }
        }

        private static void ShowFeature()
        {
            Console.WriteLine("App manage student result.");
            Console.WriteLine("Press 1 to add new Department!");
            Console.WriteLine("Press 2 to add new Student!");
            Console.WriteLine("Press 3 to define fullTime student by Id!");
            Console.WriteLine("Press 4 to define get student score by Id and term!");
            Console.WriteLine("Press 5 to get sum of fullTime student by Department");
            Console.WriteLine("Press 6 to get highest score enroll student in all Department");
            Console.WriteLine("Press 7 to get list part time students in Department by instuation name");
            Console.WriteLine("Press 8 to get list students have above 8.0 average score in latest term in each departments");
            Console.WriteLine("Press 9 to get list highest average score students in department by term");
            Console.WriteLine("Press 10 to sort student by department");
            Console.WriteLine("Press 11 to show number of students each year enroll by department");
            Console.WriteLine("Press 12 to clear console");
            Console.WriteLine("Press 13 to close app");
        }
    }
}
