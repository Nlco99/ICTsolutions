using Microsoft.AspNetCore.Mvc;

namespace ICTsolutions.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }


    }
}
