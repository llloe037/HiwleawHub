namespace HiwleawHubCustomerApp
{
    partial class CustomerMenuCardControl
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
            picFood = new PictureBox();
            lblName = new Label();
            lblPrice = new Label();
            lblRatingScore = new Label();
            ((System.ComponentModel.ISupportInitialize)picFood).BeginInit();
            SuspendLayout();
            // 
            // picFood
            // 
            picFood.Location = new Point(14, 25);
            picFood.Name = "picFood";
            picFood.Size = new Size(150, 146);
            picFood.SizeMode = PictureBoxSizeMode.Zoom;
            picFood.TabIndex = 0;
            picFood.TabStop = false;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.Location = new Point(181, 25);
            lblName.Name = "lblName";
            lblName.Size = new Size(70, 28);
            lblName.TabIndex = 1;
            lblName.Text = "label1";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(257, 162);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(59, 25);
            lblPrice.TabIndex = 2;
            lblPrice.Text = "label1";
            // 
            // lblRatingScore
            // 
            lblRatingScore.AutoSize = true;
            lblRatingScore.ForeColor = Color.Gold;
            lblRatingScore.Location = new Point(185, 69);
            lblRatingScore.Name = "lblRatingScore";
            lblRatingScore.Size = new Size(59, 25);
            lblRatingScore.TabIndex = 3;
            lblRatingScore.Text = "label1";
            // 
            // CustomerMenuCardControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblRatingScore);
            Controls.Add(lblPrice);
            Controls.Add(lblName);
            Controls.Add(picFood);
            Name = "CustomerMenuCardControl";
            Size = new Size(350, 200);
            ((System.ComponentModel.ISupportInitialize)picFood).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picFood;
        private Label lblName;
        private Label lblPrice;
        private Label lblRatingScore;
    }
}
