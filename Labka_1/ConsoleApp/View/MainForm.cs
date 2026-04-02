using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using Model;

namespace View
{
    /// <summary>
    /// Основная форма программы
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Список для хранения всех упражнений
        /// </summary>
        private List<IExercise>? _originalExercises;

        /// <summary>
        /// Список для отображения в таблице
        /// </summary>
        private BindingList<IExercise>? _exercises;

        /// <summary>
        /// Форма добавления
        /// </summary>
        private AddForm? _addForm;

        /// <summary>
        /// Форма фильтрации
        /// </summary>
        private FilterForm? _filterForm;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            SetupData();
            SetupVisualStyles();
            this.Text = "Ex0rcise - Расчёт калорий";
        }

        /// <summary>
        /// Первоначальная настройка данных
        /// </summary>
        private void SetupData()
        {
            _exercises = new BindingList<IExercise>();
            _originalExercises = new List<IExercise>();
            ExerciseDataGridView.DataSource = _exercises;
            SetupColumns();
            RefreshButtons();
        }

        /// <summary>
        /// Обновление доступности кнопок
        /// </summary>
        private void RefreshButtons()
        {
            ButtonRemove.Enabled =
                ExerciseDataGridView.SelectedRows.Count > 0;
            ButtonClear.Enabled = _exercises.Count > 0;
        }

        /// <summary>
        /// Добавление упражнения в список
        /// </summary>
        private void RegisterExercise(
            IExercise exercise)
        {
            if (exercise != null)
            {
                _exercises.Add(exercise);
                _originalExercises.Add(exercise);
                RefreshButtons();
            }
        }

        /// <summary>
        /// Клик по кнопке "Добавить"
        /// </summary>
        private void ButtonAdd_Click(
            object sender, EventArgs arg)
        {
            if (_addForm != null && !_addForm.IsDisposed)
            {
                _addForm.Activate();
                _addForm.Focus();
                return;
            }

            _addForm = new AddForm();
            _addForm.ExerciseCreated +=
                ex => RegisterExercise(ex);
            _addForm.FormClosed +=
                (s, args) => _addForm = null;
            _addForm.Show();
        }

        /// <summary>
        /// Клик по кнопке "Фильтр"
        /// </summary>
        private void ButtonFilter_Click(
            object sender, EventArgs arg)
        {
            if (_filterForm != null
                && !_filterForm.IsDisposed)
            {
                _filterForm.Activate();
                _filterForm.Focus();
                return;
            }

            _filterForm = new FilterForm(
                _originalExercises);
            _filterForm.FilterApplied +=
                list => UpdateDisplayList(list);
            _filterForm.FilterCanceled += () =>
                UpdateDisplayList(_originalExercises);
            _filterForm.FormClosed +=
                (s, args) => _filterForm = null;
            _filterForm.Show();
        }

        /// <summary>
        /// Обновление отображаемого списка
        /// </summary>
        private void UpdateDisplayList(
            List<IExercise> list)
        {
            _exercises.Clear();
            foreach (var exercise in list)
            {
                _exercises.Add(exercise);
            }
            RefreshButtons();
        }

        /// <summary>
        /// Удаление выбранного упражнения
        /// </summary>
        private void ButtonRemove_Click(
            object sender, EventArgs arg)
        {
            if (ExerciseDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            var selected =
                ExerciseDataGridView.SelectedRows[0]
                    .DataBoundItem as IExercise;
            if (selected == null)
            {
                return;
            }

            var confirm = MessageBox.Show(
                $"Удалить '{selected.Name}'?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);

            if (confirm == DialogResult.Yes)
            {
                _exercises.Remove(selected);
                _originalExercises.Remove(selected);
                RefreshButtons();
            }
        }

        /// <summary>
        /// Очистка всего списка
        /// </summary>
        private void ButtonClear_Click(
            object sender, EventArgs e)
        {
            if (_exercises.Count == 0)
            {
                return;
            }

            var confirm = MessageBox.Show(
                "Очистить весь список?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (confirm == DialogResult.Yes)
            {
                _exercises.Clear();
                _originalExercises.Clear();
                RefreshButtons();
            }
        }

        /// <summary>
        /// Выбор строки в таблице
        /// </summary>
        private void ExerciseDataGridView_SelectionChanged(
            object sender, EventArgs args)
        {
            RefreshButtons();
        }

        /// <summary>
        /// Сохранение в файл
        /// </summary>
        private void SaveToolStripMenuItem_Click(
            object sender, EventArgs e)
        {
            if (_exercises.Count == 0)
            {
                MessageBox.Show(
                    "Список пуст", "Инфо",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            //TODO: RSDN
            using var dlg = new SaveFileDialog();
            dlg.Filter =
                "Файлы упражнений (*.shizo)|*.shizo";
            dlg.DefaultExt = "shizo";
            dlg.Title = "Сохранение данных";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    SerializeExercises(dlg.FileName);
                    MessageBox.Show(
                        "Успешно сохранено", "Готово",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Ошибка: {ex.Message}",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Загрузка из файла
        /// </summary>
        private void OpenToolStripMenuItem_Click(
            object sender, EventArgs e)
        {
            //TODO: RSDN
            using var dlg = new OpenFileDialog();
            dlg.Filter =
                "Файлы упражнений (*.shizo)|*.shizo";
            dlg.DefaultExt = "shizo";
            dlg.Title = "Открытие данных";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DeserializeExercises(dlg.FileName);
                    MessageBox.Show(
                        "Успешно загружено", "Готово",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Ошибка: {ex.Message}",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Сериализация упражнений
        /// </summary>
        private void SerializeExercises(string path)
        {
            var serializer = new XmlSerializer(
                typeof(List<ExerciseWrapper>));
            var wrapped = _originalExercises
                .Select(CreateWrapper).ToList();
            using (var fs = new FileStream(
                path, FileMode.Create))
            {
                serializer.Serialize(fs, wrapped);
            }
        }

        /// <summary>
        /// Десериализация упражнений
        /// </summary>
        private void DeserializeExercises(string path)
        {
            var content = File.ReadAllText(path);
            if (content.Contains(">NaN<")
                || content.Contains(">nan<"))
            {
                throw new InvalidDataException(
                    "Повреждённый файл (NaN значения)");
            }

            var serializer = new XmlSerializer(
                typeof(List<ExerciseWrapper>));
            using (var fs = new FileStream(
                path, FileMode.Open))
            {
                var wrapped = (List<ExerciseWrapper>)
                    serializer.Deserialize(fs);
                _exercises.Clear();
                _originalExercises.Clear();

                foreach (var word in wrapped)
                {
                    var exercise = word.RecoverExercise();
                    _exercises.Add(exercise);
                    _originalExercises.Add(exercise);
                }
            }

            RefreshButtons();
        }

        /// <summary>
        /// Создание обёртки для упражнения
        /// </summary>
        private ExerciseWrapper CreateWrapper(
            IExercise exercise)
        {
            return exercise switch
            {
                //TODO: RSDN
                Running r =>
                    new ExerciseWrapper(r),
                Swimming s =>
                    new ExerciseWrapper(s),
                BenchPress b =>
                    new ExerciseWrapper(b),
                _ => throw new InvalidOperationException(
                    "Неизвестный тип")
            };
        }

        //TODO: duplication
        /// <summary>
        /// Настройка визуального оформления
        /// </summary>
        private void SetupVisualStyles()
        {
            ThemeHelper.StyleForm(this);
            ThemeHelper.StyleGroupBox(
                ExercisesGroupBox, 12F);

            ThemeHelper.StyleDataGridView(
                ExerciseDataGridView);

            ThemeHelper.ApplyButtonStyle(
                ButtonAdd, ThemeHelper.Orange);
            ThemeHelper.ApplyButtonStyle(
                ButtonRemove, ThemeHelper.Red);
            ThemeHelper.ApplyButtonStyle(
                ButtonClear, ThemeHelper.Red);
            ThemeHelper.ApplyButtonStyle(
                ButtonFilter, ThemeHelper.Orange);

            ThemeHelper.StyleMenuStrip(
                MainMenuStrip,
                fileToolStripMenuItem,
                saveToolStripMenuItem,
                openToolStripMenuItem);
        }

        /// <summary>
        /// Конфигурация колонок таблицы
        /// </summary>
        private void SetupColumns()
        {
            var dgv = ExerciseDataGridView;
            dgv.AutoGenerateColumns = false;
            dgv.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.Columns.Clear();
            dgv.ColumnHeadersDefaultCellStyle.Padding =
                new Padding(0);
            dgv.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            var darkBg = Color.FromArgb(40, 40, 40);

            var nameCol = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Название",
                Name = "nameColumn",
                ReadOnly = true,
                HeaderCell =
                {
                    Style =
                    {
                        BackColor = darkBg,
                        ForeColor = Color.White
                    }
                }
            };

            var infoCol = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ExerciseInfo",
                HeaderText = "Детали",
                Name = "detailsColumn",
                ReadOnly = true,
                HeaderCell =
                {
                    Style =
                    {
                        BackColor = darkBg,
                        ForeColor = Color.White
                    }
                }
            };

            var calCol = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Calories",
                HeaderText = "Калории",
                Name = "caloriesColumn",
                ReadOnly = true,
                HeaderCell =
                {
                    Style =
                    {
                        BackColor = darkBg,
                        ForeColor = Color.White
                    }
                }
            };

            //TODO: duplication
            var commonStyle = new DataGridViewCellStyle
            {
                BackColor = darkBg,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F)
            };

            nameCol.DefaultCellStyle = commonStyle;
            infoCol.DefaultCellStyle = commonStyle;
            //TODO: duplication
            calCol.DefaultCellStyle =
                new DataGridViewCellStyle
            {
                BackColor = darkBg,
                ForeColor = Color.White,
                Format = "F2",
                Font = new Font("Segoe UI", 9F)
            };

            dgv.Columns.AddRange(
                nameCol,
                infoCol,
                calCol);

            nameCol.FillWeight = 25;
            infoCol.FillWeight = 50;
            calCol.FillWeight = 25;
        }
    }
}
