using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ITI.BusinessLayer
{
    public class InstructorBL
    {
        public static DataTable GetAll()
        {
            string query = "Select * from Instructor";
            return ITI.DataAccessLayer.DBManager.ExecuteQuery(query);
        }

        public static DataTable GetOne(int id)
        {
            string query = $"Select * from Instructor where Ins_Id = @Id";
            SqlParameter[] parameters =
            {
                new SqlParameter("@Id", id),
            };
            return ITI.DataAccessLayer.DBManager.ExecuteQuery(query, parameters);
        }

        public static int Update(int id, Instructor ins)
        {
            string query = "update Instructor set Ins_Name = @Name, Ins_Degree = @Degree, Salary = @Salary, Dept_Id = @DeptId where Ins_Id = @Id";
            SqlParameter[] parameters =
            {
                new SqlParameter("@Id", ins.Ins_Id),
                new SqlParameter("@Name", ins.Ins_Name),
                new SqlParameter("@Degree", ins.Ins_Degree),
                new SqlParameter("@Salary", ins.Salary),
                new SqlParameter("@DeptId", ins.Dept_Id),
            };

            return ITI.DataAccessLayer.DBManager.ExecuteNonQuery(query, parameters);
        }

        public static int Insert(int id, Instructor ins)
        {
            string query = "insert into Instructor (Ins_Id, Ins_Name, Ins_Degree, Salary, Dept_Id ) values(@Id, @Name, @Degree, @Salary, @DeptId)";
            SqlParameter[] parameters =
            {
                new SqlParameter("@Id", ins.Ins_Id),
                new SqlParameter("@Name", ins.Ins_Name),
                new SqlParameter("@Degree", ins.Ins_Degree),
                new SqlParameter("@Salary", ins.Salary),
                new SqlParameter("@DeptId", ins.Dept_Id),
            };

            return ITI.DataAccessLayer.DBManager.ExecuteNonQuery(query, parameters);
        }

        public static int Delete(int id)
        {
            string query = "delete Instructor where Ins_Id = @Id";
            SqlParameter[] parameters =
            {
                new SqlParameter("@Id", id),
            };

            return ITI.DataAccessLayer.DBManager.ExecuteNonQuery(query, parameters);
        }
    }
}
