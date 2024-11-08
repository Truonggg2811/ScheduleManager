using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    [Serializable]
    public class MonthlySchedule : Schedule
    {
        public int MonthDay { get; set; }

        public override string GetScheduleInfo()
        {
            return base.GetScheduleInfo() + $" | Month Day: {MonthDay}";
        }
    }

}
