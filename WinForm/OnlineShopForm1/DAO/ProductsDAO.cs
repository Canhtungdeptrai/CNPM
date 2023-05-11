using OnlineShopForm1.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopForm1.DAO
{
    public class ProductsDAO
    {
        private static ProductsDAO instance;

        public static ProductsDAO Instance
        {
            get { if (instance == null) instance = new ProductsDAO(); return ProductsDAO.instance; }
            private set { ProductsDAO.instance = value; }
        }

        private ProductsDAO() { }

        public List<Products> GetListProducts()
        {
            List<Products> list = new List<Products>();

            string query = "select * from Products";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Products products = new Products(item);
                list.Add(products);
            }

            return list;
        }

        public bool InsertProduct(int id, string name, float price, int quantity )
        {
            string query = string.Format("INSERT dbo.Products (id, name, price, quantity )VALUES  ( {0},N'{1}', {2}, {3})", id, name, price, quantity);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateProduct(string name, float price, int quantity, int id)
        {
            string query = string.Format("UPDATE dbo.Products SET name = N'{0}', price = {1}, quantity = {2} WHERE id = {3}", name, price, quantity, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteProduct(int id)
        {        
            string query = string.Format("Delete Products where id = {0}", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public List<Products> SearchProduct(string name)
        {
            List<Products> list = new List<Products>();

            string query = string.Format("SELECT * FROM dbo.Products WHERE dbo.fuConvertToUnsign1(name) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", name);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Products products = new Products(item);
                list.Add(products);
            }

            return list;
        }
    }
}
