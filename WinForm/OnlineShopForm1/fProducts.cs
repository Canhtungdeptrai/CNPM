using OnlineShopForm1.DAO;
using OnlineShopForm1.DTO;
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
    public partial class fProducts : Form
    {
       
        public fProducts()
        {
            InitializeComponent();
            LoadListProduct();
            LoadListInForm();
            AddProductBinding();
            AddInFormBinding();
            
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            LoadListProduct();
        }

        void LoadListProduct()
        {
            string query = "select * from dbo.Products";

            dataGridViewProducts.DataSource = DataProvider.Instance.ExecuteQuery(query);

        }

        void LoadListInForm()
        {
            string query = "select * from dbo.ImportForm";
            dataGridViewFormIn.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        void AddInFormBinding()
        {
            txtIDForm.DataBindings.Add(new Binding("Text", dataGridViewFormIn.DataSource, "ID"));
            txtIDBatch.DataBindings.Add(new Binding("Text", dataGridViewFormIn.DataSource, "IDbatch"));
            txtStatus.DataBindings.Add(new Binding("Text", dataGridViewFormIn.DataSource, "status"));

        }

        void AddProductBinding()
        {
            txtID.DataBindings.Add(new Binding("Text", dataGridViewProducts.DataSource, "ID"));
            txtName.DataBindings.Add(new Binding("Text", dataGridViewProducts.DataSource, "Name",true, DataSourceUpdateMode.Never));
            txtQuantity.DataBindings.Add(new Binding("Text", dataGridViewProducts.DataSource, "Quantity"));
            txtPrice.DataBindings.Add(new Binding("Text", dataGridViewProducts.DataSource, "Price"));
        }
        
        

        private void btnCreate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            string name = txtName.Text;
            float price = float.Parse(txtPrice.Text);
            int quantity = int.Parse(txtQuantity.Text);
            int idB = int.Parse(txtIDBatch.Text);
            int status = int.Parse(txtStatus.Text);
            DateTime date = dateTimePicker1.Value;

            if (ProductsDAO.Instance.InsertProduct(id, name, price, quantity) &&
                ImportDAO.Instance.InsertFormIn(date, idB, status))
            {
                MessageBox.Show("Insert success");
                LoadListProduct();
                LoadListInForm();
                if (insertProduct != null)
                    insertProduct(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Falied!");
            }

            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            string name = txtName.Text;
            float price = float.Parse(txtPrice.Text);
            int quantity = int.Parse(txtQuantity.Text);

            if (ProductsDAO.Instance.UpdateProduct(name, price, quantity, id))
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

            if (ProductsDAO.Instance.DeleteProduct(id))
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
        private void btnUpdateForm_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtIDForm.Text);
            DateTime create = dateTimePicker1.Value;
            int idB = int.Parse(txtIDBatch.Text);
            int status = int.Parse(txtStatus.Text);

            if (ImportDAO.Instance.UpdateInForm(create,idB,status,id))
            {
                MessageBox.Show("Edit success");
                LoadListInForm();
                if (updateFood != null)
                    updateFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Falied!");
            }
        }

        private void btnDelForm_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtIDForm.Text);

            if (ImportDAO.Instance.DeleteInForm(id))
            { 
                MessageBox.Show("Delete success");
                LoadListInForm();
                if (deleteFood != null)
                    deleteFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Failed");
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        
    }
}
