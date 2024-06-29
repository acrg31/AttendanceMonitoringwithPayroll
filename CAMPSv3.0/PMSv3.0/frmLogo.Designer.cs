namespace PMSv3._0
{
    partial class frmLogo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogo));
            this.LogoCenter = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.LogoCenter)).BeginInit();
            this.SuspendLayout();
            // 
            // LogoCenter
            // 
            this.LogoCenter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogoCenter.Image = ((System.Drawing.Image)(resources.GetObject("LogoCenter.Image")));
            this.LogoCenter.Location = new System.Drawing.Point(83, 102);
            this.LogoCenter.Name = "LogoCenter";
            this.LogoCenter.Size = new System.Drawing.Size(704, 347);
            this.LogoCenter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoCenter.TabIndex = 2;
            this.LogoCenter.TabStop = false;
            // 
            // frmLogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 550);
            this.Controls.Add(this.LogoCenter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogo";
            this.Text = "frmLogo";
            ((System.ComponentModel.ISupportInitialize)(this.LogoCenter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox LogoCenter;
    }
}