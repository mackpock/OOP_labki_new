using System;
using Model;
using NUnit.Framework;

namespace UnitTests.Model
{
    /// <summary>
    /// Набор тестов для класса Swimming.
    /// Тесты валидации Name находятся в ExerciseBaseTest
    /// (Name унаследовано из базового класса).
    /// </summary>
    [TestFixture]
    public class SwimmingTest : TestBase
    {
        /// <summary>
        /// Создание валидного экземпляра Swimming.
        /// </summary>
        private static Swimming CreateValid()
        {
            return new Swimming(
                "Плавание", SwimmingStyle.Freestyle, 100.0);
        }

        /// <summary>
        /// Тестирование свойства Style при корректных значениях.
        /// </summary>
        [Test]
        [TestCase(
            SwimmingStyle.Freestyle,
            TestName =
                "Тестирование Style " +
                "при присваивании Freestyle."
        )]
        [TestCase(
            SwimmingStyle.Butterfly,
            TestName =
                "Тестирование Style " +
                "при присваивании Butterfly."
        )]
        public void StyleTest_ValidValues(SwimmingStyle style)
        {
            var swimming = CreateValid();
            swimming.Style = style;
            Assert.That(swimming.Style, Is.EqualTo(style));
        }

        /// <summary>
        /// Тестирование свойства Distance при корректных значениях.
        /// Согласно константам MinDistance = 1, MaxDistance = 10000.
        /// </summary>
        [Test]
        [TestCase(
            1.0,
            TestName =
                "Тестирование Distance " +
                "при присваивании минимального значения (1)."
        )]
        [TestCase(
            2.0,
            TestName =
                "Тестирование Distance " +
                "при присваивании min+1 (2)."
        )]
        [TestCase(
            10000.0,
            TestName =
                "Тестирование Distance " +
                "при присваивании максимального значения (10000)."
        )]
        [TestCase(
            9999.0,
            TestName =
                "Тестирование Distance " +
                "при присваивании max-1 (9999)."
        )]
        [TestCase(
            500.5,
            TestName =
                "Тестирование Distance " +
                "при присваивании дробного среднего значения."
        )]
        public void DistanceTest_ValidValues(double distance)
        {
            var swimming = CreateValid();
            swimming.Distance = distance;
            Assert.That(swimming.Distance, Is.EqualTo(distance));
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
            0.99,
            TestName =
                "Тестирование Distance " +
                "при присваивании 0.99 (меньше min)."
        )]
        [TestCase(
            10001,
            TestName =
                "Тестирование Distance " +
                "при присваивании 10001 (max+1)."
        )]
        [TestCase(
            100000,
            TestName =
                "Тестирование Distance " +
                "при присваивании очень большого значения."
        )]
        public void
            DistanceTest_InvalidValues_ThrowsException(
                double distance)
        {
            var swimming = CreateValid();
            Assert.Throws<ArgumentOutOfRangeException>(
                () => swimming.Distance = distance);
        }

        /// <summary>
        /// Тестирование расчёта калорий для стиля Freestyle.
        /// Формула: Distance * 2.0.
        /// </summary>
        [Test]
        [TestCase(
            100.0, 200.0,
            TestName =
                "Тестирование CalculateCalories (Freestyle) " +
                "при distance = 100."
        )]
        [TestCase(
            1.0, 2.0,
            TestName =
                "Тестирование CalculateCalories (Freestyle) " +
                "при минимальной дистанции."
        )]
        [TestCase(
            10000.0, 20000.0,
            TestName =
                "Тестирование CalculateCalories (Freestyle) " +
                "при максимальной дистанции."
        )]
        [TestCase(
            500.0, 1000.0,
            TestName =
                "Тестирование CalculateCalories (Freestyle) " +
                "при distance = 500."
        )]
        [TestCase(
            123.5, 247.0,
            TestName =
                "Тестирование CalculateCalories (Freestyle) " +
                "при дробной дистанции."
        )]
        public void CalculateCaloriesTest_Freestyle(
            double distance, double expected)
        {
            var swimming = new Swimming(
                "Плавание", SwimmingStyle.Freestyle, distance);
            Assert.That(
                swimming.CalculateCalories(),
                Is.EqualTo(expected).Within(Tolerance));
        }

        /// <summary>
        /// Тестирование расчёта калорий для стиля Butterfly.
        /// Формула: Distance * 3.0.
        /// </summary>
        [Test]
        [TestCase(
            100.0, 300.0,
            TestName =
                "Тестирование CalculateCalories (Butterfly) " +
                "при distance = 100."
        )]
        [TestCase(
            1.0, 3.0,
            TestName =
                "Тестирование CalculateCalories (Butterfly) " +
                "при минимальной дистанции."
        )]
        [TestCase(
            10000.0, 30000.0,
            TestName =
                "Тестирование CalculateCalories (Butterfly) " +
                "при максимальной дистанции."
        )]
        [TestCase(
            500.0, 1500.0,
            TestName =
                "Тестирование CalculateCalories (Butterfly) " +
                "при distance = 500."
        )]
        [TestCase(
            123.5, 370.5,
            TestName =
                "Тестирование CalculateCalories (Butterfly) " +
                "при дробной дистанции."
        )]
        public void CalculateCaloriesTest_Butterfly(
            double distance, double expected)
        {
            var swimming = new Swimming(
                "Плавание", SwimmingStyle.Butterfly, distance);
            Assert.That(
                swimming.CalculateCalories(),
                Is.EqualTo(expected).Within(Tolerance));
        }

        /// <summary>
        /// Тестирование свойства ExerciseInfo — содержание ключевых
        /// частей строки.
        /// </summary>
        [Test]
        public void ExerciseInfoTest_ContainsExpectedParts()
        {
            var swimming = new Swimming(
                "Плавание", SwimmingStyle.Freestyle, 100.0);
            var info = swimming.ExerciseInfo;
            Assert.Multiple(() =>
            {
                Assert.That(info, Does.StartWith("Плавание:"));
                Assert.That(info, Does.Contain("Плавание"));
                Assert.That(info, Does.Contain("Стиль"));
                Assert.That(info, Does.Contain("Freestyle"));
                Assert.That(info, Does.Contain("Дистанция"));
                Assert.That(info, Does.Contain("м"));
            });
        }

        /// <summary>
        /// Тестирование конструктора — корректные значения сохраняются.
        /// </summary>
        [Test]
        public void ConstructorTest_ValidValues_SetsProperties()
        {
            var swimming = new Swimming(
                "Плавание", SwimmingStyle.Butterfly, 250.0);

            Assert.Multiple(() =>
            {
                Assert.That(
                    swimming.Name,
                    Is.EqualTo("Плавание"));
                Assert.That(
                    swimming.Style,
                    Is.EqualTo(SwimmingStyle.Butterfly));
                Assert.That(swimming.Distance, Is.EqualTo(250.0));
            });
        }
    }
}
