using LibraryManagementSystem2.Models;
using LibraryManagementSystem2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem2.Controllers
{
    public class ReaderController : BaseController
    {
        private readonly ReaderRepository _repository;

        public ReaderController(ReaderRepository repository)
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

            var readers = _repository.GetAll();
            return View(readers);
        }

        public IActionResult Details(int id)
        {
            if (!IsUserLoggedIn())
            {
                TempData["Message"] = "You must log in first.";
                return RedirectToAction("Login", "Auth");
            }

            var reader = _repository.GetById(id);
            if (reader == null)
            {
                return NotFound();
            }
            return View(reader);
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
        public IActionResult Create(Reader reader)
        {
            if (!IsUserLoggedIn())
            {
                TempData["Message"] = "You must log in first.";
                return RedirectToAction("Login", "Auth");
            }

            _repository.Add(reader);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (!IsUserLoggedIn())
            {
                TempData["Message"] = "You must log in first.";
                return RedirectToAction("Login", "Auth");
            }

            var reader = _repository.GetById(id);
            if (reader == null)
            {
                return NotFound();
            }
            return View(reader);
        }

        [HttpPost]
        public IActionResult Edit(Reader reader)
        {
            if (!IsUserLoggedIn())
            {
                TempData["Message"] = "You must log in first.";
                return RedirectToAction("Login", "Auth");
            }

            _repository.Update(reader);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (!IsUserLoggedIn())
            {
                TempData["Message"] = "You must log in first.";
                return RedirectToAction("Login", "Auth");
            }

            var reader = _repository.GetById(id);
            if (reader == null)
            {
                return NotFound();
            }
            return View(reader);
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