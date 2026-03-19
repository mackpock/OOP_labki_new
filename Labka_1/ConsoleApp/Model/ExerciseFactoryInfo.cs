using System;
using Model;

namespace ConsoleLoader;

/// <summary>
/// Информация о фабрике создания упражнений
/// </summary>

public readonly struct ExerciseFactoryInfo
{
    /// <summary>
    /// Отображаемое имя упражнения в меню
    /// </summary>
    public string DisplayName { get; }

    /// <summary>
    /// Делегат создания упражнения
    /// </summary>
    public Func<IExercise> Creator { get; }

    /// <summary>
    /// Инициализация нового экземпляра <see cref="ExerciseFactoryInfo"/>
    /// </summary>
    /// <param name="displayName">
    /// Отображаемое имя упражнения для меню
    /// </param>
    /// <param name="creator">
    /// Делегат метода, создающего упражнение
    /// </param>
    public ExerciseFactoryInfo(string displayName, Func<IExercise> creator)
    {
        if (displayName == null)
        {
            throw new ArgumentNullException(nameof(displayName));
        }

        if (creator == null)
        {
            throw new ArgumentNullException(nameof(creator));
        }

        DisplayName = displayName;
        Creator = creator;
    }
}