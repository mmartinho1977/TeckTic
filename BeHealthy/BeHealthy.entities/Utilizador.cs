using System;
using System.Collections.Generic;
using System.Text;

namespace BeHealthy.entities
{
    public class Utilizador
    {
        private int idutilizador;
        private string username;
        private string password;

        public Utilizador()
        {

        }

        public Utilizador(string username)
        {
            this.username = username;
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public int IDUtilizador
        {
            get { return idutilizador; }
            set { idutilizador = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

    }
}
