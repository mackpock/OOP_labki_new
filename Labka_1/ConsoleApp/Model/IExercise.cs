namespace Model
{
    /// <summary>
    /// Интерфейс расчета калорий
    /// </summary>
    public interface IExercise
    {
        /// <summary>
        /// Название упражнения
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Калькулятор калорий для упражнения
        /// </summary>
        /// <returns></returns>
        double CalculateCalories();

        /// <summary>
        /// Информация об упражнении
        /// </summary>
        /// <returns>Строка с информацией</returns>
        string ExerciseInfo { get; }
    }
}
