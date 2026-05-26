namespace HiwleawHubCustomerApp
{
    partial class FormRestaurantHomePage
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
            lblRestaurantName = new Label();
            flpMenus = new FlowLayoutPanel();
            flpReviews = new FlowLayoutPanel();
            btnAddReview = new Button();
            button1 = new Button();
            timerRefresh = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // lblRestaurantName
            // 
            lblRestaurantName.AutoSize = true;
            lblRestaurantName.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRestaurantName.Location = new Point(12, 9);
            lblRestaurantName.Name = "lblRestaurantName";
            lblRestaurantName.Size = new Size(137, 54);
            lblRestaurantName.TabIndex = 0;
            lblRestaurantName.Text = "label1";
            // 
            // flpMenus
            // 
            flpMenus.AutoScroll = true;
            flpMenus.Location = new Point(12, 66);
            flpMenus.Name = "flpMenus";
            flpMenus.Size = new Size(503, 420);
            flpMenus.TabIndex = 1;
            // 
            // flpReviews
            // 
            flpReviews.AutoScroll = true;
            flpReviews.Location = new Point(521, 66);
            flpReviews.Name = "flpReviews";
            flpReviews.Size = new Size(354, 420);
            flpReviews.TabIndex = 2;
            // 
            // btnAddReview
            // 
            btnAddReview.Location = new Point(728, 495);
            btnAddReview.Name = "btnAddReview";
            btnAddReview.Size = new Size(142, 34);
            btnAddReview.TabIndex = 3;
            btnAddReview.Text = "Add Review";
            btnAddReview.UseVisualStyleBackColor = true;
            btnAddReview.Click += btnAddReview_Click;
            // 
            // button1
            // 
            button1.Location = new Point(11, 492);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 4;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnBack_Click;
            // 
            // timerRefresh
            // 
            timerRefresh.Enabled = true;
            timerRefresh.Interval = 5000;
            timerRefresh.Tick += timerRefresh_Tick;
            // 
            // FormRestaurantHomePage
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(881, 534);
            Controls.Add(button1);
            Controls.Add(btnAddReview);
            Controls.Add(flpReviews);
            Controls.Add(flpMenus);
            Controls.Add(lblRestaurantName);
            Name = "FormRestaurantHomePage";
            Text = "FormRestaurantHomePage";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblRestaurantName;
        private FlowLayoutPanel flpMenus;
        private FlowLayoutPanel flpReviews;
        private Button btnAddReview;
        private Button button1;
        private System.Windows.Forms.Timer timerRefresh;
    }
}