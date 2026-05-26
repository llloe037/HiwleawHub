namespace HiwleawHubAdminApp
{
    partial class FormManageReviews
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            flpReviews = new FlowLayoutPanel();
            btnBack = new Button();
            timerRefresh = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 26F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, -10);
            label1.Name = "label1";
            label1.Size = new Size(203, 70);
            label1.TabIndex = 0;
            label1.Text = "Review";
            // 
            // flpReviews
            // 
            flpReviews.AutoScroll = true;
            flpReviews.FlowDirection = FlowDirection.TopDown;
            flpReviews.Location = new Point(13, 55);
            flpReviews.Name = "flpReviews";
            flpReviews.Size = new Size(897, 354);
            flpReviews.TabIndex = 1;
            flpReviews.WrapContents = false;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(16, 413);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(112, 34);
            btnBack.TabIndex = 2;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // timerRefresh
            // 
            timerRefresh.Enabled = true;
            timerRefresh.Interval = 5000;
            timerRefresh.Tick += timerRefresh_Tick;
            // 
            // FormManageReviews
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(922, 450);
            Controls.Add(btnBack);
            Controls.Add(flpReviews);
            Controls.Add(label1);
            Name = "FormManageReviews";
            Text = "FormManageReviews";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private FlowLayoutPanel flpReviews;
        private Button btnBack;
        private System.Windows.Forms.Timer timerRefresh;
    }
}