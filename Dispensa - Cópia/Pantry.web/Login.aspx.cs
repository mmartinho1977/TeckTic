using Pantry.dataaccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pantry.web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SignInButton_Click(object sender, EventArgs e)
        {
            //Declaracao de variáveis
            string username, password;
            int res;

            //Guardar os valores inseridos no formulário de login nas variáveis criadas
            username = txtUsername.Text; //Valor inserido na textbox de username
            password = txtPassword.Text; //valor inserido na textbox password

            //Validar na base de dados se as credenciais de utilizador sao válidas
            res = Utilizadores.ExistsUtilizador(username, password);

            //Executa o código se o utilizador existir
            if (res > 0)
            {
                //Guardar username numa variável de sessºao
                Session["ActualUser"] = username; //assim o username passa entre páginas
                //Abrir nova página 
                Response.Redirect("HomePage.aspx");
            }
            //caso nºao exista
            else
            {
                //Abre uma janela de mensagem com o erro
                Response.Write("<script>alert('Credenciais Inválidas');</script>");
                //Limpar valores das textboxs
                txtUsername.Text = "";
                txtPassword.Text = "";

            }
        }
    }
}