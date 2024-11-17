namespace Billing_App
{
    partial class frm_materialMaster
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
			this.label1 = new System.Windows.Forms.Label();
			this.btn_add = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.txt_material = new System.Windows.Forms.TextBox();
			this.txt_qty = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(-135, 251);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(75, 25);
			this.label1.TabIndex = 9;
			this.label1.Text = "Mateial";
			// 
			// btn_add
			// 
			this.btn_add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.btn_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_add.Location = new System.Drawing.Point(185, 259);
			this.btn_add.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btn_add.Name = "btn_add";
			this.btn_add.Size = new System.Drawing.Size(201, 57);
			this.btn_add.TabIndex = 8;
			this.btn_add.Text = "ADD";
			this.btn_add.UseVisualStyleBackColor = false;
			this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(40, 119);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(75, 25);
			this.label4.TabIndex = 12;
			this.label4.Text = "Mateial";
			// 
			// txt_material
			// 
			this.txt_material.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_material.Location = new System.Drawing.Point(144, 119);
			this.txt_material.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txt_material.Name = "txt_material";
			this.txt_material.Size = new System.Drawing.Size(380, 30);
			this.txt_material.TabIndex = 13;
			// 
			// txt_qty
			// 
			this.txt_qty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_qty.Location = new System.Drawing.Point(144, 188);
			this.txt_qty.Margin = new System.Windows.Forms.Padding(4);
			this.txt_qty.Name = "txt_qty";
			this.txt_qty.Size = new System.Drawing.Size(380, 30);
			this.txt_qty.TabIndex = 15;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(40, 188);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 25);
			this.label2.TabIndex = 14;
			this.label2.Text = "QTY";
			// 
			// frm_materialMaster
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(587, 363);
			this.Controls.Add(this.txt_qty);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txt_material);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btn_add);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "frm_materialMaster";
			this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
			this.Text = "Add Material";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_material;
		private System.Windows.Forms.TextBox txt_qty;
		private System.Windows.Forms.Label label2;
	}
}