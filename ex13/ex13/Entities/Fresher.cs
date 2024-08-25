using System;

namespace ex13
{
    public enum GraduationRank
    {
        Below_Average,
        Average,
        Good,
        Excellent
    }
    public class Fresher : Employee
    {
        private DateTime _graduation_date;
        private GraduationRank _graduation_rank;
        private string _education;

        private const string GRADUATION_DATE_INFO = "Graduation Date(dd/mm/yyyy): ";
        private const string GRADUATION_MESSAGE_ERROR = "Graduation Date must be format dd/mm/yyyy";

        private const string GRADUATION_RANK_INFO = "Graduation rank: ";
        private const string GRADUATION_RANK_MESSAGE_ERROR = "Graduation rank must be from 0 to 3. Try again!!";

        private const string EDUCATION_INFO = "Education: ";
        private const string EDUCATION_MESSAGE_ERROR = "Do not leave education blank. Try again!!";

        public Fresher()
        {
            _employeeType = EmployeeType.Fresher;
        }

        public override void GetDataFromInput()
        {
            base.GetDataFromInput();
            TypeGraduationDate();
            _graduation_rank = (GraduationRank)HandleInput.TypeNumber(GRADUATION_RANK_INFO, GRADUATION_RANK_MESSAGE_ERROR, (n) =>
            {
                if (n < 0 || n > 3) return false;
                return true;
            });
            _education = HandleInput.TypeString(EDUCATION_INFO, EDUCATION_MESSAGE_ERROR);
        }

        private void TypeGraduationDate()
        {
            var input = HandleInput.TypeString(GRADUATION_DATE_INFO, GRADUATION_MESSAGE_ERROR);
            var birthDay = DateTime.Now;
            if (!DateTime.TryParseExact(input, "dd/mm/yyyy", null, System.Globalization.DateTimeStyles.None, out var birthday))
            {
                TypeGraduationDate();
            }
            _graduation_date = birthday;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine(GRADUATION_DATE_INFO + _graduation_date.ToString("dd/mm/yyyy"));
            Console.WriteLine(GRADUATION_RANK_INFO + _graduation_rank.ToString());
            Console.WriteLine(EDUCATION_INFO + _education);
        }

        public override void EditData()
        {
            base.EditData();
            TypeGraduationDate();
            _graduation_rank = (GraduationRank)HandleInput.TypeNumber(GRADUATION_RANK_INFO, GRADUATION_RANK_MESSAGE_ERROR, (n) =>
            {
                if (n < 0 || n > 3) return false;
                return true;
            });
            _education = HandleInput.TypeString(EDUCATION_INFO, EDUCATION_MESSAGE_ERROR);
        }
    }
}
