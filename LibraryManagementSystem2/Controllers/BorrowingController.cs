using LibraryManagementSystem2.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem2.Controllers
{
    [ApiController]
    [Route("api/borrowings")]
    public class BorrowingController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll() => Ok("All borrowings");

        [HttpGet("{id}")]
        public IActionResult GetById(int id) => Ok($"Borrowing {id}");

        [HttpPost]
        public IActionResult Create(Borrowing borrowing) => CreatedAtAction(nameof(GetById), new { id = 1 }, "Borrowing created");

        [HttpPut("{id}")]
        public IActionResult Update(int id, Borrowing borrowing) => Ok($"Borrowing {id} updated");

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) => Ok($"Borrowing {id} canceled");

        [HttpGet("{id}/overdue")]
        public IActionResult GetOverdueCharge(int id) => Ok($"Overdue charge for borrowing {id}: $5.00");
    }
}
