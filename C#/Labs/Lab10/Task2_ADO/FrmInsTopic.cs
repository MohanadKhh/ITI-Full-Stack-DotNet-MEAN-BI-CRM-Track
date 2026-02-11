using Microsoft.Data.SqlClient;
using System.Data;

namespace Task2_ADO
{
    public partial class FrmInsTopic : Form
    {
        public FrmInsTopic()
        {
            InitializeComponent();
            FillInstructorsToComboBox();
        }

        public void FillInstructorsToComboBox()
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=ITI;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");
            SqlCommand command = new SqlCommand();

            command.CommandText = "select Ins_Id, Ins_Name from Instructor";
            command.Connection = con;

            try
            {
                con.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                comboBoxInstructors.DataSource = dataTable;
                comboBoxInstructors.DisplayMember = "Ins_Name";
                comboBoxInstructors.ValueMember = "Ins_Id";
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public void FillTopicsToDataGrid()
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=ITI;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");
            SqlCommand command = new SqlCommand();

            command.CommandText = "select distinct t.Top_Name " +
                                  "from Instructor ins,Course c,Ins_Course ic,Topic t " +
                                  "where ins.Ins_Id = ic.Ins_Id and ic.Crs_Id = c.Crs_Id " +
                                  $"and c.Top_Id = t.Top_Id and ins.Ins_Id = @insId";

            command.Parameters.AddWithValue("@insId", comboBoxInstructors.SelectedValue);
            command.Connection = con;

            try
            {
                con.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dataGridTopics.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void comboBoxInstructors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxInstructors.SelectedValue is int)
                FillTopicsToDataGrid();
            else
                return;
        }
    }
}
