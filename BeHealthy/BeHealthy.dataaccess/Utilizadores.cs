using System;
using System.Collections.Generic;
using System.Text;
using BeHealthy.entities;
using System.Data.SqlClient;

namespace BeHealthy.dataaccess
{
    public static class Utilizadores
    {
        private static string connectionString = "";
        private static SqlConnection conn;
        private static SqlCommand command;


        public static int InsertUtilizador(Utilizador utilizador)
        {
            int res = 0;
            string query;

            conn = new SqlConnection(connectionString);
            command = new SqlCommand();

            query = string.Format("Insert into Utilizadores " +
                "(Username, Password)" +
                "values ('{0}', '{1}')",
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
        public static List<Utilizador> SelectAllUtilizadores()
        {

            SqlDataReader dataReader;
            List<Utilizador> Utilizadores = new List<Utilizador>();
            Utilizador u1;
            string query = string.Empty;

            conn = new SqlConnection(connectionString);

            command = new SqlCommand("select idutilizador , username, password  from Utilizadores", conn);

            conn.Open();

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                u1 = new Utilizador();
                u1.IDUtilizador = int.Parse(dataReader.GetValue(0).ToString());
                u1.Username = dataReader.GetValue(1).ToString();
                u1.Password = dataReader.GetValue(2).ToString();

            }

            return Utilizadores;
        }



    }
}