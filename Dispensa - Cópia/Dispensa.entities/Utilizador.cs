using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.entities
{
    public class Utilizador
    {
		private int id;
		private string username;
		private string password;

		public Utilizador() { }

		public string Password
		{
			get { return password; }
			set { password = value; }
		}


		public string Username
		{
			get { return username; }
			set { username = value; }
		}


		public int Id
		{
			get { return id; }
			set { id = value; }
		}

	}
}
