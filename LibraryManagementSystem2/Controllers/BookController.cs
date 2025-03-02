using LibraryManagementSystem2.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem2.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll() => Ok("All books");

        [HttpGet("{id}")]
        public IActionResult GetById(int id) => Ok($"Book {id}");

        [HttpPost]
        public IActionResult Create(Book book) => CreatedAtAction(nameof(GetById), new { id = 1 }, "Book created");

        [HttpPut("{id}")]
        public IActionResult Update(int id, Book book) => Ok($"Book {id} updated");

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) => Ok($"Book {id} deleted");
    }
}
