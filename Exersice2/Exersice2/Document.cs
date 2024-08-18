using System;

namespace Exersice2
{
    public class Document
    {
        private int _code;
        private string _publisher;
        private int _realeseNumber;

        public int Code {  get { return _code; } }

        public Document (int code, string publisher, int releaseNumber)
        {
            _code = code;
            _publisher = publisher;
            _realeseNumber = releaseNumber;
        }

        public virtual void ShowInfo()
        {
            
        }

        public string BaseInfo()
        {
            return "Code: " + _code + ", Publisher: " + _publisher + ", ReleaseNumber: " + _publisher + ", ReleaseNumber: " + _realeseNumber;
        }
    }
}
