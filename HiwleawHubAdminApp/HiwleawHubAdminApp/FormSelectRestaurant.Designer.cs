namespace HiwleawHubAdminApp
{
    partial class FormSelectRestaurant
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
            flpRestaurants = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // flpRestaurants
            // 
            flpRestaurants.AutoScroll = true;
            flpRestaurants.Location = new Point(9, 9);
            flpRestaurants.Name = "flpRestaurants";
            flpRestaurants.Size = new Size(779, 429);
            flpRestaurants.TabIndex = 0;
            // 
            // FormSelectRestaurant
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(flpRestaurants);
            Name = "FormSelectRestaurant";
            Text = "FormSelectRestaurant";
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpRestaurants;
    }
}