using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MuscleAcademia
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Global.academiaAtiva != null)
                {
                    nomeUser.Text = Global.academiaAtiva.Nome.ToString();
                    nomeAcademia.Text = Global.academiaAtiva.Instituicao.ToString();
                    var lstInstrutores = carregarInstrutores();
                    if (lstInstrutores != null && lstInstrutores.Count > 0)
                    {
                        QtdIntrutores.Text = lstInstrutores.Count().ToString();
                    }
                    else
                    {
                        QtdIntrutores.Text ="0" ;

                    }
                }
            }
        }

        private List<Entidades.Instrutor> carregarInstrutores()
        {
            Entidades.Instrutor Instrutor = new Entidades.Instrutor();
            return Instrutor.ObterPorIdAcademia(Global.academiaAtiva.Id);
        }
    }
}