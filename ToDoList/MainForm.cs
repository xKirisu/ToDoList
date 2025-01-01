
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text;
using iText.Kernel.Pdf;
using iText.Html2pdf;
using System.Net.Http;
using System.Diagnostics;
using System.Data.Common;
using System.Globalization;

namespace ToDoList
{
    public partial class MainForm : Form
    {
        TaskManage TaskManage = new TaskManage();

        public MainForm()
        {

            InitializeComponent();

            DateTime datetime = DateTime.Today;
            DateOnly date = DateOnly.FromDateTime(datetime);

            labelDateView.Text = "Data: " + datetime.ToString("dd MMMM yyyy; dddd");
            dateTimePicker.Value = datetime;

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.Name = "Completed";
            checkBoxColumn.HeaderText = "Completed";
            dataGridView.Columns.Add(checkBoxColumn);

            dataGridView.DataSource = TaskManage.GetTasks(date);

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Name = "EditTask";
            buttonColumn.HeaderText = "Edit Task";
            buttonColumn.Text = "Edit";
            buttonColumn.UseColumnTextForButtonValue = true;
            dataGridView.Columns.Add(buttonColumn);

            dataGridView.CellClick += dataGridView_CellClick;

            this.FormClosing += TaskManage.SaveToFile;
        }

        private void buttonAddTask_Click(object sender, EventArgs e)
        {
            CreateTask createTask = new CreateTask();

            if (createTask.ShowDialog() == DialogResult.OK)
            {
                TDTask task = createTask.Task;
                
                try
                {
                    TaskManage.addTask(task);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            DateTime datetime = dateTimePicker.Value.Date;
            DateOnly date = DateOnly.FromDateTime(datetime);

            if (textBoxFilter.Text.Length > 0)
            {

                string text = textBoxFilter.Text;

                if (checkBoxShowAll.Checked)
                {
                    dataGridView.DataSource = TaskManage.GetTaskByName(text);
                }
                else if (checkBoxOverdued.Checked)
                {
                    dataGridView.DataSource = TaskManage.GetTaskByNameOverdued(text);
                }
                else
                {
                    dataGridView.DataSource = TaskManage.GetTaskByName(text, date);
                }
            }
            else
            {
                if (checkBoxShowAll.Checked)
                {
                    dataGridView.DataSource = TaskManage.GetAllTasks();
                }
                else if (checkBoxOverdued.Checked)
                {
                    dataGridView.DataSource = TaskManage.GetOverduedTasks();
                }
                else
                {
                    dataGridView.DataSource = TaskManage.GetTasks(date);
                }
            }
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dateTimePicker = sender as DateTimePicker;

            DateTime datetime = dateTimePicker.Value.Date;
            DateOnly date = DateOnly.FromDateTime(datetime);

            if (textBoxFilter.Text.Length > 0)
            {
                string text = textBoxFilter.Text;

                dataGridView.DataSource = TaskManage.GetTaskByName(text, date);
            }
            else
            {
                dataGridView.DataSource = TaskManage.GetTasks(date);
            }
        }

        private void checkBoxShowAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            if (checkBox.Checked)
            {
                checkBoxOverdued.Checked = false;
                checkBoxOverdued.Enabled = false;

                dateTimePicker.Enabled = false;

                if (textBoxFilter.Text.Length > 0)
                {
                    string text = textBoxFilter.Text;

                    dataGridView.DataSource = TaskManage.GetTaskByName(textBoxFilter.Text);

                }
                else
                {
                    dataGridView.DataSource = TaskManage.GetAllTasks();
                }
            }
            else
            {
                checkBoxOverdued.Enabled = true;

                dateTimePicker.Enabled = true;

                DateTime datetime = dateTimePicker.Value.Date;
                DateOnly date = DateOnly.FromDateTime(datetime);

                if (textBoxFilter.Text.Length > 0)
                {
                    string text = textBoxFilter.Text;

                    dataGridView.DataSource = TaskManage.GetTaskByName(textBoxFilter.Text, date);

                }
                else
                {
                    dataGridView.DataSource = TaskManage.GetTasks(date);
                }
            }
        }

        private void checkBoxOverdued_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox.Checked)
            {
                dateTimePicker.Enabled = false;

                if (textBoxFilter.Text.Length > 0)
                {
                    string text = textBoxFilter.Text;

                    dataGridView.DataSource = TaskManage.GetTaskByNameOverdued(textBoxFilter.Text);

                }
                else
                {
                    dataGridView.DataSource = TaskManage.GetOverduedTasks();
                }
            }
            else
            {
                dateTimePicker.Enabled = true;

                DateTime datetime = dateTimePicker.Value.Date;
                DateOnly date = DateOnly.FromDateTime(datetime);

                dataGridView.DataSource = TaskManage.GetTasks(date);
            }
        }

        private void textBoxfilter_TextChanged(object sender, EventArgs e)
        {
            if (checkBoxShowAll.Checked)
            {
                dataGridView.DataSource = TaskManage.GetTaskByName(textBoxFilter.Text);
            }
            else if (checkBoxOverdued.Checked)
            {
                DateTime datetime = dateTimePicker.Value.Date;
                DateOnly date = DateOnly.FromDateTime(datetime);

                dataGridView.DataSource = TaskManage.GetTaskByNameOverdued(textBoxFilter.Text);
            }
            else
            {
                DateTime datetime = dateTimePicker.Value.Date;
                DateOnly date = DateOnly.FromDateTime(datetime);

                dataGridView.DataSource = TaskManage.GetTaskByName(textBoxFilter.Text, date);
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView dgv = sender as DataGridView;

                if (dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn && dgv.Columns[e.ColumnIndex].Name == "EditTask")
                {
                    DataGridViewRow row = dgv.Rows[e.RowIndex];

                    string name = row.Cells["Name"].Value?.ToString();
                    string description = row.Cells["Description"].Value?.ToString();
                    string date_string = row.Cells["Date"].Value?.ToString();
                    DateTime date = Convert.ToDateTime(date_string);

                    CreateTask editTask = new CreateTask(name, description, date);

                    if (editTask.ShowDialog() == DialogResult.OK)
                    {
                        TDTask task = editTask.Task;

                    }

                }
            }
        }

        private void buttonRemoveSelected_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("The action will remove the selected columns, are you sure?", "Remove selected tasks", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            switch (dr)
            {
                case DialogResult.Yes:

                    var selectedRows = dataGridView.SelectedRows;

                    if (selectedRows.Count > 0)
                    {
                        for (int i = selectedRows.Count - 1; i >= 0; i--)
                        {
                            dataGridView.Rows.RemoveAt(selectedRows[i].Index);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No rows selected to remove.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;

                case DialogResult.No:
                    MessageBox.Show("Canceled remove column deletion", "Remove canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        private void buttonCompleteSelected_Click(object sender, EventArgs e)
        {
            var selectedRows = dataGridView.SelectedRows;

            if (selectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in selectedRows)
                {
                    var checkbox = row.Cells["Completed"];
                    checkbox.Value = true;
                }
            }
        }
        private void buttonToPDF_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.AppendLine("<html>");
                stringBuilder.AppendLine("<head>");
                stringBuilder.AppendLine("<meta charset=\"UTF-8\">");
                stringBuilder.AppendLine("<style>");
                stringBuilder.AppendLine("body { font-family: 'Calibri'; }");
                stringBuilder.AppendLine("</style>");
                stringBuilder.AppendLine("</head>");
                stringBuilder.AppendLine("<body>");

                stringBuilder.AppendLine("<h1>Report</h1>");
                stringBuilder.AppendLine($"Date: {DateTime.Today.ToShortDateString()}");
                stringBuilder.AppendLine("<table border='1' style='border-collapse: collapse; width: 100%;'>");

                stringBuilder.AppendLine("<thead><tr>");
                stringBuilder.AppendLine("<th>Name</th>");
                stringBuilder.AppendLine("<th>Description</th>");
                stringBuilder.AppendLine("<th>Date</th>");
                stringBuilder.AppendLine("</tr></thead>");

                stringBuilder.AppendLine("<tbody>");
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    var checkbox = row.Cells["Completed"];
                    if (checkbox.Value is bool isChecked && isChecked)
                    {
                        stringBuilder.AppendLine("<tr>");
                        string name = row.Cells["Name"]?.Value?.ToString() ?? "N/A";
                        string description = row.Cells["Description"]?.Value?.ToString() ?? "N/A";
                        string date_string = row.Cells["Date"]?.Value?.ToString() ?? "N/A";


                        stringBuilder.AppendLine($"<td>{name}</td>");
                        stringBuilder.AppendLine($"<td>{description}</td>");
                        stringBuilder.AppendLine($"<td>{date_string}</td>");
                        stringBuilder.AppendLine("</tr>");
                    }
                }
                stringBuilder.AppendLine("</tbody>");
                stringBuilder.AppendLine("</table>");

                stringBuilder.AppendLine("</body>");
                stringBuilder.AppendLine("</html>");

                string htmlContent = stringBuilder.ToString();

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PDF Files|*.pdf";
                    saveFileDialog.Title = "Save file as PDF";
                    saveFileDialog.FileName = "Report.pdf";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string outputPath = saveFileDialog.FileName;

                        using (FileStream pdfFileStream = new FileStream(outputPath, FileMode.Create))
                        {
                           
                            HtmlConverter.ConvertToPdf(htmlContent, pdfFileStream);
                        }

                        MessageBox.Show("FIle was saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRemoveCompleted_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> rowsToRemove = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                var checkbox = row.Cells["Completed"];

                if (checkbox.Value is bool isChecked && isChecked)
                {
                    rowsToRemove.Add(row);
                }
            }

            foreach (var row in rowsToRemove)
            {
                var selected_data = row.DataBoundItem as TDTask;

                TaskManage.removeTask(selected_data);
            }


            DateTime datetime = dateTimePicker.Value.Date;
            DateOnly date = DateOnly.FromDateTime(datetime);

            if (textBoxFilter.Text.Length > 0)
            {

                string text = textBoxFilter.Text;

                if (checkBoxShowAll.Checked)
                {
                    dataGridView.DataSource = TaskManage.GetTaskByName(text);
                }
                else if (checkBoxOverdued.Checked)
                {
                    dataGridView.DataSource = TaskManage.GetTaskByNameOverdued(text);
                }
                else
                {
                    dataGridView.DataSource = TaskManage.GetTaskByName(text, date);
                }
            }
            else
            {
                if (checkBoxShowAll.Checked)
                {
                    dataGridView.DataSource = TaskManage.GetAllTasks();
                }
                else if (checkBoxOverdued.Checked)
                {
                    dataGridView.DataSource = TaskManage.GetOverduedTasks();
                }
                else
                {
                    dataGridView.DataSource = TaskManage.GetTasks(date);
                }
            }
        }
    }
}
