using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RogerDot.Dialogs.WeekInfo
{

    public class WeekInfo
    {
        private enum DaysOfWeek
        {
            Sunday,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Niedziela,
            Poniedziałek,
            Wtorek,
            Środa,
            Czwartek,
            Piątek,
            Sobota
        };
        public static DateTime[] pairDays =
       {
            new DateTime(2017,10,09), new DateTime(2017,10,23),
            new DateTime(2017,11,06), new DateTime(2017,11,20),
            new DateTime(2017,12,04), new DateTime(2017,12,18),
            new DateTime(2018,01,15), new DateTime(2017,10,10),
            new DateTime(2017,10,24), new DateTime(2017,11,07),
            new DateTime(2017,11,21), new DateTime(2017,12,05),
            new DateTime(2017,12,19), new DateTime(2018,01,16),
            new DateTime(2017,10,11), new DateTime(2017,10,25),
            new DateTime(2017,11,08), new DateTime(2017,11,22),
            new DateTime(2017,12,06), new DateTime(2017,12,20),
            new DateTime(2017,01,10), new DateTime(2017,10,05),
            new DateTime(2017,10,19), new DateTime(2017,11,09),
            new DateTime(2017,11,23), new DateTime(2017,12,07),
            new DateTime(2017,12,21), new DateTime(2018,01,11),
            new DateTime(2017,10,06), new DateTime(2017,10,20),
            new DateTime(2017,11,03), new DateTime(2017,11,17),
            new DateTime(2017,12,01), new DateTime(2017,12,15),
            new DateTime(2018,01,12)
        };
        public static DateTime[] nonPairDays =
        {
            new DateTime(2017,10,02), new DateTime(2017,10,16),
            new DateTime(2017,10,30), new DateTime(2017,11,13),
            new DateTime(2017,11,27), new DateTime(2017,11,12),
            new DateTime(2018,01,08), new DateTime(2018,01,22),
            new DateTime(2017,10,03), new DateTime(2017,10,17),
            new DateTime(2017,10,31), new DateTime(2017,11,14),
            new DateTime(2017,11,28), new DateTime(2017,12,12),
            new DateTime(2018,01,09), new DateTime(2018,01,23),
            new DateTime(2017,10,04), new DateTime(2017,10,18),
            new DateTime(2017,11,02), new DateTime(2017,11,15),
            new DateTime(2017,11,29), new DateTime(2017,12,13),
            new DateTime(2018,01,03), new DateTime(2018,01,17),
            new DateTime(2017,09,28), new DateTime(2017,10,12),
            new DateTime(2017,10,26), new DateTime(2017,11,16),
            new DateTime(2017,11,30), new DateTime(2017,12,14),
            new DateTime(2018,01,04), new DateTime(2018,01,18),
            new DateTime(2017,09,29), new DateTime(2017,10,13),
            new DateTime(2017,10,27), new DateTime(2017,11,10),
            new DateTime(2017,11,24), new DateTime(2017,12,08),
            new DateTime(2018,01,05), new DateTime(2018,01,19)
        };
        public static bool IsDay(string t)
        {
            try
            {
                DaysOfWeek day = (DaysOfWeek)Enum.Parse(typeof(DaysOfWeek), t, true);
                return true;
            } catch
            {
                return false;
            }

        }
        public static DateTime ConvertToNextDay(string t)
        {
            DateTime today = System.DateTime.Today;
            DaysOfWeek oldDay = (DaysOfWeek)Enum.Parse(typeof(DaysOfWeek), t, true);
            if ((int)oldDay > 6) oldDay -= 7;
            DayOfWeek sentDay = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), oldDay.ToString(), true);
            DateTime requestedDay;
            if ((int)today.DayOfWeek < (int)sentDay)
            {
                requestedDay = today + new System.TimeSpan((int)sentDay - (int)today.DayOfWeek, 0, 0, 0);
            } else if ((int)today.DayOfWeek > (int)sentDay)
            {
                int diff = 7 - (int)today.DayOfWeek + (int)sentDay;
                requestedDay = today + new System.TimeSpan(diff, 0, 0, 0);
            } else requestedDay = today + new System.TimeSpan(7, 0, 0, 0);
            return requestedDay;

        }

    }
}