using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ITI.BusinessLayer
{
    public class DepartmentBL
    {
        public static DataTable GetAll()
        {
            string query = "Select Dept_Name, Dept_Id from Department";
            return ITI.DataAccessLayer.DBManager.ExecuteQuery(query);
        }
    }
}
