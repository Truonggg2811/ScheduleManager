using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    [Serializable]
    public class WeeklySchedule : Schedule
    {
        public DayOfWeek WeekDay { get; set; }

        public override string GetScheduleInfo()
        {
            return base.GetScheduleInfo() + $" | Week Day: {WeekDay}";
        }
    }
}