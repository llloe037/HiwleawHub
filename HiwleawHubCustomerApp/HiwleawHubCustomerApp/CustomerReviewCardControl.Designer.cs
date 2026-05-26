namespace HiwleawHubCustomerApp
{
    partial class CustomerReviewCardControl
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
            lblReviewer = new Label();
            lblComment = new Label();
            lblStars = new Label();
            SuspendLayout();
            // 
            // lblReviewer
            // 
            lblReviewer.AutoSize = true;
            lblReviewer.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblReviewer.Location = new Point(15, 9);
            lblReviewer.Name = "lblReviewer";
            lblReviewer.Size = new Size(63, 25);
            lblReviewer.TabIndex = 0;
            lblReviewer.Text = "label1";
            // 
            // lblComment
            // 
            lblComment.AutoSize = true;
            lblComment.Location = new Point(17, 43);
            lblComment.Name = "lblComment";
            lblComment.Size = new Size(59, 25);
            lblComment.TabIndex = 1;
            lblComment.Text = "label1";
            // 
            // lblStars
            // 
            lblStars.AutoSize = true;
            lblStars.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStars.ForeColor = Color.Gold;
            lblStars.Location = new Point(208, 9);
            lblStars.Name = "lblStars";
            lblStars.Size = new Size(78, 32);
            lblStars.TabIndex = 2;
            lblStars.Text = "label1";
            // 
            // CustomerReviewCardControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblStars);
            Controls.Add(lblComment);
            Controls.Add(lblReviewer);
            Name = "CustomerReviewCardControl";
            Size = new Size(350, 100);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblReviewer;
        private Label lblComment;
        private Label lblStars;
    }
}
