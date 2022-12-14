using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Services.Bussines;

namespace WebApplication.Controllers
{
    public class EntranceController : Controller
    {
        // GET: Entrance парпарп
        public ActionResult Index()
        {
            return View("Entrance");
        }
        public static void DownloadLink(string currentLink)
        {
            string fileDownload = @"C:\Users\User\Desktop\DownLoadFiles\ex.xlsx";
            //string fileDownload = @"C:\Users\HONOR\Desktop\DownLoadFiles\ex.xlsx";
            using (var client = new WebClient())
            {
                client.DownloadFile(new Uri(currentLink), fileDownload);
            }
        }
        public static void CreateDownloadLink(string groupName)
        {
            string beginOfLinkString = "https://pstu.ru/files/file/Abitur/timetable/2022-2023%20Raspisanie%20zanyatijj%20";

            string facultyName = "EHTF";

            string fromFacultyToGroupOrfromGroupToNumber = "%20";

            string linkEnd = "%20%28osennijj%20%20posle%20smeny%29.xlsx";

            //Создание части ссылки с именем группы "____-**-**"
            string nameOfGroup = "        ";
            int stringElem = 0;

            while (groupName[stringElem] != '-')
            {
                StringBuilder workString = new StringBuilder(nameOfGroup);
                workString[stringElem] = groupName[stringElem];
                nameOfGroup = workString.ToString();
                stringElem++;
            }
            nameOfGroup = nameOfGroup.Replace(" ", "");

            stringElem = stringElem + 1;

            // Конец блока

            //Создание остальной части ссылки

            string numberGroup = groupName.Substring(stringElem, groupName.Length - stringElem);

            string downloadLink = beginOfLinkString + facultyName + fromFacultyToGroupOrfromGroupToNumber + nameOfGroup + fromFacultyToGroupOrfromGroupToNumber + "-" + numberGroup + linkEnd;

            DownloadLink(downloadLink);
        }
        public string Entrance(UserModel userModel)
        {
            SecurityService securityService = new SecurityService();
            Boolean success = securityService.Authenticate(userModel);
            String groupENG = securityService.AuthenticateGROUP(userModel);
            CreateDownloadLink(groupENG);
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