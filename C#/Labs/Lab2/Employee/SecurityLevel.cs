using System;
using System.Collections.Generic;
using System.Text;

namespace Employee
{
    [Flags]
    public enum SecurityLevel
    {
        guest = 1, Developer = 2, secretary = 4, DBA = 8, securityOfficer = 15
    }
}
