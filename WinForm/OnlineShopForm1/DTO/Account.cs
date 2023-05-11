using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopForm1.DTO
{
    public class Account
    {
        public Account(string email, string name, int isAdmin, string password = null)
        {
            this.Email = email;
            this.Name = name;
            this.IsAdmin = isAdmin;
            this.Password = password;
        }

        public Account(DataRow row)
        {
            this.Email = row["email"].ToString();
            this.Name = row["name"].ToString();
            this.IsAdmin = (int)row["isAdmin"];
            this.Password = row["password"].ToString();
        }

        private int isAdmin;

        public int IsAdmin
        {
            get { return isAdmin; }
            set { isAdmin = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}
