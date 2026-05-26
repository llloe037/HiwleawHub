namespace HiwleawHubAdminApp
{
    partial class MenuCardControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            picMenu = new PictureBox();
            lblMenuName = new Label();
            lblMenuPrice = new Label();
            btnEdit = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)picMenu).BeginInit();
            SuspendLayout();
            // 
            // picMenu
            // 
            picMenu.BackColor = SystemColors.ButtonShadow;
            picMenu.Location = new Point(29, 39);
            picMenu.Name = "picMenu";
            picMenu.Size = new Size(126, 107);
            picMenu.TabIndex = 0;
            picMenu.TabStop = false;
            // 
            // lblMenuName
            // 
            lblMenuName.AutoSize = true;
            lblMenuName.Location = new Point(34, 151);
            lblMenuName.Name = "lblMenuName";
            lblMenuName.Size = new Size(59, 25);
            lblMenuName.TabIndex = 1;
            lblMenuName.Text = "label1";
            // 
            // lblMenuPrice
            // 
            lblMenuPrice.AutoSize = true;
            lblMenuPrice.Location = new Point(34, 176);
            lblMenuPrice.Name = "lblMenuPrice";
            lblMenuPrice.Size = new Size(59, 25);
            lblMenuPrice.TabIndex = 2;
            lblMenuPrice.Text = "label1";
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(174, 204);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(56, 34);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(205, 6);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(36, 34);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "X";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // MenuCardControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(lblMenuPrice);
            Controls.Add(lblMenuName);
            Controls.Add(picMenu);
            Name = "MenuCardControl";
            Size = new Size(250, 250);
            ((System.ComponentModel.ISupportInitialize)picMenu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picMenu;
        private Label lblMenuName;
        private Label lblMenuPrice;
        private Button btnEdit;
        private Button btnDelete;
    }
}
