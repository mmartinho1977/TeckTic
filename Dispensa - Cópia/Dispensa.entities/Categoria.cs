using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry.entities
{
    public class Categoria
    {
		private int id;
		private string descricao;

		public Categoria() { }

		public string Descricao
		{
			get { return descricao; }
			set { descricao = value; }
		}


		public int Id
		{
			get { return id; }
			set { id = value; }
		}

	}
}
