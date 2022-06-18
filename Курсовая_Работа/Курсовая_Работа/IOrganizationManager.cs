using System;
using System.Collections.Generic;

namespace WarehouseApp
{
	public interface IOrganizationManager
	{
		public List<string> ProductTypes { get; }

		public List<Product> Products { get; }

		public List<Client> Clients { get; }

		public string OrganizationName { get; }

		public double TotalIncome { get; }

		public double TotalOutcome { get; }


		public double IncomeFromClient(string clientId);

		public void AddClient(string name);

		public void AddProductType(string productType);

		public void AddProduct(string name, string productType, double storagePrice);

		public void AddOrder(Client client, Product product, double pricePerUnit, int unitsCount);

		public void RemoveProductTypeAt(int index);

		public void RemoveProductAt(int index);

		public void RemoveClientAt(int index);

		public void RemoveOrderAt(int index);

		public bool CanAddProductType();

		public bool CanAddClient();

		public bool CanAddProduct();

		public bool CanAddOrder();

		public bool CanCalculateTotalIncome();
	}
}

