using System;
using System.Collections.Generic;
using System.Text;

namespace Company_events
{
    internal class Club
    {
        public int ClubID { get; set; }
        public String ClubName { get; set; }
        List<Employee> members;

        public Club() 
        {
            ClubID = 0;
            ClubName = "Honda Club";
            members = new List<Employee>();
        }
        public void AddMember(Employee e)
        {
            members.Add(e);
            e.employeeLayOff += RemoveMember;
        }
            
        ///CallBackMethod 
        public void RemoveMember(object? sender, EmployeeLayOffEventArgs e)
        {
            if (sender is not Employee emp)
                return;

            if(e.Cause == LayOffCause.ExceededVacationLimit || e.Cause == LayOffCause.NotAchievedTarget)
            {
                Console.WriteLine($"Employee with Id: {emp.EmployeeID} was removed from Club due to {e.Cause}");
                members.Remove(emp);
            }
        }
    }
}
