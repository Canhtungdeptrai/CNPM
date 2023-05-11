using OnlineShopForm1.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineShopForm1
{
    public partial class fImport : Form
    {
        public fImport()
        {
            InitializeComponent();
            LoadListProduct();
            AddInFormBinding();
        }

        void LoadListProduct()
        {
            string query = "select * from dbo.ImportFormDetail";

            dataGridViewProducts.DataSource = DataProvider.Instance.ExecuteQuery(query);

        }

        void AddInFormBinding()
        {
            txtID.DataBindings.Add(new Binding("Text", dataGridViewProducts.DataSource, "Id"));
            txtName.DataBindings.Add(new Binding("Text", dataGridViewProducts.DataSource, "ProductName"));
            txtCurr.DataBindings.Add(new Binding("Text", dataGridViewProducts.DataSource, "Currency"));
            txtPrice.DataBindings.Add(new Binding("Text", dataGridViewProducts.DataSource, "Price"));
            txtQuantity.DataBindings.Add(new Binding("Text", dataGridViewProducts.DataSource, "Quantity"));
            txtTotal.DataBindings.Add(new Binding("Text", dataGridViewProducts.DataSource, "Total"));
            //dateTimePicker1.DataBindings.Add(new Binding(""))
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            string name = txtName.Text;
            float price = float.Parse(txtPrice.Text);
            int quantity = int.Parse(txtQuantity.Text);
            string curr = txtCurr.Text;
            float total = float.Parse(txtTotal.Text);
            DateTime date = dateTimePicker1.Value;

            if (ImportDetailDAO.Instance.InsertFormIn(id,name,date,price,quantity,curr,total))
            {
                MessageBox.Show("Insert success");
                LoadListProduct();                
                if (insertProduct != null)
                    insertProduct(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Falied!");
            }
        }

        private event EventHandler insertProduct;
        public event EventHandler InsertProduct
        {
            add { insertProduct += value; }
            remove { insertProduct -= value; }
        }

        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }

        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            string name = txtName.Text;
            float price = float.Parse(txtPrice.Text);
            int quantity = int.Parse(txtQuantity.Text);
            string curr = txtCurr.Text;
            float total = float.Parse(txtTotal.Text);
            DateTime date = dateTimePicker1.Value;

            if (ImportDetailDAO.Instance.UpdateInForm(name, date,price, quantity,curr,total, id))
            {
                MessageBox.Show("Edit success");
                LoadListProduct();
                if (updateFood != null)
                    updateFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Falied!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);

            if (ImportDetailDAO.Instance.DeleteInForm(id))
            {
                MessageBox.Show("Delete success");
                LoadListProduct();
                if (deleteFood != null)
                    deleteFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            fPrint fPrint = new fPrint();
            fPrint.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
