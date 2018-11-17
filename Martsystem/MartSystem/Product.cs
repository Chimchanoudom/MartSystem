using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MartSystem
{
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }
        int proID;
        DataTable dtProduct = new DataTable();
        string sql;
        SqlDataReader dataReader;
        bool error;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(btnAdd.Text=="Cancel")
            {
                dgvProduct.ClearSelection();
                return;
            }

            foreach(TextBox txt in panel3.Controls.OfType<TextBox>())
            {
                if (txt.Text == "")
                {
                    MessageBox.Show("Please input required information", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            string barcode = txtBarcode.Text;
            string productName = txtProductName.Text;
            string unitPrice = txtUnitPrice.Text;
            string qtyType = txtQtyType.Text;

            ComboboxItem category,brand;

            if (cbCategory.SelectedIndex == -1) category = cbCategory.SelectedItem as ComboboxItem;
            else  category = cbCategory.Items[0] as ComboboxItem;

            if (cbBrand.SelectedIndex == -1) brand = cbBrand.SelectedItem as ComboboxItem;
            else brand = cbBrand.Items[0] as ComboboxItem;

            sql="insert into product values('"+lbProductID.Text+"','"+productName+"',0,'"+qtyType+"',"+unitPrice+","+category.Value+","+brand.Value+",'"+barcode+"','"+imgPath+"')";

            error = false;
            dataCon.ExecuteActionQry(sql, ref error);
            if (!error)
            {
                dtProduct.Rows.Add(lbProductID.Text, productName, 0,txtQtyType.Text, double.Parse(unitPrice), category.ToString(), brand.ToString(), barcode, ImageBox.Image);

                MessageBox.Show("New product added", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

               

                

                proID++;
                Clean();
            }
        }

        void Clean()
        {
            imgPath = "";
            ImageBox.Image = Properties.Resources.noImg;

            foreach (TextBox txt in panel3.Controls.OfType<TextBox>())
                txt.Text = "";

            cbBrand.SelectedIndex = cbCategory.SelectedIndex = -1;

            lbProductID.Text = proID.ToString("Pro_000");

            btnAdd.Text = "Add";
        }

        

        private void Product_Load(object sender, EventArgs e)
        {
            sql = "select proID 'Product ID',ProName 'Description',Qty 'Quantity',qtyType 'Quantity Type',UnitPrice ,CatName 'Category',BrandName 'Brand',Barcode from Product p join Category c on p.CatID=c.CatID join Brand b on p.BrandID=b.BrandID where 1=2;";

            SqlDataAdapter dataAdaptor = new SqlDataAdapter(sql, dataCon.Con);

            dataAdaptor.Fill(dtProduct);

            dtProduct.Columns.Add("Image", typeof(Image));


            sql = "select proID 'Product ID',ProName 'Description',Qty 'Quantity',qtyType 'Quantity Type',UnitPrice ,CatName,BrandName,Barcode,Image 'img',c.catId,b.BrandId from Product p join Category c on p.CatID=c.CatID join Brand b on p.BrandID=b.BrandID;";

            dataCon.Con.Open();
            dataReader = dataCon.ExecuteQry(sql);
            while (dataReader.Read())
            {
                Image img;
                try
                {
                    img = Image.FromFile(dataReader.GetString(8));
                }
                catch
                {
                    img = Properties.Resources.noImg;
                }

                ComboboxItem category = new ComboboxItem(dataReader.GetString(5),dataReader.GetInt32(9)+"");

                ComboboxItem brand = new ComboboxItem(dataReader.GetString(6), dataReader.GetInt32(10) + "");

                sql = "select proID 'Product ID',ProName 'Description',Qty 'Quantity',qtyType 'Quantity Type',UnitPrice ,CatName,BrandName,Barcode,Image 'img',c.catId,b.BrandId from Product p join Category c on p.CatID=c.CatID join Brand b on p.BrandID=b.BrandID;";


                dtProduct.Rows.Add(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetValue(2) + "",dataReader.GetString(3), dataReader.GetValue(4) + "", category, brand, dataReader.GetString(7), img);
            }


            dataCon.Con.Close();


            dgvProduct.DataSource = dtProduct;

            FillComboBox("select * from category;", cbCategory);

            FillComboBox("select * from brand;", cbBrand);


            sql = "NewGetAutoID 'ProID','_','product';";
            dataCon.Con.Open();
            dataReader = dataCon.ExecuteQry(sql);
            dataReader.Read();
            proID = dataReader.GetInt32(0);
            lbProductID.Text = proID.ToString("Pro_000");
            dataCon.Con.Close();

            DataGridViewImageColumn colImg =(DataGridViewImageColumn) dgvProduct.Columns[8];

            colImg.ImageLayout = DataGridViewImageCellLayout.Zoom;

            dgvProduct.ClearSelection();

            dgvProduct.Columns["UnitPrice"].DefaultCellStyle.Format="#,##0.00";
        }

        void FillComboBox(string sql,ComboBox cb)
        {
            dataCon.Con.Open();
            dataReader = dataCon.ExecuteQry(sql);


            while (dataReader.Read())
            {
                ComboboxItem item = new ComboboxItem(dataReader.GetString(1), dataReader.GetInt32(0) + "");
                cb.Items.Add(item);
            }
            dataCon.Con.Close();
        }

        string imgPath;

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = new OpenFileDialog().Filter = "Images (*.jpg)|*.jpg|Images (*.png)|*.png";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                imgPath = fd.FileName;
                ImageBox.Image = Image.FromFile(imgPath);
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageBox.Image = Properties.Resources.noImg;
            imgPath = "";
        }

        private void txtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (("0123456789.\b".IndexOf(e.KeyChar) == -1)|| (txtUnitPrice.Text.Contains(".") && e.KeyChar == '.'))
            {
                e.KeyChar = '\0';
            }
        }

        private void dgvProduct_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProduct.SelectedRows.Count == 1)
            {
                int selectedRowIndex = dgvProduct.SelectedRows[0].Index;

                lbProductID.Text = dgvProduct.Rows[selectedRowIndex].Cells["Product Id"].Value+"";
                txtBarcode.Text = dgvProduct.Rows[selectedRowIndex].Cells["Barcode"].Value + "";
                txtProductName.Text = dgvProduct.Rows[selectedRowIndex].Cells["Description"].Value + "";
                txtQtyType.Text = dgvProduct.Rows[selectedRowIndex].Cells["Quantity Type"].Value + "";
                txtUnitPrice.Text = dgvProduct.Rows[selectedRowIndex].Cells["UnitPrice"].Value + "";

                ComboboxItem cb = dgvProduct.Rows[selectedRowIndex].Cells["Category"].Value as ComboboxItem;

                cbCategory.SelectedIndex =cbCategory.FindStringExact(dgvProduct.Rows[selectedRowIndex].Cells["Category"].Value+"");


                cbBrand.SelectedIndex = cbBrand.FindStringExact(dgvProduct.Rows[selectedRowIndex].Cells["Brand"].Value + "");

                ImageBox.Image = dgvProduct.Rows[selectedRowIndex].Cells["Image"].Value as Image;

                btnAdd.Text = "Cancel";
            }
            else
            {
                Clean();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProduct.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select a row to edit", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
                

            ComboboxItem category = cbCategory.SelectedItem as ComboboxItem;
            ComboboxItem brand = cbBrand.SelectedItem as ComboboxItem;

            sql = "update Product set ProName='"+txtProductName.Text+"',QtyType='"+txtQtyType.Text+"',UnitPrice="+txtUnitPrice.Text+",CatID='"+category.Value+"',BrandID='"+brand.Value+"',Barcode='"+txtBarcode.Text+"',Image='"+imgPath+"' where proid='"+lbProductID.Text+"';";

            dataCon.ExecuteActionQry(sql,ref error);
            if (!error)
            {
                MessageBox.Show("Edit successfull", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                sql = "select proID 'Product ID',ProName 'Description',Qty 'Quantity',qtyType 'Quantity Type',UnitPrice ,CatName,BrandName,Barcode,Image 'img',c.catId,b.BrandId from Product p join Category c on p.CatID=c.CatID join Brand b on p.BrandID=b.BrandID;";

                int selectedRowIndex = dgvProduct.SelectedRows[0].Index;
                dgvProduct.Rows[selectedRowIndex].Cells["Description"].Value = txtProductName.Text;
                dgvProduct.Rows[selectedRowIndex].Cells["Quantity Type"].Value = txtQtyType.Text;
                dgvProduct.Rows[selectedRowIndex].Cells["UnitPrice"].Value = txtUnitPrice.Text;
                dgvProduct.Rows[selectedRowIndex].Cells["Category"].Value = category;
                dgvProduct.Rows[selectedRowIndex].Cells["Brand"].Value = brand;
                dgvProduct.Rows[selectedRowIndex].Cells["Image"].Value = ImageBox.Image;
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (dgvProduct.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select a row to delete", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete selected row?","", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            
            
            if (dialogResult == DialogResult.No)
                return;

            dataCon.Con.Open();
            sql = "select count(*) from invoiceDetail where proID='" + lbProductID.Text + "';";
            dataReader = dataCon.ExecuteQry(sql);
            dataReader.Read();
            int countSoldProduct = dataReader.GetInt32(0);
            dataCon.Con.Close();


            dataCon.Con.Open();
            sql = "select count(*) from importDetail where proID='" + lbProductID.Text + "';";
            dataReader.Read();
            int countImportProduct = dataReader.GetInt32(0);
            dataCon.Con.Close();

            if (countSoldProduct > 0||countImportProduct>0)
            {
                MessageBox.Show("Cannot delete product", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            sql = "delete from product where proid='" + lbProductID.Text + "';";

            dataCon.ExecuteActionQry(sql, ref error);
            if (!error)
            {
                dgvProduct.Rows.RemoveAt(dgvProduct.SelectedRows[0].Index);

                MessageBox.Show("Delete successfull", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string filter = "";

            sql = "select proID 'Product ID',ProName 'Description',Qty 'Quantity',qtyType 'Quantity Type',UnitPrice ,CatName 'Category',BrandName 'Brand',Barcode from Product p join Category c on p.CatID=c.CatID join Brand b on p.BrandID=b.BrandID where 1=2;";

            if (rndID.Checked) filter = "[Product ID]=";
            else if (rndProName.Checked) filter = "Description=";
            else if (rndCategory.Checked) filter = "Category=";
            else if (rndBrand.Checked) filter = "Brand=";
            else if (rndBarCode.Checked) filter = "Barcode=";

            filter +="'"+ txtSearch.Text+"'";

            dtProduct.DefaultView.RowFilter = filter;

            dgvProduct.ClearSelection();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dtProduct.DefaultView.RowFilter = string.Empty;
        }
    }
}
