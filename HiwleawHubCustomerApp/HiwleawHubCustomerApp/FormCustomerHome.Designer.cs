namespace HiwleawHubCustomerApp
{
    partial class FormCustomerHome
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
            label1 = new Label();
            flpRestaurants = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(516, 52);
            label1.TabIndex = 0;
            label1.Text = "Welcome To HiwleawHub";
            // 
            // flpRestaurants
            // 
            flpRestaurants.AutoScroll = true;
            flpRestaurants.BackColor = SystemColors.Control;
            flpRestaurants.Location = new Point(11, 67);
            flpRestaurants.Name = "flpRestaurants";
            flpRestaurants.Size = new Size(778, 367);
            flpRestaurants.TabIndex = 1;
            // 
            // FormCustomerHome
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(800, 450);
            Controls.Add(flpRestaurants);
            Controls.Add(label1);
            Name = "FormCustomerHome";
            Text = "FormCustomerHome";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private FlowLayoutPanel flpRestaurants;
    }
}