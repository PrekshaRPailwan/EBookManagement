using Models.Dtos;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBookMData.Interface
{
    public interface IBookService
    {
        public List<Book> GetAllBooks();
        public BookDto AddBook(BookDto bookDto);
        public string UpdateBook(int BookId, BookDto bookDto);
        public string DeleteBook(int BookId);
        public BookDto GetByTitle(string title);
        public BookDto AddBookA (BookDto bookDto,List<int> AuthorList);

    }
}
