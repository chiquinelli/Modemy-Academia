using MuscleAcademia.Stark;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MuscleAcademia.Aluno
{
    public partial class Alunos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Global.academiaAtiva != null)
                {
                    nomeUser.Text = Global.academiaAtiva.Nome.ToString();
                    nomeAcademia.Text = Global.academiaAtiva.Instituicao.ToString();
                    _ = new List<Models.Aluno>();
                    List<Models.Aluno> Alunos;
                    if (Request.QueryString["Ativo"] != null && Request.QueryString["Ativo"].ToString().ToLower() == "false")
                    {
                        Alunos = carregarAlunos(false);
                    }
                    else
                    {
                        Alunos = carregarAlunos();
                    }
                    if (Alunos != null && Alunos.Count > 0)
                    {
                        foreach (var aluno in Alunos)
                        {
                            aluno.Telefone = Stark.SextaFeira.FormatarTelefone(aluno.Telefone);
                            aluno.Cep = Stark.SextaFeira.FormatarCep(aluno.Cep);
                        }
                        QtdAlunos.Text = Alunos.Count.ToString();
                        lstAlunos.DataSource = Alunos;
                        lstAlunos.DataBind();
                    }
                    else
                    {
                        QtdAlunos.Text = "0";
                    }

                }
            }
        }

        private List<Models.Aluno> carregarAlunos(bool ativo = true)
        {
            Entidades.Aluno Aluno = new Entidades.Aluno();
            if (ativo) { return Aluno.ObterPorIdAcademia(Global.academiaAtiva.Id); } else { return Aluno.ObterPorIdAcademia(Global.academiaAtiva.Id, false); }

        }
        protected void lstAlunos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idAluno = Convert.ToInt32(e.CommandArgument);
            Entidades.Aluno Alunos = new Entidades.Aluno();


            switch (e.CommandName)
            {
                case "Editar":
                    Response.Redirect("../Cadastro/cadastroAluno.aspx?idAluno=" + SextaFeira.Encrypt(idAluno));
                    break;
                case "Excluir":
                    Alunos.Excluir(idAluno);
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                    break;

                default:
                    //Console.WriteLine("O valor de x não é 1, 2 ou 3");
                    break;
            }

        }
        protected void lstAlunos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected string GetAtivoText(bool ativo)
        {
            if (ativo)
            {
                return "Ativo";
            }
            else
            {
                return "Inativo";
            }
        }
    }
}