using System.Drawing;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Общие цвета и стили тёмной темы
    /// </summary>
    public static class ThemeHelper
    {
        /// <summary>
        /// Фон окна
        /// </summary>
        public static readonly Color Background =
            Color.FromArgb(30, 30, 30);

        /// <summary>
        /// Фон панели
        /// </summary>
        public static readonly Color Panel =
            Color.FromArgb(45, 45, 45);

        /// <summary>
        /// Оранжевый акцент
        /// </summary>
        public static readonly Color Orange =
            Color.FromArgb(255, 140, 0);

        /// <summary>
        /// Красный акцент
        /// </summary>
        public static readonly Color Red =
            Color.FromArgb(220, 20, 60);

        /// <summary>
        /// Основной текст
        /// </summary>
        public static readonly Color Text =
            Color.FromArgb(240, 240, 240);

        /// <summary>
        /// Приглушённый текст
        /// </summary>
        public static readonly Color DimText =
            Color.FromArgb(180, 180, 180);

        /// <summary>
        /// Фон полей ввода
        /// </summary>
        public static readonly Color Input =
            Color.FromArgb(60, 60, 60);

        /// <summary>
        /// Серый фон кнопки
        /// </summary>
        public static readonly Color ButtonGray =
            Color.FromArgb(80, 80, 80);

        /// <summary>
        /// Название шрифта интерфейса
        /// </summary>
        public const string FontFamily = "Segoe UI";

        /// <summary>
        /// Формат отображения чисел с плавающей точкой
        /// </summary>
        public const string FloatFormat = "F2";

        /// <summary>
        /// Базовый размер шрифта
        /// </summary>
        /// <summary>
        /// Размер шрифта ячеек таблицы
        /// </summary>
        public const float FontSizeCell = 9F;

        /// <summary>
        /// Базовый размер шрифта
        /// </summary>
        public const float FontSizeBase = 10F;

        /// <summary>
        /// Размер шрифта заголовка раздела
        /// </summary>
        public const float FontSizeSection = 11F;

        /// <summary>
        /// Увеличенный размер шрифта заголовка раздела
        /// </summary>
        public const float FontSizeSectionLarge = 12F;

        /// <summary>
        /// Шрифт ячеек таблицы
        /// </summary>
        public static readonly Font CellFont =
            new Font(FontFamily, FontSizeCell);

        /// <summary>
        /// Шрифт заголовка раздела
        /// </summary>
        public static readonly Font SectionFont =
            new Font(FontFamily, FontSizeSection, FontStyle.Bold);

        /// <summary>
        /// Увеличенный шрифт заголовка раздела
        /// </summary>
        public static readonly Font SectionFontLarge =
            new Font(FontFamily, FontSizeSectionLarge, FontStyle.Bold);

        /// <summary>
        /// Базовый стиль формы
        /// </summary>
        public static void StyleForm(Form form)
        {
            form.BackColor = Background;
            form.ForeColor = Text;
            form.FormBorderStyle =
                FormBorderStyle.FixedSingle;
            form.StartPosition =
                FormStartPosition.CenterParent;
        }

        /// <summary>
        /// Стиль группы
        /// </summary>
        public static void StyleGroupBox(
            GroupBox groupBox, Font? font = null)
        {
            groupBox.BackColor = Panel;
            groupBox.ForeColor = Orange;
            groupBox.Font = font ?? SectionFont;
        }

        /// <summary>
        /// Стиль текстового поля
        /// </summary>
        public static void StyleTextBox(TextBox textBox)
        {
            textBox.BackColor = Input;
            textBox.ForeColor = Text;
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.Font = new Font(FontFamily, FontSizeBase);
        }

        /// <summary>
        /// Стиль выпадающего списка
        /// </summary>
        public static void StyleComboBox(
            ComboBox comboBox)
        {
            comboBox.BackColor = Input;
            comboBox.ForeColor = Text;
            comboBox.Font = new Font(FontFamily, FontSizeBase);
        }

        /// <summary>
        /// Стиль числового поля
        /// </summary>
        public static void StyleNumericUpDown(
            NumericUpDown numeric)
        {
            numeric.BackColor = Input;
            numeric.ForeColor = Text;
        }

        /// <summary>
        /// Стиль метки (жирная/обычная, яркая/тусклая)
        /// </summary>
        public static void StyleLabel(
            Label label,
            bool bold = false,
            bool dim = false)
        {
            label.ForeColor = dim ? DimText : Text;
            if (bold)
            {
                label.Font = new Font(
                    FontFamily, FontSizeBase, FontStyle.Bold);
            }
        }

        /// <summary>
        /// Стиль списка с чекбоксами
        /// </summary>
        public static void StyleCheckedListBox(
            CheckedListBox list)
        {
            list.BackColor = Input;
            list.ForeColor = Text;
            list.BorderStyle = BorderStyle.FixedSingle;
        }

        /// <summary>
        /// Фон ячеек таблицы
        /// </summary>
        public static readonly Color DarkCell =
            Color.FromArgb(40, 40, 40);

        /// <summary>
        /// Вес колонки с названием
        /// </summary>
        public const float ColWeightName = 25F;

        /// <summary>
        /// Вес колонки с деталями
        /// </summary>
        public const float ColWeightInfo = 50F;

        /// <summary>
        /// Вес колонки с калориями
        /// </summary>
        public const float ColWeightCalories = 25F;

        /// <summary>
        /// Фон таблицы
        /// </summary>
        private static readonly Color GridBg =
            Color.FromArgb(50, 50, 50);

        /// <summary>
        /// Цвет линий сетки
        /// </summary>
        private static readonly Color GridLine =
            Color.FromArgb(70, 70, 70);

        /// <summary>
        /// Цвет выделения строки
        /// </summary>
        private static readonly Color Selection =
            Color.FromArgb(80, 60, 60);

        /// <summary>
        /// Стиль таблицы DataGridView
        /// </summary>
        public static void StyleDataGridView(
            DataGridView dgv)
        {
            dgv.BackgroundColor = GridBg;
            dgv.GridColor = GridLine;

            var headerStyle =
                dgv.ColumnHeadersDefaultCellStyle;
            headerStyle.BackColor = DarkCell;
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font(
                FontFamily, FontSizeBase, FontStyle.Bold);
            headerStyle.Padding = new Padding(5);
            headerStyle.SelectionBackColor = Input;
            headerStyle.SelectionForeColor = Color.White;
            headerStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersHeight = 35;
            dgv.RowHeadersDefaultCellStyle.Padding =
                new Padding(0);
            dgv.RowHeadersVisible = false;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle =
                DataGridViewCellBorderStyle.None;
            dgv.AdvancedColumnHeadersBorderStyle.All =
                DataGridViewAdvancedCellBorderStyle.None;
            dgv.RowTemplate.Height = 30;

            var cellStyle = dgv.DefaultCellStyle;
            cellStyle.BackColor = DarkCell;
            cellStyle.ForeColor = Text;
            cellStyle.Font = CellFont;
            cellStyle.SelectionBackColor = Selection;
            cellStyle.SelectionForeColor = Color.White;
        }

        /// <summary>
        /// Стиль меню
        /// </summary>
        public static void StyleMenuStrip(
            MenuStrip menu,
            params ToolStripMenuItem[] items)
        {
            menu.BackColor = Panel;
            menu.ForeColor = Text;
            foreach (var item in items)
            {
                item.BackColor = Panel;
                item.ForeColor = Text;
            }
        }

        /// <summary>
        /// Применить стиль к кнопке
        /// </summary>
        public static void ApplyButtonStyle(
            Button button, Color color,
            float fontSize = FontSizeBase)
        {
            button.BackColor = color;
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = new Font(
                FontFamily, fontSize, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
        }
    }
}
