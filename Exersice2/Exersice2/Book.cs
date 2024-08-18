using System;

namespace Exersice2
{
    public class Book : Document
    {
        private string _author;
        private int _pageNumber;

        public Book(int code, string publisher, int releaseNumber, string author, int pageNumber) : base(code, publisher, releaseNumber)
        {
            _author = author;
            _pageNumber = pageNumber;
        }

        public override void ShowInfo()
        {
            Console.WriteLine("This is a book {0}, Author: {1}, PageNumber: {2}", BaseInfo(), _author, _pageNumber);
        }
    }
}
