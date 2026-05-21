using System;
using Model;
using NUnit.Framework;

namespace UnitTests.Model
{
    /// <summary>
    /// Набор тестов для класса BenchPress.
    /// Тесты валидации Name находятся в ExerciseBaseTest
    /// (Name унаследовано из базового класса).
    /// </summary>
    [TestFixture]
    public class BenchPressTest : TestBase
    {
        /// <summary>
        /// Создание валидного экземпляра BenchPress.
        /// </summary>
        private static BenchPress CreateValid()
        {
            return new BenchPress("Жим", 50.0, 10);
        }

        /// <summary>
        /// Тестирование свойства Weight при корректных значениях.
        /// </summary>
        [Test]
        [TestCase(
            1.0,
            TestName =
                "Тестирование Weight " +
                "при присваивании минимального значения (1)."
        )]
        [TestCase(
            2.0,
            TestName =
                "Тестирование Weight " +
                "при присваивании min+1 (2)."
        )]
        [TestCase(
            341.0,
            TestName =
                "Тестирование Weight " +
                "при присваивании максимального значения (341)."
        )]
        [TestCase(
            340.0,
            TestName =
                "Тестирование Weight " +
                "при присваивании max-1 (340)."
        )]
        [TestCase(
            100.5,
            TestName =
                "Тестирование Weight " +
                "при присваивании дробного значения."
        )]
        public void WeightTest_ValidValues(double weight)
        {
            var exercise = CreateValid();
            exercise.Weight = weight;
            Assert.That(exercise.Weight, Is.EqualTo(weight));
        }

        /// <summary>
        /// Тестирование свойства Weight при некорректных значениях.
        /// </summary>
        [Test]
        [TestCase(
            0,
            TestName =
                "Тестирование Weight при присваивании 0."
        )]
        [TestCase(
            -1,
            TestName =
                "Тестирование Weight при присваивании -1."
        )]
        [TestCase(
            342,
            TestName =
                "Тестирование Weight при присваивании 342 (max+1)."
        )]
        [TestCase(
            1000,
            TestName =
                "Тестирование Weight " +
                "при присваивании значения, превышающего max."
        )]
        [TestCase(
            double.MinValue,
            TestName =
                "Тестирование Weight " +
                "при присваивании double.MinValue."
        )]
        public void
            WeightTest_InvalidValues_ThrowsException(double weight)
        {
            var exercise = CreateValid();
            Assert.Throws<ArgumentOutOfRangeException>(
                () => exercise.Weight = weight);
        }

        /// <summary>
        /// Тестирование свойства Repetitions при корректных значениях.
        /// </summary>
        [Test]
        [TestCase(
            1,
            TestName =
                "Тестирование Repetitions " +
                "при присваивании минимального значения (1)."
        )]
        [TestCase(
            2,
            TestName =
                "Тестирование Repetitions " +
                "при присваивании min+1 (2)."
        )]
        [TestCase(
            1000,
            TestName =
                "Тестирование Repetitions " +
                "при присваивании максимального значения (1000)."
        )]
        [TestCase(
            999,
            TestName =
                "Тестирование Repetitions " +
                "при присваивании max-1 (999)."
        )]
        [TestCase(
            500,
            TestName =
                "Тестирование Repetitions " +
                "при присваивании среднего значения."
        )]
        public void RepetitionsTest_ValidValues(int reps)
        {
            var exercise = CreateValid();
            exercise.Repetitions = reps;
            Assert.That(exercise.Repetitions, Is.EqualTo(reps));
        }

        /// <summary>
        /// Тестирование свойства Repetitions при некорректных значениях.
        /// </summary>
        [Test]
        [TestCase(
            0,
            TestName =
                "Тестирование Repetitions при присваивании 0."
        )]
        [TestCase(
            -1,
            TestName =
                "Тестирование Repetitions при присваивании -1."
        )]
        [TestCase(
            1001,
            TestName =
                "Тестирование Repetitions " +
                "при присваивании 1001 (max+1)."
        )]
        [TestCase(
            10000,
            TestName =
                "Тестирование Repetitions " +
                "при присваивании очень большого значения."
        )]
        [TestCase(
            int.MinValue,
            TestName =
                "Тестирование Repetitions " +
                "при присваивании int.MinValue."
        )]
        public void
            RepetitionsTest_InvalidValues_ThrowsException(int reps)
        {
            var exercise = CreateValid();
            Assert.Throws<ArgumentOutOfRangeException>(
                () => exercise.Repetitions = reps);
        }

        /// <summary>
        /// Тестирование расчёта калорий CalculateCalories().
        /// Формула: Weight * Repetitions * 0.1.
        /// </summary>
        [Test]
        [TestCase(
            50.0, 10, 50.0,
            TestName =
                "Тестирование CalculateCalories " +
                "при стандартных значениях (50кг x 10)."
        )]
        [TestCase(
            1.0, 1, 0.1,
            TestName =
                "Тестирование CalculateCalories " +
                "при минимальных значениях."
        )]
        [TestCase(
            341.0, 1000, 34100.0,
            TestName =
                "Тестирование CalculateCalories " +
                "при максимальных значениях."
        )]
        [TestCase(
            100.0, 5, 50.0,
            TestName =
                "Тестирование CalculateCalories " +
                "при 100кг x 5 повторений."
        )]
        [TestCase(
            75.5, 12, 90.6,
            TestName =
                "Тестирование CalculateCalories " +
                "при дробном весе."
        )]
        public void CalculateCaloriesTest(
            double weight, int reps, double expected)
        {
            var exercise = new BenchPress("Жим", weight, reps);
            Assert.That(
                exercise.CalculateCalories(),
                Is.EqualTo(expected).Within(Tolerance));
        }

        /// <summary>
        /// Тестирование свойства ExerciseInfo — содержание ключевых
        /// частей строки.
        /// </summary>
        [Test]
        public void ExerciseInfoTest_ContainsExpectedParts()
        {
            var exercise = new BenchPress("Жим", 50.0, 10);
            var info = exercise.ExerciseInfo;
            Assert.Multiple(() =>
            {
                Assert.That(info, Does.StartWith("Жим штанги:"));
                Assert.That(info, Does.Contain("Жим"));
                Assert.That(info, Does.Contain("Вес"));
                Assert.That(info, Does.Contain("кг"));
                Assert.That(info, Does.Contain("Повторения"));
                Assert.That(info, Does.Contain("10"));
            });
        }

        /// <summary>
        /// Тестирование конструктора — корректные значения сохраняются.
        /// </summary>
        [Test]
        public void ConstructorTest_ValidValues_SetsProperties()
        {
            var exercise = new BenchPress("Жим", 80.0, 12);

            Assert.Multiple(() =>
            {
                Assert.That(exercise.Name, Is.EqualTo("Жим"));
                Assert.That(exercise.Weight, Is.EqualTo(80.0));
                Assert.That(exercise.Repetitions, Is.EqualTo(12));
            });
        }
    }
}
