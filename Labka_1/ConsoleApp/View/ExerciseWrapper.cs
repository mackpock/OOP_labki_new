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
        /// <summary>
        /// Тип упражнения (Бег/Плавание/Жим)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Наименование упражнения
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дистанция (для бега и плавания)
        /// </summary>
        public double Distance { get; set; }

        /// <summary>
        /// Интенсивность (для бега, км/ч)
        /// </summary>
        public double Intensity { get; set; }

        /// <summary>
        /// Вес снаряда (для жима, кг)
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Число повторений (для жима)
        /// </summary>
        public int Repetitions { get; set; }

        /// <summary>
        /// Стиль плавания (для плавания)
        /// </summary>
        public SwimmingStyle Style { get; set; }

        /// <summary>
        /// Конструктор по умолчанию для сериализации
        /// </summary>
        private ExerciseWrapper() { }

        /// <summary>
        /// Создание обёртки из упражнения
        /// </summary>
        public ExerciseWrapper(IExercise exercise)
        {
            Name = exercise.Name;
            //TODO: switch-case
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
        //TODO: XML
        //TOOD: отступы
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
                //TOOD: отступы
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
