using JAnet_ALlison_PHotography.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Web.Security;
using System.Security.Claims;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JAnet_ALlison_PHotography.Controllers
{
    public class UserViewModelController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        List<SelectListItem> list = new List<SelectListItem>(); // greate a list to populate with employee user
        List<UserViewModel> UserList = new List<UserViewModel>(); // to hold list of Users

        //private readonly UserManager<ApplicationUser> _userManager;

        //public UserViewModelController(UserManager<ApplicationUser> userManager)
        //{
        //    _userManager = userManager;
        //}


        // GET: UserViewModel
        public ActionResult Index()
        {

            var currentUser = System.Web.HttpContext.Current.User.Identity.GetUserName(); 
            ViewBag.UserId = currentUser;



            //List<UserViewModel> modelLst = new List<UserViewModel>();
            //var role = context.Roles.Include(x => x.Users).ToList();

            //foreach (var r in role)
            //{
            //    foreach (var u in r.Users)
            //    {
            //        var usr = context.Users.Find(u.UserId);
            //        var obj = new UserViewModel
            //        {
            //            FirstName = usr.FirstName,
            //            LastName = usr.LastName,
            //            RoleName = r.Name
            //        };
            //        modelLst.Add(obj);
            //    }
            //    ViewBag.ModelList = modelLst;
            //}

            var usersWithRoles = (from user in context.Users
                                  from userRole in user.Roles
                                  join role in context.Roles on userRole.RoleId equals
                                  role.Id
                                  select new { user.Id, user.FirstName, user.LastName, role.Name }).ToList();
            foreach (var item in usersWithRoles)
            {
                if (item.Name.Equals("Employee"))
                {
                    list.Add(new SelectListItem() { Value = item.Id, Text = item.FirstName + " " + item.LastName });

                    //UserViewModel obj = new UserViewModel(); // ViewModel  to display the user and their role
                    //obj.Id = item.Id;
                    //obj.FirstName = item.FirstName;
                    //obj.LastName = item.LastName;
                    //obj.RoleName = item.Name;
                    
                    //UserList.Add(obj);
                }
            }
            ViewBag.Employee = list;

            return View(); //View(UserList);
                                  //UserViewModel()
                                  //{
                                  //    FirstName = user.FirstName,
                                  //    LastName = user.LastName,
                                  //    RoleName = role.Name
                                  //}).ToList();

            //return View(usersWithRoles);

        }

        [HttpPost]
        public ActionResult Index(UserViewModel uvm)
        {
            List<SelectListItem> list = new List<SelectListItem>(); // greate a list to populate with employee user

            ViewBag.Try = uvm.Id;

            var usersWithRoles = (from user in context.Users
                                  from userRole in user.Roles
                                  join role in context.Roles on userRole.RoleId equals
                                  role.Id
                                  select new { user.Id, user.FirstName, user.LastName, role.Name }).ToList();
            foreach (var item in usersWithRoles)
            {
                if (item.Name.Equals("Employee"))
                {
                    list.Add(new SelectListItem() { Value = item.Id, Text = item.FirstName + " " + item.LastName });
                }
            }
           
            
            ViewBag.Employee = list;
            return View();
        }
    }
}