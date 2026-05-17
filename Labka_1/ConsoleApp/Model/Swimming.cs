namespace Model;

/// <summary>
/// Упражнение — плавание
/// </summary>
public class Swimming : ExerciseBase
{
    /// <summary>
    /// Минимальная допустимая дистанция (м)
    /// </summary>
    public const double MinDistance = 1;

    /// <summary>
    /// Максимальная допустимая дистанция (м)
    /// </summary>
    public const double MaxDistance = 10000;

    /// <summary>
    /// Стиль плавания
    /// </summary>
    private SwimmingStyle _style;

    /// <summary>
    /// Дистанция плавания (м)
    /// </summary>
    private double _distance;

    /// <summary>
    /// Стиль плавания
    /// </summary>
    public SwimmingStyle Style
    {
        get => _style;
        set => _style = value;
    }

    /// <summary>
    /// Дистанция плавания (м)
    /// </summary>
    public double Distance
    {
        get => _distance;
        set
        {
            ValidateRange(value, MinDistance,
                MaxDistance, nameof(Distance));
            _distance = value;
        }
    }

    /// <summary>
    /// Информация о упражнении
    /// </summary>
    public override string ExerciseInfo 
        => $"Плавание: {Name}, Стиль: {Style}, Дистанция: {Distance} м";

    /// <summary>
    /// Создание упражнения «Плавание»
    /// </summary>
    /// <param name="name">Название упражнения</param>
    /// <param name="style">Стиль плавания</param>
    /// <param name="distance">Дистанция (м)</param>
    public Swimming(string name, SwimmingStyle style, double distance)
        : base(name)
    {
        Style = style;
        Distance = distance;
    }

    /// <summary>
    /// Расчёт калорий для плавания
    /// </summary>
    /// <returns>Количество сожжённых калорий</returns>
    public override double CalculateCalories() =>
       Distance * (Style == SwimmingStyle.Freestyle 
        ? 2.0 
        : 3.0);
}