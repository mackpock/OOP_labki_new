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
        /// Делегат события - фильтр отменён
        /// </summary>
        public event Action? FilterCanceled;

        //TODO: XML
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
            CheckedListBoxExercise.Items.AddRange(
                ExerciseTypes.AllExerciseTypes);
            for (int i = 0;
                i < CheckedListBoxExercise.Items.Count;
                i++)
            {
                CheckedListBoxExercise.SetItemChecked(i, true);
            }
        }

        /// <summary>
        /// Закрытие формы
        /// </summary>
        private void FilterForm_FormClosing(
            object sender, FormClosingEventArgs arg)
        {
            if (arg.CloseReason == CloseReason.UserClosing)
            {
                FilterCanceled?.Invoke();
                RestoreCheckboxes();
                MessageBox.Show(
                    "Фильтр сброшен", "Инфо",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Восстановление всех галочек
        /// </summary>
        private void RestoreCheckboxes()
        {
            for (int i = 0;
                i < CheckedListBoxExercise.Items.Count;
                i++)
            {
                CheckedListBoxExercise.SetItemChecked(
                    i, true);
            }
            TextBoxFilter.Clear();
        }

        /// <summary>
        /// Кнопка "Фильтр"
        /// </summary>
        private void ButtonFilter_Click(
            object sender, EventArgs arg)
        {
            ApplyFilter();
        }

        /// <summary>
        /// Кнопка "Отменить"
        /// </summary>
        private void ButtonCancel_Click(
            object sender, EventArgs arg)
        {
            FilterCanceled?.Invoke();
            RestoreCheckboxes();
            MessageBox.Show(
                "Фильтр сброшен", "Инфо",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        /// <summary>
        /// Кнопка "Закрыть"
        /// </summary>
        private void ButtonClose_Click(
            object sender, EventArgs arg)
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

            foreach (var item in CheckedListBoxExercise.CheckedItems)
            {
                selectedTypes.Add(item.ToString());
            }

            if (selectedTypes.Count == 0)
            {
                selectedTypes.AddRange(
                    ExerciseTypes.AllExerciseTypes);
            }

            var filtered = _allExercises
                .Where(ex =>
                    MatchType(ex, selectedTypes)
                    && MatchSearch(ex, search))
                .ToList();

            FilterApplied?.Invoke(filtered);
            MessageBox.Show(
                $"Найдено: {filtered.Count}",
                "Результат",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        /// <summary>
        /// Проверка типа упражнения
        /// </summary>
        private bool MatchType(
            IExercise ex, List<string> types)
        {
            string type = ex switch
            {
                Running    => ExerciseTypes.Running,
                Swimming   => ExerciseTypes.Swimming,
                BenchPress => ExerciseTypes.BenchPress,
                _ => throw new InvalidOperationException(
                    "Неизвестный тип")
            };

            return types.Contains(type);
        }

        /// <summary>
        /// Поиск по тексту
        /// </summary>
        private bool MatchSearch(
            //TODO: RSDN
            IExercise ex, string term)
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

        /// <summary>
        /// Тёмное оформление
        /// </summary>
        private void ApplyDarkTheme()
        {
            ThemeHelper.StyleForm(this);
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            ThemeHelper.StyleGroupBox(ExerciseGroupBox);
            ExerciseGroupBox.Anchor =
                AnchorStyles.Top | AnchorStyles.Left
                | AnchorStyles.Right;

            ThemeHelper.StyleLabel(
                LabelSearch, bold: true);
            ThemeHelper.StyleTextBox(TextBoxFilter);
            ThemeHelper.StyleCheckedListBox(
                CheckedListBoxExercise);
            CheckedListBoxExercise.CheckOnClick = true;

            ThemeHelper.ApplyButtonStyle(
                ButtonFilter, ThemeHelper.Orange);
            ThemeHelper.ApplyButtonStyle(
                ButtonCancel, ThemeHelper.Red);
            ThemeHelper.ApplyButtonStyle(
                ButtonClose, ThemeHelper.ButtonGray);
        }
    }
}
