namespace MartSystem
{
    partial class Stock
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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.rndAlmostExpired = new System.Windows.Forms.RadioButton();
            this.rndExpired = new System.Windows.Forms.RadioButton();
            this.rndExpiredDate = new System.Windows.Forms.RadioButton();
            this.rndImportDate = new System.Windows.Forms.RadioButton();
            this.rndProductName = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvStock = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.panel7);
            this.groupBox6.Controls.Add(this.groupBox7);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(0, 0);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox6.Size = new System.Drawing.Size(847, 198);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Search";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnCancel);
            this.panel7.Controls.Add(this.btnSearch);
            this.panel7.Controls.Add(this.txtSearch);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(4, 115);
            this.panel7.Margin = new System.Windows.Forms.Padding(4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(839, 32);
            this.panel7.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(428, 0);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(128, 32);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Fuchsia;
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(300, 0);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(128, 32);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtSearch.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(0, 0);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(300, 34);
            this.txtSearch.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.rndAlmostExpired);
            this.groupBox7.Controls.Add(this.rndExpired);
            this.groupBox7.Controls.Add(this.rndExpiredDate);
            this.groupBox7.Controls.Add(this.rndImportDate);
            this.groupBox7.Controls.Add(this.rndProductName);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox7.Location = new System.Drawing.Point(4, 27);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox7.Size = new System.Drawing.Size(839, 88);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Filter Condition";
            // 
            // rndAlmostExpired
            // 
            this.rndAlmostExpired.AutoSize = true;
            this.rndAlmostExpired.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rndAlmostExpired.Location = new System.Drawing.Point(644, 44);
            this.rndAlmostExpired.Margin = new System.Windows.Forms.Padding(4);
            this.rndAlmostExpired.Name = "rndAlmostExpired";
            this.rndAlmostExpired.Size = new System.Drawing.Size(175, 27);
            this.rndAlmostExpired.TabIndex = 0;
            this.rndAlmostExpired.Text = "Almost Expired";
            this.rndAlmostExpired.UseVisualStyleBackColor = true;
            this.rndAlmostExpired.Click += new System.EventHandler(this.rndExpired_Click);
            // 
            // rndExpired
            // 
            this.rndExpired.AutoSize = true;
            this.rndExpired.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rndExpired.Location = new System.Drawing.Point(534, 44);
            this.rndExpired.Margin = new System.Windows.Forms.Padding(4);
            this.rndExpired.Name = "rndExpired";
            this.rndExpired.Size = new System.Drawing.Size(102, 27);
            this.rndExpired.TabIndex = 0;
            this.rndExpired.Text = "Expired";
            this.rndExpired.UseVisualStyleBackColor = true;
            this.rndExpired.Click += new System.EventHandler(this.rndExpired_Click);
            // 
            // rndExpiredDate
            // 
            this.rndExpiredDate.AutoSize = true;
            this.rndExpiredDate.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rndExpiredDate.Location = new System.Drawing.Point(369, 44);
            this.rndExpiredDate.Margin = new System.Windows.Forms.Padding(4);
            this.rndExpiredDate.Name = "rndExpiredDate";
            this.rndExpiredDate.Size = new System.Drawing.Size(157, 27);
            this.rndExpiredDate.TabIndex = 0;
            this.rndExpiredDate.Text = "Expired Date";
            this.rndExpiredDate.UseVisualStyleBackColor = true;
            this.rndExpiredDate.Click += new System.EventHandler(this.rndImportDate_Click);
            // 
            // rndImportDate
            // 
            this.rndImportDate.AutoSize = true;
            this.rndImportDate.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rndImportDate.Location = new System.Drawing.Point(211, 44);
            this.rndImportDate.Margin = new System.Windows.Forms.Padding(4);
            this.rndImportDate.Name = "rndImportDate";
            this.rndImportDate.Size = new System.Drawing.Size(150, 27);
            this.rndImportDate.TabIndex = 0;
            this.rndImportDate.Text = "Import Date";
            this.rndImportDate.UseVisualStyleBackColor = true;
            this.rndImportDate.Click += new System.EventHandler(this.rndImportDate_Click);
            // 
            // rndProductName
            // 
            this.rndProductName.AutoSize = true;
            this.rndProductName.Checked = true;
            this.rndProductName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rndProductName.Location = new System.Drawing.Point(28, 44);
            this.rndProductName.Margin = new System.Windows.Forms.Padding(4);
            this.rndProductName.Name = "rndProductName";
            this.rndProductName.Size = new System.Drawing.Size(175, 27);
            this.rndProductName.TabIndex = 0;
            this.rndProductName.TabStop = true;
            this.rndProductName.Text = "Product Name";
            this.rndProductName.UseVisualStyleBackColor = true;
            this.rndProductName.CheckedChanged += new System.EventHandler(this.rndProductName_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvStock);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 198);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(847, 308);
            this.panel1.TabIndex = 6;
            // 
            // dgvStock
            // 
            this.dgvStock.AllowUserToAddRows = false;
            this.dgvStock.AllowUserToDeleteRows = false;
            this.dgvStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStock.ColumnHeadersHeight = 33;
            this.dgvStock.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStock.Location = new System.Drawing.Point(0, 0);
            this.dgvStock.MultiSelect = false;
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.ReadOnly = true;
            this.dgvStock.RowHeadersVisible = false;
            this.dgvStock.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvStock.RowTemplate.Height = 33;
            this.dgvStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStock.Size = new System.Drawing.Size(847, 308);
            this.dgvStock.TabIndex = 0;
            this.dgvStock.SelectionChanged += new System.EventHandler(this.dgvStock_SelectionChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(123, 28);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // Stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(847, 506);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox6);
            this.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Stock";
            this.Text = "Stock";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Stock_Load);
            this.groupBox6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RadioButton rndExpiredDate;
        private System.Windows.Forms.RadioButton rndImportDate;
        private System.Windows.Forms.RadioButton rndProductName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvStock;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.RadioButton rndAlmostExpired;
        private System.Windows.Forms.RadioButton rndExpired;
    }
}