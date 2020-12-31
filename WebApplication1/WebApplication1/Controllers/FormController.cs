using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.DB;

namespace WebApplication1.Controllers
{
    public class FormController : Controller
    {
        Database DB = new Database();
        // GET: Form
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(EMP e)
        {
            bool status = false;

            DB.InsertEMP(e);
            status = true;

            return new JsonResult { Data = new { status = status } };
        }


        
       


    }
}