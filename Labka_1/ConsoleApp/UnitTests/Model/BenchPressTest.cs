using System;
using Model;
using NUnit.Framework;

namespace UnitTests.Model
{
    /// <summary>
    /// Набор тестов для класса BenchPress.
    /// </summary>
    [TestFixture]
    public class BenchPressTest
    {
        /// <summary>
        /// Допустимое отклонение для сравнения double.
        /// </summary>
        private const double Tolerance = 0.01;

        /// <summary>
        /// Создание валидного экземпляра BenchPress для тестирования
        /// отдельных свойств.
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
        [TestCase(
            "Жим", 50.0, 10,
            TestName =
                "Тестирование ExerciseInfo " +
                "при стандартных значениях."
        )]
        [TestCase(
            "Bench", 100.0, 5,
            TestName =
                "Тестирование ExerciseInfo " +
                "при английском названии."
        )]
        [TestCase(
            "Минимум", 1.0, 1,
            TestName =
                "Тестирование ExerciseInfo " +
                "при минимальных значениях."
        )]
        public void ExerciseInfoTest(
            string name, double weight, int reps)
        {
            var exercise = new BenchPress(name, weight, reps);
            var info = exercise.ExerciseInfo;
            Assert.Multiple(() =>
            {
                Assert.That(info, Does.StartWith("Жим штанги:"));
                Assert.That(info, Does.Contain(name));
                Assert.That(info, Does.Contain("Вес"));
                Assert.That(info, Does.Contain("кг"));
                Assert.That(info, Does.Contain("Повторения"));
                Assert.That(info, Does.Contain(reps.ToString()));
            });
        }

        /// <summary>
        /// Тестирование конструктора при корректных значениях.
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

        /// <summary>
        /// Тестирование конструктора при невалидном Name.
        /// </summary>
        [Test]
        [TestCase(
            null,
            TestName =
                "Тестирование конструктора BenchPress " +
                "при name = null."
        )]
        [TestCase(
            "",
            TestName =
                "Тестирование конструктора BenchPress " +
                "при пустом name."
        )]
        public void
            ConstructorTest_InvalidName_ThrowsException(
                string? name)
        {
            Assert.Throws<ArgumentException>(
                () => new BenchPress(name!, 50.0, 10));
        }

        /// <summary>
        /// Тестирование конструктора при невалидном Weight.
        /// </summary>
        [Test]
        [TestCase(
            0,
            TestName =
                "Тестирование конструктора BenchPress " +
                "при weight = 0."
        )]
        [TestCase(
            -1,
            TestName =
                "Тестирование конструктора BenchPress " +
                "при weight = -1."
        )]
        [TestCase(
            342,
            TestName =
                "Тестирование конструктора BenchPress " +
                "при weight = 342 (max+1)."
        )]
        public void
            ConstructorTest_InvalidWeight_ThrowsException(
                double weight)
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new BenchPress("Жим", weight, 10));
        }

        /// <summary>
        /// Тестирование конструктора при невалидных Repetitions.
        /// </summary>
        [Test]
        [TestCase(
            0,
            TestName =
                "Тестирование конструктора BenchPress " +
                "при repetitions = 0."
        )]
        [TestCase(
            -1,
            TestName =
                "Тестирование конструктора BenchPress " +
                "при repetitions = -1."
        )]
        [TestCase(
            1001,
            TestName =
                "Тестирование конструктора BenchPress " +
                "при repetitions = 1001 (max+1)."
        )]
        public void
            ConstructorTest_InvalidReps_ThrowsException(int reps)
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new BenchPress("Жим", 50.0, reps));
        }
    }
}
