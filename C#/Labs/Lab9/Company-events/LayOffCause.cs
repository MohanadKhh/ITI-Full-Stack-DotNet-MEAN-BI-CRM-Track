using System;
using System.Collections.Generic;
using System.Text;

namespace Company_events
{
    public enum LayOffCause
    {
        None = 0,
        ExceededVacationLimit,   // VacationStock < 0
        RetirementAgeExceeded,    // Age > 60
        NotAchievedTarget,           //SalesPerson not achieved target       
        Ressign
    }
}