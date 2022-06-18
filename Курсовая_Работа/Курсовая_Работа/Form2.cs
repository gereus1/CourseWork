using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using WarehouseApp;

namespace Курсовая_Работа
{
    public partial class Form2 : Form
    {
        public OrganizationManager OrganizationManager;

        public Form2()
        {
            InitializeComponent();
            
        }

        private void LoadData()
        {
            foreach(string productType in OrganizationManager.ProductTypes)
            {
                dataGridView1.Rows.Add(productType);

            }

            if(!OrganizationManager.CanAddProductType())
            {
                button1.Enabled = false;
                textBox1.Enabled = false;
                button2.Enabled = false;

            }

            if (!OrganizationManager.CanAddProduct())
            {
                button5.Enabled = false;
                button6.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;

            }

            if (!OrganizationManager.CanAddClient())
            {
                button3.Enabled = false;
                button4.Enabled = false;
                textBox2.Enabled = false;

            }

            if (!OrganizationManager.CanAddOrder())
            {
                button7.Enabled = false;
                button8.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
            }

            if (!OrganizationManager.CanCalculateTotalIncome())
            {
                button9.Enabled = false;
            }

                foreach (var client in OrganizationManager.Clients)
            {
                dataGridView3.Rows.Add(client.Id, client.Name);

            }

            foreach (var products in OrganizationManager.Products)
            {
                dataGridView2.Rows.Add(products.WareType, products.Name, products.UnitStoragePrice);

            }

            foreach (var orders in OrganizationManager.Orders)
            {
                dataGridView4.Rows.Add(orders.Client.Name, orders.Product.Name, orders.PricePerUnit, orders.UnitsCount, orders.TotalPrice, orders.Product.UnitStoragePrice * orders.UnitsCount);

            }
        }

        private void ReloadData()
        {
            try
            {
               
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridView1[1, i] = linkCell;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Update_Click(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {           
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(textBox1.Text);
            OrganizationManager.AddProductType(textBox1.Text);
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows.Add("", textBox2.Text);
            OrganizationManager.AddClient(textBox2.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int prodRow = dataGridView1.SelectedCells[0].RowIndex;
            var productType = OrganizationManager.ProductTypes[prodRow];
            dataGridView2.Rows.Add(productType, textBox3.Text, textBox4.Text);
            OrganizationManager.AddProduct(textBox3.Text, productType, Convert.ToDouble(textBox4.Text));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView2.CurrentCell.RowIndex;
            dataGridView2.Rows.RemoveAt(rowIndex);
            OrganizationManager.RemoveProductAt(rowIndex);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowIndex);
            OrganizationManager.RemoveProductTypeAt(rowIndex);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView3.CurrentCell.RowIndex;
            dataGridView3.Rows.RemoveAt(rowIndex);
            OrganizationManager.RemoveClientAt(rowIndex);
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            int clientRow = dataGridView3.SelectedCells[0].RowIndex;
            var clientName = OrganizationManager.Clients[clientRow];

            int prodRow1 = dataGridView2.SelectedCells[0].RowIndex;
            var productName = OrganizationManager.Products[prodRow1];

            var pricePerUnit = Convert.ToDouble(textBox5.Text);
            var unitsCount = Convert.ToInt32(textBox6.Text);

            var totalPrice = pricePerUnit * unitsCount;
            var taxes = unitsCount * productName.UnitStoragePrice;

            dataGridView4.Rows.Add(clientName.Name, productName.Name, textBox5.Text, textBox6.Text, totalPrice.ToString(), taxes.ToString());
            OrganizationManager.AddOrder(clientName, productName, pricePerUnit, unitsCount);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView4.CurrentCell.RowIndex;
            dataGridView4.Rows.RemoveAt(rowIndex);
            OrganizationManager.RemoveOrderAt(rowIndex);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            int clientRow = dataGridView3.SelectedCells[0].RowIndex;
            var clientId = OrganizationManager.Clients[clientRow].Id;

            var TotalIncome = OrganizationManager.IncomeFromClient(clientId);
            label5.Text = TotalIncome.ToString();

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
