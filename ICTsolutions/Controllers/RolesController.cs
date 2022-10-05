using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ICTsolutions.Controllers
{
    public class RolesController : Controller
    {
        //This policy consists of "EmployeeOnly" -> it will go to program.cs and check for EmployeeOnly policy
        [Authorize(Policy = "EmployeeOnly")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
