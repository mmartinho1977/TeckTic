using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.entities
{
    public class Produto
    {

		private int codigo;
		private string descricao;
		private decimal preco;
		private int quantidadeAtual;
		private int quantidadeMaxima;
		private int quantidadeMinima;
		private Categoria categoria;
		private DateTime dataCompra;				

		

		public Produto()
		{

		}


		public DateTime DataCompra
		{
			get { return dataCompra; }
			set { dataCompra = value; }
		}


		public Produto(string descricao)
		{
			this.descricao = descricao;
		}

		public Categoria Categoria
		{
			get { return categoria; }
			set {
				if (categoria == null)
					categoria = new Categoria();
				categoria = value; }
		}


		public int QuantidadeMinima
		{
			get { return quantidadeMinima; }
			set { quantidadeMinima = value; }
		}



		public int QuantidadeMaxima
		{
			get { return quantidadeMaxima; }
			set { quantidadeMaxima = value; }
		}


		public int QuantidadeAtual
		{
			get { return quantidadeAtual; }
			set { quantidadeAtual = value; }
		}


		public decimal Preco
		{
			get { return preco; }
			set { preco = value; }
		}


		public string Descricao
		{
			get { return descricao; }
			set { descricao = value; }
		}


		public int Codigo
		{
			get { return codigo; }
			set { codigo = value; }
		}


	}
}
