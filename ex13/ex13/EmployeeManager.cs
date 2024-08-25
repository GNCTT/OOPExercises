using System;
using System.Collections.Generic;
using System.Linq;

namespace ex13
{
    internal class EmployeeManager
    {
        private Dictionary<int, Employee> employees;

        public EmployeeManager()
        {
            employees = new Dictionary<int, Employee>();
        }

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee.Id, employee);
            Console.WriteLine("Add {0} employee sucessfully!!", employee.EmployeeType);
            Employee.AddEmployeeSuccessfull(employee.Id);
        }

        public Employee GetEmployeeById(int id)
        {
            return employees[id];
        }

        public void RemoveEmployeeById(int Id)
        {
            var employee = employees[Id];
            if (employee != null)
            {
                Console.WriteLine("Remove {0} employee with Id {1} sucessfully!!", employee.EmployeeType, Id);
                employees.Remove(Id);
            }
            else
            {
                Console.WriteLine("Can not find Employee with Id {0}", Id);
            }
        }

        public void EditEmployeesInfomationById(int Id)
        {
            var employee = employees[Id];
            if (employee != null)
            {
                employee.EditData();
            }
            else
            {
                Console.WriteLine("Can not find Employee with Id {0}", Id);
            }
        }

        public void EditEmployeesType(Employee employee)
        {
            var currentType = employee.EmployeeType;
            Console.WriteLine("Type employee type current type " + currentType.ToString() + " :");
            employee.TypeEmployeeType("(" + currentType.ToString() + ")", editMode: true);
            if (currentType != employee.EmployeeType)
            {
                Employee newEmployee = null;
                switch (employee.EmployeeType)
                {
                    case EmployeeType.Experience:
                        newEmployee = new Experience();
                        break;
                    case EmployeeType.Fresher:
                        newEmployee = new Fresher();
                        break;
                    case EmployeeType.Intern:
                        newEmployee = new Intern();
                        break;
                }
                newEmployee.CopyInfo(employee);
                newEmployee.EditData();
                RemoveEmployeeById(employee.Id);
                AddEmployee(newEmployee);
            }
            else
            {
                employee.EditData();
            }
        }

        public void ShowInfoAllEmployees()
        {
            Console.WriteLine("There are {0} employees", employees.Count);
            var listEmployee = employees.Values;
            int index = 1;
            foreach(var employee in listEmployee)
            {
                Console.WriteLine("Employee {0}", ++index);
                employee.ShowInfo();
                Console.WriteLine();
            }
        }

        public void ShowInfoAllEmployeesByType<T>(EmployeeType type) where T : Employee
        {
            Console.WriteLine("All {0} employees:", type.ToString());
            var listEmployee = employees.Values.Where(e => e as T != null);
            int index = 0;
            foreach (var employee in listEmployee)
            {
                Console.WriteLine("Employee {0}", ++index);
                employee.ShowInfo();
                Console.WriteLine();
            }
        }

        public void TransformInfoEmployee<T>(Employee baseObject, T newObject) where T : Employee
        {
        }

    }
}
