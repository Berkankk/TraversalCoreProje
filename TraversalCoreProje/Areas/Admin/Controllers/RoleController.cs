using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/Role")]

    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }
        [Route("Admin/CreateRole")]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateRole")]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel viewModel)
        {
            AppRole appRole = new AppRole()
            {
                Name = viewModel.RoleName
            };
            var result = await _roleManager.CreateAsync(appRole);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [Route("DeleteRole/{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            await _roleManager.DeleteAsync(value);
            return RedirectToAction("Index");

        }
        [Route("UpdateRole/{id}")]
        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            UpdateRoleViewModel viewModel = new UpdateRoleViewModel()
            {
                RoleID = values.Id,
                RoleName = values.Name,
            };
            return View(viewModel);
        }
        [Route("UpdateRole/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRoleViewModel update)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == update.RoleID);
            value.Name = update.RoleName;
            await _roleManager.UpdateAsync(value);
            return RedirectToAction("Index");

        }
        [Route("UserList")]
        public IActionResult UserList()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }
        [Route("AssignRole/{id}")]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            TempData["Userid"] = user.Id;
            var roles = _roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);
            List<RoleAssignViewModel> roleassing = new List<RoleAssignViewModel>();
            foreach (var role in roles)
            {
                RoleAssignViewModel model = new RoleAssignViewModel();
                model.RoleID = role.Id;
                model.RoleName = role.Name;
                model.RoleExist = userRoles.Contains(role.Name);
                roleassing.Add(model);
            }
            return View(roleassing);
        }
        [Route("AssignRole/{id}")]
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> roles)
        {
            var userid =(int)TempData["userid"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userid);
            foreach(var item in roles)
            {
                if(item.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
         
            }
            return RedirectToAction("UserList");
        }
    }
}
