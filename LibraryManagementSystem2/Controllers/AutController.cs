using LibraryManagementSystem2.Models;
using LibraryManagementSystem2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem2.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserRepository _userRepository;

        public AuthController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _userRepository.GetByUsername(username);

            if (user == null)
            {
                ModelState.AddModelError("", "The account does not exist.");
                return View();
            }

            if (user.Password != password)
            {
                ModelState.AddModelError("", "The username and password do not match.");
                return View();
            }

            HttpContext.Session.SetString("Username", username);

            TempData["Message"] = "Login successful!";
            return RedirectToAction("Dashboard");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (_userRepository.GetByUsername(user.Username) != null)
            {
                ModelState.AddModelError("Username", "Username already exists.");
                return View(user);
            }

            _userRepository.Add(user);
            TempData["Message"] = "Registration successful! Please log in.";
            return RedirectToAction("Login");
        }

        public IActionResult Dashboard()
        {
            var username = HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(username))
            {
                TempData["Message"] = "You must log in first.";
                return RedirectToAction("Login");
            }

            ViewData["Username"] = username;
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["Message"] = "You have been logged out.";
            return RedirectToAction("Login");
        }
    }
}
