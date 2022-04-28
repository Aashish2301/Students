using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Models.General;
using WebMatrix.WebData;

namespace WebApplication2.Controllers
{
    public class RolesController : Controller
    {

        public TestEntities2 db = new TestEntities2();
        // GET: Roles
        [Authorize(Roles = "Administrator , Manager")]
        public ActionResult Index()
        {
            return View(db.webpages_Roles.ToList());
        }

        [Authorize(Roles = "Administrator , Manager")]
        public ActionResult Details(int id)
        {
            return View(db.webpages_Roles.Where(x => x.RoleId == id).FirstOrDefault());
        }



        [Authorize(Roles = "Administrator , Manager")]
        public ActionResult Edit(int id)
        {
            var data = db.webpages_Roles.Where(x => x.RoleId == id).FirstOrDefault();
            return View(data);
        }

        // POST: Home/Edit/5
        [HttpPost]
        [Authorize(Roles = "Administrator , Manager")]
        public ActionResult Edit(int id, webpages_Roles webpages,string Rolecode)
        {
            using (var dbcontext = new TestEntities2())

            {

                var Roleexist = from temprec in dbcontext.webpages_Roles

                                where temprec.RoleCode.Equals(Rolecode.Trim())


                                select temprec;
                try
                {
                    if (Roleexist.Count() > 0)

                    {

                        ModelState.AddModelError("RoleCode", "Role Code Already Exist");


                    }

                    else
                    {
                        db.Entry(webpages).State = EntityState.Modified;
                        db.SaveChanges();

                    }
                }

                catch
                {
                    ModelState.AddModelError("RoleName", "Role Name Already Exist");
                }


                return RedirectToAction("Index", "Roles");

            }
        }

        [Authorize(Roles = "Administrator , Manager")]
        public ActionResult CheckDuplicates()
        {
            return View ();
        }



        [HttpPost]
        [Authorize(Roles = "Administrator , Manager")]
        public ActionResult CheckDuplicates(string Rolecode, webpages_Roles webpages)

        {
            using (var dbcontext = new TestEntities2())

            {

                var Roleexist = from temprec in dbcontext.webpages_Roles

                                where temprec.RoleCode.Equals(Rolecode.Trim())


                                select temprec;
                try
                {
                    if (Roleexist.Count() > 0)

                    {

                        ModelState.AddModelError("RoleCode", "Role Code Already Exist");


                    }





                    else
                    {



                        db.webpages_Roles.Add(webpages);
                        db.SaveChanges();
                        return RedirectToAction("Index", "Dashboard");
                    }
                }
                catch
                {
                    ModelState.AddModelError("RoleName", "Role Name Already Exist");
                }

                return View();


            }
   
        }


        //public ActionResult Delete(int id)
        //{

        //    var data = db.webpages_Roles.Where(x => x.RoleId == id).FirstOrDefault();

        //    return View(data);
        //}


        //[HttpPost]
        //[Authorize(Roles = "Administrator , Manager")]
        //public ActionResult Delete(int id, FormCollection collection)
        //{

        //    try
        //    {

        //        var userolse = db.webpages_Roles.Where(x => x.RoleId == id);
        //        db.webpages_Roles.RemoveRange(userolse);
        //       webpages_Roles users = db.webpages_Roles.Where(x => x.RoleId == id).FirstOrDefault();
        //        db.webpages_Roles.Remove(users);
        //        db.SaveChanges();



        //        // TODO: Add delete logic here
        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception e)
        //    {
        //        return View(e);
        //    }
        //}


    }

}
