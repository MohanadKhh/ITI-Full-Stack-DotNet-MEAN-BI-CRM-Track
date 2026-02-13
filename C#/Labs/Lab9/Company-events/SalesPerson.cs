using System;
using System.Collections.Generic;
using System.Text;

namespace Company_events
{
    public class SalesPerson : Employee
    {
        public int AchievedTarget { get; set; }

        public SalesPerson() : base()
        {
            VacationStock = 0;
            AchievedTarget = 5;
        }
        public bool CheckTarget(int quota)
        {
            if(quota < AchievedTarget)
            {
                OnEmployeeLayOff(
                    new EmployeeLayOffEventArgs
                    {
                        Cause = LayOffCause.NotAchievedTarget
                    });
                return false;
            }
            else
                return true;
        }
    }
}
