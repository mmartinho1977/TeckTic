using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pantry.web
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Verificar se a variável de sessao foi preenchida com o username
            if (Session["ActualUser"] != null)
            {
                LoginLink.Visible = false;
                LogoutButton.Visible = true;
            }

            //Atribuir o username guardado na variável de sessºao à lable criada
            lblUsername.Text = (string)Session["ActualUser"];
        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            //voltar a mostrar o botºao de login (quando click em logout)
            LogoutButton.Visible = false;
            LoginLink.Visible = true;

            //Eliminar o utilizador da sessºao
            Session["ActualUser"] = null;
            lblUsername.Text = ""; //limpar o texto da lable
        }
    }
}

