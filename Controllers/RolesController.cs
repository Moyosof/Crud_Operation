using CRUD_Operation.Inferfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Operation.Controllers
{
    public class RolesController : Controller
    {

        private readonly IRoleService _roleService;
        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public IActionResult CreateRole()
        {
            return View();
        }

        public async Task<IActionResult> AddRole(string roleName)
        {
            var result = await _roleService.CreateRole(roleName);
            if(string.IsNullOrEmpty(result))
            {
                return View("CreateRole");
            }
            string error = result;
            ViewBag.RoleName = error;
            return View("CreateRole");
        }

        public IActionResult UserRole()
        {
            return View();
        }

        public async Task<IActionResult> AddUserToRole(string user, string roleName)
        {
            var result = await _roleService.AddUserToRole(user, roleName);
            if(string.IsNullOrEmpty(result))
            {
                return View("UserRole");

            }
            string error = result;
            ViewBag.RoleName = error;
            return View("UserRole");
        }
    }
}
