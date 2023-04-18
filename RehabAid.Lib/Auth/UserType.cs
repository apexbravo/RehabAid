using System;
using System.Collections.Generic;
using System.Text;

namespace RehabAid.Lib
{
    [Flags]
    public enum UserType : int
    {
        User = 1,
        Patient = 2,
        Staff = 3,
        Specialist = 4,
        Guardian = 5,
    }
}
