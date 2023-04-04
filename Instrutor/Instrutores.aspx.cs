﻿using MuscleAcademia.Entidades;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MuscleAcademia.Instrutor
{
    public partial class Instrutores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Global.academiaAtiva != null)
                {
                    //nomeUser.Text = Global.academiaAtiva.Nome.ToString();
                    //nomeAcademia.Text = Global.academiaAtiva.Instituicao.ToString();
                    var Instrutores = carregarInstrutores();
                    if (Instrutores != null && Instrutores.Count > 0)
                    {
                        foreach (var instrutor in Instrutores)
                        {
                            instrutor.Telefone = Stark.SextaFeira.FormatarTelefone(instrutor.Telefone);
                            instrutor.Cep = Stark.SextaFeira.FormatarCep(instrutor.Cep);
                        }
                        QtdIntrutores.Text = Instrutores.Count.ToString();
                        lstInstrutores.DataSource = Instrutores;
                        lstInstrutores.DataBind();
                    }
                    else
                    {
                        QtdIntrutores.Text = "0";
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