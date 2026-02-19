using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ITI.DataAccessLayer
{
    public class DBManager
    {

        public static DataTable ExecuteQuery(string query, SqlParameter[] parameter = null)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ITI"].ConnectionString);
            SqlCommand cmd = new SqlCommand(query, con);
            if(parameter != null)
            {
                cmd.Parameters.AddRange(parameter);
            }
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public static int ExecuteNonQuery(string query, SqlParameter[] parameter)
        {
            int affected = -1;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ITI"].ConnectionString);
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddRange(parameter);

            try
            {
                con.Open();
                affected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close(); 
            }
            return affected;
        }
    }
}
