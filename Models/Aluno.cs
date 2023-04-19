using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MuscleAcademia.Models
{
    public class Aluno
    {
        public int IdAluno { get; set; }
        public string NomeCompleto { get; set; }
        public string Endereco { get; set; }
        public string NumeroEndereco { get; set; }
        public string Cep { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public bool Ativo { get; set; }
        public int IdAcademia { get; set; }
    }
}