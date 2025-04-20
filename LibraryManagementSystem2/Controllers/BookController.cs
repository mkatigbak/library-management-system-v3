using LibraryManagementSystem2.Models;
using LibraryManagementSystem2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem2.Controllers
{
    public class BookController : BaseController
    {
        private readonly BookRepository _repository;

        public BookController(BookRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            if (!IsUserLoggedIn())
            {
                TempData["Message"] = "You must log in first.";
                return RedirectToAction("Login", "Auth");
            }

            var books = _repository.GetAll();
            return View(books);
        }

        public IActionResult Details(int id)
        {
            if (!IsUserLoggedIn())
            {
                TempData["Message"] = "You must log in first.";
                return RedirectToAction("Login", "Auth");
            }

            var book = _repository.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
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
        public IActionResult Create(Book book)
        {
            if (!IsUserLoggedIn())
            {
                TempData["Message"] = "You must log in first.";
                return RedirectToAction("Login", "Auth");
            }

            _repository.Add(book);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (!IsUserLoggedIn())
            {
                TempData["Message"] = "You must log in first.";
                return RedirectToAction("Login", "Auth");
            }

            var book = _repository.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (!IsUserLoggedIn())
            {
                TempData["Message"] = "You must log in first.";
                return RedirectToAction("Login", "Auth");
            }

            _repository.Update(book);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (!IsUserLoggedIn())
            {
                TempData["Message"] = "You must log in first.";
                return RedirectToAction("Login", "Auth");
            }

            var book = _repository.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            if (!IsUserLoggedIn())
            {
                TempData["Message"] = "You must log in first.";
                return RedirectToAction("Login", "Auth");
            }

            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}