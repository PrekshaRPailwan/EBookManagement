using EBookMData.Interface;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos;
using Models.Models;
using Service.Service;

namespace EBookManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        [HttpGet]
        [Route("/GetAllAuthors")]
        public ActionResult GetAllAuthors()
        {
            return Ok(_authorService.GetAllAuthors());
        }
        [HttpPost]
        [Route("/AddAuthor")]
        public ActionResult AddAuthor([FromBody] Author author)
        {
             return Ok(_authorService.AddAuthor(author));
        }
        [HttpPut]
        [Route("/UpdateAuthor")]
        public ActionResult UpdateAuthor(int AuthorId, [FromBody] AuthorDto author)
        {
            return Ok(_authorService.UpdateAuthor(AuthorId, author));
        }
        [HttpDelete]
        [Route("/DeleteAuthor")]
        public ActionResult DeleteAuthor(int AuthorId)
        {
            return Ok(_authorService.DeleteAuthor(AuthorId));
        }
        [HttpGet("/GetAuthorsByBook")]
        public ActionResult GetAuthorsByBook(int BookId)
        {
            var authors = _authorService.GetAuthorsByBook(BookId);
            if (authors != null)
            {
                return Ok(authors);
            }
            else
            {
                return NotFound("No authors found for the given book.");
            }
        }

    }
}
