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
        [HttpGet("GetByTitle")]
        public IActionResult GetByTitle(string title)
        {
            var book = _bookService.GetByTitle(title);
            if (book != null)
            {
                return Ok(book);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        [Route("/AddBookA")]
        public IActionResult AddBookA([FromBody] BookDto bookDto, [FromQuery] List<int> AuthorList)
        {
            var result = _bookService.AddBookA(bookDto, AuthorList);
            return Ok(result);
        }
    }
}
