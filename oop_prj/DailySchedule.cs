using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    [Serializable]
    public class DailySchedule : Schedule
    {
        public DateTime Date { get; set; }

        public override string GetScheduleInfo()
        {
            return base.GetScheduleInfo() + $" | Date: {Date.ToShortDateString()}";
        }
    }
}