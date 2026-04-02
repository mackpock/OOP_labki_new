namespace View
{
    /// <summary>
    /// Справочник типов упражнений и стилей плавания
    /// </summary>
    public static class ExerciseTypes
    {

        /// <summary>
        /// Тип упражнения — бег
        /// </summary>
        public const string Running = "Бег";

        /// <summary>
        /// Тип упражнения — плавание
        /// </summary>
        public const string Swimming = "Плавание";

        /// <summary>
        /// Тип упражнения — жим штанги
        /// </summary>
        public const string BenchPress = "Жим штанги";

        /// <summary>
        /// Стиль плавания — вольный
        /// </summary>
        public const string Freestyle = "Вольный стиль";

        /// <summary>
        /// Стиль плавания — баттерфляй
        /// </summary>
        public const string Butterfly = "Баттерфляй";

        /// <summary>
        /// Все типы упражнений
        /// </summary>
        public static readonly string[] AllExerciseTypes =
        {
            Running,
            Swimming,
            BenchPress
        };

        /// <summary>
        /// Все стили плавания
        /// </summary>
        public static readonly string[] AllSwimmingStyles =
        {
            Freestyle,
            Butterfly
        };
    }
}
