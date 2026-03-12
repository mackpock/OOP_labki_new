using System;

namespace Model;

/// <summary>
/// Базовый абстрактный класс для всех упражнений
/// </summary>
public abstract class ExerciseBase : IExercise
{
    //TODO: XML
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
                throw new ArgumentException("Название упражнения" +
                    " слишком длинное", nameof(Name));
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

    //TODO: refactor
    /// <summary>
    /// Ввод строки с валидацией
    /// </summary>
    /// <param name="prompt">Приглашение к вводу</param>
    /// <returns>Валидная строка</returns>
    public static string GetValidStringInput(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Название не может быть пустым");
            }
                
            //TODO: magic (to const)
            if (input.Length > 78)
            {
                throw new ArgumentException("Название слишком длинное" +
                    " (макс. 78 символов)");
            }

            return input;
        }
    }
    //TODO: refactor
    /// <summary>
    /// Ввод числа с плавающей точкой с валидацией
    /// </summary>
    /// <param name="prompt">Приглашение к вводу</param>
    /// <param name="min">Минимальное значение</param>
    /// <param name="max">Максимальное значение</param>
    /// <returns>Валидное число</returns>
    public static double GetValidDoubleInput(string prompt, double min, double max)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (!double.TryParse(input, out double value))
            {
                throw new FormatException("Неверный формат числа");
            }

            if (value < min || value > max)
            {
                throw new ArgumentOutOfRangeException($"Значение" +
                    $" должно быть от {min} до {max}");
            }

            return value;
        }
    }

    //TODO: refactor
    /// <summary>
    /// Ввод целого числа с валидацией
    /// </summary>
    /// <param name="prompt">Приглашение к вводу</param>
    /// <param name="min">Минимальное значение</param>
    /// <param name="max">Максимальное значение</param>
    /// <returns>Валидное целое число</returns>
    public static int GetValidIntInput(string prompt, int min, int max)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int value))
            {
                throw new FormatException("Неверный формат числа");
            }
                

            if (value < min || value > max)
            {
                throw new ArgumentOutOfRangeException($"Значение" +
                   $" должно быть от {min} до {max}");
            }
     
            return value;
        }
    }

    //TODO: refactor
    /// <summary>
    /// Ввод стиля плавания с валидацией
    /// </summary>
    /// <returns>Валидный стиль плавания</returns>
    public static SwimmingStyle GetValidSwimmingStyleInput()
    {
        while (true)
        {
            Console.Write("Выберите стиль (0-1): ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int styleValue))
            {
                throw new FormatException("Неверный формат числа");
            }

            if (!Enum.IsDefined(typeof(SwimmingStyle), styleValue))
            {
                throw new ArgumentOutOfRangeException("Неверное " +
                    "значение стиля. Введите число от 0 до 1.");
            }

            return (SwimmingStyle)styleValue;
        }
    }

    /// <summary>
    /// Расчёт затраченных калорий
    /// </summary>
    /// <returns>Количество сожжённых калорий</returns>
    public abstract double CalculateCalories();
}