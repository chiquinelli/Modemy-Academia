using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MuscleAcademia.Entidades
{
    public class Aluno
    {

        private string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        public int Inserir(Models.Aluno aluno)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "INSERT INTO tblalunos (NomeCompleto, Endereco, NumeroEndereco, Cep, Telefone, Cidade, Uf, Ativo, IdAcademia) VALUES (@NomeCompleto, @Endereco, @NumeroEndereco, @Cep, @Telefone, @Cidade, @Uf,@Ativo @IdAcademia); SELECT LAST_INSERT_ID();";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@NomeCompleto", aluno.NomeCompleto);
                command.Parameters.AddWithValue("@Endereco", aluno.Endereco);
                command.Parameters.AddWithValue("@NumeroEndereco", aluno.NumeroEndereco);
                command.Parameters.AddWithValue("@Cep", aluno.Cep);
                command.Parameters.AddWithValue("@Telefone", aluno.Telefone);
                command.Parameters.AddWithValue("@IdAcademia", aluno.IdAcademia);
                command.Parameters.AddWithValue("@Cidade", aluno.Cidade);
                command.Parameters.AddWithValue("@Uf", aluno.Uf);
                command.Parameters.AddWithValue("@Ativo", aluno.Ativo);
                var id = command.ExecuteScalar();
                return Convert.ToInt32(id);
            }
        }

        public void Atualizar(Models.Aluno aluno)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "UPDATE tblalunos SET NomeCompleto = @NomeCompleto, Endereco = @Endereco, NumeroEndereco = @NumeroEndereco, Cep = @Cep, Telefone = @Telefone, Cidade= @Cidade, Uf = @Uf, Ativo = @Ativo, IdAcademia = @IdAcademia WHERE IdAluno = @IdAluno";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdAluno", aluno.IdAluno);
                command.Parameters.AddWithValue("@NomeCompleto", aluno.NomeCompleto);
                command.Parameters.AddWithValue("@Endereco", aluno.Endereco);
                command.Parameters.AddWithValue("@NumeroEndereco", aluno.NumeroEndereco);
                command.Parameters.AddWithValue("@Cep", aluno.Cep);
                command.Parameters.AddWithValue("@Telefone", aluno.Telefone);
                command.Parameters.AddWithValue("@IdAcademia", aluno.IdAcademia);
                command.Parameters.AddWithValue("@Cidade", aluno.Cidade);
                command.Parameters.AddWithValue("@Uf", aluno.Uf);
                command.Parameters.AddWithValue("@Ativo", aluno.Ativo);
                command.ExecuteNonQuery();
            }
        }

        public void Excluir(int idaluno)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "DELETE FROM tblalunos WHERE IdAluno = @IdAluno";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdAluno", idaluno);
                command.ExecuteNonQuery();
            }
        }
        public List<Models.Aluno> ObterPorIdAcademia(int idAcademia, bool ativo = true)
        {
            var alunos = new List<Models.Aluno>();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = String.Empty;
                if (ativo) { query = "SELECT * FROM tblalunos WHERE IdAcademia = @IdAcademia"; }
                if (!ativo) { query = "SELECT * FROM tblalunos WHERE IdAcademia = @IdAcademia AND Ativo = 0"; }

                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdAcademia", idAcademia);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var aluno = new Models.Aluno
                    {
                        IdAluno = reader.GetInt32("IdAluno"),
                        NomeCompleto = reader.GetString("NomeCompleto"),
                        Endereco = reader.GetString("Endereco"),
                        NumeroEndereco = reader.GetString("NumeroEndereco"),
                        Cep = reader.GetString("Cep"),
                        Telefone = reader.GetString("Telefone"),
                        Cidade = reader.GetString("Cidade"),
                        Uf = reader.GetString("Uf"),
                        Ativo = reader.GetBoolean("Ativo"),
                        IdAcademia = reader.GetInt32("IdAcademia")
                    };
                    alunos.Add(aluno);
                }
            }
            return alunos;
        }
        public Models.Aluno ObterPorId(int idaluno)
        {
            var aluno = new Models.Aluno();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM tblalunos WHERE IdAluno = @IdAluno";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdAluno", idaluno);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {

                    aluno.IdAluno = reader.GetInt32("IdAluno");
                    aluno.NomeCompleto = reader.GetString("NomeCompleto");
                    aluno.Endereco = reader.GetString("Endereco");
                    aluno.NumeroEndereco = reader.GetString("NumeroEndereco");
                    aluno.Cep = reader.GetString("Cep");
                    aluno.Telefone = reader.GetString("Telefone");
                    aluno.Cidade = reader.GetString("Cidade");
                    aluno.Uf = reader.GetString("Uf");
                    aluno.Ativo = reader.GetBoolean("Ativo");
                    aluno.IdAcademia = reader.GetInt32("IdAcademia");
                }
            }
            return aluno;
        }
    }
}
