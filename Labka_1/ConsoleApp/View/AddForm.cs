using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Model;

namespace View
{
    /// <summary>
    /// Окно создания нового упражнения
    /// </summary>
    public partial class AddForm : Form
    {
        /// <summary>
        /// Событие создания упражнения
        /// </summary>
        public event Action<IExercise>? ExerciseCreated;

        /// <summary>
        /// Добавить форму и настроить её
        /// </summary>
        public AddForm()
        {
            InitializeComponent();
            ConfigureControls();
            ApplyDarkTheme();
            ButtonCreateRandom.Visible =
                Debugger.IsAttached;
        }

        /// <summary>
        /// Настройка элементов управления
        /// </summary>
        private void ConfigureControls()
        {
            ComboBoxExercise.Items.AddRange(
                ExerciseTypes.AllExerciseTypes);
            ComboBoxExercise.SelectedIndex = 0;
            ComboBoxStyle.Items.AddRange(
                ExerciseTypes.AllSwimmingStyles);
            ComboBoxStyle.SelectedIndex = 0;

            LabelIntensityUnit.Text = "км/ч";
            LabelRunningDistanceUnit.Text = "км";
            LabelSwimmingDistanceUnit.Text = "м";
            LabelWeightUnit.Text = "кг";

            SwitchExerciseType();
        }

        /// <summary>
        /// Переключение видимости панелей
        /// </summary>
        private void SwitchExerciseType()
        {
            PanelRunning.Visible = false;
            PanelSwimming.Visible = false;
            PanelBenchPress.Visible = false;

            string selected =
                ComboBoxExercise.SelectedItem
                    ?.ToString() ?? "";
            if (selected == ExerciseTypes.Running)
            {
                PanelRunning.Visible = true;
            }
            else if (selected == ExerciseTypes.Swimming)
            {
                PanelSwimming.Visible = true;
            }
            else if (selected == ExerciseTypes.BenchPress)
            {
                PanelBenchPress.Visible = true;
            }
        }

        /// <summary>
        /// Смена типа упражнения
        /// </summary>
        private void ComboBoxExercise_SelectedIndexChanged(
            object sender, EventArgs arg)
        {
            SwitchExerciseType();
        }

        /// <summary>
        /// Создание упражнения (кнопка)
        /// </summary>
        private void ButtonCreate_Click(
            object sender, EventArgs e)
        {
            try
            {
                if (CheckInputData())
                {
                    var exercise = BuildExercise();
                    ExerciseCreated?.Invoke(exercise);
                    TextBoxName.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Закрытие окна
        /// </summary>
        private void ButtonClose_Click(
            object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Генерация случайного упражнения
        /// </summary>
        private void ButtonCreateRandom_Click(
            object sender, EventArgs e)
        {
            try
            {
                var rnd = new Random();
                TextBoxName.Text =
                    $"Упражнение {rnd.Next(1000)}";
                string type =
                    ComboBoxExercise.SelectedItem
                        ?.ToString() ?? "";

                switch (type)
                {
                    case ExerciseTypes.Running:
                        NumericIntensity.Value = (decimal)
                            Math.Round(
                                rnd.NextDouble() * 29 + 1,
                                2);
                        NumericRunningDistance.Value =
                            (decimal)Math.Round(
                                rnd.NextDouble() * 99.9
                                + 0.1, 2);
                        break;
                    case ExerciseTypes.Swimming:
                        ComboBoxStyle.SelectedIndex =
                            rnd.Next(
                                ComboBoxStyle.Items.Count);
                        NumericSwimmingDistance.Value =
                            (decimal)Math.Round(
                                rnd.NextDouble() * 9999
                                + 1, 2);
                        break;
                    case ExerciseTypes.BenchPress:
                        NumericWeight.Value = (decimal)
                            Math.Round(
                                rnd.NextDouble() * 340 + 1,
                                2);
                        NumericRepetitions.Value =
                            rnd.Next(1, 1001);
                        break;
                }

                if (CheckInputData())
                {
                    var exercise = BuildExercise();
                    ExerciseCreated?.Invoke(exercise);
                    TextBoxName.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Проверка корректности ввода
        /// </summary>
        private bool CheckInputData()
        {
            if (string.IsNullOrWhiteSpace(TextBoxName.Text))
            {
                MessageBox.Show(
                    "Введите название", "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                TextBoxName.Focus();
                return false;
            }
            if (TextBoxName.Text.Length > ExerciseBase.MaxNameLength)
            {
                MessageBox.Show(
                    $"Длинное название (макс. {ExerciseBase.MaxNameLength})",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                TextBoxName.Focus();
                return false;
            }

            string type =
                ComboBoxExercise.SelectedItem
                    ?.ToString() 
                    ?? "";
            return type switch
            {
                ExerciseTypes.Running =>
                    CheckRunningData(),
                ExerciseTypes.Swimming =>
                    CheckSwimmingData(),
                ExerciseTypes.BenchPress =>
                    CheckBenchPressData(),
                _ => false
            };
        }

        /// <summary>
        /// Проверка данных для бега
        /// </summary>
        private bool CheckRunningData()
        {
            if (NumericIntensity.Value <
                (decimal)Running.MinIntensity ||
                NumericIntensity.Value >
                (decimal)Running.MaxIntensity)
            {
                MessageBox.Show(
                    "Интенсивность 1-30 км/ч", "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                NumericIntensity.Focus();
                return false;
            }
            if (NumericRunningDistance.Value <
                (decimal)Running.MinDistance ||
                NumericRunningDistance.Value >
                (decimal)Running.MaxDistance)
            {
                MessageBox.Show(
                    "Дистанция 0,1-100 км", "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                NumericRunningDistance.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Проверка данных для плавания
        /// </summary>
        private bool CheckSwimmingData()
        {
            if (NumericSwimmingDistance.Value <
                (decimal)Swimming.MinDistance ||
                NumericSwimmingDistance.Value >
                (decimal)Swimming.MaxDistance)
            {
                MessageBox.Show(
                    "Дистанция 1-10000 м", "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                NumericSwimmingDistance.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Проверка данных для жима
        /// </summary>
        private bool CheckBenchPressData()
        {
            if 
                (NumericWeight.Value <
                (decimal)BenchPress.MinWeight ||
                NumericWeight.Value >
                (decimal)BenchPress.MaxWeight)
            {
                MessageBox.Show(
                    "Вес 1-341 кг", "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                NumericWeight.Focus();
                return false;
            }
            if (NumericRepetitions.Value <
                (decimal)BenchPress.MinRepetitions ||
                NumericRepetitions.Value >
                (decimal)BenchPress.MaxRepetitions)
            {
                MessageBox.Show(
                    "Повторения 1-1000", "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                NumericRepetitions.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Построение объекта упражнения
        /// </summary>
        private IExercise BuildExercise()
        {
            string name = TextBoxName.Text.Trim();
            string type =
                ComboBoxExercise.SelectedItem
                    ?.ToString() ?? "";

            return type switch
            {
                ExerciseTypes.Running =>
                    new Running(name,
                        (double)NumericIntensity.Value,
                        (double)NumericRunningDistance
                            .Value),
                ExerciseTypes.Swimming =>
                    new Swimming(name,
                        (ComboBoxStyle.SelectedItem
                            ?.ToString() ?? "") 
                        switch
                        {
                            ExerciseTypes.Freestyle =>
                                SwimmingStyle.Freestyle,
                            ExerciseTypes.Butterfly =>
                                SwimmingStyle.Butterfly,
                            _ => SwimmingStyle.Freestyle
                        },
                        (double)NumericSwimmingDistance
                            .Value),
                ExerciseTypes.BenchPress =>
                    new BenchPress(name,
                        (double)NumericWeight.Value,
                        (int)NumericRepetitions.Value),
                _ => 
                throw new InvalidOperationException(
                    "Неизвестный тип")
            };
        }

        /// <summary>
        /// Тёмная тема оформления
        /// </summary>
        private void ApplyDarkTheme()
        {
            ThemeHelper.StyleForm(this);

            ThemeHelper.StyleGroupBox(ExerciseGroupBox);
            ExerciseGroupBox.FlatStyle = FlatStyle.Flat;

            PanelRunning.BackColor = ThemeHelper.Panel;
            PanelSwimming.BackColor = ThemeHelper.Panel;
            PanelBenchPress.BackColor = ThemeHelper.Panel;

            ThemeHelper.StyleLabel(
                LabelName, bold: true);
            LabelParameters.ForeColor = ThemeHelper.Orange;
            LabelParameters.Font = ThemeHelper.SectionFont;

            foreach (var label in new[]
            {
                LabelIntensity,
                LabelRunningDistance,
                LabelSwimmingDistance,
                LabelStyle,
                LabelWeight,
                LabelRepetitions,
                LabelIntensityUnit,
                LabelRunningDistanceUnit,
                LabelSwimmingDistanceUnit,
                LabelWeightUnit,
                LabelRepetitionsUnit
            })
            {
                ThemeHelper.StyleLabel(label, dim: true);
            }

            ThemeHelper.StyleTextBox(TextBoxName);
            ThemeHelper.StyleComboBox(ComboBoxExercise);
            ThemeHelper.StyleComboBox(ComboBoxStyle);

            foreach (var numeric in new[]
            {
                NumericIntensity,
                NumericRunningDistance,
                NumericSwimmingDistance,
                NumericWeight,
                NumericRepetitions
            })
            {
                ThemeHelper.StyleNumericUpDown(numeric);
            }

            ThemeHelper.ApplyButtonStyle(
                ButtonCreate, ThemeHelper.Orange,
                ThemeHelper.SectionFont.Size);
            ThemeHelper.ApplyButtonStyle(
                ButtonClose, ThemeHelper.ButtonGray,
                ThemeHelper.SectionFont.Size);
            ThemeHelper.ApplyButtonStyle(
                ButtonCreateRandom, ThemeHelper.Red,
                ThemeHelper.SectionFont.Size);
        }
    }
}
