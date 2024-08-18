using System;

namespace Exersice2
{
    public class Paper : Document
    {
        private int _issueNumber;
        private int _publicMonth;

        public Paper(int code, string publisher, int releaseNumber, int issueNumber, int publicMonth) : base(code, publisher, releaseNumber)
        {
            _issueNumber = issueNumber;
            _publicMonth = publicMonth;
        }

        public override void ShowInfo()
        {
            Console.WriteLine("This is a Paper: {0}, IssueNumber: {1}, PublicMonth: {2}", BaseInfo(), _issueNumber, _publicMonth);
        }
    }
}
