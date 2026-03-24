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
        public event Action<IExercise> ExerciseCreated;

        /// <summary>
        /// Добавить форму и настроить её
        /// </summary>
        public AddForm()
        {
            InitializeComponent();
            ConfigureControls();
            ApplyDarkTheme();
            ButtonCreateRandom.Visible = Debugger.IsAttached;
        }

        /// <summary>
        /// Настройка элементов управления
        /// </summary>
        private void ConfigureControls()
        {
            ComboBoxExercise.Items.AddRange(ExerciseTypes.AllExerciseTypes);
            ComboBoxExercise.SelectedIndex = 0;
            ComboBoxStyle.Items.AddRange(ExerciseTypes.AllSwimmingStyles);
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

            string selected = ComboBoxExercise.SelectedItem.ToString();
            if (selected == ExerciseTypes.Running) PanelRunning.Visible = true;

            else if (selected == ExerciseTypes.Swimming) PanelSwimming.Visible 
            = true;

            else if (selected == ExerciseTypes.BenchPress)
             PanelBenchPress.Visible = true;
        }

        /// <summary>
        /// Смена типа упражнения
        /// </summary>
        private void ComboBoxExercise_SelectedIndexChanged(object sender,
         EventArgs arg)
        {
            SwitchExerciseType();
        }

        /// <summary>
        /// Создание упражнения (кнопка)
        /// </summary>
        private void ButtonCreate_Click(object sender, EventArgs e)
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
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Закрытие окна
        /// </summary>
        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Генерация случайного упражнения
        /// </summary>
        private void ButtonCreateRandom_Click(object sender, EventArgs e)
        {
            try
            {
                var rnd = new Random();
                TextBoxName.Text = $"Упражнение {rnd.Next(1000)}";
                string type = ComboBoxExercise.SelectedItem.ToString();

                if (type == ExerciseTypes.Running)
                {
                    NumericIntensity.Value = (decimal)
                    Math.Round(rnd.NextDouble() * 29 + 1, 2);
                    NumericRunningDistance.Value = (decimal)
                    Math.Round(rnd.NextDouble() * 99.9 + 0.1, 2);
                }
                else if (type == ExerciseTypes.Swimming)
                {
                    ComboBoxStyle.SelectedIndex = rnd.Next
                    (ComboBoxStyle.Items.Count);
                    NumericSwimmingDistance.Value = (decimal)
                    Math.Round(rnd.NextDouble() * 9999 + 1, 2);
                }
                else if (type == ExerciseTypes.BenchPress)
                {
                    NumericWeight.Value = (decimal)
                    Math.Round(rnd.NextDouble() * 340 + 1, 2);
                    NumericRepetitions.Value = rnd.Next(1, 1001);
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
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Проверка корректности ввода
        /// </summary>
        private bool CheckInputData()
        {
            if (string.IsNullOrWhiteSpace(TextBoxName.Text))
            {
                MessageBox.Show("Введите название", "Ошибка",
                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TextBoxName.Focus();
                return false;
            }
            if (TextBoxName.Text.Length > 50)
            {
                MessageBox.Show("Длинное название (макс. 50)", "Ошибка",
                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TextBoxName.Focus();
                return false;
            }

            string type = ComboBoxExercise.SelectedItem.ToString();
            return type 
            
            switch
            {
                ExerciseTypes.Running => CheckRunningData(),
                ExerciseTypes.Swimming => CheckSwimmingData(),
                ExerciseTypes.BenchPress => CheckBenchPressData(),
                _ => false
            };
        }

        /// <summary>
        /// Проверка данных для бега
        /// </summary>
        private bool CheckRunningData()
        {
            if (NumericIntensity.Value < 1m ||
                NumericIntensity.Value > 30)
            {
                MessageBox.Show("Интенсивность 1-30 км/ч", "Ошибка",
                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NumericIntensity.Focus();
                return false;
            }
            if (NumericRunningDistance.Value < 0.1m ||
                NumericRunningDistance.Value > 100)
            {
                MessageBox.Show("Дистанция 0,1-100 км", "Ошибка",
                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (NumericSwimmingDistance.Value < 1 ||
             NumericSwimmingDistance.Value > 10000)
            {
                MessageBox.Show("Дистанция 1-10000 м", "Ошибка",
                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (NumericWeight.Value < 1 || NumericWeight.Value > 341)
            {
                MessageBox.Show("Вес 1-341 кг", "Ошибка", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NumericWeight.Focus();
                return false;
            }
            if (NumericRepetitions.Value < 1 || NumericRepetitions.Value > 1000)
            {
                MessageBox.Show("Повторения 1-1000", "Ошибка", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            string type = ComboBoxExercise.SelectedItem.ToString();

            if (type == ExerciseTypes.Running)
            {
                return new Running(name, (double)NumericIntensity.Value,
                 (double)NumericRunningDistance.Value);
            }
            else if (type == ExerciseTypes.Swimming)
            {
                var style = ComboBoxStyle.SelectedItem.ToString() 
                switch
                {
                    ExerciseTypes.Freestyle => SwimmingStyle.Freestyle,
                    ExerciseTypes.Butterfly => SwimmingStyle.Butterfly,
                    _ => SwimmingStyle.Freestyle
                };
                return new Swimming(name, style,
                 (double)NumericSwimmingDistance.Value);
            }
            else if (type == ExerciseTypes.BenchPress)
            {
                return new BenchPress(name, (double)NumericWeight.Value,
                 (int)NumericRepetitions.Value);
            }

            throw new InvalidOperationException("Неизвестный тип");
        }

        /// <summary>
        /// Тёмная тема оформления
        /// </summary>
        private void ApplyDarkTheme()
        {
            Color bg = Color.FromArgb(30, 30, 30);
            Color panel = Color.FromArgb(45, 45, 45);
            Color orange = Color.FromArgb(255, 140, 0);
            Color red = Color.FromArgb(220, 20, 60);
            Color text = Color.FromArgb(240, 240, 240);
            Color dimText = Color.FromArgb(180, 180, 180);

            this.BackColor = bg;
            this.ForeColor = text;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterParent;

            ExerciseGroupBox.BackColor = panel;
            ExerciseGroupBox.ForeColor = orange;
            ExerciseGroupBox.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            ExerciseGroupBox.FlatStyle = FlatStyle.Flat;

            PanelRunning.BackColor = panel;
            PanelSwimming.BackColor = panel;
            PanelBenchPress.BackColor = panel;

            LabelName.ForeColor = text;
            LabelName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            LabelParameters.ForeColor = orange;
            LabelParameters.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            
            foreach (var lbl in new[] 
            {
             LabelIntensity,     LabelRunningDistance, LabelSwimmingDistance, 
             LabelStyle,         LabelWeight,          LabelRepetitions,
             LabelIntensityUnit, LabelRunningDistanceUnit, 
             LabelSwimmingDistanceUnit, LabelWeightUnit, LabelRepetitionsUnit 
            })
            {
                lbl.ForeColor = dimText;
            }

            TextBoxName.BackColor = Color.FromArgb(60, 60, 60);
            TextBoxName.ForeColor = text;
            TextBoxName.BorderStyle = BorderStyle.FixedSingle;
            TextBoxName.Font = new Font("Segoe UI", 10F);

            ComboBoxExercise.BackColor = Color.FromArgb(60, 60, 60);
            ComboBoxExercise.ForeColor = text;
            ComboBoxExercise.Font = new Font("Segoe UI", 10F);
            
            ComboBoxStyle.BackColor = Color.FromArgb(60, 60, 60);
            ComboBoxStyle.ForeColor = text;
            ComboBoxStyle.Font = new Font("Segoe UI", 10F);

            foreach (var num in new[] 
            { NumericIntensity,        NumericRunningDistance, 
              NumericSwimmingDistance, NumericWeight, 
              NumericRepetitions })
            {
                num.BackColor = Color.FromArgb(60, 60, 60);
                num.ForeColor = text;
            }

            ApplyButtonStyle(ButtonCreate, orange);
            ApplyButtonStyle(ButtonClose, Color.FromArgb(80, 80, 80));
            ApplyButtonStyle(ButtonCreateRandom, red);
        }

        /// <summary>
        /// Стиль кнопки
        /// </summary>
        private void ApplyButtonStyle(Button btn, Color clr)
        {
            btn.BackColor = clr;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
        }
    }
}
