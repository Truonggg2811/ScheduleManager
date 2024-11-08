using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsApp2;

public class NotificationManager
{
    public void ShowReminder(string message)
    {
        MessageBox.Show(message, "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public void ShowOverdue(string message)
    {
        MessageBox.Show(message, "Quá hạn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    public void CheckSchedules(List<Schedule> schedules)
    {
        DateTime now = DateTime.Now;

        foreach (Schedule schedule in schedules)
        {
            if (schedule.StartTime <= now.AddMinutes(15) && schedule.StartTime > now)
            {
                ShowReminder($"Nhắc nhở: {schedule.Name} sẽ bắt đầu trong vòng 15 phút tới lúc {schedule.StartTime}");
            }

            if (schedule.EndTime < now)
            {
                ShowOverdue($"Quá hạn: {schedule.Name} đã được lên lịch kết thúc lúc {schedule.EndTime}");
            }
        }
    }
}