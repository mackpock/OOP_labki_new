namespace Model
{
    /// <summary>
    /// Класс плавание 
    /// </summary>
    public class Swimming : ExerciseBase
    {
        /// <summary>
        /// Стиль плавания
        /// </summary>
        private SwimmingStyle _style;

        /// <summary>
        /// Дистанция плавания
        /// </summary>
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
        /// Пройденное расстояние
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
        /// Детальная информация об упражнении
        /// </summary>
        public override string ExerciseInfo => $"Плавание: {Name}," +
                          $" Стиль: {Style}, Дистанция: {Distance} м";

        /// <summary>
        /// Плавание 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="style"></param>
        /// <param name="distance"></param>
        public Swimming(string name, SwimmingStyle style,
                        double distance) : base(name)
        {
            Style = style;
            Distance = distance;
        }

        /// <summary>
        /// Расчет калорий для плавания         
        /// </summary>
        /// <returns>Рассчитанное значений калорий (плавание)</returns>
        public override double CalculateCalories()
        {
            double styleCoefficient;

            switch (Style)
            {
                case SwimmingStyle.Freestyle:
                    {
                        styleCoefficient = 5.0;
                        break;
                    }
                case SwimmingStyle.Butterfly:
                    {
                        styleCoefficient = 10.0;
                        break;
                    }
                default:
                    {
                        styleCoefficient = 7.0;
                        break;
                    }

            }
            return Distance * styleCoefficient;
        }
    }
}