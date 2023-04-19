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
                    var lstAlunos = carregarAlunos();
                    QtdIntrutores.Text = "0";
                    QtdMatriculas.Text = "0";
                    QtdDesistencias.Text = "0";

                    if (lstInstrutores != null && lstInstrutores.Count > 0){ QtdIntrutores.Text = lstInstrutores.Count().ToString(); }
                    if (lstAlunos != null && lstAlunos.Count > 0){ QtdMatriculas.Text = lstAlunos.Count().ToString(); }
                    //var lstInativos = lstAlunos.Select(t => t.Ativo = false).ToList();
                    var lstInativos = lstAlunos.Where(f => f.Ativo = false).ToList();
                    if (lstInativos != null && lstInativos.Count > 0) { QtdDesistencias.Text = lstInativos.Count().ToString(); }
                }
                else
                {
                    Response.Redirect("Login/login.aspx");
                }
            }
        }

        private List<Entidades.Instrutor> carregarInstrutores()
        {
            Entidades.Instrutor Instrutor = new Entidades.Instrutor();
            return Instrutor.ObterPorIdAcademia(Global.academiaAtiva.Id);
        }
        private List<Models.Aluno> carregarAlunos()
        {
            Entidades.Aluno Aluno = new Entidades.Aluno();
            return Aluno.ObterPorIdAcademia(Global.academiaAtiva.Id);
        }
    }
}