namespace Model;

/// <summary>
/// Интерфейс для упражнений с расчётом калорий
/// </summary>
public interface IExercise
{
    /// <summary>
    /// Название упражнения
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Расчёт затраченных калорий
    /// </summary>
    /// <returns>Количество сожжённых калорий</returns>
    double CalculateCalories();

    /// <summary>
    /// Подробная информация об упражнении
    /// </summary>
    string ExerciseInfo { get; }
}
