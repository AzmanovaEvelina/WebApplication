using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class EntranceController : Controller
    {
        // GET: Entrance
        public ActionResult Index()
        {
            return View("Entrance");
        }
        public string Entrance(UserModel userModel)
        {
            return "Название группы: "+ userModel.GroupName;
        }
    }
}