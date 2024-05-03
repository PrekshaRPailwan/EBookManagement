using EBookMData.DatabaseManager;
using EBookMData.Interface;
using Models.Dtos;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class BookService : IBookService
    {
        private readonly DataManagerBook _dataManagerBook;

        public BookService(DataManagerBook dataManagerBook)
        {
            _dataManagerBook = dataManagerBook;
        }
        public List<Book> GetAllBooks()
        {
            try
            {
                return _dataManagerBook.GetAllBooks();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public BookDto AddBook(BookDto bookDto)
        {
            try
            {
                var book = _dataManagerBook.AddBook(bookDto);
                return book;
            }
            catch (Exception )
            {
                return null;

            }
        }
        public string UpdateBook(int BookId, BookDto bookDto)
        {
            try
            {
                var book = _dataManagerBook.UpdateBook(BookId, bookDto);
                return book;
                
            }
            catch (Exception )
            {
                return null;
            }
        }
        public string DeleteBook(int BookId)
        {
            try
            {
                var delete = _dataManagerBook.DeleteBook(BookId);
                return delete;
            }
            catch(Exception )
            {
                return null;
            }
        }

        public BookDto GetByTitle(string title)
        {
            try
            {
                return _dataManagerBook.GetByTitle(title);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public BookDto AddBookA(BookDto bookDto, List<int> AuthorList)
        {
            try
            {
                var book = _dataManagerBook.AddBookA(bookDto, AuthorList);
                return book;
            }
            catch (Exception)
            {
                throw new Exception();

            }

        }
    }
}
