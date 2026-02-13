using System;
using System.Collections.Generic;
using System.Text;

namespace Company_events
{
    class BoardMember : Employee
    {

        public BoardMember() : base() { }
        public void Resign()
        {
            OnEmployeeLayOff(
                new EmployeeLayOffEventArgs
                {
                    Cause = LayOffCause.Ressign
                });
        }
    }
}
