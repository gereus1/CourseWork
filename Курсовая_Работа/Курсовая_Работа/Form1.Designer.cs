
using System;
using System.Collections.Generic;

namespace Курсовая_Работа
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Log = new System.Windows.Forms.TextBox();
            this.Pass = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Log
            // 
            this.Log.Location = new System.Drawing.Point(140, 58);
            this.Log.Name = "Log";
            this.Log.PlaceholderText = "Login";
            this.Log.Size = new System.Drawing.Size(100, 23);
            this.Log.TabIndex = 0;
            this.Log.Tag = "";
            this.Log.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Pass
            // 
            this.Pass.Location = new System.Drawing.Point(140, 110);
            this.Pass.Name = "Pass";
            this.Pass.PlaceholderText = "Password";
            this.Pass.Size = new System.Drawing.Size(100, 23);
            this.Pass.TabIndex = 1;
            this.Pass.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(150, 155);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Confirm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 265);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Pass);
            this.Controls.Add(this.Log);
            this.Name = "Form1";
            this.Text = " Warehouse";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Log;
        private System.Windows.Forms.TextBox Pass;
        private System.Windows.Forms.Button button1;
    }
    public class User
    {
        private string _login;
        private string _password;

        public string Login
        {
            get => _login;
        }

        public string Password
        {
            get => _password;
        }

        public User(string login, string password)
        {
            _login = login;
            _password = password;
        }
    }
    public class Client
    {

        private string _id;
        private string _name;

        public string Id
        {
            get => _id;
        }

        public string Name
        {
            get => _name;
        }

        public Client(string name)
        {
            _id = Guid.NewGuid().ToString();
            _name = name;
        }
    }
    public class SlotOrder
    {
        private Client _client;
        private Product _product;
        private double _pricePerUnit;
        private int _unitsCount;

        public Client Client
        {
            get => _client;
        }

        public Product Product
        {
            get => _product;
        }

        public double PricePerUnit
        {
            get => _pricePerUnit;
            set
            {
                _pricePerUnit = value;
            }
        }

        public int UnitsCount
        {
            get => _unitsCount;
            set
            {
                _unitsCount = value;
            }
        }

        public double TotalPrice
        {
            get => _pricePerUnit * (double)_unitsCount;
        }

        public SlotOrder(Client client, Product product, double pricePerUnit, int unitsCount)
        {
            _client = client;
            _product = product;
            _pricePerUnit = pricePerUnit;
            _unitsCount = unitsCount;
        }
    }

    public class Product
    {
        private string _id;
        private string _wareType;
        private string _name;
        private double _unitStoragePrice;

        public string Id
        {
            get => _id;
        }

        public string WareType
        {
            get => _wareType;
        }

        public string Name
        {
            get => _name;
        }

        /// <summary>
        /// How much it costs to keep this product in warehouse.
        /// This is the price organization that keeps the warehouse should pay per unit of this product.
        /// </summary>
        public double UnitStoragePrice
        {
            get => _unitStoragePrice;
        }

        public Product(string wareType, string name, double unitStoragePrice)
        {
            _id = Guid.NewGuid().ToString();
            _wareType = wareType;
            _name = name;
            _unitStoragePrice = unitStoragePrice;
        }
    }

    public class Organization
    {
        private string _id;
        private string _name;
        private List<User> _users;

        private List<string> _productTypes;
        private List<Product> _products;
        private List<Client> _clients;
        private List<SlotOrder> _orders;

        public string Id
        {
            get => _id;
        }

        public string Name
        {
            get => _name;
        }

        public List<User> Users
        {
            get => _users;
        }

        public List<string> ProductTypes
        {
            get => _productTypes;
        }

        public List<Product> Products
        {
            get => _products;
        }

        public List<Client> Clients
        {
            get => _clients;
        }

        public Organization(string name)
        {
            _id = Guid.NewGuid().ToString();
            _name = name;
            _products = new List<Product>();
            _clients = new List<Client>();
            _productTypes = new List<string>();
            _orders = new List<SlotOrder>();
            _users = new List<User>();
        }

        public void AddClient(Client client)
        {
            _clients.Add(client);
        }

        public void RemoveClient(int index)
        {
            _clients.RemoveAt(index);
        }

        public void AddProductType(string productType)
        {
            if (!_productTypes.Contains(productType))
                _productTypes.Add(productType);
            // throw error if such product type already exists
        }

        public void AddProduct(Product product)
        {
            if (_products.Find(item => item.Name == product.Name) == null)
                _products.Add(product);
            // throw error if product with such name already exists
        }

        public void AddOrder(Product product, Client client, double pricePerUnit, int unitsCount)
        {
            var existingOrder = _orders.Find(item => item.Client.Id == client.Id && item.Product.Id == product.Id);
            if (existingOrder != null)
            {
                existingOrder.UnitsCount += unitsCount;
                existingOrder.PricePerUnit = pricePerUnit;
            }
            else
            {
                var newOrder = new SlotOrder(client, product, pricePerUnit, unitsCount);
                _orders.Add(newOrder);
            }
        }
    }
}

