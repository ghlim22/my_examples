using System;

namespace example73_2
{
    class Age
    {
        static uint[] days = { 0, 31, 59, 90, 120, 151, 181, 212, 242, 273, 304, 334 };

        static bool IsLeapYear(uint year)
        {
            return (year % 4 == 0) ^ (year % 100 == 0) ^ (year % 400 == 0);
        }

        static uint DaysPastYear(uint year, uint month, uint day)
        {
            uint daysPast = 0;
            return daysPast += days[month - 1] + day + (uint)(IsLeapYear(year) && (month > 2) ? 1 : 0);
        }

        public static uint GetTotalDays(uint bYear, uint bMonth, uint bDay)
        {
            uint totalDays = 0;

            DateTime today = DateTime.Today;
            uint tYear = Convert.ToUInt32(today.Year);
            uint tMonth = Convert.ToUInt32(today.Month);
            uint tDay = Convert.ToUInt32(today.Day);

            //올해 1월 1일 ~ 오늘까지의 날짜 구하기
            totalDays += DaysPastYear(tYear, tMonth, tDay);

            //태어난 해의 다음 년도 1월 1일 ~ 작년 12월 31일까지의 날짜 구하기
            for (uint year = bYear + 1; year < tYear; ++year)
            {
                totalDays += (uint)(IsLeapYear(year) ? 366 : 365);
            }

            //생일 ~ 태어난 해의 12월 31일까지의 날짜 구하기.
            totalDays += (uint)(IsLeapYear(bYear) ? 366 : 365) - DaysPastYear(bYear, bMonth, bDay);

            //총 날짜 반환
            return totalDays;
        }
    }
}