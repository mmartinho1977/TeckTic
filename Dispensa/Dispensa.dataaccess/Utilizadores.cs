using Pantry.entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Pantry.dataaccess
{
    public static class Utilizadores
    {
        private static string connectionString = "Server=localhost; Initial Catalog=Pantry;Trusted_Connection = true;";
        private static SqlConnection conn;
        private static SqlCommand command;

        public static int InsertUtilizador(Utilizador utilizador)
        {
            

        int res = 0;
            string query;

            conn = new SqlConnection(connectionString);
            command = new SqlCommand();



            query = string.Format("Insert into Utilizador (Username, Password) " +
                                         "Values ('{0}', HASHBYTES('SHA2_512', '{1}'));",
                                         utilizador.Username,
                                         utilizador.Password);

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

            query = string.Format("select Username " +
                "from Utilizadores WHERE Username = '{0}' and Password =  HASHBYTES('SHA2_512', '{1}')", username, password);

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
    }
}
