using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopForm1.DTO
{
    public class Import
    {
        public Import(int id, string productName, DateTime date, float price, int quantity, string currency, float total)
        {
            this.Id = id;
            this.ProductName = productName;
            this.Date = date;
            this.Price = price;
            this.Quantity = quantity;
            this.Currency = currency;
            this.Total = total;
        }

        public Import(DataRow row)
        {
            this.Id = (int)row["id"];
            this.ProductName = row["productName"].ToString();
            this.Date = (DateTime)row["date"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
            this.Quantity = (int)row["quantity"];
            this.Currency = row["currency"].ToString();
            this.Total = (float)Convert.ToDouble(row["total"].ToString());
            
        }

        private float total;
        public float Total
        {
            get { return total; }
            set { total = value; }
        }

        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        private float price;

        public float Price
        {
            get { return price; }
            set { price = value; }
        }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string productName;

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        private string currency;

        public string Currency
        {
            get { return currency; }
            set { currency = value; }
        }

        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
    }
}
