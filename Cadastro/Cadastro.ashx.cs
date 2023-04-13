using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace Academia.Cadastro
{
    /// <summary>
    /// Descrição resumida de Cadastro
    /// </summary>
    public class Cadastro : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            var method = context.Request.Params["method"];

            switch (method)
            {
                case "Cadastrar":
                    Cadastrar(context);
                    break;

                case "CadastrarInstrutor":
                    CadastrarInstrutor(context);
                    break;

                case "RecuperarObjInstrutor":
                    RecuperarObjInstrutor(context);
                    break;

                case "EditarInstrutor":
                    EditarInstrutor(context);
                    break;

                default:
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("Método inválido");
                    break;
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public void Cadastrar(HttpContext context)
        {
            // Aqui seto os valores das variaceis de acordo com os parametros enviados.
            var nome = HttpContext.Current.Request.Params["nome"];
            var cpf = HttpContext.Current.Request.Params["cpf"];
            var email = HttpContext.Current.Request.Params["email"];
            var senha = HttpContext.Current.Request.Params["senha"];
            var instituicao = HttpContext.Current.Request.Params["instituicao"];
            //instacia da entidade cadastro
            MuscleAcademia.Entidades.Academia Cadastro = new MuscleAcademia.Entidades.Academia();

            try
            {
                // Verifica se já existe um cadastro com o mesmo CPF
                if (Cadastro.VerificarCPFExistente(cpf))
                {
                    throw new Exception("Já existe um cadastro com esse CPF.");
                }

                // Insere o novo cadastro
                var retorno = Cadastro.Inserir(nome, cpf, instituicao, email, senha);

                // retorna uma resposta para a chamada AJAX caso de tudo certo
                var response = new { status = "success", mensagem = "Dados recebidos com sucesso." };
                HttpContext.Current.Response.Write(JsonConvert.SerializeObject(response));
            }
            catch (Exception ex)
            {
                // Retorna uma mensagem de erro para a chamada AJAX
                var response = new { status = "error", mensagem = ex.Message };
                HttpContext.Current.Response.Write(JsonConvert.SerializeObject(response));
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public void EditarInstrutor(HttpContext context)
        {
            // Aqui seto os valores das variaceis de acordo com os parametros enviados.
            var id = HttpContext.Current.Request.Params["id"];
            var nome = HttpContext.Current.Request.Params["nome"];
            var telefone = HttpContext.Current.Request.Params["telefone"];
            var cep = HttpContext.Current.Request.Params["cep"];
            var endereco = HttpContext.Current.Request.Params["endereco"];
            var numero = HttpContext.Current.Request.Params["numero"];
            //instacia da entidade cadastro
            MuscleAcademia.Entidades.Instrutor Instrutor = new MuscleAcademia.Entidades.Instrutor();
            try
            {
                Instrutor.IdInstrutor = int.Parse(id);
                Instrutor.NomeCompleto = nome;
                Instrutor.Endereco = endereco;
                Instrutor.Cep = cep;
                Instrutor.Telefone = telefone;
                Instrutor.NumeroEndereco = numero;
                Instrutor.IdAcademia = MuscleAcademia.Global.academiaAtiva.Id;

                // Insere o novo cadastro
                Instrutor.Atualizar(Instrutor);

                // retorna uma resposta para a chamada AJAX caso de tudo certo
                var response = new { status = "success", mensagem = "Dados recebidos com sucesso." };
                HttpContext.Current.Response.Write(JsonConvert.SerializeObject(response));
            }
            catch (Exception ex)
            {
                // Retorna uma mensagem de erro para a chamada AJAX
                var response = new { status = "error", mensagem = ex.Message };
                HttpContext.Current.Response.Write(JsonConvert.SerializeObject(response));
            }
        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public void RecuperarObjInstrutor(HttpContext context)
        {
            // Aqui seto os valores das variaceis de acordo com os parametros enviados.
            var id = HttpContext.Current.Request.Params["id"];
            //instacia da entidade cadastro
            MuscleAcademia.Entidades.Instrutor Instrutor = new MuscleAcademia.Entidades.Instrutor();
            try
            {
                // Insere o novo cadastro
                var response = Instrutor.ObterPorId(int.Parse(id));
                // retorna um obj para ajax
                HttpContext.Current.Response.Write(JsonConvert.SerializeObject(response));
            }
            catch (Exception ex)
            {
                // Retorna uma mensagem de erro para a chamada AJAX
                var response = new { status = "error", mensagem = ex.Message };
                HttpContext.Current.Response.Write(JsonConvert.SerializeObject(response));
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public void CadastrarInstrutor(HttpContext context)
        {
            // Aqui seto os valores das variaceis de acordo com os parametros enviados.
            var nome = HttpContext.Current.Request.Params["nome"];
            var telefone = HttpContext.Current.Request.Params["telefone"];
            var cep = HttpContext.Current.Request.Params["cep"];
            var endereco = HttpContext.Current.Request.Params["endereco"];
            var numero = HttpContext.Current.Request.Params["numero"];
            //instacia da entidade cadastro
            MuscleAcademia.Entidades.Instrutor CadastroInstrutor = new MuscleAcademia.Entidades.Instrutor();

            try
            {
                CadastroInstrutor.NomeCompleto = nome;
                CadastroInstrutor.Endereco = endereco;
                CadastroInstrutor.Cep = cep;
                CadastroInstrutor.Telefone = telefone;
                CadastroInstrutor.NumeroEndereco = numero;
                CadastroInstrutor.IdAcademia = MuscleAcademia.Global.academiaAtiva.Id;

                // Insere o novo cadastro
                var retorno = CadastroInstrutor.Inserir(CadastroInstrutor);

                // retorna uma resposta para a chamada AJAX caso de tudo certo
                var response = new { status = "success", mensagem = "Dados recebidos com sucesso." };
                HttpContext.Current.Response.Write(JsonConvert.SerializeObject(response));
            }
            catch (Exception ex)
            {
                // Retorna uma mensagem de erro para a chamada AJAX
                var response = new { status = "error", mensagem = ex.Message };
                HttpContext.Current.Response.Write(JsonConvert.SerializeObject(response));
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
