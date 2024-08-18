using System;

namespace Exersice2
{
    public class Magazine : Document
    {
        private int _publicDay;

        public Magazine(int code, string publisher, int releaseNumber, int publicDay) : base(code, publisher, releaseNumber)
        {
            _publicDay = publicDay;
        }

        public override void ShowInfo()
        {
            Console.WriteLine("This is a Magazine: {0}, PublicDay: {1}", BaseInfo(), _publicDay);
        }

    }
}
