using System;
using Model;
using NUnit.Framework;

namespace UnitTests.Model
{
    /// <summary>
    /// Набор тестов для абстрактного класса ExerciseBase.
    /// Тестируется через минимальную тестовую реализацию-stub,
    /// чтобы тесты не зависели от конкретных наследников.
    /// </summary>
    [TestFixture]
    public class ExerciseBaseTest : TestBase
    {
        /// <summary>
        /// Минимальная тестовая реализация ExerciseBase для проверки
        /// поведения базового класса в изоляции от наследников.
        /// </summary>
        private sealed class TestExercise : ExerciseBase
        {
            public double FakeCalories { get; set; }

            public TestExercise(string name) : base(name) { }

            public override string ExerciseInfo => $"Test: {Name}";

            public override double CalculateCalories() => FakeCalories;
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
            var exercise = new TestExercise("Тест");
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
            var exercise = new TestExercise("Тест");
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
            var exercise = new TestExercise("Тест");
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
            var exercise = new TestExercise("Тест");
            var name = new string('A', length);
            Assert.Throws<ArgumentException>(
                () => exercise.Name = name);
        }

        /// <summary>
        /// Тестирование свойства Calories — должно возвращать
        /// результат CalculateCalories(), независимо от реализации.
        /// </summary>
        [Test]
        [TestCase(
            0.0,
            TestName =
                "Тестирование Calories при нулевом значении."
        )]
        [TestCase(
            1.0,
            TestName =
                "Тестирование Calories при значении 1."
        )]
        [TestCase(
            100.5,
            TestName =
                "Тестирование Calories при дробном значении."
        )]
        [TestCase(
            999999.0,
            TestName =
                "Тестирование Calories при очень большом значении."
        )]
        [TestCase(
            -5.0,
            TestName =
                "Тестирование Calories при отрицательном значении " +
                "(свойство не валидирует, только пересылает)."
        )]
        public void CaloriesTest_ReturnsCalculateCaloriesResult(
            double expected)
        {
            var exercise = new TestExercise("Тест")
            {
                FakeCalories = expected
            };
            Assert.That(
                exercise.Calories,
                Is.EqualTo(expected).Within(Tolerance));
        }
    }
}
