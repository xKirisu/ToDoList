using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class CreateTask : Form
    {
        public TDTask Task;

        public CreateTask()
        {
            InitializeComponent();
            dateTimePicker.Value = DateTime.Now;
        }

        public CreateTask(string name, string description, DateTime date)
        {
            InitializeComponent();

            this.Name = "Edit Task";

            textBoxTitle.Text = name;
            textBoxDescription.Text = description;

            dateTimePicker.Value = date;
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            string title = textBoxTitle.Text;
            string description = textBoxDescription.Text;

            DateTime datetime = dateTimePicker.Value.Date;
            DateOnly date = DateOnly.FromDateTime(datetime);

            Task = new TDTask(title, description, date);

            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxTitle.Text = string.Empty;
            textBoxDescription.Text = string.Empty;
            dateTimePicker.Value = DateTime.Now;
        }
    }
}
