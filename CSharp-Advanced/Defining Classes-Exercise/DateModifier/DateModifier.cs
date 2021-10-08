using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifier
{
    public class DateModifier
    {
        public static int CalculateDiffranceBetweenDays(string startDay, string endDay)
        {
            DateTime dateOne = DateTime.Parse(startDay);
            DateTime dateTwo = DateTime.Parse(endDay);

            int days = Math.Abs((dateOne - dateTwo).Days);

            return days;
        }
    }
}
