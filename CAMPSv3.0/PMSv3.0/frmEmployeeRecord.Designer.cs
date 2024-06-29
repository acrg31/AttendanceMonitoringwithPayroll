namespace PMSv3._0
{
    partial class frmEmployeeRecords
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtEMployeeName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dgEmpName = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmpName)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(14)))), ((int)(((byte)(17)))));
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1310, 102);
            this.panel1.TabIndex = 328;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtEMployeeName);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(13, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 85);
            this.groupBox1.TabIndex = 296;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtEMployeeName
            // 
            this.txtEMployeeName.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtEMployeeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEMployeeName.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtEMployeeName.Location = new System.Drawing.Point(171, 35);
            this.txtEMployeeName.Name = "txtEMployeeName";
            this.txtEMployeeName.Size = new System.Drawing.Size(195, 26);
            this.txtEMployeeName.TabIndex = 276;
            this.txtEMployeeName.TextChanged += new System.EventHandler(this.txtEMployeeName_TextChanged_1);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(18, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 16);
            this.label10.TabIndex = 275;
            this.label10.Text = "Employee ID:";
            // 
            // dgEmpName
            // 
            this.dgEmpName.AllowUserToAddRows = false;
            this.dgEmpName.AllowUserToDeleteRows = false;
            this.dgEmpName.AllowUserToResizeColumns = false;
            this.dgEmpName.AllowUserToResizeRows = false;
            this.dgEmpName.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgEmpName.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgEmpName.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEmpName.Location = new System.Drawing.Point(12, 120);
            this.dgEmpName.Name = "dgEmpName";
            this.dgEmpName.ReadOnly = true;
            this.dgEmpName.RowHeadersVisible = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgEmpName.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgEmpName.Size = new System.Drawing.Size(1310, 439);
            this.dgEmpName.TabIndex = 327;
            // 
            // frmEmployeeRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1329, 589);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgEmpName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmEmployeeRecords";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Records";
            this.Load += new System.EventHandler(this.frmEmployeeRecords_Load_1);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEmpName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.TextBox txtEMployeeName;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.DataGridView dgEmpName;
    }
}