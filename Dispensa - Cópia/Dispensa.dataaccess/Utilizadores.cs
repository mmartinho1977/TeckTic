using Pantry.entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Pantry.dataaccess
{
    public static class Utilizadores
    {
        private static string connectionString = "Server=martasqlserver.database.windows.net; Initial Catalog=MyPantry;User ID=mmartinho;Password=Lj11ORWy;";
        private static SqlConnection conn;
        private static SqlCommand command;


        public static string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }


        public static int InsertUtilizador(Utilizador utilizador)
        {
            int res = 0;
            string query = "";

            conn = new SqlConnection(connectionString);
            command = new SqlCommand();

            query = string.Format("Insert into Utilizadores (Username, Password) Values ('{0}', HASHBYTES ('SHA2_512', '{1}'));", utilizador.Username, utilizador.Password);

            command.CommandText = query;
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = conn;

            conn.Open();

            res = command.ExecuteNonQuery();

            conn.Close();

            return res;
        }

        public static int ExistsUtilizador(string username, string password)
        {
            int res = 0;
            SqlDataReader dataReader;
            string query = string.Empty;


            conn = new SqlConnection(connectionString);

            query = string.Format("Select Username from Utilizadores WHERE Username = '{0}' and Password = HASHBYTES('SHA2_512', '{1}')", username, password);

            command = new SqlCommand(query, conn);

            conn.Open();

            dataReader = command.ExecuteReader();

            if (dataReader.HasRows)
            {
                res = 1;
            }

            conn.Close();

            return res;
        }

        public static List<Utilizador> SelectAllUtilizadores()
        {
            SqlDataReader dataReader;
            List<Utilizador> utilizadores = new List<Utilizador>();
            Utilizador u1;
            string query = string.Empty;

            conn = new SqlConnection(connectionString);

            command = new SqlCommand("select username, password from utilizadores", conn);

            conn.Open();

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                u1 = new Utilizador();
                u1.Username = dataReader.GetValue(0).ToString();
                u1.Password = dataReader.GetValue(1).ToString();
                utilizadores.Add(u1);
            }


            conn.Close();

            return utilizadores;
        }
    }
}
