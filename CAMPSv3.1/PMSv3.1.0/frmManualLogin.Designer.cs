namespace PMSv3._1._0
{
    partial class frmManualLogin
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lEmployeeID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnTimeOut = new System.Windows.Forms.Button();
            this.btnTimeIn = new System.Windows.Forms.Button();
            this.dgvManual = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lFirstname = new System.Windows.Forms.Label();
            this.lLastname = new System.Windows.Forms.Label();
            this.Date = new System.Windows.Forms.Label();
            this.Time = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbsubID = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManual)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lEmployeeID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(26, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 109);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Employee Information";
            // 
            // lEmployeeID
            // 
            this.lEmployeeID.AutoSize = true;
            this.lEmployeeID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lEmployeeID.Location = new System.Drawing.Point(109, 70);
            this.lEmployeeID.Name = "lEmployeeID";
            this.lEmployeeID.Size = new System.Drawing.Size(200, 18);
            this.lEmployeeID.TabIndex = 1;
            this.lEmployeeID.Text = "--------------------------------";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Employee ID :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnTimeOut);
            this.groupBox2.Controls.Add(this.btnTimeIn);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(411, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(364, 109);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Actions";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btnTimeOut
            // 
            this.btnTimeOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimeOut.Location = new System.Drawing.Point(191, 38);
            this.btnTimeOut.Name = "btnTimeOut";
            this.btnTimeOut.Size = new System.Drawing.Size(157, 50);
            this.btnTimeOut.TabIndex = 1;
            this.btnTimeOut.Text = "Time Out";
            this.btnTimeOut.UseVisualStyleBackColor = true;
            this.btnTimeOut.Click += new System.EventHandler(this.btnTimeOut_Click);
            // 
            // btnTimeIn
            // 
            this.btnTimeIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimeIn.Location = new System.Drawing.Point(18, 38);
            this.btnTimeIn.Name = "btnTimeIn";
            this.btnTimeIn.Size = new System.Drawing.Size(157, 50);
            this.btnTimeIn.TabIndex = 0;
            this.btnTimeIn.Text = "Time In";
            this.btnTimeIn.UseVisualStyleBackColor = true;
            this.btnTimeIn.Click += new System.EventHandler(this.btnTimeIn_Click);
            // 
            // dgvManual
            // 
            this.dgvManual.AllowUserToAddRows = false;
            this.dgvManual.AllowUserToDeleteRows = false;
            this.dgvManual.AllowUserToResizeColumns = false;
            this.dgvManual.AllowUserToResizeRows = false;
            this.dgvManual.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvManual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManual.Location = new System.Drawing.Point(26, 155);
            this.dgvManual.Name = "dgvManual";
            this.dgvManual.ReadOnly = true;
            this.dgvManual.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvManual.Size = new System.Drawing.Size(916, 368);
            this.dgvManual.TabIndex = 6;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.dgvManual);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(130, 49);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(979, 543);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Login";
            // 
            // lFirstname
            // 
            this.lFirstname.AutoSize = true;
            this.lFirstname.Location = new System.Drawing.Point(32, 302);
            this.lFirstname.Name = "lFirstname";
            this.lFirstname.Size = new System.Drawing.Size(52, 13);
            this.lFirstname.TabIndex = 11;
            this.lFirstname.Text = "Firstname";
            this.lFirstname.Visible = false;
            // 
            // lLastname
            // 
            this.lLastname.AutoSize = true;
            this.lLastname.Location = new System.Drawing.Point(32, 276);
            this.lLastname.Name = "lLastname";
            this.lLastname.Size = new System.Drawing.Size(53, 13);
            this.lLastname.TabIndex = 10;
            this.lLastname.Text = "Lastname";
            this.lLastname.Visible = false;
            // 
            // Date
            // 
            this.Date.AutoSize = true;
            this.Date.Location = new System.Drawing.Point(32, 250);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(30, 13);
            this.Date.TabIndex = 9;
            this.Date.Text = "Date";
            this.Date.Visible = false;
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.Location = new System.Drawing.Point(32, 225);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(30, 13);
            this.Time.TabIndex = 8;
            this.Time.Text = "Time";
            this.Time.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbsubID
            // 
            this.lbsubID.AutoSize = true;
            this.lbsubID.Location = new System.Drawing.Point(32, 204);
            this.lbsubID.Name = "lbsubID";
            this.lbsubID.Size = new System.Drawing.Size(35, 13);
            this.lbsubID.TabIndex = 12;
            this.lbsubID.Text = "label1";
            this.lbsubID.Visible = false;
            // 
            // frmManualLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 688);
            this.Controls.Add(this.lbsubID);
            this.Controls.Add(this.lFirstname);
            this.Controls.Add(this.lLastname);
            this.Controls.Add(this.Date);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmManualLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManualLogin";
            this.Load += new System.EventHandler(this.frmManualLogin_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManual)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnTimeOut;
        private System.Windows.Forms.Button btnTimeIn;
        private System.Windows.Forms.DataGridView dgvManual;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label Date;
        private System.Windows.Forms.Label Time;
        public System.Windows.Forms.Label lEmployeeID;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lFirstname;
        private System.Windows.Forms.Label lLastname;
        private System.Windows.Forms.Label lbsubID;
    }
}