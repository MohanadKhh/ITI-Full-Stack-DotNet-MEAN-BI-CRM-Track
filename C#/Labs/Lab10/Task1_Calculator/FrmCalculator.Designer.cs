namespace Task1_Calculator
{
    partial class FrmCalculator
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
            btn1 = new Button();
            btnMinus = new Button();
            btnPlus = new Button();
            btn9 = new Button();
            btn8 = new Button();
            btn7 = new Button();
            btn6 = new Button();
            btn5 = new Button();
            btn4 = new Button();
            btn3 = new Button();
            btn2 = new Button();
            btnDivide = new Button();
            btnMultiple = new Button();
            btnDot = new Button();
            btn0 = new Button();
            btnEquals = new Button();
            txtScreen = new TextBox();
            btnOpenBracket = new Button();
            btnCloseBracket = new Button();
            btnClr = new Button();
            btnDel = new Button();
            SuspendLayout();
            // 
            // btn1
            // 
            btn1.Location = new Point(42, 155);
            btn1.Name = "btn1";
            btn1.Size = new Size(49, 45);
            btn1.TabIndex = 0;
            btn1.Text = "1";
            btn1.UseVisualStyleBackColor = true;
            btn1.Click += btnInput_Click;
            // 
            // btnMinus
            // 
            btnMinus.BackColor = Color.SandyBrown;
            btnMinus.Location = new Point(271, 232);
            btnMinus.Name = "btnMinus";
            btnMinus.Size = new Size(49, 45);
            btnMinus.TabIndex = 1;
            btnMinus.Text = "-";
            btnMinus.UseVisualStyleBackColor = false;
            btnMinus.Click += btnInput_Click;
            // 
            // btnPlus
            // 
            btnPlus.BackColor = Color.SandyBrown;
            btnPlus.Location = new Point(271, 155);
            btnPlus.Name = "btnPlus";
            btnPlus.Size = new Size(49, 45);
            btnPlus.TabIndex = 2;
            btnPlus.Text = "+";
            btnPlus.UseVisualStyleBackColor = false;
            btnPlus.Click += btnInput_Click;
            // 
            // btn9
            // 
            btn9.Location = new Point(195, 309);
            btn9.Name = "btn9";
            btn9.Size = new Size(49, 45);
            btn9.TabIndex = 3;
            btn9.Text = "9";
            btn9.UseVisualStyleBackColor = true;
            btn9.Click += btnInput_Click;
            // 
            // btn8
            // 
            btn8.Location = new Point(119, 309);
            btn8.Name = "btn8";
            btn8.Size = new Size(49, 45);
            btn8.TabIndex = 4;
            btn8.Text = "8";
            btn8.UseVisualStyleBackColor = true;
            btn8.Click += btnInput_Click;
            // 
            // btn7
            // 
            btn7.Location = new Point(42, 309);
            btn7.Name = "btn7";
            btn7.Size = new Size(49, 45);
            btn7.TabIndex = 5;
            btn7.Text = "7";
            btn7.UseVisualStyleBackColor = true;
            btn7.Click += btnInput_Click;
            // 
            // btn6
            // 
            btn6.Location = new Point(195, 232);
            btn6.Name = "btn6";
            btn6.Size = new Size(49, 45);
            btn6.TabIndex = 6;
            btn6.Text = "6";
            btn6.UseVisualStyleBackColor = true;
            btn6.Click += btnInput_Click;
            // 
            // btn5
            // 
            btn5.Location = new Point(119, 232);
            btn5.Name = "btn5";
            btn5.Size = new Size(49, 45);
            btn5.TabIndex = 7;
            btn5.Text = "5";
            btn5.UseVisualStyleBackColor = true;
            btn5.Click += btnInput_Click;
            // 
            // btn4
            // 
            btn4.Location = new Point(42, 232);
            btn4.Name = "btn4";
            btn4.Size = new Size(49, 45);
            btn4.TabIndex = 8;
            btn4.Text = "4";
            btn4.UseVisualStyleBackColor = true;
            btn4.Click += btnInput_Click;
            // 
            // btn3
            // 
            btn3.Location = new Point(195, 155);
            btn3.Name = "btn3";
            btn3.Size = new Size(49, 45);
            btn3.TabIndex = 9;
            btn3.Text = "3";
            btn3.UseVisualStyleBackColor = true;
            btn3.Click += btnInput_Click;
            // 
            // btn2
            // 
            btn2.Location = new Point(119, 155);
            btn2.Name = "btn2";
            btn2.Size = new Size(49, 45);
            btn2.TabIndex = 10;
            btn2.Text = "2";
            btn2.UseVisualStyleBackColor = true;
            btn2.Click += btnInput_Click;
            // 
            // btnDivide
            // 
            btnDivide.BackColor = Color.SandyBrown;
            btnDivide.Location = new Point(271, 381);
            btnDivide.Name = "btnDivide";
            btnDivide.Size = new Size(49, 45);
            btnDivide.TabIndex = 11;
            btnDivide.Text = "/";
            btnDivide.UseVisualStyleBackColor = false;
            btnDivide.Click += btnInput_Click;
            // 
            // btnMultiple
            // 
            btnMultiple.BackColor = Color.SandyBrown;
            btnMultiple.Location = new Point(271, 309);
            btnMultiple.Name = "btnMultiple";
            btnMultiple.Size = new Size(49, 45);
            btnMultiple.TabIndex = 12;
            btnMultiple.Text = "*";
            btnMultiple.UseVisualStyleBackColor = false;
            btnMultiple.Click += btnInput_Click;
            // 
            // btnDot
            // 
            btnDot.Location = new Point(119, 381);
            btnDot.Name = "btnDot";
            btnDot.Size = new Size(49, 45);
            btnDot.TabIndex = 13;
            btnDot.Text = ".";
            btnDot.UseVisualStyleBackColor = true;
            btnDot.Click += btnInput_Click;
            // 
            // btn0
            // 
            btn0.Location = new Point(42, 381);
            btn0.Name = "btn0";
            btn0.Size = new Size(49, 45);
            btn0.TabIndex = 14;
            btn0.Text = "0";
            btn0.UseVisualStyleBackColor = true;
            btn0.Click += btnInput_Click;
            // 
            // btnEquals
            // 
            btnEquals.BackColor = Color.PaleGreen;
            btnEquals.Location = new Point(195, 381);
            btnEquals.Name = "btnEquals";
            btnEquals.Size = new Size(49, 45);
            btnEquals.TabIndex = 15;
            btnEquals.Text = "=";
            btnEquals.UseVisualStyleBackColor = false;
            btnEquals.Click += btnEquals_Click;
            // 
            // txtScreen
            // 
            txtScreen.Dock = DockStyle.Top;
            txtScreen.Location = new Point(0, 0);
            txtScreen.Name = "txtScreen";
            txtScreen.Size = new Size(456, 27);
            txtScreen.TabIndex = 16;
            // 
            // btnOpenBracket
            // 
            btnOpenBracket.BackColor = Color.LemonChiffon;
            btnOpenBracket.Location = new Point(340, 155);
            btnOpenBracket.Name = "btnOpenBracket";
            btnOpenBracket.Size = new Size(49, 45);
            btnOpenBracket.TabIndex = 17;
            btnOpenBracket.Text = "(";
            btnOpenBracket.UseVisualStyleBackColor = false;
            btnOpenBracket.Click += btnInput_Click;
            // 
            // btnCloseBracket
            // 
            btnCloseBracket.BackColor = Color.LemonChiffon;
            btnCloseBracket.Location = new Point(340, 232);
            btnCloseBracket.Name = "btnCloseBracket";
            btnCloseBracket.Size = new Size(49, 45);
            btnCloseBracket.TabIndex = 18;
            btnCloseBracket.Text = ")";
            btnCloseBracket.UseVisualStyleBackColor = false;
            btnCloseBracket.Click += btnInput_Click;
            // 
            // btnClr
            // 
            btnClr.BackColor = Color.Red;
            btnClr.Location = new Point(340, 381);
            btnClr.Name = "btnClr";
            btnClr.Size = new Size(49, 45);
            btnClr.TabIndex = 19;
            btnClr.Text = "clr";
            btnClr.UseVisualStyleBackColor = false;
            btnClr.Click += btnClr_Click;
            // 
            // btnDel
            // 
            btnDel.BackColor = Color.LightCoral;
            btnDel.Location = new Point(340, 309);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(49, 45);
            btnDel.TabIndex = 20;
            btnDel.Text = "del";
            btnDel.UseVisualStyleBackColor = false;
            btnDel.Click += btnDel_Click;
            // 
            // FrmCalculator
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(456, 471);
            Controls.Add(btnDel);
            Controls.Add(btnClr);
            Controls.Add(btnCloseBracket);
            Controls.Add(btnOpenBracket);
            Controls.Add(txtScreen);
            Controls.Add(btnEquals);
            Controls.Add(btn0);
            Controls.Add(btnDot);
            Controls.Add(btnMultiple);
            Controls.Add(btnDivide);
            Controls.Add(btn2);
            Controls.Add(btn3);
            Controls.Add(btn4);
            Controls.Add(btn5);
            Controls.Add(btn6);
            Controls.Add(btn7);
            Controls.Add(btn8);
            Controls.Add(btn9);
            Controls.Add(btnPlus);
            Controls.Add(btnMinus);
            Controls.Add(btn1);
            Name = "FrmCalculator";
            Text = "FrmCalculator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn1;
        private Button btnMinus;
        private Button btnPlus;
        private Button btn9;
        private Button btn8;
        private Button btn7;
        private Button btn6;
        private Button btn5;
        private Button btn4;
        private Button btn3;
        private Button btn2;
        private Button btnDivide;
        private Button btnMultiple;
        private Button btnDot;
        private Button btn0;
        private Button btnEquals;
        private TextBox txtScreen;
        private Button btnOpenBracket;
        private Button btnCloseBracket;
        private Button btnClr;
        private Button btnDel;
    }
}
