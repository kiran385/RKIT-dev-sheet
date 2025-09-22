using System;

namespace HelloWorld
{
    public class DateTimeDemo
    {
        public static void MyDateTimeDemo()
        {
            DateTime dt = DateTime.Now;
            Console.WriteLine("Current date and time : {0}", dt);

            DateTime today = DateTime.Today;
            Console.WriteLine("Today's date : {0}", today);

            DateTime customDate = new DateTime(2024, 12, 10, 15, 30, 45, 500);
            Console.WriteLine("Custom date : {0}",customDate);
            customDate = customDate.ToLocalTime();
            customDate = customDate.ToUniversalTime();

            Console.WriteLine($"ToString : {customDate.ToString("yyyy-MM-dd HH:mm:ss")}");

            Console.WriteLine($"\nYear : {customDate.Year} " +
                                $"\nMonth : {customDate.Month} " +
                                $"\nDay : {customDate.Day} " +
                                $"\nHour : {customDate.Hour}" +
                                $"\nMinute : {customDate.Month}" +
                                $"\nSecond : {customDate.Second}" +
                                $"\nMilliSecond : {customDate.Millisecond}" +
                                $"\nDayOfWeek : {customDate.DayOfWeek}" +
                                $"\nDayOfYear : {customDate.DayOfYear}" +
                                $"\nKind : {customDate.Kind}" +
                                $"\nTicks : {customDate.Ticks}" +
                                $"\nDaysInMonth : {DateTime.DaysInMonth(2024,2)}" +
                                $"\nIsLeapYear : {DateTime.IsLeapYear(customDate.Year)}");

            Console.WriteLine($"\nAdd : {customDate.AddYears(-1).AddMonths(2).AddDays(-5).AddHours(5)}");

            Console.WriteLine($"Subtract : {DateTime.Now - customDate}");

            Console.WriteLine($"Compare : {DateTime.Now.CompareTo(customDate)}");

            Console.WriteLine($"Parse : {DateTime.Parse("2020-10/15")}");
        }
    }
}
