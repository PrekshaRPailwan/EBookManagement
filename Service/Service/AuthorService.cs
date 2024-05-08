using EBookMData.DatabaseManager;
using EBookMData.Interface;
using Models.Dtos;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly DatabaseManager _databaseManager;

        public AuthorService(DatabaseManager databaseManager)
        {
            _databaseManager = databaseManager;
        }

        public List<Author> GetAllAuthors()
        {
            try
            {
                return _databaseManager.GetAllAuthors();
            }
            catch (Exception )
            {
                return null;
            }
        }

        public Author AddAuthor(Author author)
        {
            try
            {
                _databaseManager.AddAuthor(author);
                return author;
            }
            catch (Exception )
            {
                return null;

            }
        }
        public string UpdateAuthor(int AuthorId, AuthorDto author)
        {
            try
            {
                _databaseManager.UpdateAuthor(AuthorId,author);
                return "Author Updated";
            }
            catch (Exception )
            {
                return null;

            }
        }
        public string DeleteAuthor(int AuthorId) 
        {
            try
            {
                _databaseManager.DeleteAuthor(AuthorId);
                return "Author Deleted";
            }
            catch (Exception )
            {
                return null;

            }
        }

            public List<AuthorDto> GetAuthorsByBook(int BookId)
            {
                try
                {
                    return _databaseManager.GetAuthorsByBook(BookId);
                }
                catch (Exception ex)
                {
                Console.WriteLine($"Error retrieving authors by book title: {ex.Message}");
                return null;
            }
            }
        }

    
}
