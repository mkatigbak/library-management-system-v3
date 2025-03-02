using LibraryManagementSystem2.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem2.Controllers
{
    [ApiController]
    [Route("api/readers")]
    public class ReaderController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll() => Ok("All readers");

        [HttpGet("{id}")]
        public IActionResult GetById(int id) => Ok($"Reader {id}");

        [HttpPost]
        public IActionResult Create(Reader reader) => CreatedAtAction(nameof(GetById), new { id = 1 }, "Reader created");

        [HttpPut("{id}")]
        public IActionResult Update(int id, Reader reader) => Ok($"Reader {id} updated");

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) => Ok($"Reader {id} deleted");
    }
}
