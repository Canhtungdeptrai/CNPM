using OnlineShopForm1.DAO;
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

namespace OnlineShopForm1
{
    public partial class fAccount : Form
    {
        public fAccount()
        {
            InitializeComponent();
            LoadAccountList();
            AddInFormBinding();
        }

        void LoadAccountList()
        {
            string query = "select Name, Email, Password, IsAdmin from dbo.Users ";

            dataGridViewAccount.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        void AddInFormBinding()
        {
            txtEmail.DataBindings.Add(new Binding("Text", dataGridViewAccount.DataSource, "Email"));
            txtName.DataBindings.Add(new Binding("Text", dataGridViewAccount.DataSource, "Name"));
            txtPass.DataBindings.Add(new Binding("Text", dataGridViewAccount.DataSource, "Password"));

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string pass = txtPass.Text;
            int admin = int.Parse(txtAdmin.Text);
            string email = txtEmail.Text;

            if (AccountDAO.Instance.UpdateAcc(name,pass,admin,email))
            {
                MessageBox.Show("Edit success");
                LoadAccountList();
                if (updateFood != null)
                    updateFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Falied!");
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            
            string name = txtName.Text;
            string email = txtEmail.Text;
            string pass = txtPass.Text;
            int admin = int.Parse(txtAdmin.Text);
            

            if (AccountDAO.Instance.InsertAcc(name,email,pass,admin))
            {
                MessageBox.Show("Insert success");
                LoadAccountList();
                if (insertProduct != null)
                    insertProduct(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Falied!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;

            if (AccountDAO.Instance.DeleteAcc(email))
            {
                MessageBox.Show("Delete success");
                LoadAccountList();
                if (deleteFood != null)
                    deleteFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            LoadAccountList();
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
    }
}
