using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class ScheduleManager
    {
        private List<Schedule> schedules;
        private const string filePath = "schedules.dat";

        public ScheduleManager()
        {
            schedules = new List<Schedule>();
        }

        public void AddSchedule(Schedule schedule)
        {
            schedules.Add(schedule);
        }

        public void UpdateSchedule(Schedule schedule)
        {
            Schedule existingSchedule = schedules.Find(s => s.Name == schedule.Name);
            if (existingSchedule != null)
            {
                existingSchedule.StartTime = schedule.StartTime;
                existingSchedule.EndTime = schedule.EndTime;
            }
        }

        public void DeleteSchedule(Schedule schedule)
        {
            schedules.Remove(schedule);
        }

        public List<Schedule> GetAllSchedules()
        {
            return schedules;
        }

        public List<Schedule> GetSchedulesByDate(DateTime date)
        {
            return schedules.FindAll(s => s.StartTime.Date == date.Date);
        }

        public void SaveSchedules()
        {
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, schedules);
            }
        }

        public void LoadSchedules()
        {
            if (File.Exists(filePath))
            {
                using (FileStream stream = new FileStream(filePath, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    List<Schedule> loadedSchedules = (List<Schedule>)formatter.Deserialize(stream);
                    schedules = loadedSchedules;
                }
            }
        }
    }
}