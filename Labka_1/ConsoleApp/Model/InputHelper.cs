using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLoader;

/// <summary>
/// Вспомогательный класс для ввода данных с консоли
/// </summary>
public static class InputHelper
{
    /// <summary>
    /// Максимальная длина названия упражнения
    /// </summary>
    public const int MaxNameLength = 50;

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
                Console.WriteLine("Ошибка: Название не может быть пустым");
                continue;
            }

            if (input.Length > MaxNameLength)
            {
                Console.WriteLine($"Ошибка: Название слишком длинное (макс. {MaxNameLength} символов)");
                continue;
            }

            return input;
        }
    }

    /// <summary>
    /// Ввод числа с плавающей точкой с валидацией
    /// </summary>
    public static double GetValidDoubleInput(string prompt, double min, double max)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (!double.TryParse(input, out double value))
            {
                Console.WriteLine("Ошибка: Неверный формат числа");
                continue;
            }

            if (value < min || value > max)
            {
                Console.WriteLine($"Ошибка: Значение должно быть от {min} до {max}");
                continue;
            }

            return value;
        }
    }

    /// <summary>
    /// Ввод целого числа с валидацией
    /// </summary>
    public static int GetValidIntInput(string prompt, int min, int max)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int value))
            {
                Console.WriteLine("Ошибка: Неверный формат числа");
                continue;
            }

            if (value < min || value > max)
            {
                Console.WriteLine($"Ошибка: Значение должно быть от {min} до {max}");
                continue;
            }

            return value;
        }
    }

    /// <summary>
    /// Ввод стиля плавания с валидацией
    /// </summary>
    public static SwimmingStyle GetValidSwimmingStyleInput()
    {
        while (true)
        {
            Console.Write("Выберите стиль (0-1): ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int styleValue))
            {
                Console.WriteLine("Ошибка: Неверный формат числа");
                continue;
            }

            if (!Enum.IsDefined(typeof(SwimmingStyle), styleValue))
            {
                Console.WriteLine("Ошибка: Неверное значение стиля. Введите число от 0 до 1.");
                continue;
            }

            return (SwimmingStyle)styleValue;
        }
    }
}