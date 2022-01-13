using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeckTicForm.web
{
    public partial class Message : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string code = Page.Request.QueryString["result"];

                if (Page.Request.QueryString["result"] != "True?")
                {
                    LabelResult.Text = "Algo correu mal, não foi possível enviar requisição para o e-mail indicado";

                    LabelEmail.Text = string.Empty;
                }



            }

        }

        
    }
}