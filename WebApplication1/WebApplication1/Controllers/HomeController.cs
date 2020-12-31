using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DB;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        Database DB = new Database();
        // GET: Home
        public ActionResult Index()
        {
            List<EMP> emp = DB.EMP_List();
            ViewBag.emplist = emp;
            return View();
        }

        public ActionResult Delete(int id)
        {
            bool status = false;

            DB.DeleteEMP(id);
            status = true;

            return RedirectToAction("Index","Home");
        }
    }
}