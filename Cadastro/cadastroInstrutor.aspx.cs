using Academia.Cadastro;
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
                if (Request.QueryString["idInstrutor"] != null)
                {
                    idInstrutor = int.Parse(Request.QueryString["idInstrutor"]);
                    Button btnCadastrar = FindControl("btnCadastrar") as Button;
                    if (btnCadastrar != null)
                    {
                        //btnCadastrar.Attributes.Add("onclick", "editarInstrutor()");
                        //btnCadastrar.Text = "Editar";
                        //btnCadastrar.Click += new EventHandler(btnCadastrar_Click);
                        //btnCadastrar.Attributes.Remove("onclick");
                    }
                    // use o valor de idInstrutor como necessário
                }

            }
        }
        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (idInstrutor != 0)
            {
                // código para editar o instrutor

                string nome = Request.Form["nome"];
                string telefone = Request.Form["telefone"];
                string cep = Request.Form["cep"];
                string endereco = Request.Form["endereco"];
                string numero = Request.Form["numero"];

                if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(telefone) || string.IsNullOrEmpty(cep) || string.IsNullOrEmpty(endereco) || string.IsNullOrEmpty(numero))
                {
                    MuscleAcademia.Entidades.Instrutor CadastroInstrutor = new MuscleAcademia.Entidades.Instrutor();

                    CadastroInstrutor.IdInstrutor = idInstrutor;
                    CadastroInstrutor.NomeCompleto = nome;
                    CadastroInstrutor.Endereco = endereco;
                    CadastroInstrutor.Cep = cep;
                    CadastroInstrutor.Telefone = telefone;
                    CadastroInstrutor.NumeroEndereco = numero;
                    CadastroInstrutor.IdAcademia = MuscleAcademia.Global.academiaAtiva.Id;

                    // Insere o novo cadastro
                    CadastroInstrutor.Atualizar(CadastroInstrutor);

                    // seu código aqui
                }
            }
            else
            {

                //string script = "<script type=\"text/javascript\"> Cadastrar(); </script>";
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "Cadastrar", "MinhaFuncao();", true);

                ScriptManager.RegisterStartupScript(this, typeof(Page), "Cadastrar", "Cadastrar();", true);
            }

        }
    }
}