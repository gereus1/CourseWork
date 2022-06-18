using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using WarehouseApp;

namespace WarehouseApp
{
	public class OrganizationManager: IOrganizationManager, ILoginManager
	{
        private string _organizationsPath;
        private Organization _organization = null;
        private string _activeRole = null;
		public OrganizationManager(string organizationsFilePath)
		{
            _organizationsPath = organizationsFilePath;
		}

        public List<string> ProductTypes
        {
            get
            {
                if (_organization != null)
                    return _organization.ProductTypes;
                return new List<string>();
            }
        }

        public List<Product> Products
        {
            get
            {
                if (_organization != null)
                    return _organization.Products;
                return new List<Product>();
            }
        }

        public List<Client> Clients
        {
            get
            {
                if (_organization != null)
                    return _organization.Clients;
                return new List<Client>();
            }
        }

        public List<SlotOrder> Orders
        {
            get
            {
                if (_organization != null)
                    return _organization.Orders;
                return new List<SlotOrder>();
            }
        }

        public string OrganizationName
        {
            get
            {
                if (_organization != null)
                    return _organization.Name;
                return "";
            }
        }

        public double TotalIncome
        {
            get
            {
                double totalIncome = 0;
                if (_organization == null)
                    return totalIncome;
                foreach (SlotOrder order in _organization.Orders)
                {
                    totalIncome += order.TotalPrice;
                }
                return totalIncome;
            }
        }

        public double TotalOutcome
        {
            get
            {
                double totalOutcome = 0;
                if (_organization == null)
                    return totalOutcome;
                foreach (SlotOrder order in _organization.Orders)
                {
                    totalOutcome += order.Product.UnitStoragePrice * order.UnitsCount;
                }
                return totalOutcome;
            }
        }

        public void AddClient(string name)
        {
            if (_organization == null)
                return;

            Client newClient = new Client(name);
            _organization.AddClient(newClient);

            SaveChanges();
        }

        public void AddOrder(Client client, Product product, double pricePerUnit, int unitsCount)
        {
            if (_organization == null)
                return;

            _organization.AddOrder(product, client, pricePerUnit, unitsCount);
            SaveChanges();
        }

        public void AddProduct(string name, string productType, double storagePrice)
        {
            if (_organization == null)
                return;

            Product product = new Product(productType, name, storagePrice);
            _organization.AddProduct(product);
            SaveChanges();
        }

        public void AddProductType(string productType)
        {
            if (_organization == null)
                return;

            _organization.AddProductType(productType);
            SaveChanges();
        }

        public double IncomeFromClient(string clientId)
        {
            if (_organization == null)
                return 0;

            double totalIncome = 0;
            foreach (SlotOrder order in _organization.Orders)
            {
                if (order.Client.Id == clientId)
                {
                    totalIncome += order.TotalPrice;
                }
            }
            return totalIncome;
        }

        public bool Login(string organizationId, string login, string password)
        {
            string fullOrgPath = $"{_organizationsPath}/{organizationId}/organization.json";
            string jsonString = File.ReadAllText(fullOrgPath);
            Organization organization = JsonSerializer.Deserialize<Organization>(jsonString);

            // Organization not found
            if (organization == null)
                return false;

            foreach (User user in organization.Users)
            {
                // User with login and password found
                if (user.Login == login && user.Password == password)
                {
                    _activeRole = user.Role;
                    _organization = organization;
                    return true;
                }
            }
            return false;
        }

        public void Logout()
        {
            _activeRole = null;
            _organization = null;
        }

        public bool CanAddProductType()
        {           
                return _activeRole == "admin";
        }

        public bool CanAddProduct()
        {
            return _activeRole == "admin";
        }

        public bool CanAddClient()
        {
            var t = (_activeRole == "admin" || _activeRole == "manager");
            return t;
        }

        public bool CanAddOrder()
        {
            var t = (_activeRole == "admin" || _activeRole == "manager");
            return t;
        }

        public bool CanCalculateTotalIncome()
        {
           return _activeRole == "admin";
        }

        private async void SaveChanges()
        {
            string fullOrgPath = $"{_organizationsPath}/{_organization!.Id}/organization.json";
            using FileStream createStream = File.Create(fullOrgPath);
            await JsonSerializer.SerializeAsync(createStream, _organization!);
            await createStream.DisposeAsync();
        }
        public void RemoveProductTypeAt(int index)
        {
            ProductTypes.RemoveAt(index);
            SaveChanges();
        }

        public void RemoveProductAt(int index)
        {
            Products.RemoveAt(index);
            SaveChanges();
        }

        public void RemoveClientAt(int index)
        {
            Clients.RemoveAt(index);
            SaveChanges();
        }

        public void RemoveOrderAt (int index)
        {
            Orders.RemoveAt(index);
            SaveChanges();
        }
    }
}

