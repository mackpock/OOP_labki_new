namespace Model;

/// <summary>
/// Упражнение — плавание
/// </summary>
public class Swimming : ExerciseBase
{
    private SwimmingStyle _style;
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
            ValidatePositiveValue(value, nameof(Distance));
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
    public override double CalculateCalories()
    {
        double styleCoefficient = Style 
        switch
        {
            SwimmingStyle.Freestyle => 2.0,
            SwimmingStyle.Butterfly => 3.0,
            _ => 4.0
        };

        return Distance * styleCoefficient;
    }
}