using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex15
{
    public class FulltimeStudent : Student
    {
        public FulltimeStudent()
        {
            _type = StudentType.FullTime;
        }
    }
}
