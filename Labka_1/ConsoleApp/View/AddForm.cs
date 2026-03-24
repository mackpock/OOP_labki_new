using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Model;

namespace View
{
    /// <summary>
    /// Форма добавления упражнения
    /// </summary>
    public partial class AddForm : Form
    {
        /// <summary>
        /// Событие, возникающее при создании нового упражнения
        /// </summary>
        public event Action<IExercise> ExerciseCreated;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public AddForm()
        {
            InitializeComponent();
            InitializeForm();
            ApplyGymStyle();
            // Кнопка видима только при отладке
            ButtonCreateRandom.Visible = Debugger.IsAttached;
        }

        /// <summary>
        /// Стилизация кнопки
        /// </summary>
        private void StyleButton(Button button, Color backColor)
        {
            button.BackColor = backColor;
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// Первоначальная настройка элементов управления формы
        /// </summary>
        private void InitializeForm()
        {
            ComboBoxExercise.Items.AddRange(Constants.AllExerciseTypes);
            ComboBoxExercise.SelectedIndex = 0;
            ComboBoxStyle.Items.AddRange(Constants.AllSwimmingStyles);
            ComboBoxStyle.SelectedIndex = 0;
            LabelIntensityUnit.Text = "км/ч";
            LabelRunningDistanceUnit.Text = "км";
            LabelSwimmingDistanceUnit.Text = "м";
            LabelWeightUnit.Text = "кг";
            UpdateExerciseParameters();
        }

        /// <summary>
        /// Обновление параметров упражнения
        /// </summary>
        private void UpdateExerciseParameters()
        {
            PanelRunning.Visible = false;
            PanelSwimming.Visible = false;
            PanelBenchPress.Visible = false;
            switch (ComboBoxExercise.SelectedItem.ToString())
            {
                case Constants.Running:
                {
                    PanelRunning.Visible = true;
                    break;
                }
                case Constants.Swimming:
                {
                    PanelSwimming.Visible = true;
                    break;
                }
                case Constants.BenchPress:
                {
                    PanelBenchPress.Visible = true;
                    break;
                }
            }
        }

        /// <summary>           
        /// Обработчик изменения типа упражнения
        /// </summary>
        private void ComboBoxExercise_SelectedIndexChanged(object sender,
            EventArgs arg)
        {
            UpdateExerciseParameters();
        }

        /// <summary>
        /// Обработчик нажатия кнопки Создать
        /// </summary>
        private void ButtonCreate_Click(object sender, EventArgs arg)
        {
            try
            {
                if (ValidateInput())
                {
                    var exercise = CreateExercise();
                    ExerciseCreated?.Invoke(exercise);
                    TextBoxName.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ошибка при создании упражнения: {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки Закрыть
        /// </summary>
        private void ButtonClose_Click(object sender, EventArgs arg)
        {
            this.Close();
        }

        /// <summary>
        /// Обработчик нажатия кнопки Создать случайное упражнение
        /// </summary>
        private void ButtonCreateRandom_Click(object sender, EventArgs arg)
        {
            try
            {
                var random = new Random();
                TextBoxName.Text = $"Упражнение {random.Next(1000)}";
                switch (ComboBoxExercise.SelectedItem.ToString())
                {
                    case Constants.Running:
                        {

                            NumericIntensity.Value = (decimal)
                                Math.Round(random.NextDouble() * 29 + 1, 2);
                            NumericRunningDistance.Value = (decimal)
                                Math.Round(random.NextDouble() * 99.9 + 0.1, 2);
                            break;
                        }
                    case Constants.Swimming:
                        {
                            ComboBoxStyle.SelectedIndex =
                                random.Next(ComboBoxStyle.Items.Count);

                            NumericSwimmingDistance.Value = (decimal)
                                Math.Round(random.NextDouble() * 9999 + 1, 2);
                            break;
                        }
                    case Constants.BenchPress:
                        {
                            NumericWeight.Value = (decimal)
                                Math.Round(random.NextDouble() * 340 + 1, 2);
                            NumericRepetitions.Value = random.Next(1, 1001);
                            break;
                        }
                }
                if (ValidateInput())
                {
                    var exercise = CreateExercise();
                    ExerciseCreated?.Invoke(exercise);
                    TextBoxName.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ошибка при создании случайного упражнения: " +
                    $"{ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Валидация введенных данных имени и параметров
        /// </summary>
        /// <returns>true если данные валидны</returns>
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(TextBoxName.Text))
            {
                MessageBox.Show(
                    "Название упражнения не может быть пустым",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                TextBoxName.Focus();
                return false;
            }
            if (TextBoxName.Text.Length > 50)
            {
                MessageBox.Show(
                    "Название упражнения слишком длинное" +
                    " (максимум 50 символов)",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                TextBoxName.Focus();
                return false;
            }
            switch (ComboBoxExercise.SelectedItem.ToString())
            {
                case Constants.Running:
                    {
                        return ValidateRunningInput();
                    }
                case Constants.Swimming:
                    {
                        return ValidateSwimmingInput();
                    }
                case Constants.BenchPress:
                    {
                        return ValidateBenchPressInput();
                    }
                default:
                    {
                        return false;
                    }
            }
        }

        /// <summary>
        /// Валидация данных для бега
        /// </summary>
        /// <returns>true если данные валидны</returns>
        private bool ValidateRunningInput()
        {
            if (NumericIntensity.Value < 1m ||
                NumericIntensity.Value > 30)
            {
                MessageBox.Show(
                    "Интенсивность должна быть от 1 до 30 км/ч",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                NumericIntensity.Focus();
                return false;
            }
            if (NumericRunningDistance.Value < 0.1m ||
                NumericRunningDistance.Value > 100)
            {
                MessageBox.Show(
                    "Дистанция должна быть от 0,1 до 100 км",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                NumericRunningDistance.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Валидация данных для плавания
        /// </summary>
        /// <returns>true если данные валидны</returns>
        private bool ValidateSwimmingInput()
        {
            if (NumericSwimmingDistance.Value < 1 ||
                NumericSwimmingDistance.Value > 10000)
            {
                MessageBox.Show(
                    "Дистанция должна быть от 1 до 10000 метров",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                NumericSwimmingDistance.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Валидация данных для жима штанги
        /// </summary>
        /// <returns>true если данные валидны</returns>
        private bool ValidateBenchPressInput()
        {
            if (NumericWeight.Value < 1 ||
                NumericWeight.Value > 341)
            {
                MessageBox.Show(
                    "Вес должен быть от 1 до 341 кг",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                NumericWeight.Focus();
                return false;
            }
            if (NumericRepetitions.Value < 1 ||
                NumericRepetitions.Value > 1000)
            {
                MessageBox.Show(
                    "Количество повторений должно быть от 1 до 1000",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                NumericRepetitions.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Создание упражнения
        /// </summary>
        /// <returns>Упражнение</returns>
        private IExercise CreateExercise()
        {
            string name = TextBoxName.Text.Trim();
            string exerciseType = ComboBoxExercise.SelectedItem.ToString();
            switch (exerciseType)
            {
                case Constants.Running:
                    {
                        return new Running(
                            name,
                            (double)NumericIntensity.Value,
                            (double)NumericRunningDistance.Value);
                    }
                case Constants.Swimming:
                    {
                        SwimmingStyle style;
                        string styleString = ComboBoxStyle.SelectedItem.ToString();
                        switch (styleString)
                        {
                            case Constants.Freestyle:
                            {
                                style = SwimmingStyle.Freestyle;
                                break;
                            }
                            case Constants.Butterfly:
                            {
                                style = SwimmingStyle.Butterfly;
                                break;
                            }
                            default:
                            {
                                style = SwimmingStyle.Freestyle;
                                break;
                            }
                        }
                        return new Swimming(
                            name,
                            style,
                            (double)NumericSwimmingDistance.Value);
                    }
                case Constants.BenchPress:
                    {
                        return new BenchPress(
                            name,
                            (double)NumericWeight.Value,
                            (int)NumericRepetitions.Value);
                    }
                default:
                    {
                        throw new InvalidOperationException("Неизвестный тип упражнения");
                    }
            }
        }
        /// <summary>
        /// стиль
        /// </summary>
        private void ApplyGymStyle()
        {
            // Тёмная тема 
            Color darkBg = Color.FromArgb(30, 30, 30);
            Color darkPanel = Color.FromArgb(45, 45, 45);
            Color accentOrange = Color.FromArgb(255, 140, 0);
            Color accentRed = Color.FromArgb(220, 20, 60);
            Color textLight = Color.FromArgb(240, 240, 240);
            Color textDim = Color.FromArgb(180, 180, 180);

            // Основная форма
            this.BackColor = darkBg;
            this.ForeColor = textLight;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterParent;

            // GroupBox
            ExerciseGroupBox.BackColor = darkPanel;
            ExerciseGroupBox.ForeColor = accentOrange;
            ExerciseGroupBox.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            ExerciseGroupBox.FlatStyle = FlatStyle.Flat;

            // Панели
            PanelRunning.BackColor = darkPanel;
            PanelSwimming.BackColor = darkPanel;
            PanelBenchPress.BackColor = darkPanel;

            // Labels
            LabelName.ForeColor = textLight;
            LabelName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            LabelParameters.ForeColor = accentOrange;
            LabelParameters.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            LabelIntensity.ForeColor = textDim;
            LabelRunningDistance.ForeColor = textDim;
            LabelSwimmingDistance.ForeColor = textDim;
            LabelStyle.ForeColor = textDim;
            LabelWeight.ForeColor = textDim;
            LabelRepetitions.ForeColor = textDim;
            LabelIntensityUnit.ForeColor = textDim;
            LabelRunningDistanceUnit.ForeColor = textDim;
            LabelSwimmingDistanceUnit.ForeColor = textDim;
            LabelWeightUnit.ForeColor = textDim;
            LabelRepetitionsUnit.ForeColor = textDim;

            // TextBox
            TextBoxName.BackColor = Color.FromArgb(60, 60, 60);
            TextBoxName.ForeColor = textLight;
            TextBoxName.BorderStyle = BorderStyle.FixedSingle;
            TextBoxName.Font = new Font("Segoe UI", 10F);

            // ComboBox
            ComboBoxExercise.BackColor = Color.FromArgb(60, 60, 60);
            ComboBoxExercise.ForeColor = textLight;
            ComboBoxExercise.Font = new Font("Segoe UI", 10F);
            ComboBoxStyle.BackColor = Color.FromArgb(60, 60, 60);
            ComboBoxStyle.ForeColor = textLight;
            ComboBoxStyle.Font = new Font("Segoe UI", 10F);

            // кастомная стилизация 
            NumericIntensity.BackColor = Color.FromArgb(60, 60, 60);
            NumericIntensity.ForeColor = textLight;
            NumericRunningDistance.BackColor = Color.FromArgb(60, 60, 60);
            NumericRunningDistance.ForeColor = textLight;
            NumericSwimmingDistance.BackColor = Color.FromArgb(60, 60, 60);
            NumericSwimmingDistance.ForeColor = textLight;
            NumericWeight.BackColor = Color.FromArgb(60, 60, 60);
            NumericWeight.ForeColor = textLight;
            NumericRepetitions.BackColor = Color.FromArgb(60, 60, 60);
            NumericRepetitions.ForeColor = textLight;

            // Кнопки
            StyleButton(ButtonCreate, accentOrange);
            StyleButton(ButtonClose, Color.FromArgb(80, 80, 80));
            StyleButton(ButtonCreateRandom, accentRed);
        }
    }
}
