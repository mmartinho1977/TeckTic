using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using BeHealthy.entities;

namespace BeHealthy.dataaccess
{
    public static class Alimentos
    {
        private static string connectionString = "Server=PC-211-05\\SQLEXPRESS;Initial Catalog = BeHealthy; User ID= user; password= 12345";
        private static SqlConnection conn;
        private static SqlCommand comand;

        public static int InserirAlimento(Alimento alimento)
        {
            int res = 0;
            string query;

            conn = new SqlConnection(connectionString);
            comand = new SqlCommand();

            query = string.Format("  insert into alimentos  " +
                "( Nome, Descricao, ValorEnergetico, Lipidos, Hidratos, Sal, Fibra, Proteina, Ferro, Imagem, IDUtilizador, IDTipoAlimentos)" +
                "values('{0}','{1}',{2},{3},{4},{5},{6},{7},{8},'{9}',{10},{11})",
              
                alimento.Nome,
                alimento.Descricao,
                alimento.ValorEnergetico,
                alimento.Lipidos,
                alimento.Hidratos,
                alimento.Sal,
                alimento.Fibra,
                alimento.Proteina,
                alimento.Ferro,
                alimento.Imagem,
                alimento.IDUtilizador,
                alimento.IDTipoAlimentos);

            comand.CommandText = query;
            comand.CommandType = System.Data.CommandType.Text;
            comand.Connection = conn;

            conn.Open();

            res = comand.ExecuteNonQuery();

            conn.Close();

            return res;
        }

        public static List<Alimento> SelectAllAlimentos()
        {

            SqlDataReader dataReader;
            List<Alimento> alimentos = new List<Alimento>();
            Alimento a1;
            string query = string.Empty;

            conn = new SqlConnection(connectionString);
            comand = new SqlCommand(" Select  IdAlimento, Nome, Descricao, ValorEnergetico, Lipidos, Hidratos, Sal, Fibra, Proteina, Ferro, Imagem, IDUtilizador, IDTipoAlimentos  from Alimentos", conn);
            conn.Open();
            dataReader = comand.ExecuteReader();
            while (dataReader.Read())
            {
                a1 = new Alimento();
                a1.Id = int.Parse(dataReader.GetValue(0).ToString());
                a1.Nome = dataReader.GetValue(1).ToString();
                a1.Descricao = dataReader.GetValue(2).ToString();
                a1.ValorEnergetico = int.Parse(dataReader.GetValue(3).ToString());
                a1.Lipidos = float.Parse(dataReader.GetValue(4).ToString());
                a1.Hidratos = float.Parse(dataReader.GetValue(5).ToString());
                a1.Sal = float.Parse(dataReader.GetValue(6).ToString());
                a1.Fibra = float.Parse(dataReader.GetValue(7).ToString());
                a1.Proteina = float.Parse(dataReader.GetValue(8).ToString());
                a1.Ferro = float.Parse(dataReader.GetValue(9).ToString());
                a1.Imagem = dataReader.GetValue(10).ToString();
                a1.IDUtilizador = int.Parse(dataReader.GetValue(11).ToString());
                a1.IDTipoAlimentos = int.Parse(dataReader.GetValue(12).ToString());

                alimentos.Add(a1);
            }
            return alimentos;
        }

        public static Alimento SelectAlimentoById(int ID)
        {

            SqlDataReader dataReader;
            Alimento a1;
            string query = string.Empty;

            query = string.Format("Select  IdAlimento, Nome, Descricao, ValorEnergetico, Lipidos, Hidratos, Sal, Fibra, Proteina, " +
                "Ferro, Imagem, IDUtilizador, IDTipoAlimentos  from Alimentos where IDAlimento = {0}", ID);

            conn = new SqlConnection(connectionString);
            comand = new SqlCommand(query, conn);
            conn.Open();
            dataReader = comand.ExecuteReader();

            a1 = new Alimento();
            while (dataReader.Read())
            {
                a1.Id = int.Parse(dataReader.GetValue(0).ToString());
                a1.Nome = dataReader.GetValue(1).ToString();
                a1.Descricao = dataReader.GetValue(2).ToString();
                a1.ValorEnergetico = int.Parse(dataReader.GetValue(3).ToString());
                a1.Lipidos = float.Parse(dataReader.GetValue(4).ToString());
                a1.Hidratos = float.Parse(dataReader.GetValue(5).ToString());
                a1.Sal = float.Parse(dataReader.GetValue(6).ToString());
                a1.Fibra = float.Parse(dataReader.GetValue(7).ToString());
                a1.Proteina = float.Parse(dataReader.GetValue(8).ToString());
                a1.Ferro = float.Parse(dataReader.GetValue(9).ToString());
                a1.Imagem = dataReader.GetValue(10).ToString();
                a1.IDUtilizador = int.Parse(dataReader.GetValue(11).ToString());
                a1.IDTipoAlimentos = int.Parse(dataReader.GetValue(12).ToString());

               
            }
            return a1;
        }

        public static int DelectAlimentos(int IDAlimento)
        {
            int res = 0;
            string query;

            conn = new SqlConnection(connectionString);
            comand = new SqlCommand();

            query = string.Format(" delet from Alimentos where IDAlimento= {0};", IDAlimento);

            comand.CommandText = query;
            comand.CommandType = System.Data.CommandType.Text;
            comand.Connection = conn;

            conn.Open();
            res = comand.ExecuteNonQuery();

            conn.Close();

            return res ;

        }

        public static int UpdateAlimentos(Alimento alimento)
        {
            int res = 0;
            string query;

            conn = new SqlConnection(connectionString);
            comand = new SqlCommand();

            query = string.Format(" Update Produto set  " +
                "Nome = '{0}', Descricao = '{1}', ValorEnergetico = {2}, Lipidos = {3}, Hidratos = {4}, Sal = {5}," +
                " Fibra = {6}, Proteina = {7}, Ferro = {8}, Imagem= '{9}', IDUtilizador = {10}, IDTipoAlimentos= {11}, WHERE CODIGO = {12} ",
                alimento.Nome,
                alimento.Descricao,
                alimento.ValorEnergetico.ToString().Replace(',','.'),
                alimento.Lipidos.ToString().Replace(',', '.'),
                alimento.Hidratos.ToString().Replace(',', '.'),
                alimento.Sal.ToString().Replace(',', '.'),
                alimento.Fibra.ToString().Replace(',', '.'),
                alimento.Proteina.ToString().Replace(',', '.'),
                alimento.Ferro.ToString().Replace(',', '.'),
                alimento.Imagem,
                alimento.IDUtilizador,
                alimento.IDTipoAlimentos,
                alimento.Id ) ;

            comand.CommandText = query;
            comand.CommandType = System.Data.CommandType.Text;
            comand.Connection = conn;

            conn.Open();
            res = comand.ExecuteNonQuery();

            conn.Close();

            return res;         
        }
        

    }
}
