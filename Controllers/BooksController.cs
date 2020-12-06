using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using perpusapi.DataModel;
using perpusapi.Services;
using perpusapi.Validator;

namespace perpusapi.Controllers
{
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IBookService _bookService;

        public BooksController(ILogger<BooksController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        [HttpGet]
        [Route("api/books")]
        public IActionResult GetBooks()
        {
            return Ok(_bookService.GetBooks());
        }

        [HttpGet]
        [Route("api/books/{id}")]
        public IActionResult GetBook(int id)
        {
            return Ok(_bookService.GetBook(id));
        }

        [HttpPost]
        [Route("api/books")]
        public IActionResult AddBook([FromBody]Book book)
        {
            var validator = new BookValidator();
            if(validator.Validate(book).IsValid){
                _bookService.AddBook(book);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("api/books/{id}")]
        public IActionResult UpdateBook([FromBody]Book book, int id)
        {
            var validator = new BookValidator();
            if(validator.Validate(book).IsValid){
                book.Id = id;
                _bookService.UpdateBook(book);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("api/books/{id}")]
        public IActionResult DeleteBook(int id)
        {
            _bookService.DeleteBook(id);
            return NoContent();
        }

        [HttpPost]
        [Route("api/books/{bookId}/borrow/")]
        public IActionResult BorrowBook(int bookId, [FromBody]Member member)
        {
            _bookService.BorrowBook(bookId, member.Id);
            return Ok();
        }

        [HttpPost]
        [Route("api/books/return/{borrowBookId}")]
        public IActionResult ReturnBook(int borrowBookId)
        {
            _bookService.ReturnBook(borrowBookId);
            return Ok();
        }


    }

}
