using System;

namespace Exersice2
{
    public class Book : Document
    {
        private string _author;
        private int _pageNumber;

        private const string AUTHOR_INFO = "Author: ";
        private const string AUTHOR_MESSAGE_ERROR = "Do not leave author empty. Please try again!!";

        private const string PAGENUMBER_INFO = "Page number: ";
        private const string PAGENUMBER_MESSAGE_ERROR = "Invalid Page number. Please try again!!";

        public Book()
        {

        }

        public Book(int code, string publisher, int releaseNumber, string author, int pageNumber) : base(code, publisher, releaseNumber)
        {
            _author = author;
            _pageNumber = pageNumber;
        }

        public override void GetDataFromInput()
        {
            base.GetDataFromInput();
            _author = HandleInput.TypeString(AUTHOR_INFO, AUTHOR_MESSAGE_ERROR);
            _pageNumber = HandleInput.TypeNumber(PAGENUMBER_INFO, PAGENUMBER_MESSAGE_ERROR, n => n >= 0);
        }

        public override string ToString()
        {
            return base.ToString() + ", " + AUTHOR_INFO + _author + ", " + PAGENUMBER_INFO + _pageNumber;
        }
    }
}
