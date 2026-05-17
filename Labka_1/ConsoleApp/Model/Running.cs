using System.Xml.Linq;

namespace Model
{
    /// <summary>
    /// Упражнение - бег
    /// </summary>
    public class Running : ExerciseBase
    {
        /// <summary>
        /// Минимальная допустимая интенсивность бега (км/ч)
        /// </summary>
        public const double MinIntensity = 1;

        /// <summary>
        /// Максимальная допустимая интенсивность бега (км/ч)
        /// </summary>
        public const double MaxIntensity = 30;

        /// <summary>
        /// Минимальная допустимая дистанция бега (км)
        /// </summary>
        public const double MinDistance = 0.1;

        /// <summary>
        /// Максимальная допустимая дистанция бега (км)
        /// </summary>
        public const double MaxDistance = 100;

        /// <summary>
        /// Дистанция бега
        /// </summary>
        private double _distance;

        /// <summary>
        /// Интенсивность бега
        /// </summary>
        private double _intensity;

        /// <summary>
        /// Дистанция бега (км)
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
        /// Интенсивность бега (км/ч)
        /// </summary>
        public double Intensity
        {
            get => _intensity;
            set
            {
                ValidateRange(value, MinIntensity,
                    MaxIntensity, nameof(Intensity));
                _intensity = value;
            }
        }

        /// <summary>
        /// Информация об упражнении
        /// </summary>
        public override string ExerciseInfo => $"Бег: {Name}, Интенсивность:" +
                                $" {Intensity} км/ч, Дистанция: {Distance} км";

        /// <summary>
        /// Создание упражнения «Бег»
        /// </summary>
        /// <param name="name">Название упражнения</param>
        /// <param name="intensity">Интенсивность (км/ч)</param>
        /// <param name="distance">Дистанция (км)</param>
        public Running(string name, double intensity, double distance) 
            :base(name)
        {
            Intensity = intensity;
            Distance = distance;
        }

        /// <summary>
        /// Расчёт калорий для бега
        /// </summary>
        /// <returns>Количество сожжённых калорий</returns>
        public override double CalculateCalories()
        {
            return Distance * Intensity * 20;
        }
    }
}