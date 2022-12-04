using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Services.Bussines;

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
            //return "Название группы: "+ userModel.GroupName;
            SecurityService securityService = new SecurityService();
            Boolean success = securityService.Authenticate(userModel);
            String groupENG = securityService.AuthenticateGROUP(userModel);
            if (success)
            {
                return "Успешный вход" + groupENG;
            }
            else
            {
                return "Не удалось войти";
            }
        }
    }
}