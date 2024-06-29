namespace PMSv3._1._0
{
    partial class frmRequestLeave
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lRemaining1 = new System.Windows.Forms.Label();
            this.lPosition = new System.Windows.Forms.Label();
            this.lDays = new System.Windows.Forms.Label();
            this.lName = new System.Windows.Forms.Label();
            this.lRemaining = new System.Windows.Forms.Label();
            this.lID = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lRemaining1);
            this.groupBox3.Controls.Add(this.lRemaining);
            this.groupBox3.Controls.Add(this.btnSubmit);
            this.groupBox3.Controls.Add(this.txtReason);
            this.groupBox3.Controls.Add(this.cbType);
            this.groupBox3.Controls.Add(this.dtTo);
            this.groupBox3.Controls.Add(this.dtFrom);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(169, 49);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(804, 543);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Request Leave";
            // 
            // lRemaining1
            // 
            this.lRemaining1.AutoSize = true;
            this.lRemaining1.Location = new System.Drawing.Point(288, 495);
            this.lRemaining1.Name = "lRemaining1";
            this.lRemaining1.Size = new System.Drawing.Size(32, 24);
            this.lRemaining1.TabIndex = 12;
            this.lRemaining1.Text = "00";
            // 
            // lPosition
            // 
            this.lPosition.AutoSize = true;
            this.lPosition.Location = new System.Drawing.Point(21, 147);
            this.lPosition.Name = "lPosition";
            this.lPosition.Size = new System.Drawing.Size(44, 13);
            this.lPosition.TabIndex = 11;
            this.lPosition.Text = "Position";
            // 
            // lDays
            // 
            this.lDays.AutoSize = true;
            this.lDays.Location = new System.Drawing.Point(22, 134);
            this.lDays.Name = "lDays";
            this.lDays.Size = new System.Drawing.Size(31, 13);
            this.lDays.TabIndex = 10;
            this.lDays.Text = "Days";
            this.lDays.Visible = false;
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Location = new System.Drawing.Point(22, 121);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(35, 13);
            this.lName.TabIndex = 7;
            this.lName.Text = "Name";
            this.lName.Visible = false;
            // 
            // lRemaining
            // 
            this.lRemaining.AutoSize = true;
            this.lRemaining.Location = new System.Drawing.Point(104, 495);
            this.lRemaining.Name = "lRemaining";
            this.lRemaining.Size = new System.Drawing.Size(178, 24);
            this.lRemaining.TabIndex = 9;
            this.lRemaining.Text = "Remaining Leave:";
            // 
            // lID
            // 
            this.lID.AutoSize = true;
            this.lID.Location = new System.Drawing.Point(23, 108);
            this.lID.Name = "lID";
            this.lID.Size = new System.Drawing.Size(18, 13);
            this.lID.TabIndex = 6;
            this.lID.Text = "ID";
            this.lID.Visible = false;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(599, 468);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(143, 39);
            this.btnSubmit.TabIndex = 8;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(104, 278);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(577, 102);
            this.txtReason.TabIndex = 7;
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "wew"});
            this.cbType.Location = new System.Drawing.Point(599, 123);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(121, 32);
            this.cbType.TabIndex = 6;
            // 
            // dtTo
            // 
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTo.Location = new System.Drawing.Point(281, 123);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(200, 29);
            this.dtTo.TabIndex = 5;
            this.dtTo.ValueChanged += new System.EventHandler(this.dtTo_ValueChanged);
            // 
            // dtFrom
            // 
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrom.Location = new System.Drawing.Point(44, 123);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(200, 29);
            this.dtFrom.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(100, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Reason";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(595, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(317, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "From";
            // 
            // frmRequestLeave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 688);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lPosition);
            this.Controls.Add(this.lID);
            this.Controls.Add(this.lDays);
            this.Controls.Add(this.lName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRequestLeave";
            this.Text = "frmRequestLeave";
            this.Load += new System.EventHandler(this.frmRequestLeave_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lName;
        private System.Windows.Forms.Label lRemaining;
        public System.Windows.Forms.Label lID;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label lDays;
        private System.Windows.Forms.Label lPosition;
        private System.Windows.Forms.Label lRemaining1;
    }
}