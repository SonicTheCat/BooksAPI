namespace my_books.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using my_books.Data.Services;
    using my_books.Data.ViewModels;

    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksService booksService;

        public BooksController(BooksService booksService)
        {
            this.booksService = booksService;
        }

        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var books = this.booksService.GetAllBooks();

            return this.Ok(books);
        }

        [HttpGet("get-book-by-id/{id:int}")]
        public IActionResult GetBookById(int id)
        {
            var book = this.booksService.GetBookById(id);

            return this.Ok(book);
        }

        [HttpPost("add-new-book")]
        public IActionResult AddBook([FromBody]BookVM book)
        {
            this.booksService.AddBook(book);

            return this.Ok();
        }
    }
}