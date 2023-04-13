using Academia.Cadastro;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using WebGrease.Css.Ast.Selectors;

namespace MuscleAcademia.Cadastro
{
    public partial class cadastroInstrutor : System.Web.UI.Page
    {
        private int idInstrutor = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Global.academiaAtiva != null)
                {
                    //nomeUser.Text = Global.academiaAtiva.Nome.ToString();
                    //nomeAcademia.Text = Global.academiaAtiva.Instituicao.ToString();
                    //var lstInstrutores = carregarInstrutores();

                }
                else
                {
                    Response.Redirect("Login/login.aspx");
                }

            }
        }
        private Entidades.Instrutor carregarInstrutores()
        {
            Entidades.Instrutor Instrutor = new Entidades.Instrutor();
            return Instrutor.ObterPorId(idInstrutor);
        }
    }
}
