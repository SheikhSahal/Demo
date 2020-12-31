using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DB;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UpdateController : Controller
    {
        Database DB = new Database();
        // GET: Update
        public ActionResult Index(int id)
        {
            EMP emp = DB.get_data(id);
            ViewBag.EMP = emp;

            return View();
        }

        [HttpPost]
        public ActionResult Index(EMP e)
        {
            bool status = false;
            DB.UpdateEMP(e);

            status = true;
            return new JsonResult { Data = new { status = status } };
        }
    }
}