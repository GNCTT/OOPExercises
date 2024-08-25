using System;

namespace ex13
{
    public enum RankCertificate
    {
        None = 0,
        Below_Average,
        Average,
        Good,
        Excellent
    }
    public class Certificate
    {
        private int _id;
        private string _name;
        private RankCertificate _rank;
        private DateTime _date;

        private const string ID_INFO = "Id: ";
        private const string ID_MESSAGE_ERROR = "Invalid ID format. Type again!!";

        private const string NAME_INFO = "Name: ";
        private const string NAME_MESSAGE_ERROR = "Do not leave name blank. Type again!!";

        private const string RANK_INFO = "Rank: ";
        private const string RANK_MESSAGE_ERROR = "Rank must be a number from 1 - 4 (1: Below Average, 2: Average, 3: Good, 4: Excellent). Type again!!";

        private const string DATE_INFO = "Certificate date(dd/mm/yyyy): ";
        private const string DATE_MESSAGE_ERROR = "Wrong format date. Type again!!";

        public Certificate()
        {
        }

        public void GetDataFromInput()
        {
            Console.WriteLine("Certificate: ");
            _id = HandleInput.TypeNumber(ID_INFO, ID_MESSAGE_ERROR, id => id >= 0);
            _name = HandleInput.TypeString(NAME_INFO, NAME_MESSAGE_ERROR);
            _rank = (RankCertificate)HandleInput.TypeNumber(RANK_INFO, RANK_MESSAGE_ERROR, rank =>
            {
                if (rank < 1 || rank > 4) return false;
                return true;
            });
            TypeDateCertificate();
        }

        public override string ToString()
        {
            return ID_INFO + _id + ", " + NAME_INFO + _name + ", " + RANK_INFO + _rank.ToString() + ", " + "Certificate date: " + _date.ToString("dd/mm/yyyy");
        }

        private void TypeDateCertificate()
        {
            var input = HandleInput.TypeString(DATE_INFO, DATE_MESSAGE_ERROR);
            var birthDay = DateTime.Now;
            if (!DateTime.TryParseExact(input, "dd/mm/yyyy", null, System.Globalization.DateTimeStyles.None, out var birthday))
            {
                TypeDateCertificate();
            }
            _date = birthday;
        }
    }
}
