using Models.Dtos;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBookMData.Interface
{
    public interface IAuthorService
    {
        public List<Author> GetAllAuthors();
        public Author AddAuthor(Author author);
        public string UpdateAuthor(int AuthorId, AuthorDto author);
        public string DeleteAuthor(int AuthorId);
    }
}
