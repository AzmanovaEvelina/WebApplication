using System;
using ClosedXML.Excel;

namespace ReadExcel
{
    class ExcelToTimetable
    {
        static int toMonth(string month)
        {
            if (month == "марта") return 3;
            if (month == "апреля") return 4;
            if (month == "октября") return 10;
            if (month == "ноября") return 11;
            return 0;
        }

        static int daysInMonths(int month)
        {
            if (month < 0) return 0;
            if (month == 2) return 28;
            return 30 + month % 2 + daysInMonths(month - 1);
        }

        public static Day[] ConvertExcelToTimetable(string path)
        {
            XLWorkbook workbook = new XLWorkbook(path);
            var sheet = workbook.Worksheet(1);

            // первая неделя или вторая
            string weekStart = sheet.Cell("a2").GetValue<string>();
            var weekStartWords = weekStart.Split();

            DateTime timetableStart = new DateTime();
            int isTimetableStartEven = 0;

            for (int i = 0; i < weekStartWords.Length; i++)
            {
                if (weekStartWords[i] == "марта" || weekStartWords[i] == "апреля" || weekStartWords[i] == "октября" || weekStartWords[i] == "ноября")
                {
                    timetableStart = new DateTime(DateTime.Now.Year, toMonth(weekStartWords[i]), Int32.Parse(weekStartWords[i - 1]));
                }

                if (weekStartWords[i] == "неделя")
                    isTimetableStartEven = Int32.Parse(weekStartWords[i - 1]);
            }

            int dif = daysInMonths(DateTime.Now.Month) + DateTime.Now.Day - (daysInMonths(timetableStart.Month) + timetableStart.Day) + isTimetableStartEven * 7;

            bool isFirst = (dif / 7) % 2 == 1;


            Day[] Week = new Day[6];
            for (int i = 0; i < Week.Length; i++)
            {
                Week[i] = new Day();

                /*
                 * номер строки в которой начинается день недели
                 * первые 4 строки -- общая инфа о расписании
                 * потом названия дней каждые 12 строчек
                */
                int dayStart = 12 * i + 4;

                // "имя" дня недели в первой клетке первой строки
                Week[i].name = sheet.Cell("a" + dayStart.ToString()).GetValue<string>();

                // todo: Week[i].date

                Week[i].lessons = new Lesson[6];
                for (int j = 0; j < Week[i].lessons.Length; j++)
                {
                    /*
                     * на каждое время пары отводится две строки: на первую
                     * неделю и на вторую, так что индекс пары это начало дня
                     * плюс номер пары * 2
                    */
                    int lessonIndex = dayStart + j * 2;

                    string time = sheet.Cell("b" + lessonIndex.ToString()).GetValue<string>();

                    /*
                     * время пары в строке с первой неделей, но если сейчас 
                     * вторая, то ее назваание в строке со второй неделей
                     */
                    if (!isFirst) lessonIndex++;
                    string name = sheet.Cell("c" + lessonIndex.ToString()).GetValue<string>();

                    Week[i].lessons[j] = new Lesson(name, time);
                }
            }
            return Week;
        }
    }
}