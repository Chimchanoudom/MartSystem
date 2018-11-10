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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtBarcode = new MartSystem.Custom_Contols.Watermarked_Textbox();
            this.cbProduct = new System.Windows.Forms.ComboBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClean = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtChangeEng = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtChangeKh = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.lbRecieve = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRecieveEng = new System.Windows.Forms.TextBox();
            this.txtRecieveKh = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lbGrand = new System.Windows.Forms.Label();
            this.txtGrandEng = new System.Windows.Forms.TextBox();
            this.txtGrandKh = new System.Windows.Forms.TextBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.dgvInvoiceDetail = new System.Windows.Forms.DataGridView();
            this.ProName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ProID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel9 = new System.Windows.Forms.Panel();
            this.dtDateTime = new System.Windows.Forms.DateTimePicker();
            this.panel11 = new System.Windows.Forms.Panel();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInvoiceID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceDetail)).BeginInit();
            this.panel9.SuspendLayout();
            this.panel11.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel10);
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(913, 502);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(522, 62);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(391, 440);
            this.panel2.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel8.Controls.Add(this.txtBarcode);
            this.panel8.Controls.Add(this.cbProduct);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 339);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(391, 101);
            this.panel8.TabIndex = 3;
            // 
            // txtBarcode
            // 
            this.txtBarcode.ForeColor = System.Drawing.Color.Gray;
            this.txtBarcode.Location = new System.Drawing.Point(11, 11);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(363, 30);
            this.txtBarcode.TabIndex = 1;
            this.txtBarcode.Text = "Enter Barcode";
            this.txtBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBarcode.WatermarkedText = "Enter Barcode";
            this.txtBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.watermarked_Textbox1_KeyPress);
            // 
            // cbProduct
            // 
            this.cbProduct.FormattingEnabled = true;
            this.cbProduct.Location = new System.Drawing.Point(11, 52);
            this.cbProduct.Name = "cbProduct";
            this.cbProduct.Size = new System.Drawing.Size(363, 33);
            this.cbProduct.TabIndex = 0;
            this.cbProduct.SelectedIndexChanged += new System.EventHandler(this.cbProduct_SelectedIndexChanged);
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel7.Controls.Add(this.btnSave);
            this.panel7.Controls.Add(this.btnPrint);
            this.panel7.Controls.Add(this.btnClean);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 219);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(391, 120);
            this.panel7.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Firebrick;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(11, 62);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(363, 41);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.SeaGreen;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(195, 14);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(179, 41);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // btnClean
            // 
            this.btnClean.BackColor = System.Drawing.Color.SeaGreen;
            this.btnClean.FlatAppearance.BorderSize = 0;
            this.btnClean.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClean.ForeColor = System.Drawing.Color.White;
            this.btnClean.Location = new System.Drawing.Point(11, 14);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(179, 41);
            this.btnClean.TabIndex = 1;
            this.btnClean.Text = "Clean";
            this.btnClean.UseVisualStyleBackColor = false;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.panel12);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(391, 219);
            this.panel3.TabIndex = 1;
            // 
            // panel12
            // 
            this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel12.Controls.Add(this.label6);
            this.panel12.Controls.Add(this.label7);
            this.panel12.Controls.Add(this.txtChangeEng);
            this.panel12.Controls.Add(this.txtChangeKh);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(0, 160);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(387, 66);
            this.panel12.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(6, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 25);
            this.label6.TabIndex = 1;
            this.label6.Text = "Change:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Kh Battambang", 12F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(347, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 36);
            this.label7.TabIndex = 3;
            this.label7.Text = "$";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label7.Click += new System.EventHandler(this.lbRecieve_Click);
            // 
            // txtChangeEng
            // 
            this.txtChangeEng.ContextMenuStrip = this.contextMenuStrip1;
            this.txtChangeEng.Location = new System.Drawing.Point(194, 13);
            this.txtChangeEng.Name = "txtChangeEng";
            this.txtChangeEng.Size = new System.Drawing.Size(146, 30);
            this.txtChangeEng.TabIndex = 106;
            this.txtChangeEng.Text = "0.00";
            this.txtChangeEng.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txtChangeKh
            // 
            this.txtChangeKh.Location = new System.Drawing.Point(195, 12);
            this.txtChangeKh.Name = "txtChangeKh";
            this.txtChangeKh.Size = new System.Drawing.Size(146, 30);
            this.txtChangeKh.TabIndex = 2;
            this.txtChangeKh.Text = "0";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.lbRecieve);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.txtRecieveEng);
            this.panel4.Controls.Add(this.txtRecieveKh);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 60);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(387, 100);
            this.panel4.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Kh Battambang", 12F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(346, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 36);
            this.label5.TabIndex = 3;
            this.label5.Text = "$";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbRecieve
            // 
            this.lbRecieve.AutoSize = true;
            this.lbRecieve.Font = new System.Drawing.Font("Kh Battambang", 12F);
            this.lbRecieve.ForeColor = System.Drawing.Color.Black;
            this.lbRecieve.Location = new System.Drawing.Point(347, 15);
            this.lbRecieve.Name = "lbRecieve";
            this.lbRecieve.Size = new System.Drawing.Size(22, 36);
            this.lbRecieve.TabIndex = 3;
            this.lbRecieve.Text = "៛";
            this.lbRecieve.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            // txtRecieveEng
            // 
            this.txtRecieveEng.ContextMenuStrip = this.contextMenuStrip1;
            this.txtRecieveEng.Location = new System.Drawing.Point(194, 57);
            this.txtRecieveEng.Name = "txtRecieveEng";
            this.txtRecieveEng.Size = new System.Drawing.Size(146, 30);
            this.txtRecieveEng.TabIndex = 105;
            this.txtRecieveEng.Text = "0.00";
            this.txtRecieveEng.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRecieveEng_KeyPress);
            // 
            // txtRecieveKh
            // 
            this.txtRecieveKh.Location = new System.Drawing.Point(195, 12);
            this.txtRecieveKh.Name = "txtRecieveKh";
            this.txtRecieveKh.Size = new System.Drawing.Size(146, 30);
            this.txtRecieveKh.TabIndex = 104;
            this.txtRecieveKh.Text = "0";
            this.txtRecieveKh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRecieveKh_KeyPress);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.lbGrand);
            this.panel5.Controls.Add(this.txtGrandEng);
            this.panel5.Controls.Add(this.txtGrandKh);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.ForeColor = System.Drawing.Color.Blue;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(387, 60);
            this.panel5.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(6, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "Grand Total:";
            // 
            // lbGrand
            // 
            this.lbGrand.AutoSize = true;
            this.lbGrand.Font = new System.Drawing.Font("Kh Battambang", 12F);
            this.lbGrand.ForeColor = System.Drawing.Color.Black;
            this.lbGrand.Location = new System.Drawing.Point(346, 14);
            this.lbGrand.Name = "lbGrand";
            this.lbGrand.Size = new System.Drawing.Size(26, 36);
            this.lbGrand.TabIndex = 3;
            this.lbGrand.Text = "$";
            this.lbGrand.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbGrand.Click += new System.EventHandler(this.lbRecieve_Click);
            // 
            // txtGrandEng
            // 
            this.txtGrandEng.ContextMenuStrip = this.contextMenuStrip1;
            this.txtGrandEng.Location = new System.Drawing.Point(195, 15);
            this.txtGrandEng.Name = "txtGrandEng";
            this.txtGrandEng.Size = new System.Drawing.Size(146, 30);
            this.txtGrandEng.TabIndex = 103;
            this.txtGrandEng.Text = "0.00";
            this.txtGrandEng.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // txtGrandKh
            // 
            this.txtGrandKh.Location = new System.Drawing.Point(195, 15);
            this.txtGrandKh.Name = "txtGrandKh";
            this.txtGrandKh.Size = new System.Drawing.Size(146, 30);
            this.txtGrandKh.TabIndex = 2;
            this.txtGrandKh.Text = "0";
            this.txtGrandKh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
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
            this.dgvInvoiceDetail.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvInvoiceDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoiceDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProName,
            this.Column3,
            this.Column4,
            this.Qty,
            this.Column5,
            this.Column7,
            this.ColSubtotal,
            this.Column6,
            this.ProID});
            this.dgvInvoiceDetail.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvInvoiceDetail.Location = new System.Drawing.Point(0, 0);
            this.dgvInvoiceDetail.Margin = new System.Windows.Forms.Padding(4);
            this.dgvInvoiceDetail.Name = "dgvInvoiceDetail";
            this.dgvInvoiceDetail.RowHeadersVisible = false;
            this.dgvInvoiceDetail.RowTemplate.Height = 50;
            this.dgvInvoiceDetail.Size = new System.Drawing.Size(517, 440);
            this.dgvInvoiceDetail.TabIndex = 101;
            this.dgvInvoiceDetail.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvInvoiceDetail_CellBeginEdit);
            this.dgvInvoiceDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvoiceDetail_CellContentClick);
            this.dgvInvoiceDetail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvoiceDetail_CellEndEdit);
            this.dgvInvoiceDetail.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvInvoiceDetail_EditingControlShowing);
            this.dgvInvoiceDetail.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvInvoiceDetail_RowsAdded);
            // 
            // ProName
            // 
            this.ProName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProName.FillWeight = 1F;
            this.ProName.HeaderText = "Description";
            this.ProName.MinimumWidth = 300;
            this.ProName.Name = "ProName";
            this.ProName.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column3.FillWeight = 1F;
            this.Column3.HeaderText = "Quantity Type";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column4.FillWeight = 1F;
            this.Column4.HeaderText = "";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column4.Width = 50;
            // 
            // Qty
            // 
            this.Qty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Qty.DefaultCellStyle = dataGridViewCellStyle1;
            this.Qty.FillWeight = 1F;
            this.Qty.HeaderText = "Quantity";
            this.Qty.MinimumWidth = 90;
            this.Qty.Name = "Qty";
            this.Qty.Width = 90;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column5.FillWeight = 1F;
            this.Column5.HeaderText = "";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column5.Width = 50;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column7.FillWeight = 1F;
            this.Column7.HeaderText = "Unit Price";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 120;
            // 
            // ColSubtotal
            // 
            this.ColSubtotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColSubtotal.HeaderText = "SubTotal";
            this.ColSubtotal.MinimumWidth = 120;
            this.ColSubtotal.Name = "ColSubtotal";
            this.ColSubtotal.ReadOnly = true;
            this.ColSubtotal.Width = 120;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column6.FillWeight = 1F;
            this.Column6.HeaderText = "";
            this.Column6.MinimumWidth = 50;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column6.Width = 50;
            // 
            // ProID
            // 
            this.ProID.HeaderText = "Column1";
            this.ProID.Name = "ProID";
            this.ProID.Visible = false;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.dtDateTime);
            this.panel9.Controls.Add(this.panel11);
            this.panel9.Controls.Add(this.txtInvoiceID);
            this.panel9.Controls.Add(this.label3);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(913, 62);
            this.panel9.TabIndex = 1;
            // 
            // dtDateTime
            // 
            this.dtDateTime.CustomFormat = "dd/MM/yyyy hh:mm:ss tt";
            this.dtDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateTime.Location = new System.Drawing.Point(323, 13);
            this.dtDateTime.Name = "dtDateTime";
            this.dtDateTime.Size = new System.Drawing.Size(287, 30);
            this.dtDateTime.TabIndex = 100;
            this.dtDateTime.Visible = false;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.txtRate);
            this.panel11.Controls.Add(this.label2);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel11.Location = new System.Drawing.Point(522, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(391, 62);
            this.panel11.TabIndex = 6;
            // 
            // txtRate
            // 
            this.txtRate.ContextMenuStrip = this.contextMenuStrip1;
            this.txtRate.Location = new System.Drawing.Point(198, 15);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(146, 30);
            this.txtRate.TabIndex = 100;
            this.txtRate.Text = "0";
            this.txtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(9, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Rate:";
            // 
            // txtInvoiceID
            // 
            this.txtInvoiceID.ContextMenuStrip = this.contextMenuStrip1;
            this.txtInvoiceID.Location = new System.Drawing.Point(118, 15);
            this.txtInvoiceID.Name = "txtInvoiceID";
            this.txtInvoiceID.Size = new System.Drawing.Size(178, 30);
            this.txtInvoiceID.TabIndex = 99;
            this.txtInvoiceID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
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
            // CreateInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(913, 502);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CreateInvoice";
            this.Text = "CreateInvoice";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CreateInvoice_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceDetail)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvInvoiceDetail;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtGrandKh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ComboBox cbProduct;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.TextBox txtInvoiceID;
        private System.Windows.Forms.Label label3;
        private Custom_Contols.Watermarked_Textbox txtBarcode;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label lbRecieve;
        private System.Windows.Forms.TextBox txtRecieveKh;
        private System.Windows.Forms.Label lbGrand;
        private System.Windows.Forms.TextBox txtRecieveEng;
        private System.Windows.Forms.TextBox txtGrandEng;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtChangeEng;
        private System.Windows.Forms.TextBox txtChangeKh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewButtonColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewButtonColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSubtotal;
        private System.Windows.Forms.DataGridViewButtonColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProID;
    }
}