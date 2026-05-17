using System;
using Model;
using NUnit.Framework;

namespace UnitTests.Model
{
    /// <summary>
    /// Набор тестов для класса Running.
    /// </summary>
    [TestFixture]
    public class RunningTest
    {
        /// <summary>
        /// Допустимое отклонение для сравнения double.
        /// </summary>
        private const double Tolerance = 0.01;

        /// <summary>
        /// Создание валидного экземпляра Running.
        /// </summary>
        private static Running CreateValid()
        {
            return new Running("Бег", 10.0, 5.0);
        }

        /// <summary>
        /// Тестирование свойства Intensity при корректных значениях.
        /// </summary>
        [Test]
        [TestCase(
            1.0,
            TestName =
                "Тестирование Intensity " +
                "при присваивании минимального значения (1)."
        )]
        [TestCase(
            2.0,
            TestName =
                "Тестирование Intensity " +
                "при присваивании min+1 (2)."
        )]
        [TestCase(
            30.0,
            TestName =
                "Тестирование Intensity " +
                "при присваивании максимального значения (30)."
        )]
        [TestCase(
            29.0,
            TestName =
                "Тестирование Intensity " +
                "при присваивании max-1 (29)."
        )]
        [TestCase(
            15.5,
            TestName =
                "Тестирование Intensity " +
                "при присваивании дробного среднего значения."
        )]
        public void IntensityTest_ValidValues(double intensity)
        {
            var running = CreateValid();
            running.Intensity = intensity;
            Assert.That(running.Intensity, Is.EqualTo(intensity));
        }

        /// <summary>
        /// Тестирование свойства Intensity при некорректных значениях.
        /// </summary>
        [Test]
        [TestCase(
            0,
            TestName =
                "Тестирование Intensity при присваивании 0."
        )]
        [TestCase(
            -1,
            TestName =
                "Тестирование Intensity при присваивании -1."
        )]
        [TestCase(
            0.99,
            TestName =
                "Тестирование Intensity при присваивании 0.99 (min-)."
        )]
        [TestCase(
            31,
            TestName =
                "Тестирование Intensity при присваивании 31 (max+1)."
        )]
        [TestCase(
            100,
            TestName =
                "Тестирование Intensity " +
                "при присваивании 100 (значительно больше max)."
        )]
        public void
            IntensityTest_InvalidValues_ThrowsException(
                double intensity)
        {
            var running = CreateValid();
            Assert.Throws<ArgumentOutOfRangeException>(
                () => running.Intensity = intensity);
        }

        /// <summary>
        /// Тестирование свойства Distance при корректных значениях.
        /// Согласно константам MinDistance = 0.1, MaxDistance = 100.
        /// </summary>
        [Test]
        [TestCase(
            0.1,
            TestName =
                "Тестирование Distance " +
                "при присваивании минимального значения (0.1)."
        )]
        [TestCase(
            100.0,
            TestName =
                "Тестирование Distance " +
                "при присваивании максимального значения (100)."
        )]
        [TestCase(
            99.0,
            TestName =
                "Тестирование Distance " +
                "при присваивании max-1 (99)."
        )]
        [TestCase(
            1.0,
            TestName =
                "Тестирование Distance " +
                "при присваивании 1 км."
        )]
        [TestCase(
            50.5,
            TestName =
                "Тестирование Distance " +
                "при присваивании дробного среднего значения."
        )]
        public void DistanceTest_ValidValues(double distance)
        {
            var running = CreateValid();
            running.Distance = distance;
            Assert.That(running.Distance, Is.EqualTo(distance));
        }

        /// <summary>
        /// Тестирование свойства Distance при некорректных значениях.
        /// </summary>
        [Test]
        [TestCase(
            0,
            TestName =
                "Тестирование Distance при присваивании 0."
        )]
        [TestCase(
            -1,
            TestName =
                "Тестирование Distance при присваивании -1."
        )]
        [TestCase(
            0.09,
            TestName =
                "Тестирование Distance " +
                "при присваивании 0.09 (меньше min)."
        )]
        [TestCase(
            101,
            TestName =
                "Тестирование Distance при присваивании 101 (max+1)."
        )]
        [TestCase(
            1000,
            TestName =
                "Тестирование Distance " +
                "при присваивании очень большого значения."
        )]
        public void
            DistanceTest_InvalidValues_ThrowsException(
                double distance)
        {
            var running = CreateValid();
            Assert.Throws<ArgumentOutOfRangeException>(
                () => running.Distance = distance);
        }

        /// <summary>
        /// Тестирование расчёта калорий CalculateCalories().
        /// Формула: Distance * Intensity * 20.
        /// </summary>
        [Test]
        [TestCase(
            10.0, 5.0, 1000.0,
            TestName =
                "Тестирование CalculateCalories " +
                "при intensity = 10, distance = 5."
        )]
        [TestCase(
            1.0, 0.1, 2.0,
            TestName =
                "Тестирование CalculateCalories " +
                "при минимальных значениях."
        )]
        [TestCase(
            30.0, 100.0, 60000.0,
            TestName =
                "Тестирование CalculateCalories " +
                "при максимальных значениях."
        )]
        [TestCase(
            15.0, 10.0, 3000.0,
            TestName =
                "Тестирование CalculateCalories " +
                "при средних значениях."
        )]
        [TestCase(
            12.5, 7.5, 1875.0,
            TestName =
                "Тестирование CalculateCalories " +
                "при дробных значениях."
        )]
        public void CalculateCaloriesTest(
            double intensity, double distance, double expected)
        {
            var running = new Running("Бег", intensity, distance);
            Assert.That(
                running.CalculateCalories(),
                Is.EqualTo(expected).Within(Tolerance));
        }

        /// <summary>
        /// Тестирование свойства ExerciseInfo — содержание ключевых
        /// частей строки (независимо от форматирования чисел и
        /// культурной настройки).
        /// </summary>
        [Test]
        [TestCase(
            "Бег", 10.0, 5.0,
            TestName =
                "Тестирование ExerciseInfo " +
                "при стандартных значениях."
        )]
        [TestCase(
            "Marathon", 12.0, 42.0,
            TestName =
                "Тестирование ExerciseInfo " +
                "при английском названии."
        )]
        [TestCase(
            "Спринт", 30.0, 1.0,
            TestName =
                "Тестирование ExerciseInfo " +
                "при максимальной интенсивности."
        )]
        public void ExerciseInfoTest(
            string name, double intensity, double distance)
        {
            var running = new Running(name, intensity, distance);
            var info = running.ExerciseInfo;
            Assert.Multiple(() =>
            {
                Assert.That(info, Does.StartWith("Бег:"));
                Assert.That(info, Does.Contain(name));
                Assert.That(info, Does.Contain("Интенсивность"));
                Assert.That(info, Does.Contain("км/ч"));
                Assert.That(info, Does.Contain("Дистанция"));
                Assert.That(info, Does.Contain("км"));
            });
        }

        /// <summary>
        /// Тестирование конструктора при корректных значениях.
        /// </summary>
        [Test]
        public void ConstructorTest_ValidValues_SetsProperties()
        {
            var running = new Running("Бег", 12.0, 8.0);

            Assert.Multiple(() =>
            {
                Assert.That(running.Name, Is.EqualTo("Бег"));
                Assert.That(running.Intensity, Is.EqualTo(12.0));
                Assert.That(running.Distance, Is.EqualTo(8.0));
            });
        }

        /// <summary>
        /// Тестирование конструктора при невалидном Name.
        /// </summary>
        [Test]
        [TestCase(
            null,
            TestName =
                "Тестирование конструктора Running при name = null."
        )]
        [TestCase(
            "",
            TestName =
                "Тестирование конструктора Running при пустом name."
        )]
        public void
            ConstructorTest_InvalidName_ThrowsException(string? name)
        {
            Assert.Throws<ArgumentException>(
                () => new Running(name!, 10.0, 5.0));
        }

        /// <summary>
        /// Тестирование конструктора при невалидном Intensity.
        /// </summary>
        [Test]
        [TestCase(
            0,
            TestName =
                "Тестирование конструктора Running при intensity = 0."
        )]
        [TestCase(
            31,
            TestName =
                "Тестирование конструктора Running " +
                "при intensity = 31 (max+1)."
        )]
        public void
            ConstructorTest_InvalidIntensity_ThrowsException(
                double intensity)
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new Running("Бег", intensity, 5.0));
        }

        /// <summary>
        /// Тестирование конструктора при невалидной Distance.
        /// </summary>
        [Test]
        [TestCase(
            0,
            TestName =
                "Тестирование конструктора Running при distance = 0."
        )]
        [TestCase(
            -1,
            TestName =
                "Тестирование конструктора Running при distance = -1."
        )]
        [TestCase(
            101,
            TestName =
                "Тестирование конструктора Running " +
                "при distance = 101 (max+1)."
        )]
        public void
            ConstructorTest_InvalidDistance_ThrowsException(
                double distance)
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new Running("Бег", 10.0, distance));
        }
    }
}
