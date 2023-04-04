using MuscleAcademia;
using MuscleAcademia.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Academia.Login
{
    /// <summary>
    /// Descrição resumida de Logar
    /// </summary>
    public class Logar : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            var method = context.Request.Params["method"];
            switch (method)
            {
                case "Login":
                    RealizarLogin(context);
                    break;
                case "Sair":
                    Deslogar(context);
                    break;

                case "ResgatarLogin":
                    ResgatarLogin(context);
                    break;
                default:
                    var response = new { status = "success", mensagem = "Dados recebidos com sucesso." };
                    HttpContext.Current.Response.Write(JsonConvert.SerializeObject(response));
                    break;
            }
        }

        private void Deslogar(HttpContext context)
        {
            Global.academiaAtiva = null;
            var response = new { status = "OK", mensagem = "SingOut com sucesso!" };
            HttpContext.Current.Response.Write(JsonConvert.SerializeObject(response));
        }

        public void RealizarLogin(HttpContext context)
        {
            // Aqui seto os valores das variaceis de acordo com os parametros enviados.

            var email = HttpContext.Current.Request.Params["email"];
            var senha = HttpContext.Current.Request.Params["senha"];
            //instacia da entidade cadastro
            MuscleAcademia.Entidades.Academia Academia = new MuscleAcademia.Entidades.Academia();

            try
            {

                // Insere o novo cadastro
                Academia = Academia.Selecionar(email, senha);
                if (Academia != null)
                {
                    Global.academiaAtiva = Academia;
                    //var response = new { status = "success", mensagem = "Dados recebidos com sucesso." };
                    HttpContext.Current.Response.Write(JsonConvert.SerializeObject(Academia));
                }
                else
                {
                    var response = new { status = "error", mensagem = "Usuário não encontrado." };
                    HttpContext.Current.Response.Write(JsonConvert.SerializeObject(response));

                }

            }
            catch (Exception ex)
            {
                // Retorna uma mensagem de erro para a chamada AJAX
                var response = new { status = "error", mensagem = ex.Message };
                HttpContext.Current.Response.Write(JsonConvert.SerializeObject(response));
            }
        }
        public void ResgatarLogin(HttpContext context)
        {
            // Aqui seto os valores das variaceis de acordo com os parametros enviados.

            var usuarioId = HttpContext.Current.Request.Params["Id"];
            //instacia da entidade cadastro
            MuscleAcademia.Entidades.Academia Academia = new MuscleAcademia.Entidades.Academia();

            try
            {

                // Insere o novo cadastro
                Academia = Academia.ResgatarLogin(usuarioId);
                //var response = new { status = "success", mensagem = "Dados recebidos com sucesso." };
                HttpContext.Current.Response.Write(JsonConvert.SerializeObject(Academia));
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