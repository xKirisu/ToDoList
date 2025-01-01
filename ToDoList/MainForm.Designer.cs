namespace ToDoList
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView = new DataGridView();
            labelDateView = new Label();
            buttonAddTask = new Button();
            dateTimePicker = new DateTimePicker();
            checkBoxShowAll = new CheckBox();
            checkBoxOverdued = new CheckBox();
            textBoxFilter = new TextBox();
            label1 = new Label();
            label2 = new Label();
            buttonRemoveSelected = new Button();
            buttonToPDF = new Button();
            buttonCompleteSelected = new Button();
            buttonRemoveCompleted = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.BackgroundColor = SystemColors.Control;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(22, 83);
            dataGridView.Margin = new Padding(8);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(766, 380);
            dataGridView.TabIndex = 0;
            // 
            // labelDateView
            // 
            labelDateView.AutoSize = true;
            labelDateView.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            labelDateView.Location = new Point(22, 9);
            labelDateView.Name = "labelDateView";
            labelDateView.Size = new Size(62, 28);
            labelDateView.TabIndex = 1;
            labelDateView.Text = "Date: ";
            // 
            // buttonAddTask
            // 
            buttonAddTask.Location = new Point(22, 47);
            buttonAddTask.Name = "buttonAddTask";
            buttonAddTask.Size = new Size(183, 29);
            buttonAddTask.TabIndex = 2;
            buttonAddTask.Text = "Add New Task";
            buttonAddTask.UseVisualStyleBackColor = true;
            buttonAddTask.Click += buttonAddTask_Click;
            // 
            // dateTimePicker
            // 
            dateTimePicker.Format = DateTimePickerFormat.Short;
            dateTimePicker.Location = new Point(631, 46);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(157, 27);
            dateTimePicker.TabIndex = 3;
            dateTimePicker.ValueChanged += dateTimePicker_ValueChanged;
            // 
            // checkBoxShowAll
            // 
            checkBoxShowAll.AutoSize = true;
            checkBoxShowAll.Location = new Point(278, 49);
            checkBoxShowAll.Name = "checkBoxShowAll";
            checkBoxShowAll.Size = new Size(89, 24);
            checkBoxShowAll.TabIndex = 4;
            checkBoxShowAll.Text = "Show All";
            checkBoxShowAll.UseVisualStyleBackColor = true;
            checkBoxShowAll.CheckedChanged += checkBoxShowAll_CheckedChanged;
            // 
            // checkBoxOverdued
            // 
            checkBoxOverdued.AutoSize = true;
            checkBoxOverdued.Location = new Point(373, 50);
            checkBoxOverdued.Name = "checkBoxOverdued";
            checkBoxOverdued.Size = new Size(136, 24);
            checkBoxOverdued.TabIndex = 5;
            checkBoxOverdued.Text = "Show Overdued";
            checkBoxOverdued.UseVisualStyleBackColor = true;
            checkBoxOverdued.CheckedChanged += checkBoxOverdued_CheckedChanged;
            // 
            // textBoxFilter
            // 
            textBoxFilter.Location = new Point(571, 10);
            textBoxFilter.Name = "textBoxFilter";
            textBoxFilter.Size = new Size(217, 27);
            textBoxFilter.TabIndex = 8;
            textBoxFilter.TextChanged += textBoxfilter_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(448, 17);
            label1.Name = "label1";
            label1.Size = new Size(117, 20);
            label1.TabIndex = 9;
            label1.Text = "Search by name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(515, 50);
            label2.Name = "label2";
            label2.Size = new Size(110, 20);
            label2.TabIndex = 10;
            label2.Text = "Search by date:";
            // 
            // buttonRemoveSelected
            // 
            buttonRemoveSelected.Location = new Point(615, 472);
            buttonRemoveSelected.Name = "buttonRemoveSelected";
            buttonRemoveSelected.Size = new Size(173, 29);
            buttonRemoveSelected.TabIndex = 13;
            buttonRemoveSelected.Text = "Remove Selected";
            buttonRemoveSelected.UseVisualStyleBackColor = true;
            buttonRemoveSelected.Click += buttonRemoveSelected_Click;
            // 
            // buttonToPDF
            // 
            buttonToPDF.Location = new Point(201, 472);
            buttonToPDF.Name = "buttonToPDF";
            buttonToPDF.Size = new Size(158, 29);
            buttonToPDF.TabIndex = 14;
            buttonToPDF.Text = "Complete To PDF";
            buttonToPDF.UseVisualStyleBackColor = true;
            buttonToPDF.Click += buttonToPDF_Click;
            // 
            // buttonCompleteSelected
            // 
            buttonCompleteSelected.Location = new Point(22, 472);
            buttonCompleteSelected.Name = "buttonCompleteSelected";
            buttonCompleteSelected.Size = new Size(173, 29);
            buttonCompleteSelected.TabIndex = 15;
            buttonCompleteSelected.Text = "Complete Selected";
            buttonCompleteSelected.UseVisualStyleBackColor = true;
            buttonCompleteSelected.Click += buttonCompleteSelected_Click;
            // 
            // buttonRemoveCompleted
            // 
            buttonRemoveCompleted.Location = new Point(365, 472);
            buttonRemoveCompleted.Name = "buttonRemoveCompleted";
            buttonRemoveCompleted.Size = new Size(158, 29);
            buttonRemoveCompleted.TabIndex = 16;
            buttonRemoveCompleted.Text = "Remove Completed";
            buttonRemoveCompleted.UseVisualStyleBackColor = true;
            buttonRemoveCompleted.Click += buttonRemoveCompleted_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(806, 513);
            Controls.Add(buttonRemoveCompleted);
            Controls.Add(buttonCompleteSelected);
            Controls.Add(buttonToPDF);
            Controls.Add(buttonRemoveSelected);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxFilter);
            Controls.Add(checkBoxOverdued);
            Controls.Add(checkBoxShowAll);
            Controls.Add(dateTimePicker);
            Controls.Add(buttonAddTask);
            Controls.Add(labelDateView);
            Controls.Add(dataGridView);
            Name = "MainForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView;
        private Label labelDateView;
        private Button buttonAddTask;
        private DateTimePicker dateTimePicker;
        private CheckBox checkBoxShowAll;
        private CheckBox checkBoxOverdued;
        private TextBox textBoxFilter;
        private Label label1;
        private Label label2;
        private Button buttonRemoveSelected;
        private Button buttonToPDF;
        private Button buttonCompleteSelected;
        private Button buttonRemoveCompleted;
    }
}
