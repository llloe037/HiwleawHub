namespace HiwleawHubAdminApp
{
    partial class FormAddEditMenu
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
            lblTitle = new Label();
            label1 = new Label();
            txtName = new TextBox();
            label2 = new Label();
            txtPrice = new TextBox();
            btnSave = new Button();
            btnBack = new Button();
            picMenu = new PictureBox();
            btnBrowseImage = new Button();
            ((System.ComponentModel.ISupportInitialize)picMenu).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(59, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "label1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(20, 156);
            label1.Name = "label1";
            label1.Size = new Size(96, 21);
            label1.TabIndex = 1;
            label1.Text = "Menu Name";
            // 
            // txtName
            // 
            txtName.Location = new Point(125, 150);
            txtName.Name = "txtName";
            txtName.Size = new Size(137, 31);
            txtName.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(70, 213);
            label2.Name = "label2";
            label2.Size = new Size(44, 21);
            label2.TabIndex = 3;
            label2.Text = "Price";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(125, 209);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(137, 31);
            txtPrice.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(276, 265);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 34);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(12, 265);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(112, 34);
            btnBack.TabIndex = 6;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // picMenu
            // 
            picMenu.Location = new Point(115, 17);
            picMenu.Name = "picMenu";
            picMenu.Size = new Size(150, 116);
            picMenu.SizeMode = PictureBoxSizeMode.Zoom;
            picMenu.TabIndex = 7;
            picMenu.TabStop = false;
            // 
            // btnBrowseImage
            // 
            btnBrowseImage.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBrowseImage.Location = new Point(276, 57);
            btnBrowseImage.Name = "btnBrowseImage";
            btnBrowseImage.Size = new Size(73, 32);
            btnBrowseImage.TabIndex = 8;
            btnBrowseImage.Text = "Browse";
            btnBrowseImage.UseVisualStyleBackColor = true;
            btnBrowseImage.Click += btnBrowseImage_Click;
            // 
            // FormAddEditMenu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 324);
            Controls.Add(btnBrowseImage);
            Controls.Add(picMenu);
            Controls.Add(btnBack);
            Controls.Add(btnSave);
            Controls.Add(txtPrice);
            Controls.Add(label2);
            Controls.Add(txtName);
            Controls.Add(label1);
            Controls.Add(lblTitle);
            Name = "FormAddEditMenu";
            Text = "FormAddEditMenu";
            ((System.ComponentModel.ISupportInitialize)picMenu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label label1;
        private TextBox txtName;
        private Label label2;
        private TextBox txtPrice;
        private Button btnSave;
        private Button btnBack;
        private PictureBox picMenu;
        private Button btnBrowseImage;
    }
}