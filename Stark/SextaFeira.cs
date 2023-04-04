using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MuscleAcademia.Stark
{
    public class SextaFeira
    {
        public static string FormatarTelefone(string telefone)
        {
            if (!string.IsNullOrEmpty(telefone) && telefone.Length == 11)
            {
                return string.Format("{0:(##) #####-####}", double.Parse(telefone));
            }
            return telefone;
        }

        public static string FormatarCep(string cep)
        {
            if (!string.IsNullOrEmpty(cep) && cep.Length == 8)
            {
                return string.Format("{0:#####-###}", double.Parse(cep));
            }
            return cep;
        }
    }
}