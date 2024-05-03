using Microsoft.Extensions.Configuration;
using Models.Dtos;
using Models.Models;
using System.Data;
using System.Data.SqlClient;

namespace EBookMData.DatabaseManager
{
    public class DatabaseManager 
    {
        private readonly string _connectionString;

        public DatabaseManager(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }
        public List<Author> GetAllAuthors()
        {
            List<Author> authors = new List<Author>();
            using SqlConnection connection = new SqlConnection(_connectionString);
            string storedProcedureName = "GetAllAuthors";
            using SqlCommand command = new SqlCommand(storedProcedureName, connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Author author = new Author();

                author.AuthorId = reader.GetInt32("AuthorId");
                author.FirstName = reader.GetString("FirstName");
                author.LastName = reader.GetString("LastName");
                author.Biography = reader.GetString("Biography");
                author.Birthdate = reader.GetDateTime("Birthdate");
                author.Country = reader.GetString("Country");
                author.CreatedAt = reader.GetDateTime("CreatedAt");
                author.UpdatedAt = reader.GetDateTime("UpdatedAt");
                
                authors.Add(author);
            }
            return authors;
        }
        public Author AddAuthor(Author author)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string storedProcedureName = "AddAuthor";
            SqlCommand command = new SqlCommand(storedProcedureName, connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@FirstName", author.FirstName);
            command.Parameters.AddWithValue("@LastName", author.LastName);
            command.Parameters.AddWithValue("@Biography", author.Biography);
            command.Parameters.AddWithValue("@Birthdate", author.Birthdate);
            command.Parameters.AddWithValue("@Country", author.Country);
            command.Parameters.AddWithValue("@CreatedAt", author.CreatedAt);
            command.Parameters.AddWithValue("@UpdatedAt", author.UpdatedAt);
            int rowsAffected = command.ExecuteNonQuery();
            return author;

        }
        public string UpdateAuthor(int AuthorId, AuthorDto authorDto)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string storedProcedureName = "UpdateAuthor";
            SqlCommand command = new SqlCommand(storedProcedureName, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@AuthorId", AuthorId);
            command.Parameters.AddWithValue("@FirstName", authorDto.FirstName);
            command.Parameters.AddWithValue("@LastName", authorDto.LastName);
            command.Parameters.AddWithValue("@Biography", authorDto.Biography);
            command.Parameters.AddWithValue("@Birthdate", authorDto.Birthdate);
            command.Parameters.AddWithValue("@Country", authorDto.Country);
            command.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
            int rowsAffected = command.ExecuteNonQuery();
            return (storedProcedureName);
        }
        public string DeleteAuthor(int AuthorId)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string storedProcedureName = "DeleteAuthor";
            SqlCommand command = new SqlCommand(storedProcedureName, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@AuthorId", AuthorId);
            int rowsAffected = command.ExecuteNonQuery();
            return (storedProcedureName);
        }
    }
}
