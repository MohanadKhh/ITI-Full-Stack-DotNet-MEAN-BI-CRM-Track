using System;
using System.Collections.Generic;
using System.Text;

namespace Company_events
{
    internal class Department
    {
        public int DeptID { get; set; }
        public string DeptName { get; set; }
        List<Employee> staff;

        public Department()
        {
            DeptID = 0; ;
            DeptName = "Developmnet Dept";
            staff = new List<Employee>();
        }
        public void AddStaff(Employee e)
        {
            staff.Add(e);
            e.employeeLayOff += RemoveStaff;
        }

        ///CallBackMethod 
        public void RemoveStaff(object? sender, EmployeeLayOffEventArgs e)
        {
            if (sender is not Employee emp)
                return;

            if(e.Cause != 0)
            {
                Console.WriteLine($"Employee with Id: {emp.EmployeeID} was removed from Department due to {e.Cause}");
                staff.Remove(emp);
            }
        }
    }
}
