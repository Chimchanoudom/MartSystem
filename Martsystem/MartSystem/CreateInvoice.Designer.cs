namespace MartSystem
{
    partial class CreateInvoice
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.dgvInvoiceDetail = new System.Windows.Forms.DataGridView();
            this.panel9 = new System.Windows.Forms.Panel();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.cbProduct = new System.Windows.Forms.ComboBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtChangeKh = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtDollar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtGrandKh = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbRecieve = new System.Windows.Forms.Label();
            this.txtRecieveKh = new System.Windows.Forms.TextBox();
            this.lbGrand = new System.Windows.Forms.Label();
            this.lbChange = new System.Windows.Forms.Label();
            this.txtRecieveEng = new System.Windows.Forms.TextBox();
            this.txtGrandEng = new System.Windows.Forms.TextBox();
            this.txtChangeEng = new System.Windows.Forms.TextBox();
            this.watermarked_Textbox1 = new MartSystem.Custom_Contols.Watermarked_Textbox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceDetail)).BeginInit();
            this.panel9.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel10);
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(913, 502);
            this.panel1.TabIndex = 0;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.dgvInvoiceDetail);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 62);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(913, 440);
            this.panel10.TabIndex = 2;
            // 
            // dgvInvoiceDetail
            // 
            this.dgvInvoiceDetail.AllowUserToAddRows = false;
            this.dgvInvoiceDetail.AllowUserToDeleteRows = false;
            this.dgvInvoiceDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInvoiceDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoiceDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column4,
            this.Column2,
            this.Column5,
            this.Column7,
            this.SubTotal,
            this.Column6});
            this.dgvInvoiceDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInvoiceDetail.Location = new System.Drawing.Point(0, 0);
            this.dgvInvoiceDetail.Margin = new System.Windows.Forms.Padding(4);
            this.dgvInvoiceDetail.Name = "dgvInvoiceDetail";
            this.dgvInvoiceDetail.RowHeadersVisible = false;
            this.dgvInvoiceDetail.RowTemplate.Height = 50;
            this.dgvInvoiceDetail.Size = new System.Drawing.Size(913, 440);
            this.dgvInvoiceDetail.TabIndex = 0;
            this.dgvInvoiceDetail.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvInvoiceDetail_CellBeginEdit);
            this.dgvInvoiceDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvoiceDetail_CellContentClick);
            this.dgvInvoiceDetail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvoiceDetail_CellContentClick);
            this.dgvInvoiceDetail.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvInvoiceDetail_EditingControlShowing);
            this.dgvInvoiceDetail.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvInvoiceDetail_RowsAdded);
            this.dgvInvoiceDetail.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvInvoiceDetail_UserDeletingRow);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.textBox6);
            this.panel9.Controls.Add(this.label3);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(913, 62);
            this.panel9.TabIndex = 1;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(127, 12);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(178, 30);
            this.textBox6.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(8, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Invoice ID:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(522, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(391, 502);
            this.panel2.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel8.Controls.Add(this.watermarked_Textbox1);
            this.panel8.Controls.Add(this.cbProduct);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 300);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(391, 202);
            this.panel8.TabIndex = 3;
            // 
            // cbProduct
            // 
            this.cbProduct.FormattingEnabled = true;
            this.cbProduct.Location = new System.Drawing.Point(11, 52);
            this.cbProduct.Name = "cbProduct";
            this.cbProduct.Size = new System.Drawing.Size(363, 33);
            this.cbProduct.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel7.Controls.Add(this.button3);
            this.panel7.Controls.Add(this.button2);
            this.panel7.Controls.Add(this.button1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 180);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(391, 120);
            this.panel7.TabIndex = 8;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Firebrick;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(11, 62);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(363, 41);
            this.button3.TabIndex = 2;
            this.button3.Text = "Save";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.SeaGreen;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(195, 14);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(179, 41);
            this.button2.TabIndex = 1;
            this.button2.Text = "Print";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SeaGreen;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(11, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 41);
            this.button1.TabIndex = 1;
            this.button1.Text = "Clean";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(391, 180);
            this.panel3.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.txtChangeEng);
            this.panel6.Controls.Add(this.txtChangeKh);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.lbChange);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 120);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(387, 60);
            this.panel6.TabIndex = 9;
            // 
            // txtChangeKh
            // 
            this.txtChangeKh.Location = new System.Drawing.Point(195, 12);
            this.txtChangeKh.Name = "txtChangeKh";
            this.txtChangeKh.Size = new System.Drawing.Size(146, 30);
            this.txtChangeKh.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(6, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 25);
            this.label5.TabIndex = 1;
            this.label5.Text = "Change:";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.txtRecieveEng);
            this.panel4.Controls.Add(this.txtRecieveKh);
            this.panel4.Controls.Add(this.txtDollar);
            this.panel4.Controls.Add(this.lbRecieve);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 60);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(387, 60);
            this.panel4.TabIndex = 7;
            // 
            // txtDollar
            // 
            this.txtDollar.Location = new System.Drawing.Point(195, 12);
            this.txtDollar.Name = "txtDollar";
            this.txtDollar.Size = new System.Drawing.Size(146, 30);
            this.txtDollar.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Recieve:";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.txtGrandEng);
            this.panel5.Controls.Add(this.txtGrandKh);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.lbGrand);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.ForeColor = System.Drawing.Color.Blue;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(387, 60);
            this.panel5.TabIndex = 8;
            // 
            // txtGrandKh
            // 
            this.txtGrandKh.Location = new System.Drawing.Point(195, 15);
            this.txtGrandKh.Name = "txtGrandKh";
            this.txtGrandKh.Size = new System.Drawing.Size(146, 30);
            this.txtGrandKh.TabIndex = 2;
            this.txtGrandKh.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(6, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "Grand Total(USD):";
            // 
            // lbRecieve
            // 
            this.lbRecieve.AutoSize = true;
            this.lbRecieve.Font = new System.Drawing.Font("Kh Battambang", 12F);
            this.lbRecieve.ForeColor = System.Drawing.Color.Black;
            this.lbRecieve.Location = new System.Drawing.Point(347, 15);
            this.lbRecieve.Name = "lbRecieve";
            this.lbRecieve.Size = new System.Drawing.Size(26, 36);
            this.lbRecieve.TabIndex = 3;
            this.lbRecieve.Text = "$";
            this.lbRecieve.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbRecieve.Click += new System.EventHandler(this.lbRecieve_Click);
            // 
            // txtRecieveKh
            // 
            this.txtRecieveKh.Location = new System.Drawing.Point(195, 12);
            this.txtRecieveKh.Name = "txtRecieveKh";
            this.txtRecieveKh.Size = new System.Drawing.Size(146, 30);
            this.txtRecieveKh.TabIndex = 4;
            // 
            // lbGrand
            // 
            this.lbGrand.AutoSize = true;
            this.lbGrand.Font = new System.Drawing.Font("Kh Battambang", 12F);
            this.lbGrand.ForeColor = System.Drawing.Color.Black;
            this.lbGrand.Location = new System.Drawing.Point(347, 15);
            this.lbGrand.Name = "lbGrand";
            this.lbGrand.Size = new System.Drawing.Size(26, 36);
            this.lbGrand.TabIndex = 3;
            this.lbGrand.Text = "$";
            this.lbGrand.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbGrand.Click += new System.EventHandler(this.lbRecieve_Click);
            // 
            // lbChange
            // 
            this.lbChange.AutoSize = true;
            this.lbChange.Font = new System.Drawing.Font("Kh Battambang", 12F);
            this.lbChange.ForeColor = System.Drawing.Color.Black;
            this.lbChange.Location = new System.Drawing.Point(347, 12);
            this.lbChange.Name = "lbChange";
            this.lbChange.Size = new System.Drawing.Size(26, 36);
            this.lbChange.TabIndex = 3;
            this.lbChange.Text = "$";
            this.lbChange.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbChange.Click += new System.EventHandler(this.lbRecieve_Click);
            // 
            // txtRecieveEng
            // 
            this.txtRecieveEng.Location = new System.Drawing.Point(195, 12);
            this.txtRecieveEng.Name = "txtRecieveEng";
            this.txtRecieveEng.Size = new System.Drawing.Size(146, 30);
            this.txtRecieveEng.TabIndex = 5;
            // 
            // txtGrandEng
            // 
            this.txtGrandEng.Location = new System.Drawing.Point(195, 15);
            this.txtGrandEng.Name = "txtGrandEng";
            this.txtGrandEng.Size = new System.Drawing.Size(146, 30);
            this.txtGrandEng.TabIndex = 4;
            this.txtGrandEng.Text = "0";
            // 
            // txtChangeEng
            // 
            this.txtChangeEng.Location = new System.Drawing.Point(195, 12);
            this.txtChangeEng.Name = "txtChangeEng";
            this.txtChangeEng.Size = new System.Drawing.Size(146, 30);
            this.txtChangeEng.TabIndex = 4;
            // 
            // watermarked_Textbox1
            // 
            this.watermarked_Textbox1.ForeColor = System.Drawing.Color.Gray;
            this.watermarked_Textbox1.Location = new System.Drawing.Point(11, 11);
            this.watermarked_Textbox1.Name = "watermarked_Textbox1";
            this.watermarked_Textbox1.Size = new System.Drawing.Size(363, 30);
            this.watermarked_Textbox1.TabIndex = 2;
            this.watermarked_Textbox1.Text = "Enter Barcode";
            this.watermarked_Textbox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.watermarked_Textbox1.WatermarkedText = "Enter Barcode";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Description";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Quantity Type";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Quantity";
            this.Column2.Name = "Column2";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Unit Price";
            this.Column7.Name = "Column7";
            // 
            // SubTotal
            // 
            this.SubTotal.HeaderText = "SubTotal";
            this.SubTotal.Name = "SubTotal";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // CreateInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(913, 502);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CreateInvoice";
            this.Text = "CreateInvoice";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CreateInvoice_Load);
            this.panel1.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceDetail)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvInvoiceDetail;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtDollar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txtChangeKh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtGrandKh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbProduct;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label3;
        private Custom_Contols.Watermarked_Textbox watermarked_Textbox1;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label lbRecieve;
        private System.Windows.Forms.Label lbChange;
        private System.Windows.Forms.TextBox txtRecieveKh;
        private System.Windows.Forms.Label lbGrand;
        private System.Windows.Forms.TextBox txtRecieveEng;
        private System.Windows.Forms.TextBox txtGrandEng;
        private System.Windows.Forms.TextBox txtChangeEng;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewButtonColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewButtonColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        private System.Windows.Forms.DataGridViewButtonColumn Column6;
    }
}