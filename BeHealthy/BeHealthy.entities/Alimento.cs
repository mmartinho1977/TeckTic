using System;
using System.Collections.Generic;
using System.Text;

namespace BeHealthy.entities
{
    public class Alimento
    {
        private int id;
        private string nome;
        private string descricao;
        private int valorenergetico;
        private float lipidos;
        private float hidratos;
        private float sal;
        private float fibra;
        private float proteina;
        private float ferro;
        private string imagem;
        private int idutilizador;
        private int idtipoalimentos;

        public Alimento()
        {

        }

        public Alimento(string descricao)
        {
            this.descricao = descricao;
        }

        public float Lipidos
        {
            get { return lipidos; }
            set { lipidos = value; }
        }

        public int ValorEnergetico
        {
            get { return valorenergetico; }
            set { valorenergetico = value; }
        }

        public float Hidratos
        {
            get { return hidratos; }
            set { hidratos = value; }
        }

        public float Sal
        {
            get { return sal; }
            set { sal = value; }
        }

        public float Fibra
        {
            get { return fibra; }
            set { fibra = value; }
        }

        public float Proteina
        {
            get { return proteina; }
            set { proteina = value; }
        }

        public float Ferro
        {
            get { return ferro; }
            set { ferro = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Imagem
        {
            get { return imagem; }
            set { imagem = value; }
        }

        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        public int IDTipoAlimentos
        {
            get { return idtipoalimentos; }
            set { idtipoalimentos = value; }
        }

        public int IDUtilizador
        {
            get { return idutilizador; }
            set { idutilizador = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
