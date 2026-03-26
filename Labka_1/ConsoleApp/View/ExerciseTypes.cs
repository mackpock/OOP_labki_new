namespace View
{
    /// <summary>
    /// Справочник типов упражнений и стилей плавания
    /// </summary>
    public static class ExerciseTypes
    {
        // Типы упражнений
        //TODO: XML
        public const string Running = "Бег";
        public const string Swimming = "Плавание";
        public const string BenchPress = "Жим штанги";

        // Стили плавания
        public const string Freestyle = "Вольный стиль";
        public const string Butterfly = "Баттерфляй";

        // Списки для ComboBox
        public static readonly string[] AllExerciseTypes = 
        { 
           Running,
           Swimming,
           BenchPress 
        };
        public static readonly string[] AllSwimmingStyles = 
        { 
            Freestyle,
            Butterfly 
        };
    }
}
