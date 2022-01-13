using System;
using System.Collections.Generic;
using System.Text;
using BeHealthy.entities;
using System.Data.SqlClient;

namespace BeHealthy.dataaccess
{
    public static class TipoAlimentos
    {
        private static string connectionString = "Server=PC-211-05\\SQLEXPRESS;Initial Catalog = BeHealthy; User ID= user; password= 12345";
        private static SqlConnection conn;
        private static SqlCommand command;


        public static int InsertTipoAlimento(TipoAlimento tipoAlimento)
        {
            int res = 0;
            string query;

            conn = new SqlConnection(connectionString);
            command = new SqlCommand();

            query = string.Format("Insert into TipoAlimentos " +
                "(Descricao)" +
                "values ('{0}')",
                tipoAlimento.Descricao);

            command.CommandText = query;
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = conn;

            conn.Open();

            res = command.ExecuteNonQuery();

            conn.Close();

            return res;
        }
        public static List<TipoAlimento> SelectAllTipoAlimentos()
        {

            SqlDataReader dataReader;
            List<TipoAlimento> tipoAlimentos = new List<TipoAlimento>();
            TipoAlimento tp1;
            string query = string.Empty;

            conn = new SqlConnection(connectionString);

            command = new SqlCommand("select IDTipoAlimentos , descricao from TipoAlimentos", conn);

            conn.Open();

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                tp1 = new TipoAlimento();
                tp1.IDTipoAlimentos = int.Parse(dataReader.GetValue(0).ToString());
                tp1.Descricao = dataReader.GetValue(1).ToString();

                tipoAlimentos.Add(tp1);

            }

            return tipoAlimentos;
        }
        public static TipoAlimento SelectTipoAlimentosById(int ID)
        {

            SqlDataReader dataReader;
            TipoAlimento ta1;
            string query = string.Empty;

            query = string.Format("Select  IDTipoAlimentos, Descricao, from TipoAlimentos where IDTipoAlimentos = {0}", ID);

            conn = new SqlConnection(connectionString);
            command = new SqlCommand(query, conn);
            conn.Open();
            dataReader = command.ExecuteReader();

            ta1 = new TipoAlimento();
            while (dataReader.Read())
            {
                ta1.IDTipoAlimentos = int.Parse(dataReader.GetValue(0).ToString());
                ta1.Descricao = dataReader.GetValue(1).ToString();
            
            }
            return ta1;
        }

        public static int DelectTipoAlimentos(int IDTipoAlimentos)
        {
            int res = 0;
            string query;

            conn = new SqlConnection(connectionString);
            command = new SqlCommand();

            query = string.Format(" delete TipoAlimentos where IDTipoAlimentos= {0};", IDTipoAlimentos);

            command.CommandText = query;
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = conn;

            conn.Open();
            res = command.ExecuteNonQuery();

            conn.Close();

            return res;

        }

        public static int UpdateTipoAlimentos(TipoAlimento tipoAlimento)
        {
            int res = 0;
            string query;

            conn = new SqlConnection(connectionString);
            command = new SqlCommand();

            query = string.Format(" Update TipoAlimentos set  " +
                "Descricao = '{0}' WHERE IDTipoAlimentos = {1} ",
                tipoAlimento.Descricao,
               tipoAlimento.IDTipoAlimentos);

            command.CommandText = query;
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = conn;

            conn.Open();
            res = command.ExecuteNonQuery();

            conn.Close();

            return res;
        }



    }
}