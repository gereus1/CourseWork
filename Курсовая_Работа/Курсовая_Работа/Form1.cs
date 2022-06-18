using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseApp;

namespace Курсовая_Работа
{
    public partial class Form1 : Form
    {

        public OrganizationManager OrganizationManager;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (OrganizationManager.Login("1", Log.Text, Pass.Text))
            {
                this.Hide();
                Form2 form2 = new Form2();
                form2.OrganizationManager = OrganizationManager;
                form2.Show();
            }
            else MessageBox.Show("Password or Login is incorrect!");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }


}
