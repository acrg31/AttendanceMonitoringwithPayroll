namespace PMSv3._0
{
    partial class frmHoliday
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
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.cmbDays = new System.Windows.Forms.ComboBox();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lvlID = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgHoliday = new System.Windows.Forms.DataGridView();
            this.groupBox9.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgHoliday)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox9
            // 
            this.groupBox9.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox9.Controls.Add(this.cmbDays);
            this.groupBox9.Controls.Add(this.cmbMonth);
            this.groupBox9.Controls.Add(this.panel3);
            this.groupBox9.Controls.Add(this.lvlID);
            this.groupBox9.Controls.Add(this.txtDescription);
            this.groupBox9.Controls.Add(this.btnEdit);
            this.groupBox9.Controls.Add(this.label1);
            this.groupBox9.Controls.Add(this.cmbType);
            this.groupBox9.Controls.Add(this.btnClear);
            this.groupBox9.Controls.Add(this.label14);
            this.groupBox9.Controls.Add(this.label2);
            this.groupBox9.Controls.Add(this.label9);
            this.groupBox9.Controls.Add(this.btnAdd);
            this.groupBox9.Controls.Add(this.btnSave);
            this.groupBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox9.ForeColor = System.Drawing.Color.Black;
            this.groupBox9.Location = new System.Drawing.Point(355, 10);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(311, 330);
            this.groupBox9.TabIndex = 306;
            this.groupBox9.TabStop = false;
            // 
            // cmbDays
            // 
            this.cmbDays.AllowDrop = true;
            this.cmbDays.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cmbDays.DropDownHeight = 140;
            this.cmbDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDays.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.cmbDays.FormatString = "D";
            this.cmbDays.FormattingEnabled = true;
            this.cmbDays.IntegralHeight = false;
            this.cmbDays.ItemHeight = 20;
            this.cmbDays.Location = new System.Drawing.Point(170, 73);
            this.cmbDays.MaxDropDownItems = 10;
            this.cmbDays.Name = "cmbDays";
            this.cmbDays.Size = new System.Drawing.Size(60, 28);
            this.cmbDays.TabIndex = 314;
            // 
            // cmbMonth
            // 
            this.cmbMonth.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cmbMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMonth.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.cmbMonth.FormatString = "M";
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.ItemHeight = 20;
            this.cmbMonth.Location = new System.Drawing.Point(35, 73);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(129, 28);
            this.cmbMonth.TabIndex = 313;
            this.cmbMonth.TextChanged += new System.EventHandler(this.cmbMonth_TextChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(14)))), ((int)(((byte)(17)))));
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(345, 36);
            this.panel3.TabIndex = 312;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(128, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 183;
            this.label3.Text = "Holiday";
            // 
            // lvlID
            // 
            this.lvlID.AutoSize = true;
            this.lvlID.BackColor = System.Drawing.Color.Transparent;
            this.lvlID.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvlID.ForeColor = System.Drawing.Color.Black;
            this.lvlID.Location = new System.Drawing.Point(32, 18);
            this.lvlID.Name = "lvlID";
            this.lvlID.Size = new System.Drawing.Size(0, 16);
            this.lvlID.TabIndex = 303;
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtDescription.Location = new System.Drawing.Point(35, 138);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(195, 26);
            this.txtDescription.TabIndex = 311;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.AliceBlue;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEdit.Location = new System.Drawing.Point(114, 262);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(73, 42);
            this.btnEdit.TabIndex = 310;
            this.btnEdit.Text = "Update";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(32, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 308;
            this.label1.Text = "Type:";
            // 
            // cmbType
            // 
            this.cmbType.AllowDrop = true;
            this.cmbType.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbType.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(35, 204);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(195, 28);
            this.cmbType.TabIndex = 306;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.AliceBlue;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClear.Location = new System.Drawing.Point(193, 262);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(73, 42);
            this.btnClear.TabIndex = 304;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click_1);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(32, 119);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 16);
            this.label14.TabIndex = 295;
            this.label14.Text = "Discription:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(32, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 294;
            this.label2.Text = "Date:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(31, 489);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(271, 18);
            this.label9.TabIndex = 261;
            this.label9.Text = "Note: Please Double-Click on the room.";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.AliceBlue;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAdd.Location = new System.Drawing.Point(35, 262);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(73, 42);
            this.btnAdd.TabIndex = 309;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click_1);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.AliceBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSave.Location = new System.Drawing.Point(35, 262);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(73, 42);
            this.btnSave.TabIndex = 303;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click_1);
            // 
            // dgHoliday
            // 
            this.dgHoliday.AllowUserToAddRows = false;
            this.dgHoliday.AllowUserToDeleteRows = false;
            this.dgHoliday.AllowUserToResizeColumns = false;
            this.dgHoliday.AllowUserToResizeRows = false;
            this.dgHoliday.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgHoliday.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHoliday.Location = new System.Drawing.Point(8, 10);
            this.dgHoliday.Name = "dgHoliday";
            this.dgHoliday.ReadOnly = true;
            this.dgHoliday.RowHeadersVisible = false;
            this.dgHoliday.Size = new System.Drawing.Size(339, 330);
            this.dgHoliday.TabIndex = 305;
            this.dgHoliday.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgHoliday_CellDoubleClick_1);
            // 
            // frmHoliday
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(676, 350);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.dgHoliday);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmHoliday";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Holiday";
            this.Load += new System.EventHandler(this.FrmHoliday_Load);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgHoliday)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label lvlID;
        internal System.Windows.Forms.TextBox txtDescription;
        internal System.Windows.Forms.Button btnEdit;
        internal System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox cmbType;
        internal System.Windows.Forms.Button btnClear;
        internal System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgHoliday;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.ComboBox cmbDays;
    }
}