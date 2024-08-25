using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex15
{
    public class PartTimeStudent : Student
    {
        private string _instuation;

        public string Instuations { get
            {
                return _instuation;
            } 
        }

        private const string INSTUATION_INFO = "Instuation: ";
        private const string INSTUATION_MESSAGE_ERROR = "Do not leave instuation blank. Try again!!";
        public PartTimeStudent()
        {
            _type = StudentType.PartTime;
        }

        public override void GetDataFromInput()
        {
            base.GetDataFromInput();
            TypeInstuation();
        }

        private void TypeInstuation()
        {
            _instuation = HandleInput.TypeString(INSTUATION_INFO, INSTUATION_MESSAGE_ERROR);
        }
    }
}
