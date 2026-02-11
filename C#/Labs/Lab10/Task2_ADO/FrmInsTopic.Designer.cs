
namespace Task2_ADO
{
    partial class FrmInsTopic
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBoxInstructors = new ComboBox();
            lbl_Ins = new Label();
            dataGridTopics = new DataGridView();
            lblTopic = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridTopics).BeginInit();
            SuspendLayout();
            // 
            // comboBoxInstructors
            // 
            comboBoxInstructors.FormattingEnabled = true;
            comboBoxInstructors.Location = new Point(21, 45);
            comboBoxInstructors.Name = "comboBoxInstructors";
            comboBoxInstructors.Size = new Size(236, 28);
            comboBoxInstructors.TabIndex = 0;
            comboBoxInstructors.SelectedIndexChanged += this.comboBoxInstructors_SelectedIndexChanged;
            // 
            // lbl_Ins
            // 
            lbl_Ins.AutoSize = true;
            lbl_Ins.Location = new Point(21, 22);
            lbl_Ins.Name = "lbl_Ins";
            lbl_Ins.Size = new Size(77, 20);
            lbl_Ins.TabIndex = 1;
            lbl_Ins.Text = "Instructors";
            // 
            // dataGridTopics
            // 
            dataGridTopics.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridTopics.Location = new Point(0, 262);
            dataGridTopics.Name = "dataGridTopics";
            dataGridTopics.RowHeadersWidth = 51;
            dataGridTopics.Size = new Size(800, 188);
            dataGridTopics.TabIndex = 2;
            // 
            // lblTopic
            // 
            lblTopic.AutoSize = true;
            lblTopic.Location = new Point(314, 224);
            lblTopic.Name = "lblTopic";
            lblTopic.Size = new Size(146, 20);
            lblTopic.TabIndex = 3;
            lblTopic.Text = "Topics for Instructors";
            // 
            // FrmInsTopic
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblTopic);
            Controls.Add(dataGridTopics);
            Controls.Add(lbl_Ins);
            Controls.Add(comboBoxInstructors);
            Name = "FrmInsTopic";
            Text = "FrmData";
            ((System.ComponentModel.ISupportInitialize)dataGridTopics).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxInstructors;
        private Label lbl_Ins;
        private DataGridView dataGridTopics;
        private Label lblTopic;
    }
}
