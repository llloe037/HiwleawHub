namespace HiwleawHubCustomerApp
{
    partial class RestaurantCardControl
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
            picRestaurant = new PictureBox();
            lblRestaurantName = new Label();
            lblRating = new Label();
            ((System.ComponentModel.ISupportInitialize)picRestaurant).BeginInit();
            SuspendLayout();
            // 
            // picRestaurant
            // 
            picRestaurant.Location = new Point(70, 14);
            picRestaurant.Name = "picRestaurant";
            picRestaurant.Size = new Size(150, 130);
            picRestaurant.SizeMode = PictureBoxSizeMode.Zoom;
            picRestaurant.TabIndex = 0;
            picRestaurant.TabStop = false;
            picRestaurant.Click += CardIsClicked;
            // 
            // lblRestaurantName
            // 
            lblRestaurantName.AutoSize = true;
            lblRestaurantName.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRestaurantName.Location = new Point(9, 163);
            lblRestaurantName.Name = "lblRestaurantName";
            lblRestaurantName.Size = new Size(70, 28);
            lblRestaurantName.TabIndex = 1;
            lblRestaurantName.Text = "label1";
            lblRestaurantName.Click += CardIsClicked;
            // 
            // lblRating
            // 
            lblRating.AutoSize = true;
            lblRating.ForeColor = Color.Gold;
            lblRating.Location = new Point(223, 166);
            lblRating.Name = "lblRating";
            lblRating.Size = new Size(59, 25);
            lblRating.TabIndex = 2;
            lblRating.Text = "label1";
            lblRating.Click += CardIsClicked;
            // 
            // RestaurantCardControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lblRating);
            Controls.Add(lblRestaurantName);
            Controls.Add(picRestaurant);
            Name = "RestaurantCardControl";
            Size = new Size(298, 248);
            Click += CardIsClicked;
            ((System.ComponentModel.ISupportInitialize)picRestaurant).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picRestaurant;
        private Label lblRestaurantName;
        private Label lblRating;
    }
}
