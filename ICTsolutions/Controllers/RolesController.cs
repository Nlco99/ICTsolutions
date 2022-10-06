using ICTsolutions.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ICTsolutions.Controllers
{
    public class RolesController : Controller
    {
        //This policy consists of "EmployeeOnly" -> it will go to program.cs and check for EmployeeOnly policy
        //[Authorize(Policy = "EmployeeOnly")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Policy = Constants.Policies.RequireAdmin)]
        public IActionResult Manager()
        {
            return View();
        }

        //[Authorize(Policy = "RequireAdmin")]
        //removing magic string by adding a class Constants 
        [Authorize(Roles = $"{Constants.Roles.Administrator}, {Constants.Roles.Manager}")]
        public IActionResult Admin()
        {
            return View();
        }

    }
}
