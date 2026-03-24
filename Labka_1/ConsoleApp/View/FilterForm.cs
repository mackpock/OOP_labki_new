using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Model;

namespace View
{
    /// <summary>
    /// Форма фильтрации упражнений
    /// </summary>
    public partial class FilterForm : Form
    {
        /// <summary>
        /// Исходный список всех упражнений для фильтрации
        /// </summary>
        private List<IExercise> _allExercises;

        /// <summary>
        /// Событие, возникающее при применении фильтра
        /// </summary>
        public event Action<List<IExercise>> FilterApplied;

        /// <summary>
        /// Событие, возникающее при отмене фильтра
        /// </summary>
        public event Action FilterCanceled;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        /// <param name="exercises">Список упражнений</param>
        public FilterForm(List<IExercise> exercises)
        {
            InitializeComponent();
            _allExercises = exercises;
            InitializeForm();
            this.FormClosing += FilterForm_FormClosing;
        }

        /// <summary>
        /// Обрабатывает событие закрытия формы
        /// </summary>
        private void FilterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                FilterCanceled?.Invoke();
                MessageBox.Show(
                    "Фильтр отменен. Показаны все упражнения.",
                    "Отмена фильтра",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Первоначальная настройка элементов управления формы фильтрации
        /// </summary>
        private void InitializeForm()
        {
            CheckedListBoxExercise.Items.AddRange(Constants.AllExerciseTypes);
            for (int i = 0; i < CheckedListBoxExercise.Items.Count; i++)
            {
                CheckedListBoxExercise.SetItemChecked(i, true);
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки Фильтр
        /// </summary>
        private void ButtonFilter_Click(object sender, EventArgs e)
        {
            PerformFilter();
        }

        /// <summary>
        /// Обработчик нажатия кнопки Отменить
        /// </summary>
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            FilterCanceled?.Invoke();
            MessageBox.Show(
                "Фильтр отменен. Показаны все упражнения.",
                "Отмена фильтра",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        /// <summary>
        /// Обработчик нажатия кнопки Закрыть
        /// </summary>
        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Выполнение фильтрации
        /// </summary>
        private void PerformFilter()
        {
            var searchTerm = TextBoxFilter.Text.Trim();
            var selectedTypes = new List<string>();
            foreach (var item in CheckedListBoxExercise.CheckedItems)
            {
                selectedTypes.Add(item.ToString());
            }

            if (selectedTypes.Count == 0)
            {
                selectedTypes.AddRange(Constants.AllExerciseTypes);
            }

            var filteredExercises = _allExercises
                .Where(ex => IsExerciseTypeSelected(ex, selectedTypes) &&
                             ContainsSearchTerm(ex, searchTerm))
                .ToList();

            FilterApplied?.Invoke(filteredExercises);
            MessageBox.Show(
                $"Найдено упражнений: {filteredExercises.Count}",
                "Результаты фильтрации",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        /// <summary>
        /// Проверка соответствия типа упражнения выбранным типам
        /// </summary>
        /// <param name="exercise">Упражнение</param>
        /// <param name="selectedTypes">Выбранный тип</param>
        /// <returns>true если тип выбран</returns>
        private bool IsExerciseTypeSelected(IExercise exercise, List<string> selectedTypes)
        {
            string exerciseType;
            switch (exercise)
            {
                case Running running:
                    {
                        exerciseType = Constants.Running;
                        break;
                    }
                case Swimming swimming:
                    {
                        exerciseType = Constants.Swimming;
                        break;
                    }
                case BenchPress benchPress:
                    {
                        exerciseType = Constants.BenchPress;
                        break;
                    }
                default:
                    {
                        throw new InvalidOperationException("Неизвестный тип упражнения");
                    }
            }
            return selectedTypes.Contains(exerciseType);
        }

        /// <summary>
        /// Проверка содержания поискового запроса в данных упражнения
        /// </summary>
        /// <param name="exercise">Упражнение</param>
        /// <param name="searchTerm">Поисковый запрос</param>
        /// <returns>true если найдено совпадение</returns>
        private bool ContainsSearchTerm(IExercise exercise, string searchTerm)
        {
            var searchLower = searchTerm.ToLower();
            if (exercise.Name.ToLower().Contains(searchLower))
            {
                return true;
            }
            if (exercise.ExerciseInfo.ToLower().Contains(searchLower))
            {
                return true;
            }
            if (exercise.Calories.ToString("F2").Contains(searchTerm) ||
                exercise.Calories.ToString("F0").Contains(searchTerm))
            {
                return true;
            }
            return false;
        }
    }
}
