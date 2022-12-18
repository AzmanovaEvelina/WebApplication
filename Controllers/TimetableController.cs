using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReadExcel;

namespace WebApplication.Controllers
{
    public class TimetableController : Controller
    {
        // GET: TimetableSSS
        public ActionResult Timetable()
        {
            // Вызов /Timetable/Timetable
            //string excelName = "test.xlsx";
            //string pathToExcel = @"D:\Downloads";

            // Путь до Excel файла, где скачено расписание
            // Эвелина:
             //string excelWithTimetable = @"C:\Users\HONOR\Desktop\DownLoadFiles\ex.xlsx";
             //Артур
            string excelWithTimetable = @"C:\Users\User\Desktop\DownLoadFiles\ex.xlsx";

            ViewBag.Week = ExcelToTimetable.ConvertExcelToTimetable(excelWithTimetable);
            return View();
        }
    }
}