using System;

namespace Exersice2
{
    public class Document
    {
        private int _code;
        private string _publisher;
        private int _realeseNumber;

        private const string CODE_INFO = "Code: ";
        private const string CODE_MESSAGE_ERROR = "Invalid code. Please try again!!";

        private const string PUBLISHER_INFO = "Publisher: ";
        private const string PUBLISHER_MESSAGE_ERROR = "Do not leave publisher empty. Please try again!!";

        private const string RELEASE_NUMBER_INFO = "Release number: ";
        private const string RELEASE_NUMBER_MESSAGE_ERROR = "Invalid release number. Please try again";

        public int Code {  get { return _code; } }

        public Document()
        {
            
        }

        public Document (int code, string publisher, int releaseNumber)
        {
            _code = code;
            _publisher = publisher;
            _realeseNumber = releaseNumber;
        }

        public virtual void GetDataFromInput()
        {
            _code = HandleInput.TypeNumber(CODE_INFO, CODE_MESSAGE_ERROR, n => n >= 0);
            _publisher = HandleInput.TypeString(PUBLISHER_INFO, PUBLISHER_MESSAGE_ERROR);
            _realeseNumber = HandleInput.TypeNumber(RELEASE_NUMBER_INFO, RELEASE_NUMBER_MESSAGE_ERROR, n => n >= 0);
        }

        public override string ToString()
        {
            return CODE_INFO + _code + ", " + PUBLISHER_INFO + _publisher + ", " + RELEASE_NUMBER_INFO + _realeseNumber;
        }
    }
}
