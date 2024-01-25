using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class DateModifier
    {
        public DateTime FirstDate { get; set; }
        public DateTime SecondDate { get; set; }

        public DateModifier(string firstDate, string secondDate)
        {
            FirstDate = Convert.ToDateTime(firstDate);
            SecondDate = Convert.ToDateTime(secondDate);
        }

        public void CalculateDifference()
        {
            TimeSpan difference = FirstDate - SecondDate;
            double days = Math.Abs(difference.TotalDays);

            Console.WriteLine(days);
        }
    }
}
