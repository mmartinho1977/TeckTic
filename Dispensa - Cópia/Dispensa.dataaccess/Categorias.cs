using Pantry.entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Pantry.dataaccess
{
    static public class Categorias
    {
        private static string connectionString; //= "Server=localhost; Initial Catalog=Pantry;User ID=sa;Password=Lj11ORWy;";
        private static SqlConnection conn;
        private static SqlCommand command;

  

        public static string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }





        public static int InsertCategoria(Categoria categoria)
        {
            int res = 0;
            string query;

            conn = new SqlConnection(connectionString);
            command = new SqlCommand();



            query = string.Format("Insert into Categoria (Descricao) " +
                                         "Values ('{0}'",
                                         categoria.Descricao);

            command.CommandText = query;
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = conn;

            conn.Open();

            res = command.ExecuteNonQuery();

            conn.Close();

            return res;
        }

        public static int DeleteCategoria(int codigo)
        {
            int res = 0;
            string query;

            conn = new SqlConnection(connectionString);
            command = new SqlCommand();


            query = string.Format("Delete from Categoria Where Codigo = {0};",
                                         codigo);

            command.CommandText = query;
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = conn;

            conn.Open();

            res = command.ExecuteNonQuery();

            conn.Close();

            return res;
        }


        public static int UpdateCategoria(Categoria categoria)
        {
            int res = 0;
            string query;

            conn = new SqlConnection(connectionString);
            command = new SqlCommand();

            query = string.Format("Update Categoria set " +
                                                "Descricao = '{0}', " +
                                                "Where Codigo = {1}; ",
                                         categoria.Descricao,
                                         categoria.Id);

            command.CommandText = query;
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = conn;

            conn.Open();

            res = command.ExecuteNonQuery();

            conn.Close();

            return res;
        }

        public static List<Categoria> SelectAllCategorias()
        {
            SqlDataReader dataReader;
            List<Categoria> categorias = new List<Categoria>();
            Categoria c1;
            string query = string.Empty;

            conn = new SqlConnection(connectionString);

            command = new SqlCommand("select Codigo, Descricao from Categoria", conn);

            conn.Open();

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                c1 = new Categoria();
                c1.Id = int.Parse(dataReader.GetValue(0).ToString());
                c1.Descricao = dataReader.GetValue(1).ToString();
                categorias.Add(c1);
            }


            conn.Close();

            return categorias;
        }

        public static Categoria SelectCategoriasByCodigo(int codigo)
        {
            SqlDataReader dataReader;
           Categoria categoria = new Categoria();
            string query = string.Empty;

            conn = new SqlConnection(connectionString);

            query = string.Format("select Codigo, Descricao from Categoria Where codigo = {0}", codigo);
            command = new SqlCommand(query, conn);

            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }
            

            dataReader = command.ExecuteReader();

            categoria = new Categoria();
            while (dataReader.Read())
            {
                categoria.Id = int.Parse(dataReader.GetValue(0).ToString());
                categoria.Descricao = dataReader.GetValue(1).ToString();
            }

            conn.Close();

            return categoria;
        }

    }
}
