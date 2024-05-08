using EBookMData.Interface;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos;
using Models.Models;
using Service.Service;

namespace EBookManagement.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet("/GetAllbooks")]
        public IActionResult GetAllBooks()
        {
            List<Book> books = _bookService.GetAllBooks();
            return Ok(books);
        }

        [HttpPost]
        [Route("/AddBook")]
        public ActionResult AddBook([FromBody] BookDto bookDto)
        {
            var result = _bookService.AddBook(bookDto);
            return Ok(result);
        }
        [HttpPut]
        [Route("/UpdateBook")]
        public ActionResult UpdateBook(int BookId, [FromBody] BookDto bookDto)
        {
            var res = _bookService.UpdateBook(BookId, bookDto);
            return Ok(res);
        }
        [HttpDelete("/Deletebook")]
        public IActionResult DeleteBook(int BookId)
        {
            string delete = _bookService.DeleteBook(BookId);
            return Ok(delete);
        }
        [HttpGet("/GetByTitle")]
        public IActionResult GetByTitle(string title)
        {
            var book = _bookService.GetByTitle(title);
            if (book != null)
            {
                return Ok(book);
            }
            else
            {
                return NotFound("Unable");
            }
        }
        [HttpPost]
        [Route("/AddBookA")]
        public IActionResult AddBookA([FromBody] BookDto bookDto, [FromQuery] List<int> AuthorList)
        {
            var result = _bookService.AddBookA(bookDto, AuthorList);
            return Ok(result);
        }
        [HttpGet]
        [Route("/GetBooksByAuthor")]
        public IActionResult GetBooksByAuthor(int authorId)
        {
            var books = _bookService.GetBooksByAuthor(authorId);
            if (books != null)
            {
                return Ok(books);
            }
            else
            {
                return NotFound("No books found for the given author.");
            }
        }
        [HttpGet("/GetBooksByGenre")]
        public IActionResult GetBooksByGenre(int genreId)
        {
            var books = _bookService.GetBooksByGenre(genreId);
            if (books != null)
            {
                return Ok(books);
            }
            else
            {
                return NotFound("No books found for the given genre.");
            }
        }


    }
}
