using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TestView()
        {
            return View();
        }
        public string PrintMessage()
        {
            return "<h1>Welcome</h1><p>This is the custom page.</p>";
        }

        public string Play()
        {
            return "<h1>Добро пожаловать!</h1><p>This is the custom page.</p>";
        }
    }
   
}