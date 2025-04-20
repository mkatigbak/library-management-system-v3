using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem2.Controllers
{
    public class BaseController : Controller
    {
        protected bool IsUserLoggedIn()
        {
            return !string.IsNullOrEmpty(HttpContext.Session.GetString("Username"));
        }
    }
}