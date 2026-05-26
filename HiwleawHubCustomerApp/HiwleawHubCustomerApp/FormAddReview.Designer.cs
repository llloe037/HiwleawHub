namespace HiwleawHubCustomerApp
{
    partial class FormAddReview
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbMenus = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            txtComment = new TextBox();
            txtName = new TextBox();
            label3 = new Label();
            lblStar1 = new Label();
            lblStar2 = new Label();
            lblStar3 = new Label();
            lblStar4 = new Label();
            lblStar5 = new Label();
            btnSubmit = new Button();
            SuspendLayout();
            // 
            // cmbMenus
            // 
            cmbMenus.FormattingEnabled = true;
            cmbMenus.Location = new Point(209, 86);
            cmbMenus.Name = "cmbMenus";
            cmbMenus.Size = new Size(207, 33);
            cmbMenus.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(30, 9);
            label1.Name = "label1";
            label1.Size = new Size(246, 54);
            label1.TabIndex = 1;
            label1.Text = "Add Review";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(64, 77);
            label2.Name = "label2";
            label2.Size = new Size(108, 25);
            label2.TabIndex = 2;
            label2.Text = "Select Menu";
            // 
            // txtComment
            // 
            txtComment.Location = new Point(95, 142);
            txtComment.Multiline = true;
            txtComment.Name = "txtComment";
            txtComment.PlaceholderText = "Enter Comment";
            txtComment.Size = new Size(321, 144);
            txtComment.TabIndex = 3;
            // 
            // txtName
            // 
            txtName.Location = new Point(217, 309);
            txtName.Name = "txtName";
            txtName.Size = new Size(193, 31);
            txtName.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(64, 309);
            label3.Name = "label3";
            label3.Size = new Size(133, 25);
            label3.TabIndex = 5;
            label3.Text = "Reviewer Name";
            // 
            // lblStar1
            // 
            lblStar1.AutoSize = true;
            lblStar1.Cursor = Cursors.Hand;
            lblStar1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStar1.ForeColor = Color.Gold;
            lblStar1.Location = new Point(116, 364);
            lblStar1.Name = "lblStar1";
            lblStar1.Size = new Size(68, 65);
            lblStar1.TabIndex = 6;
            lblStar1.Text = "☆";
            lblStar1.Click += lblStar1_Click;
            // 
            // lblStar2
            // 
            lblStar2.AutoSize = true;
            lblStar2.Cursor = Cursors.Hand;
            lblStar2.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStar2.ForeColor = Color.Gold;
            lblStar2.Location = new Point(163, 364);
            lblStar2.Name = "lblStar2";
            lblStar2.Size = new Size(68, 65);
            lblStar2.TabIndex = 7;
            lblStar2.Text = "☆";
            lblStar2.Click += lblStar2_Click;
            // 
            // lblStar3
            // 
            lblStar3.AutoSize = true;
            lblStar3.Cursor = Cursors.Hand;
            lblStar3.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStar3.ForeColor = Color.Gold;
            lblStar3.Location = new Point(207, 364);
            lblStar3.Name = "lblStar3";
            lblStar3.Size = new Size(68, 65);
            lblStar3.TabIndex = 8;
            lblStar3.Text = "☆";
            lblStar3.Click += lblStar3_Click;
            // 
            // lblStar4
            // 
            lblStar4.AutoSize = true;
            lblStar4.Cursor = Cursors.Hand;
            lblStar4.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStar4.ForeColor = Color.Gold;
            lblStar4.Location = new Point(256, 364);
            lblStar4.Name = "lblStar4";
            lblStar4.Size = new Size(68, 65);
            lblStar4.TabIndex = 9;
            lblStar4.Text = "☆";
            lblStar4.Click += lblStar4_Click;
            // 
            // lblStar5
            // 
            lblStar5.AutoSize = true;
            lblStar5.Cursor = Cursors.Hand;
            lblStar5.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStar5.ForeColor = Color.Gold;
            lblStar5.Location = new Point(302, 364);
            lblStar5.Name = "lblStar5";
            lblStar5.Size = new Size(68, 65);
            lblStar5.TabIndex = 10;
            lblStar5.Text = "☆";
            lblStar5.Click += lblStar5_Click;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.DodgerBlue;
            btnSubmit.Location = new Point(179, 468);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(112, 34);
            btnSubmit.TabIndex = 11;
            btnSubmit.Text = "Add Review";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // FormAddReview
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(490, 514);
            Controls.Add(btnSubmit);
            Controls.Add(lblStar5);
            Controls.Add(lblStar4);
            Controls.Add(lblStar3);
            Controls.Add(lblStar2);
            Controls.Add(lblStar1);
            Controls.Add(label3);
            Controls.Add(txtName);
            Controls.Add(txtComment);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbMenus);
            Name = "FormAddReview";
            Text = "FormAddReview";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbMenus;
        private Label label1;
        private Label label2;
        private TextBox txtComment;
        private TextBox txtName;
        private Label label3;
        private Label lblStar1;
        private Label lblStar2;
        private Label lblStar3;
        private Label lblStar4;
        private Label lblStar5;
        private Button btnSubmit;
    }
}