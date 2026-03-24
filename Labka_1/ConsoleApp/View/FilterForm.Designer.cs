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
            this.components = new System.ComponentModel.Container();
            this.ExerciseGroupBox = new System.Windows.Forms.GroupBox();
            this.CheckedListBoxExercise = new System.Windows.Forms.CheckedListBox();
            this.LabelSearch = new System.Windows.Forms.Label();
            this.TextBoxFilter = new System.Windows.Forms.TextBox();
            this.ButtonFilter = new System.Windows.Forms.Button();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ExerciseGroupBox.SuspendLayout();
            this.SuspendLayout();
            //
            // ExerciseGroupBox
            //
            this.ExerciseGroupBox.Controls.Add(this.CheckedListBoxExercise);
            this.ExerciseGroupBox.Location = new System.Drawing.Point(12, 12);
            this.ExerciseGroupBox.Name = "ExerciseGroupBox";
            this.ExerciseGroupBox.Size = new System.Drawing.Size(300, 100);
            this.ExerciseGroupBox.TabIndex = 0;
            this.ExerciseGroupBox.TabStop = false;
            this.ExerciseGroupBox.Text = "Типы упражнений";
            //
            // CheckedListBoxExercise
            //
            this.CheckedListBoxExercise.FormattingEnabled = true;
            this.CheckedListBoxExercise.Location = new System.Drawing.Point(10, 20);
            this.CheckedListBoxExercise.Name = "CheckedListBoxExercise";
            this.CheckedListBoxExercise.Size = new System.Drawing.Size(280, 70);
            this.CheckedListBoxExercise.TabIndex = 0;
            //
            // LabelSearch
            //
            this.LabelSearch.AutoSize = true;
            this.LabelSearch.Location = new System.Drawing.Point(12, 125);
            this.LabelSearch.Name = "LabelSearch";
            this.LabelSearch.Size = new System.Drawing.Size(45, 15);
            this.LabelSearch.TabIndex = 1;
            this.LabelSearch.Text = "Поиск:";
            //
            // TextBoxFilter
            //
            this.TextBoxFilter.Location = new System.Drawing.Point(12, 145);
            this.TextBoxFilter.Name = "TextBoxFilter";
            this.TextBoxFilter.Size = new System.Drawing.Size(300, 23);
            this.TextBoxFilter.TabIndex = 2;
            //
            // ButtonFilter
            //
            this.ButtonFilter.Location = new System.Drawing.Point(12, 180);
            this.ButtonFilter.Name = "ButtonFilter";
            this.ButtonFilter.Size = new System.Drawing.Size(90, 30);
            this.ButtonFilter.TabIndex = 3;
            this.ButtonFilter.Text = "Фильтр";
            this.ButtonFilter.UseVisualStyleBackColor = true;
            this.ButtonFilter.Click += new System.EventHandler(this.ButtonFilter_Click);
            //
            // ButtonCancel
            //
            this.ButtonCancel.Location = new System.Drawing.Point(114, 180);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(90, 30);
            this.ButtonCancel.TabIndex = 4;
            this.ButtonCancel.Text = "Отменить";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            //
            // ButtonClose
            //
            this.ButtonClose.Location = new System.Drawing.Point(222, 180);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(90, 30);
            this.ButtonClose.TabIndex = 5;
            this.ButtonClose.Text = "Закрыть";
            this.ButtonClose.UseVisualStyleBackColor = true;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            //
            // FilterForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 220);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonClose);
            this.Controls.Add(this.ButtonFilter);
            this.Controls.Add(this.TextBoxFilter);
            this.Controls.Add(this.LabelSearch);
            this.Controls.Add(this.ExerciseGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Фильтр упражнений";
            this.ExerciseGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
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
