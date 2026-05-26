namespace HiwleawHubAdminApp
{
    partial class FormManageMenu
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
            btnAddMenu = new Button();
            flpMenus = new FlowLayoutPanel();
            btnBack = new Button();
            btnViewReviews = new Button();
            SuspendLayout();
            // 
            // btnAddMenu
            // 
            btnAddMenu.Location = new Point(681, 414);
            btnAddMenu.Name = "btnAddMenu";
            btnAddMenu.Size = new Size(112, 34);
            btnAddMenu.TabIndex = 0;
            btnAddMenu.Text = "Add Menu";
            btnAddMenu.UseVisualStyleBackColor = true;
            btnAddMenu.Click += btnAddMenu_Click;
            // 
            // flpMenus
            // 
            flpMenus.AutoScroll = true;
            flpMenus.Location = new Point(10, 4);
            flpMenus.Name = "flpMenus";
            flpMenus.Size = new Size(781, 407);
            flpMenus.TabIndex = 1;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(12, 414);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(112, 34);
            btnBack.TabIndex = 2;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnViewReviews
            // 
            btnViewReviews.Location = new Point(351, 416);
            btnViewReviews.Name = "btnViewReviews";
            btnViewReviews.Size = new Size(132, 34);
            btnViewReviews.TabIndex = 3;
            btnViewReviews.Text = "ShowReview";
            btnViewReviews.UseVisualStyleBackColor = true;
            btnViewReviews.Click += btnViewReviews_Click;
            // 
            // FormManageMenu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnViewReviews);
            Controls.Add(btnBack);
            Controls.Add(flpMenus);
            Controls.Add(btnAddMenu);
            Name = "FormManageMenu";
            Text = "FormManageMenu";
            ResumeLayout(false);
        }

        #endregion

        private Button btnAddMenu;
        private FlowLayoutPanel flpMenus;
        private Button btnBack;
        private Button btnViewReviews;
    }
}