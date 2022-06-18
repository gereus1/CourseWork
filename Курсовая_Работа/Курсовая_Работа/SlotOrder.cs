using System;
namespace WarehouseApp
{
	public class SlotOrder
	{
		private Client _client;
		private Product _product;
		private double _pricePerUnit;
		private int _unitsCount;

		public Client Client
        {
            get => _client;
			set => _client = value;
		}

		public Product Product
        {
			get => _product;
			set => _product = value;
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

		public SlotOrder ()
        {
			_client = null;
			_product = null;
			_pricePerUnit = 0;
			_unitsCount = 0;
		}
		public SlotOrder(Client client, Product product, double pricePerUnit, int unitsCount)
		{
			_client = client;
			_product = product;
			_pricePerUnit = pricePerUnit;
			_unitsCount = unitsCount;
		}

	}
}

