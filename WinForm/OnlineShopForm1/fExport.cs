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
    public partial class fExport : Form
    {
        public fExport()
        {
            InitializeComponent();
            LoadProductCombobox(cbBoxProducts);
        }

        void LoadProducts()
        {
            List<Products> products = ProductsDAO.Instance.GetListProducts();
            cbBoxProducts.DataSource = products;
            cbBoxProducts.DisplayMember = "name";
        }

        private void cbBoxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }

        void LoadProductCombobox(ComboBox comboBox)
        {
            comboBox.DataSource = ProductsDAO.Instance.GetListProducts();
            comboBox.DisplayMember = "name";
        }
    }
}
