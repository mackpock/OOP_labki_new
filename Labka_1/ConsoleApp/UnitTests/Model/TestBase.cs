namespace UnitTests.Model
{
    /// <summary>
    /// Базовый класс для всех тестовых классов.
    /// </summary>
    public abstract class TestBase
    {
        /// <summary>
        /// Допустимое отклонение для сравнения значений double.
        /// </summary>
        protected const double Tolerance = 0.01;
    }
}
