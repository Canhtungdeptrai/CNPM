using OnlineShopForm1.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopForm1.DTO
{
    public class Products
    {
        public Products(int id, string name, float price, int quantity)
        {
            this.ID = id;
            this.Name = name;           
            this.Price = price;
            this.Quantity = quantity;

        }

        public Products(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();            
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
            this.Quantity = (int)row["quantity"];
        }

        private float price;

        public float Price
        {
            get { return price; }
            set { price = value; }
        }

        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
    }
}

