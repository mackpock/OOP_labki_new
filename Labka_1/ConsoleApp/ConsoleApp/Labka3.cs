using System;
using System.Collections.Generic;
using Model;

namespace ConsoleLoader;

/// <summary>
/// Основной класс программы
/// </summary>
public class Program
{
    /// <summary>
    /// Точка входа в приложение
    /// </summary>
    public static void Main(string[] args)
    {
        Console.WriteLine("Exorcise - Расчёт затраченных калорий" +
            " в зависимости от вида упражнений");

        var exercises = new List<IExercise>();
        bool continueAdding = true;

        while (continueAdding)
        {
            Console.WriteLine("\nВыберите упражнение для расчёта калорий:");
            Console.WriteLine("1. Бег");
            Console.WriteLine("2. Плавание");
            Console.WriteLine("3. Жим штанги");
            Console.WriteLine("4. Выход");

            int choice = InputHelper.GetValidIntInput("Введите цифру" +
                " (1-4): ", 1, 4);

            //TODO: {} +
            switch (choice)
            {
                case 1:
                {
                    var running = CreateRunningExercise();
                    if (running != null)
                    {
                        exercises.Add(running);
                    }
                    break;
                }

                case 2:
                {
                    var swimming = CreateSwimmingExercise();
                    if (swimming != null)
                    {
                        exercises.Add(swimming);
                    }
                    break;
                }

                case 3:
                {
                    var benchPress = CreateBenchPressExercise();
                    if (benchPress != null)
                    {
                        exercises.Add(benchPress);
                    }
                    break;
                }

                case 4:
                {
                    continueAdding = false;
                    break;
                }
            }

            //TODO: {} +
            if (continueAdding && exercises.Count > 0)
            {
                Console.WriteLine($"\nДобавлено упражнений:" +
                    $" {exercises.Count}");
            }
               
        }

        if (exercises.Count > 0)
        {
            ShowResults(exercises);
            ShowCalories(exercises);
        }
        else
        {
            Console.WriteLine("\nНе добавлено ни одного упражнения.");
        }

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }

    /// <summary>
    /// Создание упражнения «Бег»
    /// </summary>
    private static Running CreateRunningExercise()
    {
        
        Console.WriteLine("\n--- Бег ---");
        
        string name = InputHelper.GetValidStringInput("Название " +
            "упражнения: ");
        double intensity = InputHelper.GetValidDoubleInput("Интенсивность " +
            "(км/ч): ", 1, 30);
        double distance = InputHelper.GetValidDoubleInput("Дистанция " +
            "(км): ", 0.1, 100);
        
        var running = new Running(name, intensity, distance);
        double calories = running.CalculateCalories();
        
        Console.WriteLine("Упражнение успешно создано!");
        Console.WriteLine($"Сожжено калорий: {calories:F2}");
        
        return running;

    }

    /// <summary>
    /// Создание упражнения «Плавание»
    /// </summary>
    private static Swimming CreateSwimmingExercise()
    {
       
         Console.WriteLine("\n--- Плавание ---");
         
         string name = InputHelper.GetValidStringInput("Название" +
             " упражнения: ");
         
         Console.WriteLine("\nДоступные стили плавания:");
         Console.WriteLine("0 — Вольный стиль (кроль)");
         Console.WriteLine("1 — Баттерфляй");
         
         SwimmingStyle style = InputHelper.GetValidSwimmingStyleInput();
         double distance = InputHelper.GetValidDoubleInput("Дистанция" +
             " (м): ", 1, 100000);
         
         var swimming = new Swimming(name, style, distance);
         double calories = swimming.CalculateCalories();
         
         Console.WriteLine("Упражнение успешно создано!");
         Console.WriteLine($"Сожжено калорий: {calories:F2}");

        return swimming;
    }

    /// <summary>
    /// Создание упражнения «Жим штанги»
    /// </summary>
    private static BenchPress CreateBenchPressExercise()
    {
        
        
         Console.WriteLine("\nxXx Жим штанги xXx");

         string name = InputHelper.GetValidStringInput("Название" +
             " упражнения: ");
         double weight = InputHelper.GetValidDoubleInput("Вес (кг):" +
             " ", 1, 341);
         int repetitions = InputHelper.GetValidIntInput("Повторения:" +
             " ", 1, 1000);

         var benchPress = new BenchPress(name, weight, repetitions);
         double calories = benchPress.CalculateCalories();

         Console.WriteLine("Упражнение успешно создано!");
         Console.WriteLine($"Затрачено калорий: {calories:F2}");

         return benchPress;
        

    }


    /// <summary>
    /// Вывод результатов по каждому упражнению
    /// </summary>
    private static void ShowResults(List<IExercise> exercises)
    {
        Console.WriteLine("\n\n=== Результаты расчёта калорий ===\n");

        double totalCalories = 0;

        for (int i = 0; i < exercises.Count; i++)
        {
            double calories = exercises[i].CalculateCalories();
            totalCalories += calories;

            Console.WriteLine($"Упражнение #{i + 1}:");
            Console.WriteLine(exercises[i].ExerciseInfo);
            Console.WriteLine($"Затрачено калорий: {calories:F2}\n");
        }

        Console.WriteLine($"Всего сожжено за тренировку: {totalCalories:F2}");
        Console.WriteLine($"Количество упражнений: {exercises.Count}");
    }

    /// <summary>
    /// Итоговый вывод калорий с визуализацией прогресса
    /// </summary>
    private static void ShowCalories(List<IExercise> exercises)
    {
        double totalCalories = 0;
        foreach (var exercise in exercises)
        {
            totalCalories += exercise.CalculateCalories();
        }

        Console.WriteLine("\n=== Итоговый результат ===");
        Console.WriteLine("Введите целевое значение калорий" +
            " для визуализации:");

        double maxCaloriesForVisualization = InputHelper.GetValidDoubleInput
            ("Цель (ккал): ", 1, 15000);

        double progressPercent = (totalCalories / 
            maxCaloriesForVisualization) * 100;

        Console.WriteLine($"\nРезультат (сожжено/цель):");
        Console.WriteLine($"{totalCalories:F0} / " +
            $"{maxCaloriesForVisualization} ккал " +
            $"({progressPercent:F2}%)");

        Console.WriteLine("\nДетализация по упражнениям:");
        Console.WriteLine("───────────────────────────");

        foreach (var exercise in exercises)
        {
            double calories = exercise.CalculateCalories();
            double percentage = (calories / totalCalories) * 100;

            Console.WriteLine($"{exercise.Name}: {calories:F0} " +
                $"ккал ({percentage:F1}%)");
        }

        Console.WriteLine("───────────────────────────");
        Console.WriteLine($"Итого: {totalCalories:F0} " +
            $"ккал за {exercises.Count} упр.");
    }
}