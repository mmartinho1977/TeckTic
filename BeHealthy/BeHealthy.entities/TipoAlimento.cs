using System;
using System.Collections.Generic;
using System.Text;

namespace BeHealthy.entities
{
    public class TipoAlimento
    {
        private int idtipoalimentos;
        private string descricao;

        public TipoAlimento()
        {

        }

        public TipoAlimento(string descricao)
        {
            this.descricao = descricao;
        }

        public int IDTipoAlimentos
        {
            get { return idtipoalimentos; }
            set { idtipoalimentos = value; }
        }

        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
    }
}
