using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Model;

namespace View
{
    /// <summary>
    /// Окно фильтрации списка упражнений
    /// </summary>
    public partial class FilterForm : Form
    {
        /// <summary>
        /// Полный список упражнений
        /// </summary>
        private List<IExercise> _allExercises;

        /// <summary>
        /// Делегат события - фильтр обновлен
        /// </summary>
        public event Action<List<IExercise>>? FilterApplied;

        /// <summary>
        /// Делегат события - фильтр отменён (форма закрыта без применения)
        /// </summary>
        public event Action? FilterCanceled;

        public FilterForm(List<IExercise> exercises)
        {
            InitializeComponent();
            _allExercises = exercises;
            InitControls();
            ApplyDarkTheme();
            this.FormClosing += FilterForm_FormClosing;
        }

        /// <summary>
        /// Инициализация контролов
        /// </summary>
        private void InitControls()
        {
            CheckedListBoxExercise.Items.AddRange(ExerciseTypes.AllExerciseTypes);
            //TODO: {}
            for (int i = 0; i < CheckedListBoxExercise.Items.Count; i++)
                CheckedListBoxExercise.SetItemChecked(i, true);
        }

        /// <summary>
        /// Закрытие формы
        /// </summary>
        private void FilterForm_FormClosing(object sender,
            //TOOD: отступы
         FormClosingEventArgs arg)
        {
            if (arg.CloseReason == CloseReason.UserClosing)
            {
                FilterCanceled?.Invoke();
                RestoreCheckboxes();
                MessageBox.Show("Фильтр сброшен", "Инфо", MessageBoxButtons.OK,
                 MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Восстановление всех галочек
        /// </summary>
        private void RestoreCheckboxes()
        {
            //TODO: {}
            for (int i = 0; i < CheckedListBoxExercise.Items.Count; i++)
                CheckedListBoxExercise.SetItemChecked(i, true);
            TextBoxFilter.Clear();
        }

        /// <summary>
        /// Кнопка "Фильтр"
        /// </summary>
        private void ButtonFilter_Click(object sender, EventArgs arg)
        {
            ApplyFilter();
        }

        /// <summary>
        /// Кнопка "Отменить"
        /// </summary>
        private void ButtonCancel_Click(object sender, EventArgs arg)
        {
            FilterCanceled?.Invoke();
            RestoreCheckboxes();
            //TOOD: отступы
            MessageBox.Show("Фильтр сброшен", "Инфо", MessageBoxButtons.OK,
             MessageBoxIcon.Information);
        }

        /// <summary>
        /// Кнопка "Закрыть"
        /// </summary>
        private void ButtonClose_Click(object sender, EventArgs arg)
        {
            this.Close();
        }

        /// <summary>
        /// Применение фильтрации
        /// </summary>
        private void ApplyFilter()
        {
            string search = TextBoxFilter.Text.Trim();
            var selectedTypes = new List<string>();

            //TODO: {}
            foreach (var item in CheckedListBoxExercise.CheckedItems)
                selectedTypes.Add(item.ToString());

            //TODO: {}
            if (selectedTypes.Count == 0)
                selectedTypes.AddRange(ExerciseTypes.AllExerciseTypes);

            var filtered = _allExercises
                .Where(ex => MatchType(ex, selectedTypes)
                && MatchSearch(ex, search))
                .ToList();

            FilterApplied?.Invoke(filtered);
            MessageBox.Show($"Найдено: {filtered.Count}", "Результат",
             MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Проверка типа упражнения
        /// </summary>
        private bool MatchType(IExercise ex, List<string> types)
        {
            string type = ex 
            switch
            {
                Running => ExerciseTypes.Running,
                Swimming => ExerciseTypes.Swimming,
                BenchPress => ExerciseTypes.BenchPress,
                _ => throw new InvalidOperationException("Неизвестный тип")
            };

            return types.Contains(type);
        }

        /// <summary>
        /// Поиск по тексту
        /// </summary>
        private bool MatchSearch(IExercise ex, string term)
        {
            if (string.IsNullOrEmpty(term))
            {
                return true;
            }

            var lower = term.ToLower();
            if (ex.Name.ToLower().Contains(lower))
            {
                return true;
            }

            if (ex.ExerciseInfo.ToLower().Contains(lower))
            {
                return true;
            }

            if (ex.Calories.ToString("F2").Contains(term))
            {
                return true;
            }

            if (ex.Calories.ToString("F0").Contains(term))
            {
                return true;
            }

            return false;
        }

        //TODO: duplication
        /// <summary>
        /// Тёмное оформление
        /// </summary>
        private void ApplyDarkTheme()
        {
            Color bg = Color.FromArgb(30, 30, 30);
            Color panel = Color.FromArgb(45, 45, 45);
            Color orange = Color.FromArgb(255, 140, 0);
            Color red = Color.FromArgb(220, 20, 60);
            Color text = Color.FromArgb(240, 240, 240);

            this.BackColor = bg;
            this.ForeColor = text;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            ExerciseGroupBox.BackColor = panel;
            ExerciseGroupBox.ForeColor = orange;
            ExerciseGroupBox.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            ExerciseGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left |
            AnchorStyles.Right;

            LabelSearch.ForeColor = text;
            LabelSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            TextBoxFilter.BackColor = Color.FromArgb(60, 60, 60);
            TextBoxFilter.ForeColor = text;
            TextBoxFilter.BorderStyle = BorderStyle.FixedSingle;
            TextBoxFilter.Font = new Font("Segoe UI", 10F);

            CheckedListBoxExercise.BackColor = Color.FromArgb(60, 60, 60);
            CheckedListBoxExercise.ForeColor = text;
            CheckedListBoxExercise.BorderStyle = BorderStyle.FixedSingle;
            CheckedListBoxExercise.CheckOnClick = true;

            ApplyButtonStyle(ButtonFilter, orange);
            ApplyButtonStyle(ButtonCancel, red);
            ApplyButtonStyle(ButtonClose, Color.FromArgb(80, 80, 80));
        }

        //TODO: duplication
        /// <summary>
        /// Оформление кнопки
        /// </summary>
        private void ApplyButtonStyle(Button btn, Color clr)
        {
            btn.BackColor = clr;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
        }
        //TODO: remove
        private void LabelSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
