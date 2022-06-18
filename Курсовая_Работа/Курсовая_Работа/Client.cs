using System;
namespace WarehouseApp
{
	public class Client
	{

		private string _id;
		private string _name;

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

		public Client()
        {
			_id = "";
			_name = "";
        }

		public Client(string name)
		{
			_id = Guid.NewGuid().ToString();
			_name = name;
		}
	}
}

