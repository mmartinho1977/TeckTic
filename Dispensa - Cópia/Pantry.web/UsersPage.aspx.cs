using Pantry.dataaccess;
using Pantry.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pantry.web
{
    public partial class UsersPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Utilizador> users = Utilizadores.SelectAllUtilizadores();
        }
    }
}