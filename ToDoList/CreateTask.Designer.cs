namespace ToDoList
{
    partial class CreateTask
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonSave = new Button();
            buttonCanel = new Button();
            buttonClear = new Button();
            dateTimePicker = new DateTimePicker();
            labelTitle = new Label();
            labelDescription = new Label();
            textBoxTitle = new TextBox();
            textBoxDescription = new TextBox();
            SuspendLayout();
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(14, 246);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(94, 29);
            buttonSave.TabIndex = 0;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCanel
            // 
            buttonCanel.DialogResult = DialogResult.Cancel;
            buttonCanel.Location = new Point(390, 246);
            buttonCanel.Name = "buttonCanel";
            buttonCanel.Size = new Size(94, 29);
            buttonCanel.TabIndex = 1;
            buttonCanel.Text = "Canel";
            buttonCanel.UseVisualStyleBackColor = true;
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(290, 246);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(94, 29);
            buttonClear.TabIndex = 2;
            buttonClear.Text = "Clear";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // dateTimePicker
            // 
            dateTimePicker.Format = DateTimePickerFormat.Short;
            dateTimePicker.Location = new Point(318, 11);
            dateTimePicker.Margin = new Padding(8);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(166, 27);
            dateTimePicker.TabIndex = 3;
            dateTimePicker.Value = new DateTime(2024, 12, 27, 0, 0, 0, 0);
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Location = new Point(14, 14);
            labelTitle.Margin = new Padding(5);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(41, 20);
            labelTitle.TabIndex = 4;
            labelTitle.Text = "Title:";
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Location = new Point(17, 44);
            labelDescription.Margin = new Padding(5);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(88, 20);
            labelDescription.TabIndex = 5;
            labelDescription.Text = "Description:";
            // 
            // textBoxTitle
            // 
            textBoxTitle.Location = new Point(63, 11);
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.Size = new Size(248, 27);
            textBoxTitle.TabIndex = 6;
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(17, 77);
            textBoxDescription.Margin = new Padding(8);
            textBoxDescription.Multiline = true;
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(467, 158);
            textBoxDescription.TabIndex = 7;
            // 
            // CreateTask
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(501, 283);
            Controls.Add(textBoxDescription);
            Controls.Add(textBoxTitle);
            Controls.Add(labelDescription);
            Controls.Add(labelTitle);
            Controls.Add(dateTimePicker);
            Controls.Add(buttonClear);
            Controls.Add(buttonCanel);
            Controls.Add(buttonSave);
            Name = "CreateTask";
            Text = "Create Task";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonSave;
        private Button buttonCanel;
        private Button buttonClear;
        private DateTimePicker dateTimePicker;
        private Label labelTitle;
        private Label labelDescription;
        private TextBox textBoxTitle;
        private TextBox textBoxDescription;
    }
}