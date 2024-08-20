using System;
using System.Collections.Generic;

namespace Ex4
{
    public class Town
    {
        private int _familiesNumber;

        private List<Family> families;

        private const string FAMILIES_NUMBER_INFO = "Families number: ";
        private const string FAMILIES_NUMBER_MESSAGE_ERROR = "Not valid families number. Type again!!";
        public Town() {
            families = new List<Family>();
        }

        public void AddFamily(Family family)
        {
            families.Add(family);
        }

        public void GetDataFromInput()
        {
            _familiesNumber = HandleInput.TypeNumber(FAMILIES_NUMBER_INFO, FAMILIES_NUMBER_MESSAGE_ERROR, (n) => n > 0);
            for (int i = 0; i < _familiesNumber; i++)
            {
                Console.WriteLine("Family {0} :", i + 1);
                Family family = new Family();
                family.GetDataFromInput();
                families.Add(family);
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine("Info of town, have {0} families", _familiesNumber + ": ");
            for (int i = 0; i < _familiesNumber; i++)
            {
                Console.WriteLine("Family {0} :", i + 1);
                families[i].ShowInfo();
            }
        }
    }
}
