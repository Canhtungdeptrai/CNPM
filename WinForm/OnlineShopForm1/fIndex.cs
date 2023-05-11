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
    public partial class fIndex : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; /*ChangeAccount(loginAccount.IsAdmin);*/ }
        }

        public fIndex(Account acc)
        {
            InitializeComponent();

            this.LoginAccount = acc;
            
        }

        void ChangeAccount(int isAdmin)
        {
            //myProfileToolStripMenuItem.Enabled = isAdmin == 1;
            changeInformationToolStripMenuItem.Text += " (" + LoginAccount.Name + ")";
        }

        private void importFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fImport fImport = new fImport();
            
            fImport.Show();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fProducts fProducts = new fProducts();
            fProducts.Show();
        }


        private void myProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccount fAccount = new fAccount();

            fAccount.Show();
        }

       

        private void changeInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountChange f = new fAccountChange(LoginAccount);
            f.UpdateAccount += f_UpdateAccount;
            f.ShowDialog();
        }

        void f_UpdateAccount(object sender, AccountEvent e)
        {
            changeInformationToolStripMenuItem.Text = "Thông tin tài khoản (" + e.Acc.Name + ")";
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void exportFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fExport fExport = new fExport();

            fExport.Show();
        }
    }
}
