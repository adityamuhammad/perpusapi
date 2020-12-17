using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
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
        [EnableCors("MyPolicy")]
        [Route("api/books")]
        public IActionResult GetBooks()
        {
            return Ok(_bookService.GetBooks());
        }

        [HttpGet]
        [Route("api/books/{id}")]
        public IActionResult GetBook(int id)
        {
            var book = _bookService.GetBook(id);
            if (book != null){
                return Ok(book);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("api/books")]
        public IActionResult AddBook([FromBody]Book book)
        {
            var validator = new BookValidator();
            if(validator.Validate(book).IsValid)
            {
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
            if(validator.Validate(book).IsValid)
            {
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

        [HttpGet]
        [Route("api/books/borrowing/")]
        public IActionResult BorrowingData()
        {
            var borrowings = _bookService.GetBorrowingBooks();
            return Ok(borrowings);
        }

        [HttpPost]
        [Route("api/books/borrow/")]
        public IActionResult BorrowBook([FromBody]BookMember bookMember)
        {
            var validator = new BookMemberValidator();
            if(validator.Validate(bookMember).IsValid)
            {
                _bookService.BorrowBook(bookMember);
                return Ok();
            }
            return BadRequest();
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
