using System;

namespace Exercise
{
    public class CanBo
    {
        public string HoTen { get; set; }
        public int Age { get; set; }
        public int Sex { get; set; }
        public string Address { get; set; }

        public CanBo()
        {

        }

        public CanBo(string hoTen)
        {
            HoTen = hoTen;
        }

        public virtual void Introduce()
        {

        }

        public virtual void GetDataFromInput()
        {
            TypeName();
            TypeAge();
            TypeSex();
            TypeAddress();
        }

        private void TypeName()
        {
            Console.WriteLine("FullName: ");
            string fullName = Console.ReadLine();
            if (string.IsNullOrEmpty(fullName))
            {
                Console.WriteLine("Invalid name.Do not leave name empty, try again!");
                TypeName();
            } else
            {
                HoTen = fullName;
            }
        }

        private void TypeAge()
        {
            Console.WriteLine("Age: ");
            string ageInput = Console.ReadLine();
            if (ValidateAge(ageInput))
            {
                Age = int.Parse(ageInput);
            } else
            {
                Console.WriteLine("Wrong Age format, age from 0 - 200. Please try again");
                TypeAge();
            }
        }

        private void TypeSex()
        {
            Console.WriteLine("Sex(1: Male, 2: FeMale, 3: Other): ");
            string sexInput = Console.ReadLine();
            if (ValidDateSex(sexInput))
            {
                Sex = int.Parse(sexInput);
            } else
            {
                Console.WriteLine("Wrong Sex format. Please type (1, 2 or 3).");
                TypeSex();
            }
        }

        private void TypeAddress()
        {
            Console.WriteLine("Address: ");
            string addressInput = Console.ReadLine();
            if (string.IsNullOrEmpty (addressInput))
            {
                Console.WriteLine("Wrong adress format.Please not leave address empty");
                TypeAddress();
            } else
            {
                Address = addressInput;
            }
        }

        private bool ValidateAge(string ageInput)
        {
            if (string.IsNullOrEmpty (ageInput))
            {
                return false;
            }
            int age = 0;
            if (!int.TryParse(ageInput, out age))
            {
                return false;
            }
            if (age <= 0 || age >= 200)
            {
                return false;
            }
            return true;
        }

        private bool ValidDateSex(string sexInput)
        {
            if (string.IsNullOrEmpty(sexInput)) { return false; }
            int sex = 0;
            if (!int.TryParse(sexInput, out sex))
            {
                return false;
            }
            if (sex < 1 || sex > 3)
            {
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            if (Sex == 1) return "FullName: " + HoTen + ", Sex: Male" + ", Age:" + Age + ", Address:" + Address;
            if (Sex == 2) return "FullName: " + HoTen + ", Sex: FeMale" + ", Age:" + Age + ", Address:" + Address;
            return "FullName: " + HoTen + ", Sex: Other" + ", Age:" + Age + ", Address:" + Address;
        }
    }
}
