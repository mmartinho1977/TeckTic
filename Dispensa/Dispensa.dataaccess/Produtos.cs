using System;
using System.Collections.Generic;
using System.Text;
using Pantry.entities;
using System.Data.SqlClient;


namespace Pantry.dataaccess
{
    public static class Produtos
    {
        private static string connectionString = "Server=localhost; Initial Catalog=Pantry;Trusted_Connection = true;";
        private static SqlConnection conn;
        private static SqlCommand command;
        private static string format = "yyyy-MM-dd HH:mm:ss";


        public static int InsertProtuto(Produto produto)
        {
            int res = 0;
            string query;

            conn = new SqlConnection(connectionString);
            command = new SqlCommand();



            query = string.Format("Insert into Produto (Descricao, Preco, " +
                "QuantidadeAtual, QuantidadeMaxima, QuantidadeMinima, DataCompra, CodigoCategoria) " +
                                         "Values ('{0}', {1}, {2}, {3}, {4}, '{5}', {6});",
                                         produto.Descricao,
                                         produto.Preco.ToString().Replace(',', '.'),
                                         produto.QuantidadeAtual,
                                         produto.QuantidadeMaxima,
                                         produto.QuantidadeMinima,
                                         produto.DataCompra.ToString(format),
                                         produto.Categoria.Id);

            command.CommandText = query;
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = conn;

            conn.Open();

            res = command.ExecuteNonQuery();

            conn.Close();

            return res;
        }

        public static int DeleteProtuto(int codigo)
        {
            int res = 0;
            string query;

            conn = new SqlConnection(connectionString);
            command = new SqlCommand();


            query = string.Format("Delete from Produto Where Codigo = {0};",
                                         codigo);

            command.CommandText = query;
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = conn;

            conn.Open();

            res = command.ExecuteNonQuery();

            conn.Close();

            return res;
        }

        public static int UpdateProtuto(Produto produto)
        {
            int res = 0;
            string query;

            conn = new SqlConnection(connectionString);
            command = new SqlCommand();

            query = string.Format("Update Produto set " +
                                                "Descricao = '{0}', " +
                                                "Preco = {1}, " +
                                                "QuantidadeAtual = {2}, " +
                                                "QuantidadeMaxima = {3}, " +
                                                "QuantidadeMinima = {4}, " +
                                                "DataCompra = '{5}', " +
                                                "CodigoCategoria = {6} " +
                                                "Where Codigo = {7}; ",
                                         produto.Descricao,
                                         produto.Preco.ToString().Replace(',', '.'),
                                         produto.QuantidadeAtual,
                                         produto.QuantidadeMaxima,
                                         produto.QuantidadeMinima,
                                         produto.DataCompra.ToString(format),
                                         produto.Categoria.Id,
                                         produto.Codigo);

            command.CommandText = query;
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = conn;

            conn.Open();

            res = command.ExecuteNonQuery();

            conn.Close();

            return res;
        }
        public static List<Produto> SelectAllProdutos()
        {
            SqlDataReader dataReader;
            List<Produto> produtos = new List<Produto>();
            Produto p1;
            string query = string.Empty;

            conn = new SqlConnection(connectionString);

            command = new SqlCommand("select Codigo, Descricao, Preco from Produto", conn);

            conn.Open();

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                p1 = new Produto();
                p1.Codigo = int.Parse(dataReader.GetValue(0).ToString());
                p1.Descricao = dataReader.GetValue(1).ToString();
                p1.Preco = decimal.Parse(dataReader.GetValue(2).ToString());
                produtos.Add(p1);
            }

           
            conn.Close();

            return produtos;
        }

        public static List<Produto> SelectProdutosByCategoria(string categoria)
        {
            SqlDataReader dataReader;
            List<Produto> produtos = new List<Produto>();
            Produto p1;
            string query = string.Empty;

            conn = new SqlConnection(connectionString);

            query = string.Format("select Codigo, Descricao, Preco, Categoria" +
                "from Produto WHERE Categoria = '{0}'", categoria);

            command = new SqlCommand(query, conn);

            conn.Open();

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                p1 = new Produto();
                p1.Codigo = int.Parse(dataReader.GetValue(0).ToString());
                p1.Descricao = dataReader.GetValue(1).ToString();
                p1.Preco = decimal.Parse(dataReader.GetValue(2).ToString());
                produtos.Add(p1);
            }


            conn.Close();

            return produtos;
        }


        /// <summary>
        /// Vai buscar à base de dados um produto através do seu código
        /// </summary>
        /// <param name="codigo"> Codigo do produto a procurar</param>
        /// <returns></returns>
        public static Produto SelectProdutosByCodigo(int codigo)
        {
            SqlDataReader dataReader;
            Produto p1;
            string query = string.Empty;

            conn = new SqlConnection(connectionString);

            query = string.Format("select Codigo, Descricao, Preco, QuantidadeAtual, QuantidadeMinima, QuantidadeMaxima, DataCompra, CodigoCategoria " +
                "from Produto WHERE Codigo = {0}", codigo);

            command = new SqlCommand(query, conn);

            conn.Open();

            dataReader = command.ExecuteReader();

            p1 = new Produto();
            while (dataReader.Read())
            {

                p1.Codigo = int.Parse(dataReader.GetValue(0).ToString());
                p1.Descricao = dataReader.GetValue(1).ToString();
                p1.Preco = decimal.Parse(dataReader.GetValue(2).ToString());
                p1.QuantidadeAtual = int.Parse(dataReader.GetValue(3).ToString());
                p1.QuantidadeMinima = int.Parse(dataReader.GetValue(4).ToString());
                p1.QuantidadeMaxima = int.Parse(dataReader.GetValue(5).ToString());
                p1.DataCompra = DateTime.Parse(dataReader.GetValue(6).ToString());
                //p1.Categoria.Id = int.Parse(dataReader.GetValue(7).ToString());

                p1.Categoria = Categorias.SelectCategoriasByCodigo(int.Parse(dataReader.GetValue(7).ToString()));
            }


            conn.Close();

            return p1;
        }


        /// <summary>
        /// Recolhe da base de dados o ultimo código criado
        /// </summary>
        /// <returns>Código mais alto dos produtos guardados</returns>
        public static int GetProductId()
        {
            int codigo = 0;
            SqlDataReader dataReader;
            string query = string.Empty;

            conn = new SqlConnection(connectionString);

            //esta query atravez da funçao MAX() retorma o id mais alto da base de dados
            command = new SqlCommand("select MAX(Codigo) from Produto", conn);

            conn.Open();

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                codigo = int.Parse(dataReader.GetValue(0).ToString());
            }

            conn.Close();

            return codigo;
        }
    }
}
