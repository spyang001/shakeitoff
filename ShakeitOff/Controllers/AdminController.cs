using ShakeitOff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShakeitOff.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        UserRoleAssignHelper helper = new UserRoleAssignHelper();


        // GET: Admin
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<AdminUserViewModel> userList = new List<AdminUserViewModel>();
            foreach (var users in db.Users.ToList())
            {
                var userCollection = new AdminUserViewModel();
                userCollection.user = users;
                userCollection.role = helper.ListUserRoles(users.Id).ToList();
                userList.Add(userCollection);
            }
            return View(userList);
        }


        //Get: Admin/SelectRole/5
        public ActionResult SelectRole(string id)
        {
            var user = db.Users.Find(id);
            var roleUser = new UserRoleViewModel();
            roleUser.Id = user.Id;
            roleUser.FirstName = user.FirstName;
            //roleUser.LastName = user.LastName;
            roleUser.DisplayName = user.DisplayName;
            roleUser.SeletedRoles = helper.ListUserRoles(user.Id).ToArray();
            roleUser.UserRoles = new MultiSelectList(db.Roles, "Name", "Name", roleUser.SeletedRoles);

            return View(roleUser);
        }

        [HttpPost]
        public ActionResult SelectRole(UserRoleViewModel model)
        {
            var user = db.Users.Find(model.Id);
            foreach (var roler in db.Roles.Select(r => r.Id).ToList())
            // foreach (var rolermv in user.Roles.ToList())
            {
                helper.RemoveUserFromRole(user.Id, roler); 
            }

            foreach (var roleadd in model.SeletedRoles)
            {
                helper.AddUserToRole(user.Id, roleadd);
            }
            ViewBag.Confirm = "User's role had been successfully modified";
            return RedirectToAction("Index");


        }
    }
}