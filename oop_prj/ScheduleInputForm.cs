using System;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public class ScheduleInputForm : Form
    {
        private TextBox textBoxName;
        private DateTimePicker dateTimePickerStart;
        private DateTimePicker dateTimePickerEnd;
        private Button buttonOK;
        private Button buttonCancel;

        private Schedule schedule;

        public ScheduleInputForm()
        {
            InitializeComponent();
            SetPlaceholderText();
        }

        public ScheduleInputForm(Schedule existingSchedule) : this()
        {
            schedule = existingSchedule;
            textBoxName.Text = schedule.Name;
            dateTimePickerStart.Value = schedule.StartTime;
            dateTimePickerEnd.Value = schedule.EndTime;
        }

        private void InitializeComponent()
        {
            this.textBoxName = new TextBox();
            this.dateTimePickerStart = new DateTimePicker();
            this.dateTimePickerEnd = new DateTimePicker();
            this.buttonOK = new Button();
            this.buttonCancel = new Button();

            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(12, 12);
            this.textBoxName.Size = new System.Drawing.Size(260, 20);
            this.textBoxName.Enter += new EventHandler(TextBoxName_Enter);
            this.textBoxName.Leave += new EventHandler(TextBoxName_Leave);

            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(12, 38);
            this.dateTimePickerStart.Size = new System.Drawing.Size(260, 20);
            this.dateTimePickerStart.Format = DateTimePickerFormat.Custom;
            this.dateTimePickerStart.CustomFormat = "dd/MM/yyyy HH:mm";

            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(12, 64);
            this.dateTimePickerEnd.Size = new System.Drawing.Size(260, 20);
            this.dateTimePickerEnd.Format = DateTimePickerFormat.Custom;
            this.dateTimePickerEnd.CustomFormat = "dd/MM/yyyy HH:mm";

            // 
            // buttonOK
            // 
            this.buttonOK.Text = "OK";
            this.buttonOK.Location = new System.Drawing.Point(12, 90);
            this.buttonOK.Click += new EventHandler(this.ButtonOK_Click);

            // 
            // buttonCancel
            // 
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Location = new System.Drawing.Point(100, 90);
            this.buttonCancel.Click += new EventHandler(this.ButtonCancel_Click);

            // 
            // ScheduleInputForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 121);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Text = "Schedule Input";
        }

        private void SetPlaceholderText()
        {
            textBoxName.Text = "Schedule Name";
            textBoxName.ForeColor = System.Drawing.Color.Gray;
        }

        private void TextBoxName_Enter(object sender, EventArgs e)
        {
            if (textBoxName.Text == "Schedule Name")
            {
                textBoxName.Text = "";
                textBoxName.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void TextBoxName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text)) // Sửa lỗi ở đây
            {
                SetPlaceholderText();
            }
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            if (schedule == null)
            {
                schedule = new Schedule
                {
                    Name = textBoxName.Text,
                    StartTime = dateTimePickerStart.Value,
                    EndTime = dateTimePickerEnd.Value
                };
            }
            else
            {
                schedule.Name = textBoxName.Text;
                schedule.StartTime = dateTimePickerStart.Value;
                schedule.EndTime = dateTimePickerEnd.Value;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public Schedule GetSchedule()
        {
            return schedule;
        }
    }
}