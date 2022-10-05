using ICTsolutions.Areas.Identity.Data;
using ICTsolutions.Core.IRepositories;
using ICTsolutions.Core.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ICTsolutions.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UsersController(IUnitOfWork unitOfWork, SignInManager<ApplicationUser> signInManager)
        {
            _unitOfWork = unitOfWork;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            var users = _unitOfWork.User.GetUsers();
            return View(users);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var user = _unitOfWork.User.GetUser(id);
            var roles = _unitOfWork.Role.GetRoles();

            //you can test with a break point here to see which roles the singin user has
            var userRoles = await _signInManager.UserManager.GetRolesAsync(user);

            var roleItems = new List<SelectListItem>();

            foreach (var role in roles)
            {
                //loop inside the user roles and checks if the role exists
                var hasRole = userRoles.Any(ur => ur.Contains(role.Name));

                //its set to hasRole so when you open the edit page you can see the current role before you change it
                roleItems.Add(new SelectListItem(role.Name, role.Id, hasRole));
            }


            var vm = new EditUserViewModel
            {
                User = user,
                Roles = roleItems
            };

            return View(vm);
        }

        //this gets a view model that returns a view
        //breakpoint on return View();, return all the data from a chosen user from user edit page
        //here you can check if the roles from the users | tutorial 37.14 - 2 way data binding
        [HttpPost]
        public async Task<IActionResult> OnPostAsync(EditUserViewModel data)
        {
            var user = _unitOfWork.User.GetUser(data.User.Id);
            if (user == null)
            {
                return NotFound();
            }

            //this gets all the roles assigned to the user
            var userRolesInDb = await _signInManager.UserManager.GetRolesAsync(user);

            //Loop through the roles in ViewModel
            //Check if the Role is Assigned in DB
            //If Assigned -> Do Nothing
            //If Not Assigned -> Add Role
            foreach (var role in data.Roles)
            {
                var assignedInDb = userRolesInDb.FirstOrDefault(ur => ur == role.Text);
                if (role.Selected)
                {
                    if (assignedInDb == null)
                    {
                        //Add Role
                        await _signInManager.UserManager.AddToRoleAsync(user, role.Text);
                    }
                }
                else
                {
                    if (assignedInDb != null)
                    {
                        //Remove Role
                        await _signInManager.UserManager.RemoveFromRoleAsync(user, role.Text);
                    }
                }
            }

            user.FirstName = data.User.FirstName;
            user.LastName = data.User.LastName;
            user.Email = data.User.Email;

            //updating database
            _unitOfWork.User.UpdateUser(user);


            //redirecting to action view
            return RedirectToAction("Edit", new { id = user.Id });
        }
    }
}
