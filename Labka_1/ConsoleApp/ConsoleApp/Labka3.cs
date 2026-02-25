using System;
using System.Collections.Generic;
using Model;

namespace ConsoleLoader
{
    /// <summary>
    /// Класс Program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Основной метод программы
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Расчет затраченных калорий в зависимости от вида упражнений");

            List<IExercise> exercises = new List<IExercise>();
            bool continueAdding = true;

            while (continueAdding)
            {
                Console.WriteLine("\nВыберете желаемое упражнение для " +
                    "рассчёта затраченных ккал:");
                Console.WriteLine("1. Бег");
                Console.WriteLine("2. Плавание");
                Console.WriteLine("3. Жим штанги");
                Console.WriteLine("4. Выход");

                int choice = GetValidIntInput("Выберите соответствующую" +
                    " цифру (1-4): ", 1, 4);

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

                if (continueAdding && exercises.Count > 0)
                {
                    Console.WriteLine($"\nУпражнений добавлено: " +
                                      $"{exercises.Count}");
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
        /// Бег
        /// </summary>
        /// <returns></returns>
        private static Running CreateRunningExercise()
        {
            try
            {
                string name = "";
                double intensity = 0;
                double distance = 0;

                Console.WriteLine("\nБег");

                name = GetValidStringInput("Название упражнения: ");
                intensity = GetValidDoubleInput("Интенсивность (км/ч): ", 1, 30);
                distance = GetValidDoubleInput("Дистанция (км): ", 0.1, 100);

                Running running = new Running(name, intensity, distance);
                double calories = running.CalculateCalories();

                Console.WriteLine("Упражнение успешно создано!");
                Console.WriteLine($"Сожжено калорий: {calories:F2}");

                return running;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nПроизошла ошибка!: {ex.Message}");
                Console.WriteLine("Создание упражнения отменено.");
                return null;
            }
        }

        /// <summary>
        /// Плавание
        /// </summary>
        /// <returns></returns>
        private static Swimming CreateSwimmingExercise()
        {
            try
            {
                string name = "";
                SwimmingStyle style = SwimmingStyle.Freestyle;
                double distance = 0;

                Console.WriteLine("\nПлавание");

                name = GetValidStringInput("Название упражнения: ");

                Console.WriteLine("Доступные стили плавания:");
                Console.WriteLine("0 - Свободное плавание");
                Console.WriteLine("1 - Стиль бабочки");

                style = GetValidSwimmingStyleInput();
                distance = GetValidDoubleInput("Дистанция (м): ", 1, 100000);

                Swimming swimming = new Swimming(name, style, distance);
                double calories = swimming.CalculateCalories();

                Console.WriteLine("Упражнение успешно создано!");
                Console.WriteLine($"Сожжено калорий: {calories:F2}");

                return swimming;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nПроизошла ошибка!: {ex.Message}");
                Console.WriteLine("Создание упражнения отменено.");
                return null;
            }
        }

        /// <summary>
        /// Жим штанги
        /// </summary>
        /// <returns></returns>
        private static BenchPress CreateBenchPressExercise()
        {
            try
            {
                string name = "";
                double weight = 0;
                int repetitions = 0;

                Console.WriteLine("\nЖим штанги");

                name = GetValidStringInput("Название упражнения: ");
                weight = GetValidDoubleInput("Вес (кг): ", 1, 341);
                repetitions = GetValidIntInput("Повторения: ", 1, 1000);

                BenchPress benchPress = new BenchPress(name, weight, repetitions);
                double calories = benchPress.CalculateCalories();

                Console.WriteLine("Упражнение  успешно создано!");
                Console.WriteLine($"Затрачено калорий: {calories:F2}");

                return benchPress;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nПроизошла ошибка!: {ex.Message}");
                Console.WriteLine("Создание упражнения отменено.");
                return null;
            }
        }

        /// <summary>
        /// Строковый ввод с валидацией
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        private static string GetValidStringInput(string prompt)
        {
            while (true)
            {
                try
                {
                    return ExerciseBase.GetValidStringInput(prompt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine("Пожалуйста, введите значение снова:");
                }
            }
        }

        /// <summary>
        /// Валидный числовой ввод с плавающей точкой
        /// </summary>
        /// <param name="проверяемое значение"></param>
        /// <param name="минимальное допустимое значение"></param>
        /// <param name="максимальное допустимое значение"></param>
        /// <returns>Валидное число с плавающей точкой</returns>
        private static double GetValidDoubleInput(string prompt, 
                                         double min, double max)
        {
            while (true)
            {
                try
                {
                    return ExerciseBase.GetValidDoubleInput(prompt, min, max);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine("Введите заново:");
                }
            }
        }

        /// <summary>
        /// Валидный целочисленный ввод
        /// </summary>
        /// <param name="проверяемое значение"></param>
        /// <param name="верхняя граница max"></param>
        /// <param name="нижняя граница min"></param>
        /// <returns></returns>
        private static int GetValidIntInput(string prompt, int min, int max)
        {
            while (true)
            {
                try
                {
                    return ExerciseBase.GetValidIntInput(prompt, min, max);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine("Введите целое число:");
                }
            }
        }

        /// <summary>
        /// Метод ввода стиля плавания
        /// </summary>
        /// <returns></returns>
        private static SwimmingStyle GetValidSwimmingStyleInput()
        {
            while (true)
            {
                try
                {
                    return ExerciseBase.GetValidSwimmingStyleInput();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine("Введите снова:");
                }
            }
        }

        /// <summary>
        /// Вывод данных каждого упражнения
        /// </summary>
        /// <param></param>
        private static void ShowResults(List<IExercise> exercises)
        {
            Console.WriteLine("\n\n\nРезультаты расчета калорий по упражнениям:\n");

            double totalCalories = 0;

            for (int i = 0; i < exercises.Count; i++)
            {
                double calories = exercises[i].CalculateCalories();
                totalCalories += calories;

                Console.WriteLine($"Упражнение #{i + 1}:");
                Console.WriteLine(exercises[i].ExerciseInfo);
                Console.WriteLine($"Затрачено калорий: {calories:F2}");
            }
            Console.WriteLine($"Калорий сожжено за тренировку:" +
                $" {totalCalories:F2}");
            Console.WriteLine($"Количество упражнений: {exercises.Count}");
        }

        /// <summary>
        /// Итоговый метод для вывода всех калорий
        /// </summary>
        /// <param name="exercises">Список упражнений</param>
        private static void ShowCalories(List<IExercise> exercises)
        {
            double totalCalories = 0;
            foreach (var exercise in exercises)
            {
                totalCalories += exercise.CalculateCalories();
            }

            Console.WriteLine("\n\n\nПоздравляю, Чемпион! " +
                "Чтобы подвести результат потраченных ккал, введите:\n");

            double maxCaloriesForVisualization = GetValidDoubleInput(
                "Целевое значение калорий: ",1, 15000);

            // сожжено/цель ккал
            double progressPercent = (totalCalories /
                maxCaloriesForVisualization) * 100;
            Console.WriteLine($"\nИтоговый результат ккал (сожжено/цель):");
            Console.WriteLine($"{totalCalories:F0}/{maxCaloriesForVisualization} " +
                $"ккал ({progressPercent:F2}%)");

            Console.WriteLine("\nДетализация по упражнениям:");
            Console.WriteLine("───────────────────────────");

            foreach (var exercise in exercises)
            {
                double calories = exercise.CalculateCalories();
                double percentage = (calories / totalCalories) * 100;

                Console.WriteLine($"{exercise.Name} {calories:F0} " +
                    $"ккал ({percentage:F1}%)");
            }

            Console.WriteLine("───────────────────────────");
            Console.WriteLine($"Итого: {totalCalories:F0} ккал за" +
                $" {exercises.Count} упражнений(я)");
        }
    }
}