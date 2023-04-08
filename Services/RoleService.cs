using CRUD_Operation.Inferfaces;
using CRUD_Operation.Models;
using Microsoft.AspNetCore.Identity;

namespace CRUD_Operation.Services
{
    public class RoleService : IRoleService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleService(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        /// <summary>
        /// Create Role
        /// </summary>
        /// <param name="user"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        


        public async Task<string> AddUserToRole(string user, string roleName)
        {
            var find = await _userManager.FindByNameAsync(user);
            if (find != null)
            {
                var checkRole = await _roleManager.RoleExistsAsync(roleName);
                if (checkRole == true)
                {
                    var checkUser = await _userManager.IsInRoleAsync(find, roleName);
                    if(checkUser == false)
                    {
                        var result = await _userManager.AddToRoleAsync(find, roleName);
                        if (result.Succeeded)
                        {
                            return $"{roleName} successfully added";
                        }
                        else
                        {
                            return result.Errors.First().Description;
                        }
                    }
                    return $"User already in {roleName}";
                }
                return "Role not Exist";
            }
            return "User not found";
        }

        public async Task<string> CreateRole(string roleName)
        {
            var checkIfRoleExist = await _roleManager.RoleExistsAsync(roleName);
            if (!checkIfRoleExist)
            {
                IdentityRole role = new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = roleName,
                };
                var result =await _roleManager.CreateAsync(role);

                if (result.Succeeded)
                {
                    return string.Empty;
                }
                else
                {
                    return result.Errors.First().Description;
                }
            }
            return "Role Already exist";
        }
    }
}
