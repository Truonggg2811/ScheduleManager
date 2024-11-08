using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public class MainForm : Form
    {
        private ScheduleManager scheduleManager;
        private UserManager userManager;
        private NotificationManager notificationManager;
        private ListBox listBoxSchedules;
        private Button buttonAdd;
        private Button buttonEdit;
        private Button buttonDelete;
        private Button buttonSave;
        private Button buttonLoad;
        private DateTimePicker dateTimePickerSearch;
        private Button buttonSearch;
        private Timer notificationTimer;

        public MainForm()
        {
            scheduleManager = new ScheduleManager();
            userManager = new UserManager();
            notificationManager = new NotificationManager();
            InitializeComponent();
            InitializeNotificationTimer();
        }

        private void InitializeComponent()
        {
            this.listBoxSchedules = new System.Windows.Forms.ListBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.dateTimePickerSearch = new System.Windows.Forms.DateTimePicker();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxSchedules
            // 
            this.listBoxSchedules.BackColor = System.Drawing.Color.White;
            this.listBoxSchedules.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxSchedules.FormattingEnabled = true;
            this.listBoxSchedules.ItemHeight = 23;
            this.listBoxSchedules.Location = new System.Drawing.Point(1, 12);
            this.listBoxSchedules.Name = "listBoxSchedules";
            this.listBoxSchedules.Size = new System.Drawing.Size(751, 301);
            this.listBoxSchedules.TabIndex = 0;
            this.listBoxSchedules.SelectedIndexChanged += new System.EventHandler(this.listBoxSchedules_SelectedIndexChanged);
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.LightGreen;
            this.buttonAdd.ForeColor = System.Drawing.Color.Black;
            this.buttonAdd.Location = new System.Drawing.Point(12, 321);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(169, 42);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Add Schedule";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.BackColor = System.Drawing.Color.LightYellow;
            this.buttonEdit.ForeColor = System.Drawing.Color.Black;
            this.buttonEdit.Location = new System.Drawing.Point(322, 321);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(162, 42);
            this.buttonEdit.TabIndex = 2;
            this.buttonEdit.Text = "Edit Schedule";
            this.buttonEdit.UseVisualStyleBackColor = false;
            this.buttonEdit.Click += new System.EventHandler(this.ButtonEdit_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.LightCoral;
            this.buttonDelete.ForeColor = System.Drawing.Color.White;
            this.buttonDelete.Location = new System.Drawing.Point(590, 321);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(162, 42);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Delete Schedule";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.LightBlue;
            this.buttonSave.ForeColor = System.Drawing.Color.Black;
            this.buttonSave.Location = new System.Drawing.Point(12, 373);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(169, 42);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.buttonLoad.ForeColor = System.Drawing.Color.Black;
            this.buttonLoad.Location = new System.Drawing.Point(322, 369);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(162, 42);
            this.buttonLoad.TabIndex = 5;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = false;
            this.buttonLoad.Click += new System.EventHandler(this.ButtonLoad_Click);
            // 
            // dateTimePickerSearch
            // 
            this.dateTimePickerSearch.CalendarMonthBackground = System.Drawing.Color.LightCyan;
            this.dateTimePickerSearch.Location = new System.Drawing.Point(12, 441);
            this.dateTimePickerSearch.Name = "dateTimePickerSearch";
            this.dateTimePickerSearch.Size = new System.Drawing.Size(304, 30);
            this.dateTimePickerSearch.TabIndex = 6;
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.LightPink;
            this.buttonSearch.ForeColor = System.Drawing.Color.Black;
            this.buttonSearch.Location = new System.Drawing.Point(322, 441);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(165, 32);
            this.buttonSearch.TabIndex = 7;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(764, 483);
            this.Controls.Add(this.listBoxSchedules);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.dateTimePickerSearch);
            this.Controls.Add(this.buttonSearch);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "MainForm";
            this.Text = "Schedule Manager";
            this.ResumeLayout(false);

        }

        private void InitializeNotificationTimer()
        {
            notificationTimer = new Timer();
            notificationTimer.Interval = 60000; // Kiểm tra mỗi phút
            notificationTimer.Tick += NotificationTimer_Tick;
            notificationTimer.Start();
        }

        private void NotificationTimer_Tick(object sender, EventArgs e)
        {
            List<Schedule> schedules = scheduleManager.GetAllSchedules();
            notificationManager.CheckSchedules(schedules);
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            ScheduleInputForm inputForm = new ScheduleInputForm();
            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                Schedule newSchedule = inputForm.GetSchedule();
                scheduleManager.AddSchedule(newSchedule);
                UpdateScheduleList();
            }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (listBoxSchedules.SelectedItem is Schedule selectedSchedule)
            {
                ScheduleInputForm inputForm = new ScheduleInputForm(selectedSchedule);
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    scheduleManager.UpdateSchedule(inputForm.GetSchedule());
                    UpdateScheduleList();
                }
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (listBoxSchedules.SelectedItem is Schedule selectedSchedule)
            {
                scheduleManager.DeleteSchedule(selectedSchedule);
                UpdateScheduleList();
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            scheduleManager.SaveSchedules();
        }

        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            scheduleManager.LoadSchedules();
            UpdateScheduleList();
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            DateTime searchDate = dateTimePickerSearch.Value;
            List<Schedule> results = scheduleManager.GetSchedulesByDate(searchDate);
            listBoxSchedules.Items.Clear();
            foreach (Schedule schedule in results)
            {
                listBoxSchedules.Items.Add(schedule);
            }
        }

        private void UpdateScheduleList()
        {
            listBoxSchedules.Items.Clear();
            List<Schedule> schedules = scheduleManager.GetAllSchedules();
            foreach (Schedule schedule in schedules)
            {
                listBoxSchedules.Items.Add(schedule);
            }
        }

        private void listBoxSchedules_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}