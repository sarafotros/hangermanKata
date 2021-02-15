using System;
using System.Globalization;

namespace HangerMan
{
    public class DateProvider
    {
        // 2021-02-08
        // private readonly DateTime dateTime = DateTime.Now;

        DateTime _localDate;

        public DateProvider()
        {
            _localDate = DateTime.Now;

        }

        public string TodaysDate()
        {

            var date = _localDate.ToString("d",DateTimeFormatInfo.InvariantInfo);

            return date;
        }
    }
}

