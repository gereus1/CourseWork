using System;
namespace WarehouseApp
{
	public class User
	{
		private string _login;
		private string _password;
		private string _role;

		public string Login
        {
			get => _login;
			set => _login = value;
		}

		public string Password
        {
			get => _password;
			set => _password = value;
		}

		public string Role
        {
			get => _role;
			set => _role = value;
		}

		public User(string login, string password, string role)
		{
			_login = login;
			_password = password;
			_role = role;
		}

		public User()
        {
			_login = "";
			_password = "";
			_role = "guest";
        }
	}
}

