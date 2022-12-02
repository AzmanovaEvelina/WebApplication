using System;
using System.Net;
using System.Text;
using System.IO;
/*using System.Collections.Generic;
using System.Linq;*/

namespace DownLoadingLink
{
    class Program
    {
        public static void DownloadLink(string currentLink)
        {
            string fileDownload = @"C:\Users\User\Desktop\DownLoadFiles\ex.xlsx";
            //File.Create(fileDownload);
            //StreamWriter file = new StreamWriter(@"C:\Users\User\Desktop\DownLoadFiles\ex.xlsx");   - Подготовка для записи в файл
            using (var client = new WebClient())
            {
                client.DownloadFile(new Uri(currentLink), fileDownload);
            }
        }


        public static /*string*/ void CreateDownloadLink(string groupName)
        {
            string beginOfLinkString = "https://pstu.ru/files/file/Abitur/timetable/2022-2023%20Raspisanie%20zanyatijj%20";

            string facultyName = "EHTF";

            string fromFacultyToGroupOrfromGroupToNumber = "%20";

            string linkEnd = "%20%28osennijj%20%20posle%20smeny%29.xlsx";

            //Создание части ссылки с именем группы "____-**-**"
            string nameOfGroup = "        ";
            int stringElem = 0;

            while(groupName[stringElem] != '-')
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
            //return downloadLink;
            //return numberGroup;

            //return facultyName;

        }
        static void Main(string[] args)
        {
            string downloadLink;
            Console.WriteLine("Номер группы:");
            string groupName = Console.ReadLine();
            CreateDownloadLink(groupName);
            //Console.Write(downloadLink);
        }
    }
}
