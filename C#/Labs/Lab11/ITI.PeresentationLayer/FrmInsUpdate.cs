using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Task2_ADO
{
    public partial class FrmInsUpdate : Form
    {
        public FrmInsUpdate()
        {
            InitializeComponent();
            FillInstructorsToComboBox();
            FillDeptToComboBox();
        }

        public void FillInstructorsToComboBox()
        {
            DataTable dataTable = ITI.BusinessLayer.InstructorBL.GetAll();
            comboBoxInstructors.DataSource = dataTable;
            comboBoxInstructors.DisplayMember = "Ins_Name";
            comboBoxInstructors.ValueMember = "Ins_Id";
        }

        public void FillInsDataToTxtBox()
        {
            DataTable dataTable = ITI.BusinessLayer.InstructorBL.GetOne(Convert.ToInt32(comboBoxInstructors.SelectedValue)); ;
            txtBoxName.Text = dataTable.Rows[0]["Ins_Name"].ToString();
            txtBoxDegree.Text = dataTable.Rows[0]["Ins_Degree"].ToString();
            txtBoxSalary.Text = dataTable.Rows[0]["Salary"].ToString();
            comboBoxDept.SelectedValue = dataTable.Rows[0]["Dept_Id"];
        }

        private void comboBoxInstructors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxInstructors.SelectedValue is int)
            {
                FillInsDataToTxtBox();
                MessageBox.Show(comboBoxInstructors.SelectedValue.ToString());
            }
            else
                return;
        }

        private void FillDeptToComboBox()
        {
            DataTable dataTable = ITI.BusinessLayer.DepartmentBL.GetAll();
            comboBoxInstructors.DataSource = dataTable;
            comboBoxInstructors.DisplayMember = "Dept_Name";
            comboBoxInstructors.ValueMember = "Dept_Id";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            //SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=ITI;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");
            //SqlCommand command = new SqlCommand();

            //command.CommandText = "update Instructor " +
            //                      "set Ins_Name = @insName, Ins_Degree = @insDegree, Salary = @insSalary, Dept_Id = @insDept " +
            //                      "where Ins_Id = @insId";

            //command.Parameters.AddWithValue("@insId", comboBoxInstructors.SelectedValue);
            //command.Parameters.AddWithValue("@insName", txtBoxName.Text);
            //command.Parameters.AddWithValue("@insSalary", txtBoxSalary.Text);
            //command.Parameters.AddWithValue("@insDegree", txtBoxDegree.Text);
            //command.Parameters.AddWithValue("@insDept", comboBoxDept.SelectedValue);
            //command.Connection = con;

            //try
            //{
            //    con.Open();
            //    int affected = command.ExecuteNonQuery();
            //    if (affected > 0)
            //    {
            //        lblResult.Text = "Updated...";
            //        FillInstructorsToComboBox();
            //    }
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Not Valid Data for update");
            //}
            //finally
            //{
            //    con.Close();
            //}
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=ITI;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");
            //SqlCommand cmdDelIns = new SqlCommand("DELETE from Instructor where Ins_Id = @insId", con);
            //SqlCommand cmdDelIncCr = new SqlCommand("DELETE FROM Ins_Course WHERE Ins_Id = @insId", con);
            //SqlCommand cmdUpdate = new SqlCommand("Update Department set Dept_Manager = null WHERE Dept_Manager = @insId", con);

            //cmdDelIns.Parameters.AddWithValue("@insId", comboBoxInstructors.SelectedValue);
            //cmdDelIncCr.Parameters.AddWithValue("@insId", comboBoxInstructors.SelectedValue);
            //cmdUpdate.Parameters.AddWithValue("@insId", comboBoxInstructors.SelectedValue);

            //try
            //{
            //    con.Open();
            //    int affected = cmdDelIncCr.ExecuteNonQuery();
            //    int affectUpdated = cmdUpdate.ExecuteNonQuery();
            //    affected += cmdDelIns.ExecuteNonQuery();
            //    if (affected > 0)
            //    {
            //        lblRseultDel.Text = $"Deleted {affected} rows...\nUpdated {affectUpdated} rows...";
            //        FillInstructorsToComboBox();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    con.Close();
            //}
        }
    }
}
