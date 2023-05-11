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
    public partial class fAccountChange : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount); }
        }

        public fAccountChange(Account acc)
        {
            InitializeComponent();

            LoginAccount = acc;
        }

        void ChangeAccount(Account acc)
        {
            txtEmail.Text = LoginAccount.Email;
            txtName.Text = LoginAccount.Name;
        }

        void UpdateAccountInfo()
        {
            string name = txtName.Text;
            string password = txtPass.Text;
            string newpass = txtNewpass.Text;
            string reenterPass = txtRepass.Text;
            string email = txtEmail.Text;

            if (!newpass.Equals(reenterPass))
            {
                MessageBox.Show("Please confirm right new password!");
            }
            else
            {
                if (AccountDAO.Instance.UpdateAccount(email, name, password, newpass))
                {
                    MessageBox.Show("Update successfully");
                    if (updateAccount != null)
                        updateAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByEmail(email)));
                }
                else
                {
                    MessageBox.Show("Please enter password ");
                }
            }
        }

        private event EventHandler<AccountEvent> updateAccount;
        public event EventHandler<AccountEvent> UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAccountInfo();
        }
    }

    public class AccountEvent : EventArgs
    {
        private Account acc;

        public Account Acc
        {
            get { return acc; }
            set { acc = value; }
        }

        public AccountEvent(Account acc)
        {
            this.Acc = acc;
        }
    }
}
