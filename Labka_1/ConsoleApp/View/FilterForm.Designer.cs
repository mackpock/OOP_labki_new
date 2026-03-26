namespace View
{
    partial class FilterForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ExerciseGroupBox = new GroupBox();
            CheckedListBoxExercise = new CheckedListBox();
            LabelSearch = new Label();
            TextBoxFilter = new TextBox();
            ButtonFilter = new Button();
            ButtonClose = new Button();
            ButtonCancel = new Button();
            ExerciseGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // ExerciseGroupBox
            // 
            ExerciseGroupBox.Controls.Add(CheckedListBoxExercise);
            ExerciseGroupBox.Location = new Point(12, 74);
            ExerciseGroupBox.Name = "ExerciseGroupBox";
            ExerciseGroupBox.Size = new Size(300, 100);
            ExerciseGroupBox.TabIndex = 0;
            ExerciseGroupBox.TabStop = false;
            ExerciseGroupBox.Text = "Типы упражнений";
            // 
            // CheckedListBoxExercise
            // 
            CheckedListBoxExercise.FormattingEnabled = true;
            CheckedListBoxExercise.Location = new Point(10, 20);
            CheckedListBoxExercise.Name = "CheckedListBoxExercise";
            CheckedListBoxExercise.Size = new Size(280, 76);
            CheckedListBoxExercise.TabIndex = 0;
            // 
            // LabelSearch
            // 
            LabelSearch.AutoSize = true;
            LabelSearch.Location = new Point(22, 22);
            LabelSearch.Name = "LabelSearch";
            LabelSearch.Size = new Size(45, 15);
            LabelSearch.TabIndex = 1;
            LabelSearch.Text = "Поиск:";
            LabelSearch.Click += LabelSearch_Click;
            // 
            // TextBoxFilter
            // 
            TextBoxFilter.Location = new Point(22, 40);
            TextBoxFilter.Name = "TextBoxFilter";
            TextBoxFilter.Size = new Size(280, 23);
            TextBoxFilter.TabIndex = 2;
            // 
            // ButtonFilter
            // 
            ButtonFilter.Location = new Point(345, 40);
            ButtonFilter.Name = "ButtonFilter";
            ButtonFilter.Size = new Size(90, 30);
            ButtonFilter.TabIndex = 3;
            ButtonFilter.Text = "Фильтр";
            ButtonFilter.UseVisualStyleBackColor = true;
            ButtonFilter.Click += ButtonFilter_Click;
            // 
            // ButtonClose
            // 
            ButtonClose.Location = new Point(345, 144);
            ButtonClose.Name = "ButtonClose";
            ButtonClose.Size = new Size(90, 30);
            ButtonClose.TabIndex = 5;
            ButtonClose.Text = "Закрыть";
            ButtonClose.UseVisualStyleBackColor = true;
            ButtonClose.Click += ButtonClose_Click;
            // 
            // ButtonCancel
            // 
            ButtonCancel.Location = new Point(345, 94);
            ButtonCancel.Name = "ButtonCancel";
            ButtonCancel.Size = new Size(90, 30);
            ButtonCancel.TabIndex = 4;
            ButtonCancel.Text = "Отменить";
            ButtonCancel.UseVisualStyleBackColor = true;
            ButtonCancel.Click += ButtonCancel_Click;
            // 
            // FilterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(453, 183);
            Controls.Add(ButtonCancel);
            Controls.Add(ButtonClose);
            Controls.Add(ButtonFilter);
            Controls.Add(TextBoxFilter);
            Controls.Add(LabelSearch);
            Controls.Add(ExerciseGroupBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FilterForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Фильтр упражнений";
            ExerciseGroupBox.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.GroupBox ExerciseGroupBox;
        private System.Windows.Forms.CheckedListBox CheckedListBoxExercise;
        private System.Windows.Forms.Label LabelSearch;
        private System.Windows.Forms.TextBox TextBoxFilter;
        private System.Windows.Forms.Button ButtonFilter;
        private System.Windows.Forms.Button ButtonClose;
        private System.Windows.Forms.Button ButtonCancel;
    }
}
