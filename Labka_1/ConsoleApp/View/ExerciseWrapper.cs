using Model;
using System;

namespace View
{
    /// <summary>
    /// Обёртка для XML-сериализации объектов упражнений
    /// </summary>
    [Serializable]
    public class ExerciseWrapper
    {
        // Тип (Бег/Плавание/Жим)
        public string Type { get; set; }

        // Наименование
        public string Name { get; set; }

        // Дистанция (для бега и плавания)
        public double Distance { get; set; }

        // Интенсивность (для бега)
        public double Intensity { get; set; }

        // Вес снаряда (для жима)
        public double Weight { get; set; }

        // Число повторений (для жима)
        public int Repetitions { get; set; }

        // Стиль (для плавания)
        public SwimmingStyle Style { get; set; }

        // Конструктор по умолчанию для сериализации
        private ExerciseWrapper() { }

        /// <summary>
        /// Создание обёртки из упражнения
        /// </summary>
        public ExerciseWrapper(IExercise exercise)
        {
            Name = exercise.Name;

            if (exercise is Running run)
            {
                Type = ExerciseTypes.Running;
                Distance = run.Distance;
                Intensity = run.Intensity;
            }
            else if (exercise is Swimming swim)
            {
                Type = ExerciseTypes.Swimming;
                Distance = swim.Distance;
                Style = swim.Style;
            }
            else if (exercise is BenchPress press)
            {
                Type = ExerciseTypes.BenchPress;
                Weight = press.Weight;
                Repetitions = press.Repetitions;
            }
        }

        // Методы для сериализации полей
        public bool ShouldSerializeDistance() => 
        Type == ExerciseTypes.Running ||
        Type == ExerciseTypes.Swimming;
        public bool ShouldSerializeIntensity() =>
        Type == ExerciseTypes.Running;
        public bool ShouldSerializeWeight() => 
        Type == ExerciseTypes.BenchPress;
        public bool ShouldSerializeRepetitions() =>
        Type == ExerciseTypes.BenchPress;
        public bool ShouldSerializeStyle() => 
        Type == ExerciseTypes.Swimming;

        /// <summary>
        /// Восстановление упражнения из обёртки
        /// </summary>
        public IExercise RecoverExercise()
        {
            return Type 
            switch
            {
                ExerciseTypes.Running => 
                new Running(Name, Intensity, Distance),
                ExerciseTypes.Swimming => 
                new Swimming(Name, Style, Distance),
                ExerciseTypes.BenchPress => 
                new BenchPress(Name, Weight, Repetitions),
                _ => throw new 
                InvalidOperationException("Неизвестный тип упражнения")
            };
        }
    }
}
