using System;
using System.Collections.Generic;

namespace Ex4
{
    public class Family
    {
        private int _memberNumber;
        private string _address;

        private const string MEMBER_NUMBER_INFO = "Member number: ";
        private const string MEMBER_NUMER_MESSAGE_ERROR = "Invalid member number. Type again!!";

        private const string ADRESS_INFO = "Adress";
        private const string ADRESS_MESSAGE_ERROR = "Do not leave adress blank";

        private List<Person> _members;

        public Family()
        {
            _members = new List<Person>();
        }

        public void GetDataFromInput()
        {
            _memberNumber = HandleInput.TypeNumber(MEMBER_NUMBER_INFO, MEMBER_NUMER_MESSAGE_ERROR, n => n > 0);
            for (int i = 0; i < _memberNumber; i++)
            {
                Console.WriteLine("Type person {0} info:", i + 1);
                Person person = new Person();
                person.GetDataFromInput();
                _members.Add(person);
            }
            _address = HandleInput.TypeString(ADRESS_INFO, ADRESS_MESSAGE_ERROR);
        }

        public void ShowInfo()
        {
            Console.WriteLine("Family at " + _address + ", " + MEMBER_NUMBER_INFO + _memberNumber + ": ");
            foreach (var person in _members)
            {
                Console.WriteLine(person);
            }
        }
    }
}
