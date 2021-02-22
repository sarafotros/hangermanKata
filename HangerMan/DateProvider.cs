using System;
using System.Globalization;

namespace HangerMan
{
    public class DateProvider
    {
       
        DateTime _localDate;

        public DateProvider()
        {
            _localDate = DateTime.Now;

        }

        public string TodaysDate()
        {

            var date = _localDate.ToString("yyyy-MM-dd");

            return date;
        }
    }
}

