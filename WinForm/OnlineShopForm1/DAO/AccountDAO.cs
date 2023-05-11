using OnlineShopForm1.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopForm1.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }
        
        private AccountDAO()
        {

        }

        public bool Login(string email, string password)
        {
            string query = "Login @email , @password";

            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { email, password});

            return result.Rows.Count > 0;
        }

        public bool UpdateAccount(string email, string name, string pass, string newPass)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("exec UpdateAccount @email , @name , @password , @newPassword", new object[] { email, name, pass, newPass });

            return result > 0;
        }

        public Account GetAccountByEmail(string email)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from Users where Email = '" + email + "'");

            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }

            return null;
        }

        public bool InsertAcc(string name, string email, string password, int admin)
        {
            string query = string.Format("INSERT dbo.Users (name, email, password, isadmin)VALUES  ( '{0}','{1}', '{2}', {3})", name, email, password,admin);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateAcc(string name, string password, int admin, string email)
        {
            string query = string.Format("UPDATE dbo.Users SET name = N'{0}', password = '{1}', isadmin = {2} WHERE email = '{3}'", name, password, admin, email);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteAcc(string email)
        {
            string query = string.Format("Delete Users where email = '{0}'", email);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
