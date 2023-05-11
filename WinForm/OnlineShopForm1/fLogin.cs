using OnlineShopForm1.DAO;
using OnlineShopForm1.DTO;
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
    public partial class fLogin : Form
    {

        public fLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPass.Text;
            if (Login(email, password))
            {

                Account loginAccount = AccountDAO.Instance.GetAccountByEmail(email);
                fIndex fIndex = new fIndex(loginAccount); 
                this.Hide();
                fIndex.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Email or password wrong!");
            }

        }

        bool Login(string email, string password)
        {
            return AccountDAO.Instance.Login(email, password);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Cofirm exit", "Notice",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation) != System.Windows.Forms.DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void fLogin_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
