namespace HiwleawHubAdminApp
{
    partial class ReviewCardControl
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
            lblMenuName = new Label();
            lblReviewerName = new Label();
            lblComment = new Label();
            lblRating = new Label();
            btnDelete = new Button();
            SuspendLayout();
            // 
            // lblMenuName
            // 
            lblMenuName.AutoSize = true;
            lblMenuName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMenuName.Location = new Point(17, 11);
            lblMenuName.Name = "lblMenuName";
            lblMenuName.Size = new Size(83, 32);
            lblMenuName.TabIndex = 0;
            lblMenuName.Text = "label1";
            // 
            // lblReviewerName
            // 
            lblReviewerName.AutoSize = true;
            lblReviewerName.ForeColor = Color.DimGray;
            lblReviewerName.Location = new Point(17, 70);
            lblReviewerName.Name = "lblReviewerName";
            lblReviewerName.Size = new Size(59, 25);
            lblReviewerName.TabIndex = 1;
            lblReviewerName.Text = "label1";
            // 
            // lblComment
            // 
            lblComment.AutoSize = true;
            lblComment.ForeColor = SystemColors.GrayText;
            lblComment.Location = new Point(237, 17);
            lblComment.Name = "lblComment";
            lblComment.Size = new Size(59, 25);
            lblComment.TabIndex = 2;
            lblComment.Text = "label1";
            // 
            // lblRating
            // 
            lblRating.AutoSize = true;
            lblRating.ForeColor = Color.Gold;
            lblRating.Location = new Point(620, 11);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(59, 25);
            lblRating.TabIndex = 3;
            lblRating.Text = "label1";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(739, 6);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(46, 34);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "🗑️";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // ReviewCardControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(btnDelete);
            Controls.Add(lblRating);
            Controls.Add(lblComment);
            Controls.Add(lblReviewerName);
            Controls.Add(lblMenuName);
            Name = "ReviewCardControl";
            Size = new Size(800, 110);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMenuName;
        private Label lblReviewerName;
        private Label lblComment;
        private Label lblRating;
        private Button btnDelete;
    }
}
