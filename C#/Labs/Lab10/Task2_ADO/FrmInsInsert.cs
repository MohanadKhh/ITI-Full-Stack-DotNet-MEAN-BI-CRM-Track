using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Task2_ADO
{
    public partial class FrmInsInsert : Form
    {
        public FrmInsInsert()
        {
            InitializeComponent();
            FillDeptToComboBox();
        }

        private void FillDeptToComboBox()
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=ITI;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");
            SqlCommand command = new SqlCommand();

            command.CommandText = "select Dept_Name, Dept_Id from Department";
            command.Connection = con;

            try
            {
                con.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                comboBoxDept.DataSource = dataTable;
                comboBoxDept.DisplayMember = "Dept_Name";
                comboBoxDept.ValueMember = "Dept_Id";

                comboBoxDept.SelectedIndex = -1;
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

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=ITI;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");
            SqlCommand command = new SqlCommand();

            command.CommandText = "INSERT INTO Instructor VALUES(@insId, @insName, @insDegree, @insSalary, @insDept);";

            command.Parameters.AddWithValue("@insId", txtBoxId.Text);
            command.Parameters.AddWithValue("@insName", txtBoxName.Text);
            command.Parameters.AddWithValue("@insSalary", txtBoxSalary.Text);
            command.Parameters.AddWithValue("@insDegree", txtBoxDegree.Text);
            command.Parameters.AddWithValue("@insDept", comboBoxDept.SelectedValue);
            command.Connection = con;

            try
            {
                con.Open();
                int affected = command.ExecuteNonQuery();
                txtBoxId.Text = "";
                txtBoxName.Text = "";
                txtBoxDegree.Text = "";
                txtBoxSalary.Text = "";
                comboBoxDept.SelectedValue = -1;
                if (affected > 0)
                {
                    lblResult.Text = "Inserted...";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Not Valid Data");
            }
            finally
            {
                con.Close();
            }
        }
    }
}
