using System;
using System.Collections.Generic;
using System.Text;

namespace Company_events
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public DateTime BirthDate { get; set; }
        public int VacationStock { get; set; }

        private static int id = 1;

        public Employee()
        {
            EmployeeID = id;
            BirthDate = new DateTime(1988, 2, 10);
            VacationStock = 0;
            id++;
        }

        public Employee(DateTime birthDate, int vacationStock)
        {
            EmployeeID = id;
            BirthDate = birthDate;
            VacationStock = vacationStock;
            id++;
        }


        public event EventHandler<EmployeeLayOffEventArgs>? employeeLayOff;
        protected virtual void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            employeeLayOff?.Invoke(this, e);
        }

        public bool RequestVacation(DateTime from, DateTime to)
        {
            int daysOfVacation = (to - from).Days;
            if (daysOfVacation < VacationStock)
            {
                return true;
            }
            else
            {
                OnEmployeeLayOff(
                    new EmployeeLayOffEventArgs
                    {
                        Cause = LayOffCause.ExceededVacationLimit
                    });
                return false;
            }
        }

        public void EndOfYearOperation()
        {
            int ageOfEmp = (DateTime.Today - BirthDate).Days / 365;
            if (ageOfEmp > 60)
            {
                OnEmployeeLayOff(
                    new EmployeeLayOffEventArgs
                    {
                        Cause = LayOffCause.RetirementAgeExceeded
                    });
            }
        }
    }
}