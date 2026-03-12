using System;

namespace Model;

/// <summary>
/// Базовый абстрактный класс для всех упражнений
/// </summary>
public abstract class ExerciseBase : IExercise
{
    /// <summary>
    /// Максимальная длина названия упражнения
    /// </summary>
    protected const int MaxNameLength = 50;

    /// <summary>
    /// Название упражнения
    /// </summary>
    private string _name;

    /// <summary>
    /// Название упражнения
    /// </summary>
    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Название упражнения" +
                    " не может быть пустым", nameof(Name));
            }
               

            if (value.Length > 50)
            {
                throw new ArgumentException($"Название упражнения слишком" +
                    $" длинное (макс. {MaxNameLength} символов)", nameof(Name));
            }

            _name = value;
        }
    }

    /// <summary>
    /// Подробная информация об упражнении
    /// </summary>
    public abstract string ExerciseInfo { get; }

    /// <summary>
    /// Инициализация нового экземпляра <see cref="ExerciseBase"/>
    /// </summary>
    /// <param name="name">Название упражнения</param>
    protected ExerciseBase(string name) => Name = name;

    /// <summary>
    /// Проверка положительности значения
    /// </summary>
    /// <param name="value">Проверяемое значение</param>
    /// <param name="parameterName">Имя параметра</param>
    protected void ValidatePositiveValue(double value, string parameterName)
    {
        if (value <= 0)
        {
            throw new ArgumentOutOfRangeException(parameterName,
                "Значение должно быть положительным");
        }
            
    }

    /// <summary>
    /// Проверка диапазона значений (double)
    /// </summary>
    protected void ValidateRange(double value, double min,
        double max, string parameterName)
    {
        if (value < min || value > max)
        {
            throw new ArgumentOutOfRangeException(parameterName,
                $"Значение должно быть в диапазоне от {min} до {max}");
        }
    }

    /// <summary>
    /// Проверка диапазона значений (int)
    /// </summary>
    protected void ValidateRange(int value, int min, int max,
        string parameterName)
    {
        if (value < min || value > max)
        {
            throw new ArgumentOutOfRangeException(parameterName,
                $"Значение должно быть в диапазоне от {min} до {max}");
        }
    }

    /// <summary>
    /// Расчёт затраченных калорий
    /// </summary>
    /// <returns>Количество сожжённых калорий</returns>
    public abstract double CalculateCalories();
}