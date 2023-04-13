using MuscleAcademia.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;


namespace MuscleAcademia.Entidades
{
    public class Instrutor
    {
        public int IdInstrutor { get; set; }
        public string NomeCompleto { get; set; }
        public string Endereco { get; set; }
        public string NumeroEndereco { get; set; }
        public string Cep { get; set; }
        public string Telefone { get; set; }
        public int IdAcademia { get; set; }

        private string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;




        public int Inserir(Instrutor instrutor)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "INSERT INTO tblInstrutores (NomeCompleto, Endereco, NumeroEndereco, Cep, Telefone, IdAcademia) VALUES (@NomeCompleto, @Endereco, @NumeroEndereco, @Cep, @Telefone, @IdAcademia); SELECT LAST_INSERT_ID();";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@NomeCompleto", instrutor.NomeCompleto);
                command.Parameters.AddWithValue("@Endereco", instrutor.Endereco);
                command.Parameters.AddWithValue("@NumeroEndereco", instrutor.NumeroEndereco);
                command.Parameters.AddWithValue("@Cep", instrutor.Cep);
                command.Parameters.AddWithValue("@Telefone", instrutor.Telefone);
                command.Parameters.AddWithValue("@IdAcademia", instrutor.IdAcademia);
                var id = command.ExecuteScalar();
                return Convert.ToInt32(id);
            }
        }

        public void Atualizar(Instrutor instrutor)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "UPDATE tblInstrutores SET NomeCompleto = @NomeCompleto, Endereco = @Endereco, NumeroEndereco = @NumeroEndereco, Cep = @Cep, Telefone = @Telefone, IdAcademia = @IdAcademia WHERE IdInstrutor = @IdInstrutor";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdInstrutor", instrutor.IdInstrutor);
                command.Parameters.AddWithValue("@NomeCompleto", instrutor.NomeCompleto);
                command.Parameters.AddWithValue("@Endereco", instrutor.Endereco);
                command.Parameters.AddWithValue("@NumeroEndereco", instrutor.NumeroEndereco);
                command.Parameters.AddWithValue("@Cep", instrutor.Cep);
                command.Parameters.AddWithValue("@Telefone", instrutor.Telefone);
                command.Parameters.AddWithValue("@IdAcademia", instrutor.IdAcademia);
                command.ExecuteNonQuery();
            }
        }

        public void Excluir(int idInstrutor)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "DELETE FROM tblInstrutores WHERE IdInstrutor = @IdInstrutor";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdInstrutor", idInstrutor);
                command.ExecuteNonQuery();
            }
        }
        public List<Instrutor> ObterPorIdAcademia(int idAcademia)
        {
            var instrutores = new List<Instrutor>();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM tblInstrutores WHERE IdAcademia = @IdAcademia";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdAcademia", idAcademia);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var instrutor = new Instrutor
                    {
                        IdInstrutor = reader.GetInt32("IdInstrutor"),
                        NomeCompleto = reader.GetString("NomeCompleto"),
                        Endereco = reader.GetString("Endereco"),
                        NumeroEndereco = reader.GetString("NumeroEndereco"),
                        Cep = reader.GetString("Cep"),
                        Telefone = reader.GetString("Telefone"),
                        IdAcademia = reader.GetInt32("IdAcademia")
                    };
                    instrutores.Add(instrutor);
                }
            }
            return instrutores;
        }
        public Instrutor ObterPorId(int idInstrutor)
        {
            var instrutor = new Instrutor();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM tblInstrutores WHERE IdInstrutor = @IdInstrutor";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdInstrutor", idInstrutor);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {

                    instrutor.IdInstrutor = reader.GetInt32("IdInstrutor");
                    instrutor.NomeCompleto = reader.GetString("NomeCompleto");
                    instrutor.Endereco = reader.GetString("Endereco");
                    instrutor.NumeroEndereco = reader.GetString("NumeroEndereco");
                    instrutor.Cep = reader.GetString("Cep");
                    instrutor.Telefone = reader.GetString("Telefone");
                    instrutor.IdAcademia = reader.GetInt32("IdAcademia");


                }
            }
            return instrutor;
        }
    }
}
