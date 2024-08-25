using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeManager employeeManager = new EmployeeManager();
            while (true) {
                ShowFeature();

                string cmd = Console.ReadLine();
                switch (cmd)
                {
                    case "1":
                        {
                            Console.WriteLine("Add new Experience employee");
                            Employee employee = new Experience();
                            employee.GetDataFromInput();
                            employeeManager.AddEmployee(employee);
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Add new Fresher employee");
                            Employee employee = new Fresher();
                            employee.GetDataFromInput();
                            employeeManager.AddEmployee(employee);
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Add new Intern employee");
                            Employee employee = new Intern();
                            employee.GetDataFromInput();
                            employeeManager.AddEmployee(employee);
                            break;
                        }
                    case "4":
                        {
                            Employee employee = null;
                            Console.WriteLine("Type employee Id:");
                            int id = HandleInput.TypeNumber("", "Can not find Employee!!", (n) =>
                            {
                                if (n < 0) return false;
                                employee = employeeManager.GetEmployeeById(n);
                                if (employee == null) return false;
                                return true;
                            });
                            Console.WriteLine("Type e to edit employee infomation!!");
                            Console.WriteLine("Type r to remove employee");

                            var iCmd = Console.ReadLine();
                            switch (iCmd)
                            {
                                case "e":
                                    {
                                        employeeManager.EditEmployeesType(employee);
                                        break;
                                    }
                                case "r":
                                    {
                                        employeeManager.RemoveEmployeeById(id);
                                        break;
                                    }
                                default:
                                    break;
                            }
                            break;
                        }
                    case "5":
                        {
                            employeeManager.ShowInfoAllEmployeesByType<Experience>(EmployeeType.Experience);
                            break;
                        }
                    case "6":
                        {
                            employeeManager.ShowInfoAllEmployeesByType<Fresher>(EmployeeType.Fresher);
                            break;
                        }
                    case "7":
                        {
                            employeeManager.ShowInfoAllEmployeesByType<Intern>(EmployeeType.Intern);
                            break;
                        }
                    case "8":
                        {
                            Console.Clear();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                if (cmd == "9") break;
            }
            
        }

        private static void ShowFeature()
        {
            Console.WriteLine("App manage employees");
            Console.WriteLine("Type 1 to add Experience employees");
            Console.WriteLine("Type 2 to add Fresher employees");
            Console.WriteLine("Type 3 to add Intern employees");
            Console.WriteLine("Type 4 to interact employees infomation by ID");
            Console.WriteLine("Type 5 to show infomation of all Experience employees");
            Console.WriteLine("Type 6 to show infomation of all Fresher employees");
            Console.WriteLine("Type 7 to show infomation of all Intern employees");
            Console.WriteLine("Type 8 to clear Console");
            Console.WriteLine("Type 9 to exit App");
        }
    }
}
