using System;

namespace WarehouseApp
{

	public class Product
	{
		private string _id;
		private string _wareType;
		private string _name;
		private double _unitStoragePrice;

		public string Id
        {
			get => _id;
			set => _id = value;
		}

		public string WareType
        {
			get => _wareType;
			set => _wareType = value;
		}

		public string Name
        {
			get => _name;
			set => _name = value;
		}
		/// <summary>
        /// How much it costs to keep this product in warehouse.
        /// This is the price organization that keeps the warehouse should pay per unit of this product.
        /// </summary>
		public double UnitStoragePrice
        {
			get => _unitStoragePrice;
			set => _unitStoragePrice = value;
		}
		public Product()
		{
			_name = "";
			_wareType = "";
			_id = "";
			_unitStoragePrice = 0;

		}

		public Product(string wareType, string name, double unitStoragePrice)
		{
			_id = Guid.NewGuid().ToString();
			_wareType = wareType;
			_name = name;
			_unitStoragePrice = unitStoragePrice;
		}
	}
}

