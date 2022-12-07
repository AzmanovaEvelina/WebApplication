using System;
using ClosedXML.Excel;

namespace ReadExcel
{
    class ExcelToTimetable
    {
        public static Day[] ConvertExcelToTimetable(string path)
        {
            XLWorkbook workbook = new XLWorkbook(path);
            var sheet = workbook.Worksheet(1);

            string weekStart = sheet.Cell("a2").GetValue<string>();
            // todo сделать определение, первая или вторая неделя
            bool isFirst = false;

            //Console.WriteLine(DateTime.Now);

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