
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication2.Models;
using WebApplication2.Models.Account;
using WebApplication2.Models.General;
using WebApplication2.ViewModels.Account;
using WebMatrix.WebData;
using PagedList;

namespace WebApplication2.Controllers
{
    public class AccountController : Controller
    {

        public TestEntities2 db = new TestEntities2();

        [Authorize(Roles = "Administrator , Manager")]
        public ActionResult Index(int? page)
        {
            var I = db.Users.ToList().ToPagedList(page ?? 1, 3);
            return View(I);
        }
        [Authorize(Roles = "Administrator , Manager")]
        public ActionResult Details(int id)
        {
            return View(db.Users.Where(x => x.UserId == id).FirstOrDefault());
        }







        // GET: Home/Edit/5
        [Authorize(Roles = "Administrator , Manager")]
        public ActionResult Edit(int id)
        {
            var data = db.Users.Where(x => x.UserId == id).FirstOrDefault();
            return View(data);
        }

        // POST: Home/Edit/5
        [HttpPost]
        [Authorize(Roles = "Administrator , Manager")]
        public ActionResult Edit(int id, User user)
        {
            try
            {
                // TODO: Add update logic here

                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(db.Users.Where(x => x.UserId == id).FirstOrDefault());
            }
        }

        [Authorize(Roles = "Administrator , Manager")]
        public ActionResult Delete(int id)
        {

            var data = db.Users.Where(x => x.UserId == id).FirstOrDefault();

            return View(data);
        }


        [HttpPost]
        [Authorize(Roles = "Administrator , Manager")]
        public ActionResult Delete(int id, FormCollection collection)
        {

            try
            {

                var userolse = db.webpages_UsersInRoles.Where(x => x.UserId == id);
                db.webpages_UsersInRoles.RemoveRange(userolse);
                User users = db.Users.Where(x => x.UserId == id).FirstOrDefault();
                db.Users.Remove(users);
                db.SaveChanges();



                // TODO: Add delete logic here
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(e);
            }
        }




        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel loginModel)

        {
            if (ModelState.IsValid)
            {

                bool isAuthenticated = WebSecurity.Login(loginModel.UserName, loginModel.Password, loginModel.RememberMe);


                if (isAuthenticated)
                {
                    string returnUrl = Request.QueryString["ReturnUrl"];

                    if (returnUrl == null)
                    {
                        return RedirectToAction("Index", "Dashboard");
                    }
                    else
                    {
                        return Redirect(Url.Content(returnUrl));
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is Invalid");
                }
            }


            return View();
        }

        public ActionResult Logoff()
        {
            WebSecurity.Logout();
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        [Authorize(Roles = "Administrator , Manager")]
        public ActionResult Register()
        {
            GetRolesForCurrentUser();
            return View();
        }

        private ActionResult GetRolesForCurrentUser()
        {
            if (System.Web.Security.Roles.IsUserInRole(WebSecurity.CurrentUserName, "Administrator"))
                ViewBag.RoleId = (int)Role.Administrator;
            else
                ViewBag.RoleId = (int)Role.NoRole;
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator , Manager")]
        public ActionResult Register(RegisterModel registerModel)
        {

            GetRolesForCurrentUser();

            if (ModelState.IsValid)
            {
                bool isUserExists = WebSecurity.UserExists(registerModel.UserName);

                if (isUserExists)
                {
                    ModelState.AddModelError("UserName", "User Name is Already Exists.");
                }
                else
                {
                    WebSecurity.CreateUserAndAccount(registerModel.UserName, registerModel.Password, new
                    {
                        FullName = registerModel.FullName,
                        Email = registerModel.Email,
                        Gender = registerModel.Gender,
                        MobileNo = registerModel.MobileNo,
                        IsActive = registerModel.IsActive
                    });
                    System.Web.Security.Roles.AddUserToRole(registerModel.UserName, registerModel.Role);

                    return RedirectToAction("Index", "Dashboard");
                }
            }
            return View();
        }
        [HttpGet, Authorize]

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost, Authorize, ValidateAntiForgeryToken]

        public ActionResult ChangePassword(ChangePasswordModel changePasswordModel)
        {

            if (ModelState.IsValid)
            {
                bool isPasswordChanged = WebSecurity.ChangePassword(WebSecurity.CurrentUserName, changePasswordModel.OldPassword, changePasswordModel.NewPassword);
                if (isPasswordChanged)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ModelState.AddModelError("OldPassword", "Old Password is not correct");
                }
            }
            return View();
        }

        [HttpGet, Authorize]
        public ActionResult UserProfile()
        {
            return View();
        }





    }
}