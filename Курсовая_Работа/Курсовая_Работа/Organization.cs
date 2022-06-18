using System;
using System.Collections.Generic;

namespace WarehouseApp
{
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
			set => _id = value;
		}

		public string Name
        {
			get => _name;
			set => _name = value;
		}

		public List<User> Users
        {
			get => _users;
			set => _users = value;
		}

		public List<string> ProductTypes
        {
			get => _productTypes;
			set => _productTypes = value;
		}

		public List<Product> Products
        {
			get => _products;
			set => _products = value;
		}

		public List<Client> Clients
        {
			get => _clients;
			set => _clients = value;
		}

		public List<SlotOrder> Orders
        {
			get => _orders;
			set => _orders = value;
		}
		public Organization()
		{
			_id = Guid.NewGuid().ToString();
			_name = "";
			_products = new List<Product>();
			_clients = new List<Client>();
			_productTypes = new List<string>();
			_orders = new List<SlotOrder>();
			_users = new List<User>();
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
            } else
            {
				var newOrder = new SlotOrder(client, product, pricePerUnit, unitsCount);
				_orders.Add(newOrder);
            }
        }
	}
}

