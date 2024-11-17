namespace Billing_App
{
    partial class frm_client
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			this.txt_contact = new System.Windows.Forms.TextBox();
			this.txt_address = new System.Windows.Forms.TextBox();
			this.btn_submit = new System.Windows.Forms.Button();
			this.grd_clienttable = new System.Windows.Forms.DataGridView();
			this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btn_delete = new System.Windows.Forms.Button();
			this.btn_createinvoice = new System.Windows.Forms.Button();
			this.txt_search = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.lbl_id = new System.Windows.Forms.Label();
			this.lbl_Name = new System.Windows.Forms.Label();
			this.lbl_email = new System.Windows.Forms.Label();
			this.lbl_Contact = new System.Windows.Forms.Label();
			this.lbl_address = new System.Windows.Forms.Label();
			this.txt_name = new System.Windows.Forms.TextBox();
			this.txt_email = new System.Windows.Forms.TextBox();
			this.btn_exportExcel = new System.Windows.Forms.Button();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.btn_clientReport = new System.Windows.Forms.Button();
			this.btn_searchInvoice = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.grd_clienttable)).BeginInit();
			this.SuspendLayout();
			// 
			// txt_contact
			// 
			this.txt_contact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txt_contact.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_contact.Location = new System.Drawing.Point(167, 220);
			this.txt_contact.Margin = new System.Windows.Forms.Padding(4);
			this.txt_contact.Name = "txt_contact";
			this.txt_contact.Size = new System.Drawing.Size(443, 38);
			this.txt_contact.TabIndex = 2;
			// 
			// txt_address
			// 
			this.txt_address.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_address.Location = new System.Drawing.Point(698, 135);
			this.txt_address.Margin = new System.Windows.Forms.Padding(4);
			this.txt_address.Multiline = true;
			this.txt_address.Name = "txt_address";
			this.txt_address.Size = new System.Drawing.Size(487, 125);
			this.txt_address.TabIndex = 3;
			// 
			// btn_submit
			// 
			this.btn_submit.BackColor = System.Drawing.Color.DarkTurquoise;
			this.btn_submit.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_submit.ForeColor = System.Drawing.Color.Black;
			this.btn_submit.Location = new System.Drawing.Point(973, 314);
			this.btn_submit.Margin = new System.Windows.Forms.Padding(4);
			this.btn_submit.Name = "btn_submit";
			this.btn_submit.Size = new System.Drawing.Size(208, 60);
			this.btn_submit.TabIndex = 4;
			this.btn_submit.Text = "Submit";
			this.btn_submit.UseVisualStyleBackColor = false;
			this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
			// 
			// grd_clienttable
			// 
			this.grd_clienttable.AllowUserToAddRows = false;
			this.grd_clienttable.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.Teal;
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
			this.grd_clienttable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.grd_clienttable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.grd_clienttable.BackgroundColor = System.Drawing.Color.Silver;
			this.grd_clienttable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.grd_clienttable.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaption;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grd_clienttable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.grd_clienttable.ColumnHeadersHeight = 30;
			this.grd_clienttable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Name,
            this.Column2,
            this.Column3,
            this.Column4});
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle8.NullValue = null;
			dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Teal;
			dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.grd_clienttable.DefaultCellStyle = dataGridViewCellStyle8;
			this.grd_clienttable.GridColor = System.Drawing.Color.Teal;
			this.grd_clienttable.Location = new System.Drawing.Point(49, 428);
			this.grd_clienttable.Margin = new System.Windows.Forms.Padding(4);
			this.grd_clienttable.Name = "grd_clienttable";
			this.grd_clienttable.ReadOnly = true;
			this.grd_clienttable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
			this.grd_clienttable.RowHeadersWidth = 55;
			this.grd_clienttable.Size = new System.Drawing.Size(1123, 329);
			this.grd_clienttable.TabIndex = 11;
			this.grd_clienttable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grd_clienttable_CellClick);
			this.grd_clienttable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grd_clienttable_CellContentClick);
			// 
			// Column5
			// 
			this.Column5.DataPropertyName = "Client_ID";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle3.NullValue = null;
			this.Column5.DefaultCellStyle = dataGridViewCellStyle3;
			this.Column5.HeaderText = "ID";
			this.Column5.MinimumWidth = 6;
			this.Column5.Name = "Column5";
			this.Column5.ReadOnly = true;
			this.Column5.Visible = false;
			// 
			// Name
			// 
			this.Name.DataPropertyName = "Client_Name";
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle4.NullValue = null;
			this.Name.DefaultCellStyle = dataGridViewCellStyle4;
			this.Name.HeaderText = "Name";
			this.Name.MinimumWidth = 6;
			this.Name.Name = "Name";
			this.Name.ReadOnly = true;
			// 
			// Column2
			// 
			this.Column2.DataPropertyName = "Contact";
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.Column2.DefaultCellStyle = dataGridViewCellStyle5;
			this.Column2.HeaderText = "Contact";
			this.Column2.MinimumWidth = 6;
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			// 
			// Column3
			// 
			this.Column3.DataPropertyName = "Email";
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.Column3.DefaultCellStyle = dataGridViewCellStyle6;
			this.Column3.HeaderText = "Email";
			this.Column3.MinimumWidth = 6;
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			// 
			// Column4
			// 
			this.Column4.DataPropertyName = "Address";
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.Column4.DefaultCellStyle = dataGridViewCellStyle7;
			this.Column4.HeaderText = "Address";
			this.Column4.MinimumWidth = 6;
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			// 
			// btn_delete
			// 
			this.btn_delete.BackColor = System.Drawing.Color.Tomato;
			this.btn_delete.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_delete.ForeColor = System.Drawing.Color.Black;
			this.btn_delete.Location = new System.Drawing.Point(1045, 764);
			this.btn_delete.Margin = new System.Windows.Forms.Padding(4);
			this.btn_delete.Name = "btn_delete";
			this.btn_delete.Size = new System.Drawing.Size(127, 43);
			this.btn_delete.TabIndex = 14;
			this.btn_delete.Text = "Delete";
			this.btn_delete.UseVisualStyleBackColor = false;
			this.btn_delete.Visible = false;
			this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
			// 
			// btn_createinvoice
			// 
			this.btn_createinvoice.BackColor = System.Drawing.Color.DarkTurquoise;
			this.btn_createinvoice.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_createinvoice.ForeColor = System.Drawing.Color.Black;
			this.btn_createinvoice.Location = new System.Drawing.Point(987, 826);
			this.btn_createinvoice.Margin = new System.Windows.Forms.Padding(4);
			this.btn_createinvoice.Name = "btn_createinvoice";
			this.btn_createinvoice.Size = new System.Drawing.Size(185, 50);
			this.btn_createinvoice.TabIndex = 15;
			this.btn_createinvoice.Text = "Create Invoice";
			this.btn_createinvoice.UseVisualStyleBackColor = false;
			this.btn_createinvoice.Click += new System.EventHandler(this.btn_createinvoice_Click);
			// 
			// txt_search
			// 
			this.txt_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_search.Location = new System.Drawing.Point(128, 388);
			this.txt_search.Margin = new System.Windows.Forms.Padding(4);
			this.txt_search.Multiline = true;
			this.txt_search.Name = "txt_search";
			this.txt_search.Size = new System.Drawing.Size(360, 32);
			this.txt_search.TabIndex = 16;
			this.txt_search.TextChanged += new System.EventHandler(this.txt_search_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(47, 388);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 24);
			this.label2.TabIndex = 17;
			this.label2.Text = "Search";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// lbl_id
			// 
			this.lbl_id.AutoSize = true;
			this.lbl_id.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_id.Location = new System.Drawing.Point(1108, 30);
			this.lbl_id.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbl_id.Name = "lbl_id";
			this.lbl_id.Size = new System.Drawing.Size(41, 34);
			this.lbl_id.TabIndex = 5;
			this.lbl_id.Text = "Id";
			this.lbl_id.Visible = false;
			// 
			// lbl_Name
			// 
			this.lbl_Name.AutoSize = true;
			this.lbl_Name.BackColor = System.Drawing.Color.White;
			this.lbl_Name.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_Name.ForeColor = System.Drawing.Color.Black;
			this.lbl_Name.Location = new System.Drawing.Point(41, 94);
			this.lbl_Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbl_Name.Name = "lbl_Name";
			this.lbl_Name.Size = new System.Drawing.Size(88, 37);
			this.lbl_Name.TabIndex = 1;
			this.lbl_Name.Text = "Name";
			// 
			// lbl_email
			// 
			this.lbl_email.AutoSize = true;
			this.lbl_email.BackColor = System.Drawing.Color.White;
			this.lbl_email.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_email.ForeColor = System.Drawing.Color.Black;
			this.lbl_email.Location = new System.Drawing.Point(45, 159);
			this.lbl_email.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbl_email.Name = "lbl_email";
			this.lbl_email.Size = new System.Drawing.Size(82, 37);
			this.lbl_email.TabIndex = 2;
			this.lbl_email.Text = "Email";
			// 
			// lbl_Contact
			// 
			this.lbl_Contact.AutoSize = true;
			this.lbl_Contact.BackColor = System.Drawing.Color.White;
			this.lbl_Contact.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_Contact.ForeColor = System.Drawing.Color.Black;
			this.lbl_Contact.Location = new System.Drawing.Point(16, 223);
			this.lbl_Contact.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbl_Contact.Name = "lbl_Contact";
			this.lbl_Contact.Size = new System.Drawing.Size(109, 37);
			this.lbl_Contact.TabIndex = 3;
			this.lbl_Contact.Text = "Contact";
			// 
			// lbl_address
			// 
			this.lbl_address.AutoSize = true;
			this.lbl_address.BackColor = System.Drawing.Color.White;
			this.lbl_address.Font = new System.Drawing.Font("Yu Gothic UI", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_address.ForeColor = System.Drawing.Color.Black;
			this.lbl_address.Location = new System.Drawing.Point(687, 94);
			this.lbl_address.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbl_address.Name = "lbl_address";
			this.lbl_address.Size = new System.Drawing.Size(111, 37);
			this.lbl_address.TabIndex = 4;
			this.lbl_address.Text = "Address";
			// 
			// txt_name
			// 
			this.txt_name.AccessibleDescription = "";
			this.txt_name.AccessibleName = "";
			this.txt_name.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_name.Location = new System.Drawing.Point(167, 98);
			this.txt_name.Margin = new System.Windows.Forms.Padding(4);
			this.txt_name.Name = "txt_name";
			this.txt_name.Size = new System.Drawing.Size(443, 38);
			this.txt_name.TabIndex = 0;
			this.txt_name.Tag = "";
			// 
			// txt_email
			// 
			this.txt_email.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_email.Location = new System.Drawing.Point(167, 159);
			this.txt_email.Margin = new System.Windows.Forms.Padding(4);
			this.txt_email.Name = "txt_email";
			this.txt_email.Size = new System.Drawing.Size(443, 38);
			this.txt_email.TabIndex = 1;
			// 
			// btn_exportExcel
			// 
			this.btn_exportExcel.BackColor = System.Drawing.Color.DarkTurquoise;
			this.btn_exportExcel.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_exportExcel.ForeColor = System.Drawing.Color.Black;
			this.btn_exportExcel.Location = new System.Drawing.Point(64, 826);
			this.btn_exportExcel.Margin = new System.Windows.Forms.Padding(4);
			this.btn_exportExcel.Name = "btn_exportExcel";
			this.btn_exportExcel.Size = new System.Drawing.Size(197, 50);
			this.btn_exportExcel.TabIndex = 19;
			this.btn_exportExcel.Text = "Export To Excel";
			this.btn_exportExcel.UseVisualStyleBackColor = false;
			this.btn_exportExcel.Click += new System.EventHandler(this.btn_exportExcel_Click);
			// 
			// btn_clientReport
			// 
			this.btn_clientReport.BackColor = System.Drawing.Color.DarkTurquoise;
			this.btn_clientReport.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_clientReport.ForeColor = System.Drawing.Color.Black;
			this.btn_clientReport.Location = new System.Drawing.Point(345, 826);
			this.btn_clientReport.Margin = new System.Windows.Forms.Padding(4);
			this.btn_clientReport.Name = "btn_clientReport";
			this.btn_clientReport.Size = new System.Drawing.Size(179, 50);
			this.btn_clientReport.TabIndex = 20;
			this.btn_clientReport.Text = "Client Report";
			this.btn_clientReport.UseVisualStyleBackColor = false;
			this.btn_clientReport.Click += new System.EventHandler(this.btn_clientReport_Click);
			// 
			// btn_searchInvoice
			// 
			this.btn_searchInvoice.BackColor = System.Drawing.Color.DarkTurquoise;
			this.btn_searchInvoice.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_searchInvoice.ForeColor = System.Drawing.Color.Black;
			this.btn_searchInvoice.Location = new System.Drawing.Point(625, 826);
			this.btn_searchInvoice.Margin = new System.Windows.Forms.Padding(4);
			this.btn_searchInvoice.Name = "btn_searchInvoice";
			this.btn_searchInvoice.Size = new System.Drawing.Size(192, 50);
			this.btn_searchInvoice.TabIndex = 21;
			this.btn_searchInvoice.Text = "Search Invoice ";
			this.btn_searchInvoice.UseVisualStyleBackColor = false;
			this.btn_searchInvoice.Visible = false;
			this.btn_searchInvoice.Click += new System.EventHandler(this.btn_searchInvoice_Click);
			// 
			// frm_client
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1216, 933);
			this.Controls.Add(this.btn_searchInvoice);
			this.Controls.Add(this.btn_clientReport);
			this.Controls.Add(this.lbl_id);
			this.Controls.Add(this.txt_email);
			this.Controls.Add(this.btn_exportExcel);
			this.Controls.Add(this.txt_name);
			this.Controls.Add(this.lbl_address);
			this.Controls.Add(this.lbl_Contact);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lbl_email);
			this.Controls.Add(this.txt_search);
			this.Controls.Add(this.lbl_Name);
			this.Controls.Add(this.btn_createinvoice);
			this.Controls.Add(this.btn_delete);
			this.Controls.Add(this.txt_address);
			this.Controls.Add(this.grd_clienttable);
			this.Controls.Add(this.txt_contact);
			this.Controls.Add(this.btn_submit);
			this.Margin = new System.Windows.Forms.Padding(4);
			//this.Name = "frm_client";
			this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
			this.Text = "Client Data";
			this.Theme = MetroFramework.MetroThemeStyle.Default;
			this.Load += new System.EventHandler(this.frm_client_Load);
			((System.ComponentModel.ISupportInitialize)(this.grd_clienttable)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_contact;
        private System.Windows.Forms.TextBox txt_address;
        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.DataGridView grd_clienttable;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_createinvoice;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_id;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Label lbl_email;
        private System.Windows.Forms.Label lbl_Contact;
        private System.Windows.Forms.Label lbl_address;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.Button btn_exportExcel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btn_clientReport;
        private System.Windows.Forms.Button btn_searchInvoice;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
		private System.Windows.Forms.DataGridViewTextBoxColumn Name;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
	}
}