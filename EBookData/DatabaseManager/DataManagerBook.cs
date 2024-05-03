using Microsoft.Extensions.Configuration;
using Models.Dtos;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBookMData.DatabaseManager
{
    public class DataManagerBook
    {
        private readonly string _connectionString;

        public DataManagerBook(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }
        public List<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();

            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string storedProcedureName = "GetAllBooks";
            SqlCommand command = new SqlCommand(storedProcedureName, connection);
            command.CommandType = CommandType.StoredProcedure;

            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Book book = new Book();

                book.BookId = reader.GetInt32("BookId");
                     book.Title = reader.GetString("Title");
                     book.Description = reader.GetString("Description");
                     book.ISBN = reader.GetInt32("ISBN");
                     book.PublicationDate = reader.GetDateTime("PublicationDate");
                     book.Price = reader.GetDecimal("Price");
                     book.Language = reader.GetString("Language");
                     book.Publisher = reader.GetString("Publisher");
                     book.PageCount = reader.GetInt32("PageCount");
                  book.AverageRating = (float)reader.GetDouble("AverageRating");
                     book.GenreId = reader.GetInt32("GenreId");
                     book.CreatedAt = reader.GetDateTime("CreatedAt");
                book.UpdatedAt = reader.GetDateTime("UpdatedAt");
                
                books.Add(book);
            }

            return books;
        }

        public BookDto AddBook(BookDto bookDto)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string storedProcedureName = "AddBook";
            SqlCommand command = new SqlCommand(storedProcedureName, connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Title", bookDto.Title);
            command.Parameters.AddWithValue("@Description", bookDto.Description);
            command.Parameters.AddWithValue("@PublicationDate", bookDto.PublicationDate);
            command.Parameters.AddWithValue("@ISBN", bookDto.ISBN);
            command.Parameters.AddWithValue("@Price", bookDto.Price);
            command.Parameters.AddWithValue("@Language", bookDto.Language);
            command.Parameters.AddWithValue("@Publisher", bookDto.Publisher);
            command.Parameters.AddWithValue("@PageCount", bookDto.PageCount);
            command.Parameters.AddWithValue("@AverageRating", bookDto.AverageRating);
            command.Parameters.AddWithValue("@GenreId", bookDto.GenreId);
            command.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
            command.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);

            
            int rowsAffected = command.ExecuteNonQuery();

            if(rowsAffected > 0)
            {
                return bookDto;
            }
            else
            {
                Console.Write("Unable to post");
                return null;
            }

        }

        public string UpdateBook(int BookId, BookDto bookDto)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string storedProcedureName = "UpdateBook";
            SqlCommand command = new SqlCommand(storedProcedureName, connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@BookId", BookId);
            command.Parameters.AddWithValue("@Title", bookDto.Title);
            command.Parameters.AddWithValue("@Description", bookDto.Description);
            command.Parameters.AddWithValue("@PublicationDate", bookDto.PublicationDate);
            command.Parameters.AddWithValue("@ISBN", bookDto.ISBN);
            command.Parameters.AddWithValue("@Price", bookDto.Price);
            command.Parameters.AddWithValue("@Language", bookDto.Language);
            command.Parameters.AddWithValue("@Publisher", bookDto.Publisher);
            command.Parameters.AddWithValue("@PageCount", bookDto.PageCount);
            command.Parameters.AddWithValue("@AverageRating", bookDto.AverageRating);
            command.Parameters.AddWithValue("@GenreId", bookDto.GenreId);
            command.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
            command.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                return "Updated";
            }
            else
            {
                Console.Write("Unable to post");
                return null;
            }
        }
        public string DeleteBook(int BookId)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string deleteMappingProcedureName = "DeleteBookAuthorMappings";
            SqlCommand deleteMappingCommand = new SqlCommand(deleteMappingProcedureName, connection);
            deleteMappingCommand.CommandType = CommandType.StoredProcedure;
            deleteMappingCommand.Parameters.AddWithValue("@BookId", BookId);
            deleteMappingCommand.ExecuteNonQuery();

            string storedProcedureName = "DeleteBook";
            SqlCommand command = new SqlCommand(storedProcedureName, connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@BookId", BookId);

            int rowsAffected = command.ExecuteNonQuery();
            return "Book Deleted ";
        }
        public BookDto GetByTitle(string title)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string storedProcedureName = "GetByTitle";
            SqlCommand command = new SqlCommand(storedProcedureName, connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Title", title);

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                BookDto resultBookDto = new BookDto();

                resultBookDto.Title = reader.GetString("Title");
                resultBookDto.Description = reader.GetString("Description");
                resultBookDto.ISBN = reader.GetInt32("ISBN");
                resultBookDto.PublicationDate = reader.GetDateTime("PublicationDate");
                resultBookDto.Price = reader.GetDecimal("Price");
                resultBookDto.Language = reader.GetString("Language");
                resultBookDto.Publisher = reader.GetString("Publisher");
                resultBookDto.PageCount = reader.GetInt32("PageCount");
                resultBookDto.AverageRating = (float)reader.GetDouble("AverageRating");
                resultBookDto.GenreId = reader.GetInt32("GenreId");

                return resultBookDto;
            }

            return null;
        }

        public BookDto AddBookA(BookDto bookDto, List<int> AuthorList)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string storedProcedureName = "AddBook";
            SqlCommand command = new SqlCommand(storedProcedureName, connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Title", bookDto.Title);
            command.Parameters.AddWithValue("@Description", bookDto.Description);
            command.Parameters.AddWithValue("@PublicationDate", bookDto.PublicationDate);
            command.Parameters.AddWithValue("@ISBN", bookDto.ISBN);
            command.Parameters.AddWithValue("@Price", bookDto.Price);
            command.Parameters.AddWithValue("@Language", bookDto.Language);
            command.Parameters.AddWithValue("@Publisher", bookDto.Publisher);
            command.Parameters.AddWithValue("@PageCount", bookDto.PageCount);
            command.Parameters.AddWithValue("@AverageRating", bookDto.AverageRating);
            command.Parameters.AddWithValue("@GenreId", bookDto.GenreId);
            command.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
            command.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);


            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                string getBookId = "SELECT BookId from Books where Title=@Title";
                SqlCommand insertintoMapping = new SqlCommand(getBookId, connection);
                insertintoMapping.Parameters.AddWithValue("@Title",bookDto.Title);
                int bookId = Convert.ToInt32(insertintoMapping.ExecuteScalar());

                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("AuthorId", typeof(int));

                foreach(int auhtor in AuthorList)
                {
                    dataTable.Rows.Add(auhtor);
                }

                string mapping = "MappingTable";
                using SqlCommand map = new SqlCommand(mapping, connection);
                map.CommandType = CommandType.StoredProcedure;
                map.Parameters.AddWithValue("@BookId", bookId);
                map.Parameters.AddWithValue("@AuthorIds", dataTable);
                map.ExecuteNonQuery();
                return bookDto;

            }
            else
            {
                Console.Write("Unable to add");
                return null;
            }

        }


    }
}
