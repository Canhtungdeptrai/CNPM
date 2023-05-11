using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopForm1
{
    class Connection
    {
        private static string cnn = "Data Source=JULIO\\SQLEXPRESS;Initial Catalog=OnlineShop;Integrated Security=True";
        
        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(cnn);
        }
    }
}
