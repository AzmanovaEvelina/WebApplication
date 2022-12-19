using System;
namespace ReadExcel
{
    public class Day
    {
        public string name = "";
        public Date date = new Date();
        public Lesson[] lessons = new Lesson[6];

        public Day() { }

        public void Debug()
        {
            Console.WriteLine(name);
            for (int i = 0; i < lessons.Length; i++)
            {
                Console.WriteLine(lessons[i].time + "\t\t\t" + lessons[i].name);
            }
            Console.WriteLine('\n');
        }
    }
}

