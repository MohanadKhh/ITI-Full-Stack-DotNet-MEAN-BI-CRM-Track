using System;
using System.Collections.Generic;
using System.Text;

namespace Company_events
{
    public class EmployeeLayOffEventArgs : EventArgs
    {
        public LayOffCause Cause { get; set; }
    }
}
