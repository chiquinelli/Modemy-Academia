using MuscleAcademia.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MuscleAcademia.Entidades
{
    public class Academia
    {

        //private string connectionString = "Data Source=localhost;Initial Catalog=desenvolvimento;User ID=root;Password=12345678";

        private string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Instituicao { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }



        public string Inserir(string nome, string cpf, string instituicao, string email, string senha)
        {
            //string connectionString = "Server=localhost;Database=desenvolvimento;Uid=root;Pwd=12345678;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO tblAcademia ( instituicao,nome, cpf, email, senha) VALUES (@Instituicao,@Nome, @Cpf, @Email, @Senha)";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Instituicao", instituicao);
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@Cpf", cpf);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Senha", senha);
                    command.ExecuteNonQuery();
                }
                connection.Close();
                return "OK";
            }

        }

        public void Atualizar(string cpf, string nome, string email, string senha, string endereco)
        {
            //código para atualizar os dados na tabela
        }

        public void Deletar(string cpf)
        {
            //código para deletar os dados na tabela
        }

        public Academia Selecionar(string email, string senha)
        {
            Academia objAcademia = new Academia();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * from tblAcademia WHERE email = @Email AND senha = @Senha";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Senha", senha);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.Read())
                        {
                            // Os dados do usuário foram encontrados
                            objAcademia.Id = reader.GetInt32("Id");
                            objAcademia.Nome = reader.GetString("Nome");
                            objAcademia.Email = reader.GetString("Email");
                            objAcademia.Senha = reader.GetString("Senha");
                            objAcademia.Instituicao = reader.GetString("Instituicao");
                            objAcademia.Cpf = reader.GetString("Cpf");
                            // etc...
                            // Retornar os dados do usuário como preferir (ex: criar um objeto Usuario)
                        }
                        else
                        {
                            objAcademia = null;
                            // Os dados do usuário não foram encontrados
                        }
                    }
                }
                connection.Close();
            }
            return objAcademia;
        }
        public Academia  ResgatarLogin(string usuarioId)
        {
            Academia objAcademia = new Academia();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * from tblAcademia WHERE Id = @Id";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", usuarioId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.Read())
                        {
                            // Os dados do usuário foram encontrados
                            objAcademia.Id = reader.GetInt32("Id");
                            objAcademia.Nome = reader.GetString("Nome");
                            objAcademia.Email = reader.GetString("Email");
                            objAcademia.Senha = reader.GetString("Senha");
                            objAcademia.Instituicao = reader.GetString("Instituicao");
                            objAcademia.Cpf = reader.GetString("Cpf");
                            // etc...
                            // Retornar os dados do usuário como preferir (ex: criar um objeto Usuario)
                        }
                        else
                        {
                            objAcademia = null;
                            // Os dados do usuário não foram encontrados
                        }
                    }
                }
                connection.Close();
            }
            return objAcademia;
        }
        public Boolean VerificarCPFExistente(string cpf)
        {
            var count = 0;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string checkExistSql = "SELECT COUNT(*) FROM tblAcademia WHERE Cpf = @cpf";
                using (MySqlCommand command = new MySqlCommand(checkExistSql, connection))
                {
                    command.Parameters.AddWithValue("@Cpf", cpf);
                    count = Convert.ToInt32(command.ExecuteScalar());
                }
                if (count > 0)
                {
                    connection.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}
