using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace MuscleAcademia
{
    public partial class SiteMaster : MasterPage
    {

        public static Entidades.Academia academiaAtiva { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

           if(!IsPostBack)
            {
                if (Global.academiaAtiva != null) {
                    academiaAtiva = Global.academiaAtiva;
                    //nomeUser.Text = Global.academiaAtiva.Nome.ToString();
                    //nomeAcademia.Text = Global.academiaAtiva.Instituicao.ToString();
                    var x = 0;
                }
            }

        }
    }
}