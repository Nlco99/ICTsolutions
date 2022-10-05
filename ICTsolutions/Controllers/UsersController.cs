using ICTsolutions.Core.IRepositories;
using ICTsolutions.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ICTsolutions.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var users = _unitOfWork.User.GetUsers();
            return View(users);
        }

        public IActionResult Edit(string id)
        {
            var user = _unitOfWork.User.GetUser(id);

            var vm = new EditUserViewModel
            {
                User = user
            };

            return View(vm);
        }
    }
}
