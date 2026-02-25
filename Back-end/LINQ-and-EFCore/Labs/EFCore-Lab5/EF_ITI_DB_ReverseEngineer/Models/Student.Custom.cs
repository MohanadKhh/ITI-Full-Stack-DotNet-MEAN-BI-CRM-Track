using System;
using System.Collections.Generic;
using System.Text;

namespace EF_ITI_DB_ReverseEngineer.Models
{
    public partial class Student
    {
        public override string ToString()
        {
            return $"Id: {StId}, Name: {StFname} {StLname}, Age: {StAge}, DeptId: {DeptId}, SupervisorId: {StSuper}";
        }
    }
}
