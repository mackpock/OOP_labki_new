namespace Model;

/// <summary>
/// Упражнение — жим штанги лёжа
/// </summary>
public class BenchPress : ExerciseBase
{
    /// <summary>
    /// Минимальный допустимый вес штанги (кг)
    /// </summary>
    private const double MinWeight = 1;

    /// <summary>
    /// Максимальный допустимый вес штанги (кг)
    /// </summary>
    private const double MaxWeight = 341;

    /// <summary>
    /// Минимальное допустимое количество повторений
    /// </summary>
    private const int MinRepetitions = 1;


    /// <summary>
    /// Максимальное допустимое количество повторений
    /// </summary>
    private const int MaxRepetitions = 1000;

    /// <summary>
    /// Вес штанги (кг)
    /// </summary>
    private double _weight;

    /// <summary>
    /// Количество повторений
    /// </summary>
    private int _repetitions;

    /// <summary>
    /// Вес штанги (кг)
    /// </summary>
    public double Weight
    {
        get => _weight;
        set
        {
            //TODO: magic (to const) +
            ValidateRange(value, MinWeight, MaxWeight, nameof(Weight));
            _weight = value;
        }
    }

    /// <summary>
    /// Количество повторений
    /// </summary>
    public int Repetitions
    {
        get => _repetitions;
        set
        {
            //TODO: magic (to const) +
            ValidateRange(value, MinRepetitions,
                MaxRepetitions, nameof(Repetitions));
            _repetitions = value;
        }
    }

    /// <summary>
    /// Информация о упражнении
    /// </summary>
    public override string ExerciseInfo 
        => $"Жим штанги: {Name}, Вес: {Weight} кг, Повторения: {Repetitions}";

    /// <summary>
    /// Создание упражнения «Жим штанги»
    /// </summary>
    /// <param name="name">Название упражнения</param>
    /// <param name="weight">Вес штанги (кг)</param>
    /// <param name="repetitions">Количество повторений</param>
    public BenchPress(string name, double weight, int repetitions)
        : base(name)
    {
        Weight = weight;
        Repetitions = repetitions;
    }

    /// <summary>
    /// Расчёт калорий для жима штанги
    /// </summary>
    /// <returns>Количество сожжённых калорий</returns>
    public override double CalculateCalories() => Weight * Repetitions * 0.1;
}
