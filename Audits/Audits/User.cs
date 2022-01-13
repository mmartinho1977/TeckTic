using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audits
{
    public class User
    {
		//private properties
		private int id;
		private string code;
		private string name;
		private string profile;
		private bool externalAccessAllowed;
		private DateTime passwordDateSet;
		private string username;

		public string Username
		{
			get { return username; }
			set { username = value; }
		}



		/// <summary>
		/// Empty constructor
		/// </summary>
		public User() { }


		/// <summary>
		/// Password setting date
		/// </summary>
		public DateTime PasswordDateSet
		{
			get { return passwordDateSet; }
			set { passwordDateSet = value; }
		}

		/// <summary>
		/// If user have external acce
		/// </summary>
		public bool ExternalAccessAllowed
		{
			get { return externalAccessAllowed; }
			set { externalAccessAllowed = value; }
		}

		/// <summary>
		/// 
		/// </summary>
		public string Profile
		{
			get { return profile; }
			set { profile = value; }
		}

		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			get { return name; }
			set { name = value; }
		}


		/// <summary>
		/// 
		/// </summary>
		public string Code
		{
			get { return code; }
			set { code = value; }
		}

		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		/// <summary>
		/// Object user ToString() override
		/// </summary>
		/// <returns>User string formate</returns>
		public override string ToString()
		{
			return string.Format("[{0}] {1}", this.code, this.name);
		}

		private int InsertUser()
		{
			int result;
			SqlConnection connection;
			SqlCommand command;
			string query;

			connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

			query = string.Format("INSERT INTO [dbo].[Users]" +
									"           ([Code]" +
									"           ,[Name]" +
									"           ,[Profile]" +
									"           ,[ExternalAccessAllowed]" +
									"           ,[PasswordDateSet]" +
									"           ,[Username]" +
									"           ,[Active]" +
									"           ,[CreationDate]" +
									"           ,[UpdateDate])" +
									"     VALUES" +
									"			('{0}')" +
									"			, '{1}'" +
									"			, '{2}'" +
									"			, {3}" +
									"			, '{4}'" +
									"			, '{5}'" +
									"			, 1" +
									"			, GetDate()" +
									"			, GetDate())", this.code,
															this.name,
															this.profile,
															this.externalAccessAllowed,
															this.passwordDateSet,
															this.username);

			command = new SqlCommand(query, connection);

			connection.Open();

			result = command.ExecuteNonQuery();

			connection.Close();

			return result;

		}


		private int UpdateUser()
		{
			int result;
			SqlConnection connection;
			SqlCommand command;
			string query;

			connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

			query = string.Format("insert into users (code, username, name, username");

			command = new SqlCommand(query, connection);

			connection.Open();

			result = command.ExecuteNonQuery();

			connection.Close();

			return result;

		}


		public bool ExistUser(string username)
		{
			SqlConnection connection;
			SqlCommand command;
			SqlDataReader dataReader;
			string query;
			bool exist = false;

			connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString);

			query = string.Format("Select id from Users where username = '{0}'", username);

			command = new SqlCommand(query, connection);

			connection.Open();

			dataReader = command.ExecuteReader();

			if (dataReader.HasRows)
			{
				exist = true;
			}

			connection.Close();			
			
			return exist;
		}
	}
}
