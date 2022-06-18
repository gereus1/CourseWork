using System;
namespace WarehouseApp
{
	public interface ILoginManager
	{
		public bool Login(string organizationId, string login, string password);

		public void Logout();
	}
}

