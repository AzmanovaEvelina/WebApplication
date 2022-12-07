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
        // GET: Timetable
        public ActionResult Timetable()
        {
            string excelName = "test.xlsx";
            string pathToExcel = @"D:\Downloads";
            ViewBag.Week = $@"{pathToExcel}\{excelName}";
            ViewBag.Week = ExcelToTimetable.ConvertExcelToTimetable($@"{pathToExcel}\{excelName}");
            return View();
        }
    }
}