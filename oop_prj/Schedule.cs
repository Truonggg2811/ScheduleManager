using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsFormsApp2
{
    [Serializable]
    public class Schedule
    {
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public virtual string GetScheduleInfo()
        {
            return $"Name: {Name} | Start: {StartTime} | End: {EndTime}";
        }

        public override string ToString()
        {
            return GetScheduleInfo();
        }
    }
}