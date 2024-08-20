using System;

namespace Exersice2
{
    public class Paper : Document
    {
        private int _issueNumber;
        private int _publicMonth;

        private const string ISSUE_NUMBER_INFO = "Issue Number: ";
        private const string ISSUE_NUMBER_MESSAGE_ERROR = "Invalid issue number. Please type again!!";

        private const string PUBLIC_MONTH_INFO = "Public month: ";
        private const string PUBLIC_MONTH_MESSAGE_ERROR = "Invalid public month. Please type again!!";

        public Paper()
        {
        }

        public Paper(int code, string publisher, int releaseNumber, int issueNumber, int publicMonth) : base(code, publisher, releaseNumber)
        {
            _issueNumber = issueNumber;
            _publicMonth = publicMonth;
        }

        public override void GetDataFromInput()
        {
            base.GetDataFromInput();
            _issueNumber = HandleInput.TypeNumber(ISSUE_NUMBER_INFO, ISSUE_NUMBER_MESSAGE_ERROR, n => n >= 0);
            _publicMonth = HandleInput.TypeNumber(PUBLIC_MONTH_INFO, PUBLIC_MONTH_MESSAGE_ERROR, (n) =>
            {
                if (n < 1 || n > 12) return false;
                return true;
            });
        }

        public override string ToString()
        {
            return base.ToString() + ", " + ISSUE_NUMBER_INFO + _issueNumber + ", " + PUBLIC_MONTH_INFO + _publicMonth;
        }
    }
}
