using System;
using Model;
using NUnit.Framework;

namespace UnitTests.Model
{
    /// <summary>
    /// Набор тестов для класса ExerciseBase
    /// (тестируется через дочерний BenchPress, т.к. ExerciseBase абстрактный).
    /// </summary>
    [TestFixture]
    public class ExerciseBaseTest
    {
        //TODO: duplication
        /// <summary>
        /// Допустимое отклонение для сравнения double.
        /// </summary>
        private const double Tolerance = 0.01;

        /// <summary>
        /// Создание валидного экземпляра BenchPress для тестирования
        /// унаследованных свойств.
        /// </summary>
        private static BenchPress CreateValidExercise()
        {
            return new BenchPress("Жим", 50.0, 10);
        }

        /// <summary>
        /// Тестирование свойства Name при корректных значениях.
        /// </summary>
        [Test]
        [TestCase(
            "Жим штанги",
            TestName =
                "Тестирование Name " +
                "при присваивании корректного названия."
        )]
        [TestCase(
            "А",
            TestName =
                "Тестирование Name " +
                "при присваивании названия из 1 символа."
        )]
        [TestCase(
            "Bench Press",
            TestName =
                "Тестирование Name " +
                "при присваивании названия на английском."
        )]
        [TestCase(
            "Жим-штанги",
            TestName =
                "Тестирование Name " +
                "при присваивании названия с дефисом."
        )]
        [TestCase(
            "Подъём на бицепс со штангой",
            TestName =
                "Тестирование Name " +
                "при присваивании длинного названия."
        )]
        public void NameTest_ValidValues(string name)
        {
            var exercise = CreateValidExercise();
            exercise.Name = name;
            Assert.That(exercise.Name, Is.EqualTo(name));
        }

        /// <summary>
        /// Тестирование свойства Name при некорректных значениях.
        /// </summary>
        [Test]
        [TestCase(
            null,
            TestName =
                "Тестирование Name при присваивании null."
        )]
        [TestCase(
            "",
            TestName =
                "Тестирование Name " +
                "при присваивании пустой строки."
        )]
        [TestCase(
            "   ",
            TestName =
                "Тестирование Name " +
                "при присваивании строки из пробелов."
        )]
        [TestCase(
            "\t",
            TestName =
                "Тестирование Name " +
                "при присваивании табуляции."
        )]
        [TestCase(
            "\n",
            TestName =
                "Тестирование Name " +
                "при присваивании перевода строки."
        )]
        public void NameTest_InvalidValues_ThrowsException(
            string? name)
        {
            var exercise = CreateValidExercise();
            Assert.Throws<ArgumentException>(
                () => exercise.Name = name!);
        }

        /// <summary>
        /// Тестирование валидации maxLength для свойства Name
        /// (max = 50): граничные допустимые значения.
        /// </summary>
        [Test]
        [TestCase(
            50,
            TestName =
                "Тестирование Name " +
                "при длине ровно 50 символов."
        )]
        [TestCase(
            49,
            TestName =
                "Тестирование Name " +
                "при длине 49 символов (max-1)."
        )]
        [TestCase(
            1,
            TestName =
                "Тестирование Name " +
                "при длине 1 символ (min)."
        )]
        [TestCase(
            25,
            TestName =
                "Тестирование Name " +
                "при длине 25 символов (середина)."
        )]
        public void NameTest_MaxLength_ValidEdge(int length)
        {
            var exercise = CreateValidExercise();
            var name = new string('A', length);
            exercise.Name = name;
            Assert.That(exercise.Name, Is.EqualTo(name));
        }

        /// <summary>
        /// Тестирование валидации maxLength для свойства Name
        /// (max = 50): значения, превышающие максимум.
        /// </summary>
        [Test]
        [TestCase(
            51,
            TestName =
                "Тестирование Name " +
                "при длине 51 символ (max+1)."
        )]
        [TestCase(
            100,
            TestName =
                "Тестирование Name " +
                "при длине 100 символов."
        )]
        [TestCase(
            1000,
            TestName =
                "Тестирование Name " +
                "при очень длинном названии."
        )]
        public void
            NameTest_MaxLength_Exceeds_ThrowsException(int length)
        {
            var exercise = CreateValidExercise();
            var name = new string('A', length);
            Assert.Throws<ArgumentException>(
                () => exercise.Name = name);
        }

        /// <summary>
        /// Тестирование свойства Calories — должно возвращать
        /// результат CalculateCalories().
        /// </summary>
        [Test]
        [TestCase(
            10.0, 5, 5.0,
            TestName =
                "Тестирование Calories " +
                "при стандартных значениях BenchPress."
        )]
        [TestCase(
            100.0, 10, 100.0,
            TestName =
                "Тестирование Calories " +
                "при больших значениях BenchPress."
        )]
        [TestCase(
            1.0, 1, 0.1,
            TestName =
                "Тестирование Calories " +
                "при минимальных значениях BenchPress."
        )]
        [TestCase(
            341.0, 1000, 34100.0,
            TestName =
                "Тестирование Calories " +
                "при максимальных значениях BenchPress."
        )]
        [TestCase(
            50.5, 8, 40.4,
            TestName =
                "Тестирование Calories " +
                "при дробном весе BenchPress."
        )]
        public void CaloriesTest_BenchPress(
            double weight, int reps, double expected)
        {
            var exercise = new BenchPress("Жим", weight, reps);
            Assert.That(
                exercise.Calories,
                Is.EqualTo(expected).Within(Tolerance));
        }
    }
}
