using System.Data;

namespace Task1_Calculator
{
    public partial class FrmCalculator : Form
    {
        public FrmCalculator()
        {
            InitializeComponent();
            
        }

        bool flagStart = true;

        private void btnInput_Click(object sender, EventArgs e)
        {
            if (flagStart)
            {
                txtScreen.Clear();
                flagStart = false;
            }
            Button btn = (Button)sender;
            txtScreen.AppendText(btn.Text);
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            try
            {
                txtScreen.Text = new DataTable().Compute(txtScreen.Text, null).ToString();
                flagStart = true;
            }
            catch
            {
                MessageBox.Show("Invalid Expression");
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            txtScreen.Text = txtScreen.Text.Substring(0, txtScreen.Text.Length - 1);
        }

        private void btnClr_Click(object sender, EventArgs e)
        {
            txtScreen.Clear();
        }
    }
}
