using LibraryManagementSystem2.Models;
using LibraryManagementSystem2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem2.Controllers
{
    public class BorrowingController : BaseController
    {
        private readonly BorrowingRepository _borrowingRepository;
        private readonly BookRepository _bookRepository;
        private readonly ReaderRepository _readerRepository;

        public BorrowingController(BorrowingRepository borrowingRepository, BookRepository bookRepository, ReaderRepository readerRepository)
        {
            _borrowingRepository = borrowingRepository;
            _bookRepository = bookRepository;
            _readerRepository = readerRepository;
        }

        public IActionResult Index()
        {
            if (!IsUserLoggedIn())
            {
                TempData["Message"] = "You must log in first.";
                return RedirectToAction("Login", "Auth");
            }

            var borrowings = _borrowingRepository.GetAll();
            return View(borrowings);
        }

        public IActionResult Details(int id)
        {
            if (!IsUserLoggedIn())
            {
                TempData["Message"] = "You must log in first.";
                return RedirectToAction("Login", "Auth");
            }

            var borrowing = _borrowingRepository.GetById(id);
            if (borrowing == null)
            {
                return NotFound();
            }
            return View(borrowing);
        }

        public IActionResult Create()
        {
            if (!IsUserLoggedIn())
            {
                TempData["Message"] = "You must log in first.";
                return RedirectToAction("Login", "Auth");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Create(Borrowing borrowing)
        {
            if (!IsUserLoggedIn())
            {
                TempData["Message"] = "You must log in first.";
                return RedirectToAction("Login", "Auth");
            }

            // Validate BookId
            if (_bookRepository.GetById(borrowing.BookId) == null)
            {
                ModelState.AddModelError("BookId", "The specified Book ID does not exist.");
            }

            // Validate ReaderId
            if (_readerRepository.GetById(borrowing.ReaderId) == null)
            {
                ModelState.AddModelError("ReaderId", "The specified Reader ID does not exist.");
            }

            if (!ModelState.IsValid)
            {
                return View(borrowing);
            }

            _borrowingRepository.Add(borrowing);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (!IsUserLoggedIn())
            {
                TempData["Message"] = "You must log in first.";
                return RedirectToAction("Login", "Auth");
            }

            var borrowing = _borrowingRepository.GetById(id);
            if (borrowing == null)
            {
                return NotFound();
            }
            return View(borrowing);
        }

        [HttpPost]
        public IActionResult Edit(Borrowing borrowing)
        {
            if (!IsUserLoggedIn())
            {
                TempData["Message"] = "You must log in first.";
                return RedirectToAction("Login", "Auth");
            }

            _borrowingRepository.Update(borrowing);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (!IsUserLoggedIn())
            {
                TempData["Message"] = "You must log in first.";
                return RedirectToAction("Login", "Auth");
            }

            var borrowing = _borrowingRepository.GetById(id);
            if (borrowing == null)
            {
                return NotFound();
            }
            return View(borrowing);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            if (!IsUserLoggedIn())
            {
                TempData["Message"] = "You must log in first.";
                return RedirectToAction("Login", "Auth");
            }

            _borrowingRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}