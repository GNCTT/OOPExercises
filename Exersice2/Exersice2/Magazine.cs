using System;

namespace Exersice2
{
    public class Magazine : Document
    {
        private int _publicDay;

        private const string PUBLIC_DAY_INFO = "Public day: ";
        private const string PUBLIC_DAY_MESSAGE_ERROR = "Invalid day. Please try again";

        public Magazine()
        {
        }

        public Magazine(int code, string publisher, int releaseNumber, int publicDay) : base(code, publisher, releaseNumber)
        {
            _publicDay = publicDay;
        }

        public override void GetDataFromInput()
        {
            base.GetDataFromInput();
            _publicDay = HandleInput.TypeNumber(PUBLIC_DAY_INFO, PUBLIC_DAY_MESSAGE_ERROR, (n) =>
            {
                if (n < 1 || n > 31)
                {
                    return false;
                }
                return true;
            });
        }

        public override string ToString()
        {
            return base.ToString() + ", " + PUBLIC_DAY_INFO + _publicDay;
        }

    }
}
