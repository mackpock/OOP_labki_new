namespace View
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Метод для инициализации компонентов формы
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            ExercisesGroupBox = new GroupBox();
            ButtonClear = new Button();
            ButtonFilter = new Button();
            ButtonAdd = new Button();
            ButtonRemove = new Button();
            ExerciseDataGridView = new DataGridView();
            exerciseBindingSource = new BindingSource(components);
            MainMenuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            ExercisesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ExerciseDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)exerciseBindingSource).BeginInit();
            MainMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // ExercisesGroupBox
            // 
            ExercisesGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ExercisesGroupBox.Controls.Add(ButtonClear);
            ExercisesGroupBox.Controls.Add(ButtonFilter);
            ExercisesGroupBox.Controls.Add(ButtonAdd);
            ExercisesGroupBox.Controls.Add(ButtonRemove);
            ExercisesGroupBox.Controls.Add(ExerciseDataGridView);
            ExercisesGroupBox.Location = new Point(9, 33);
            ExercisesGroupBox.Name = "ExercisesGroupBox";
            ExercisesGroupBox.Padding = new Padding(3, 9, 3, 3);
            ExercisesGroupBox.Size = new Size(566, 293);
            ExercisesGroupBox.TabIndex = 0;
            ExercisesGroupBox.TabStop = false;
            ExercisesGroupBox.Text = "Лист упражнений";
            ExercisesGroupBox.Enter += ExercisesGroupBox_Enter;
            // 
            // ButtonClear
            // 
            ButtonClear.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ButtonClear.Enabled = false;
            ButtonClear.Location = new Point(339, 246);
            ButtonClear.Name = "ButtonClear";
            ButtonClear.Size = new Size(105, 38);
            ButtonClear.TabIndex = 3;
            ButtonClear.Text = "Удалить всё";
            ButtonClear.UseVisualStyleBackColor = true;
            ButtonClear.Click += ButtonClear_Click;
            // 
            // ButtonFilter
            // 
            ButtonFilter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ButtonFilter.Location = new Point(118, 246);
            ButtonFilter.Name = "ButtonFilter";
            ButtonFilter.Size = new Size(105, 38);
            ButtonFilter.TabIndex = 2;
            ButtonFilter.Text = "Фильтр";
            ButtonFilter.UseVisualStyleBackColor = true;
            ButtonFilter.Click += ButtonFilter_Click;
            // 
            // ButtonAdd
            // 
            ButtonAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ButtonAdd.Location = new Point(5, 246);
            ButtonAdd.Name = "ButtonAdd";
            ButtonAdd.Size = new Size(105, 38);
            ButtonAdd.TabIndex = 1;
            ButtonAdd.Text = "Добавить";
            ButtonAdd.UseVisualStyleBackColor = true;
            ButtonAdd.Click += ButtonAdd_Click;
            // 
            // ButtonRemove
            // 
            ButtonRemove.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ButtonRemove.Enabled = false;
            ButtonRemove.Location = new Point(453, 246);
            ButtonRemove.Name = "ButtonRemove";
            ButtonRemove.Size = new Size(105, 38);
            ButtonRemove.TabIndex = 4;
            ButtonRemove.Text = "Удалить";
            ButtonRemove.UseVisualStyleBackColor = true;
            ButtonRemove.Click += ButtonRemove_Click;
            // 
            // ExerciseDataGridView
            // 
            ExerciseDataGridView.AllowUserToAddRows = false;
            ExerciseDataGridView.AllowUserToDeleteRows = false;
            ExerciseDataGridView.AllowUserToResizeRows = false;
            ExerciseDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ExerciseDataGridView.AutoGenerateColumns = false;
            ExerciseDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(40, 40, 40);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(60, 60, 60);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            ExerciseDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            ExerciseDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ExerciseDataGridView.DataSource = exerciseBindingSource;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            ExerciseDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            ExerciseDataGridView.Location = new Point(5, 28);
            ExerciseDataGridView.MultiSelect = false;
            ExerciseDataGridView.Name = "ExerciseDataGridView";
            ExerciseDataGridView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            ExerciseDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            ExerciseDataGridView.RowHeadersVisible = false;
            ExerciseDataGridView.RowHeadersWidth = 51;
            ExerciseDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ExerciseDataGridView.Size = new Size(556, 212);
            ExerciseDataGridView.TabIndex = 0;
            ExerciseDataGridView.SelectionChanged += ExerciseDataGridView_SelectionChanged;
            // 
            // MainMenuStrip
            // 
            MainMenuStrip.ImageScalingSize = new Size(20, 20);
            MainMenuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            MainMenuStrip.Location = new Point(0, 0);
            MainMenuStrip.Name = "MainMenuStrip";
            MainMenuStrip.Padding = new Padding(4, 0, 0, 5);
            MainMenuStrip.Size = new Size(584, 24);
            MainMenuStrip.TabIndex = 6;
            MainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem, openToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(48, 19);
            fileToolStripMenuItem.Text = "Файл";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(132, 22);
            saveToolStripMenuItem.Text = "Сохранить";
            saveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(132, 22);
            openToolStripMenuItem.Text = "Открыть";
            openToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 338);
            Controls.Add(ExercisesGroupBox);
            Controls.Add(MainMenuStrip);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ex0rcise - Калькулятор калорий";
            ExercisesGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ExerciseDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)exerciseBindingSource).EndInit();
            MainMenuStrip.ResumeLayout(false);
            MainMenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox ExercisesGroupBox;
        private System.Windows.Forms.DataGridView ExerciseDataGridView;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.Button ButtonRemove;
        private System.Windows.Forms.Button ButtonClear;
        private System.Windows.Forms.Button ButtonFilter;
        private new System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.BindingSource exerciseBindingSource;
    }
}
