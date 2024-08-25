using System;

namespace ex13
{
    public class Experience : Employee
    {
        private int _expInYear;
        private string _proSkill;

        private const string EXPINYEAR_INFO = "Exp InYear: ";
        private const string EXPINYEAR_MESSAGE_ERROR = "Exp in year muse be from 1 - n. Type again!!";

        private const string PROSKILL_INFO = "ProSkill: ";
        private const string PROSKILL_MESSAGE_ERROR = "Do not leave ProSkill blank. Try again!!";

        public Experience()
        {
            _employeeType = EmployeeType.Experience;
        }

        public override void GetDataFromInput()
        {
            base.GetDataFromInput();
            _expInYear = HandleInput.TypeNumber(EXPINYEAR_INFO, EXPINYEAR_MESSAGE_ERROR, n => n > 0);
            _proSkill = HandleInput.TypeString(PROSKILL_INFO, PROSKILL_MESSAGE_ERROR);
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine(EXPINYEAR_INFO + _expInYear);
            Console.WriteLine(PROSKILL_INFO + _proSkill);
        }

        public override void EditData()
        {
            base.EditData();
            _expInYear = HandleInput.TypeNumber(EXPINYEAR_INFO, EXPINYEAR_MESSAGE_ERROR, n => n > 0);
            _proSkill = HandleInput.TypeString(PROSKILL_INFO, PROSKILL_MESSAGE_ERROR);
        }
    }
}
