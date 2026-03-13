namespace SchoolApp.UI.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblSub = new Label();
            pnlCardInstructor = new Panel();
            lblCardInstructorIcon = new Label();
            lblCardInstructorTitle = new Label();
            lblCardInstructorSub = new Label();
            pnlCardCourse = new Panel();
            lblCardCourseIcon = new Label();
            lblCardCourseTitle = new Label();
            lblCardCourseSub = new Label();
            btnExit = new Button();
            pnlHeader.SuspendLayout();
            pnlCardInstructor.SuspendLayout();
            pnlCardCourse.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(30, 58, 138);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSub);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(911, 100);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(185, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(540, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🎓  School Management";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSub
            // 
            lblSub.Font = new Font("Segoe UI", 10F);
            lblSub.ForeColor = Color.FromArgb(147, 197, 253);
            lblSub.Location = new Point(185, 59);
            lblSub.Name = "lblSub";
            lblSub.Size = new Size(540, 25);
            lblSub.TabIndex = 1;
            lblSub.Text = "Manage your instructors and courses";
            lblSub.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCardInstructor
            // 
            pnlCardInstructor.BackColor = Color.White;
            pnlCardInstructor.Controls.Add(lblCardInstructorIcon);
            pnlCardInstructor.Controls.Add(lblCardInstructorTitle);
            pnlCardInstructor.Controls.Add(lblCardInstructorSub);
            pnlCardInstructor.Cursor = Cursors.Hand;
            pnlCardInstructor.Location = new Point(215, 196);
            pnlCardInstructor.Name = "pnlCardInstructor";
            pnlCardInstructor.Size = new Size(200, 160);
            pnlCardInstructor.TabIndex = 1;
            pnlCardInstructor.Click += btnInstructors_Click;
            // 
            // lblCardInstructorIcon
            // 
            lblCardInstructorIcon.BackColor = Color.Transparent;
            lblCardInstructorIcon.Font = new Font("Segoe UI Emoji", 26F);
            lblCardInstructorIcon.Location = new Point(13, 18);
            lblCardInstructorIcon.Name = "lblCardInstructorIcon";
            lblCardInstructorIcon.Size = new Size(174, 55);
            lblCardInstructorIcon.TabIndex = 0;
            lblCardInstructorIcon.Text = "👨‍🏫";
            lblCardInstructorIcon.TextAlign = ContentAlignment.MiddleCenter;
            lblCardInstructorIcon.Click += btnInstructors_Click;
            // 
            // lblCardInstructorTitle
            // 
            lblCardInstructorTitle.BackColor = Color.Transparent;
            lblCardInstructorTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCardInstructorTitle.ForeColor = Color.FromArgb(30, 58, 138);
            lblCardInstructorTitle.Location = new Point(12, 75);
            lblCardInstructorTitle.Name = "lblCardInstructorTitle";
            lblCardInstructorTitle.Size = new Size(174, 28);
            lblCardInstructorTitle.TabIndex = 1;
            lblCardInstructorTitle.Text = "Instructors";
            lblCardInstructorTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblCardInstructorTitle.Click += btnInstructors_Click;
            // 
            // lblCardInstructorSub
            // 
            lblCardInstructorSub.BackColor = Color.Transparent;
            lblCardInstructorSub.Font = new Font("Segoe UI", 8F);
            lblCardInstructorSub.ForeColor = Color.FromArgb(100, 116, 139);
            lblCardInstructorSub.Location = new Point(12, 105);
            lblCardInstructorSub.Name = "lblCardInstructorSub";
            lblCardInstructorSub.Size = new Size(174, 35);
            lblCardInstructorSub.TabIndex = 2;
            lblCardInstructorSub.Text = "Add, edit and manage instructors";
            lblCardInstructorSub.TextAlign = ContentAlignment.MiddleCenter;
            lblCardInstructorSub.Click += btnInstructors_Click;
            // 
            // pnlCardCourse
            // 
            pnlCardCourse.BackColor = Color.White;
            pnlCardCourse.Controls.Add(lblCardCourseIcon);
            pnlCardCourse.Controls.Add(lblCardCourseTitle);
            pnlCardCourse.Controls.Add(lblCardCourseSub);
            pnlCardCourse.Cursor = Cursors.Hand;
            pnlCardCourse.Location = new Point(459, 196);
            pnlCardCourse.Name = "pnlCardCourse";
            pnlCardCourse.Size = new Size(200, 160);
            pnlCardCourse.TabIndex = 2;
            pnlCardCourse.Click += btnCourses_Click;
            // 
            // lblCardCourseIcon
            // 
            lblCardCourseIcon.BackColor = Color.Transparent;
            lblCardCourseIcon.Font = new Font("Segoe UI Emoji", 26F);
            lblCardCourseIcon.Location = new Point(12, 18);
            lblCardCourseIcon.Name = "lblCardCourseIcon";
            lblCardCourseIcon.Size = new Size(177, 55);
            lblCardCourseIcon.TabIndex = 0;
            lblCardCourseIcon.Text = "📚";
            lblCardCourseIcon.TextAlign = ContentAlignment.MiddleCenter;
            lblCardCourseIcon.Click += btnCourses_Click;
            // 
            // lblCardCourseTitle
            // 
            lblCardCourseTitle.BackColor = Color.Transparent;
            lblCardCourseTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCardCourseTitle.ForeColor = Color.FromArgb(5, 122, 85);
            lblCardCourseTitle.Location = new Point(11, 75);
            lblCardCourseTitle.Name = "lblCardCourseTitle";
            lblCardCourseTitle.Size = new Size(177, 28);
            lblCardCourseTitle.TabIndex = 1;
            lblCardCourseTitle.Text = "Courses";
            lblCardCourseTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblCardCourseTitle.Click += btnCourses_Click;
            // 
            // lblCardCourseSub
            // 
            lblCardCourseSub.BackColor = Color.Transparent;
            lblCardCourseSub.Font = new Font("Segoe UI", 8F);
            lblCardCourseSub.ForeColor = Color.FromArgb(100, 116, 139);
            lblCardCourseSub.Location = new Point(12, 105);
            lblCardCourseSub.Name = "lblCardCourseSub";
            lblCardCourseSub.Size = new Size(177, 35);
            lblCardCourseSub.TabIndex = 2;
            lblCardCourseSub.Text = "Add, edit and manage courses";
            lblCardCourseSub.TextAlign = ContentAlignment.MiddleCenter;
            lblCardCourseSub.Click += btnCourses_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.FromArgb(100, 116, 139);
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(369, 391);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(120, 38);
            btnExit.TabIndex = 3;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // MainForm
            // 
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(911, 526);
            Controls.Add(pnlHeader);
            Controls.Add(pnlCardInstructor);
            Controls.Add(pnlCardCourse);
            Controls.Add(btnExit);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "School Management System";
            pnlHeader.ResumeLayout(false);
            pnlCardInstructor.ResumeLayout(false);
            pnlCardCourse.ResumeLayout(false);
            ResumeLayout(false);
        }

        private static void StyleCard(Panel card, Color accentColor)
        {
            card.Paint += (s, e) =>
            {
                var g    = e.Graphics;
                var rect = new Rectangle(0, 0, card.Width - 1, card.Height - 1);
                using var pen   = new Pen(accentColor, 2);
                using var brush = new SolidBrush(accentColor);
                g.DrawRectangle(pen, rect);
                g.FillRectangle(brush, 0, 0, card.Width, 5);
            };
        }

        // ── Control Declarations ──────────────────────────────────
        private Panel  pnlHeader;
        private Label  lblTitle;
        private Label  lblSub;

        private Panel  pnlCardInstructor;
        private Label  lblCardInstructorIcon;
        private Label  lblCardInstructorTitle;
        private Label  lblCardInstructorSub;

        private Panel  pnlCardCourse;
        private Label  lblCardCourseIcon;
        private Label  lblCardCourseTitle;
        private Label  lblCardCourseSub;

        private Button btnExit;
    }
}
