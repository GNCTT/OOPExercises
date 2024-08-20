using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            School school = new School();
            while (true)
            {
                Console.WriteLine("App manage students");
                Console.WriteLine("Type 1 to add new student");
                Console.WriteLine("Type 2 to show student that are 20 yeas old");
                Console.WriteLine("Type 3 to show number of students who are 23 yease old and live in DN");
                Console.WriteLine("Type 4 to close app");

                string cmd = Console.ReadLine();
                switch (cmd)
                {
                    case "1":
                        {
                            Student student = new Student();
                            student.GetDataFromInput();
                            school.AddStudent(student);
                            break;
                        }
                    case "2":
                        {
                            school.ShowInfoStudentAtAge(20);
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Number of studentd 23 years old and live in DN: " +
                                school.GetNumberOfStudentWithPredicate((s) =>
                                {
                                    if (s.Age == 23 && s.HomeTown.Equals("DN")) return true;
                                    return false;
                                }));
                            break;
                        }
                    default:
                        break;
                }
                if (cmd == "4") break;
                Console.WriteLine("--------------------------------");
            }
        }
    }
}
