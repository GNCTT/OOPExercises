using System;
using System.Collections.Generic;

namespace Ex6
{
    public class School
    {
        private readonly List<Student> students;
        public School() { 
            students = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            Console.WriteLine("Add student {0} succesfully!!", student);
            students.Add(student);
        }

        public void ShowInfoStudentAtAge(int age)
        {
            var listStudent = students.FindAll(s => s.Age == age);
            Console.WriteLine("List students {0} years old: ", age);
            foreach (var student in listStudent)
            {
                Console.WriteLine(student);
            }
        }

        public long GetNumberOfStudentWithPredicate(Predicate<Student> condition) 
        {
            return students.FindAll(condition).Count;
        }
    }
}
