using System;
using ConsoleLoader;
using Model;
using NUnit.Framework;

namespace UnitTests.Model
{
    /// <summary>
    /// Набор тестов для структуры ExerciseFactoryInfo.
    /// </summary>
    [TestFixture]
    public class ExerciseFactoryInfoTest
    {
        /// <summary>
        /// Тестирование конструктора при корректных значениях.
        /// </summary>
        [Test]
        public void ConstructorTest_ValidValues_SetsProperties()
        {
            Func<IExercise> creator =
                () => new BenchPress("Жим", 50.0, 10);
            var info = new ExerciseFactoryInfo(
                "Жим штанги", creator);

            Assert.Multiple(() =>
            {
                Assert.That(
                    info.DisplayName,
                    Is.EqualTo("Жим штанги"));
                Assert.That(
                    info.Creator,
                    Is.SameAs(creator));
            });
        }

        /// <summary>
        /// Тестирование конструктора с разными типами упражнений.
        /// </summary>
        [Test]
        [TestCase(
            "Жим штанги",
            TestName =
                "Тестирование конструктора ExerciseFactoryInfo " +
                "с DisplayName = 'Жим штанги'."
        )]
        [TestCase(
            "Бег",
            TestName =
                "Тестирование конструктора ExerciseFactoryInfo " +
                "с DisplayName = 'Бег'."
        )]
        [TestCase(
            "Плавание",
            TestName =
                "Тестирование конструктора ExerciseFactoryInfo " +
                "с DisplayName = 'Плавание'."
        )]
        [TestCase(
            "",
            TestName =
                "Тестирование конструктора ExerciseFactoryInfo " +
                "с пустым DisplayName."
        )]
        [TestCase(
            "A",
            TestName =
                "Тестирование конструктора ExerciseFactoryInfo " +
                "с DisplayName из 1 символа."
        )]
        public void ConstructorTest_VariousNames_SetsDisplayName(
            string displayName)
        {
            Func<IExercise> creator =
                () => new BenchPress("Жим", 50.0, 10);
            var info = new ExerciseFactoryInfo(displayName, creator);
            Assert.That(info.DisplayName, Is.EqualTo(displayName));
        }

        /// <summary>
        /// Тестирование конструктора — Creator действительно
        /// создает экземпляр упражнения.
        /// </summary>
        [Test]
        public void ConstructorTest_CreatorInvocation_ReturnsExercise()
        {
            Func<IExercise> creator =
                () => new BenchPress("Жим", 50.0, 10);
            var info = new ExerciseFactoryInfo("Жим", creator);

            var exercise = info.Creator();

            Assert.That(exercise, Is.InstanceOf<BenchPress>());
        }

        /// <summary>
        /// Тестирование конструктора при displayName = null.
        /// </summary>
        [Test]
        public void
            ConstructorTest_NullDisplayName_ThrowsException()
        {
            Func<IExercise> creator =
                () => new BenchPress("Жим", 50.0, 10);
            Assert.Throws<ArgumentNullException>(
                () => new ExerciseFactoryInfo(null!, creator));
        }

        /// <summary>
        /// Тестирование конструктора при creator = null.
        /// </summary>
        [Test]
        public void ConstructorTest_NullCreator_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(
                () => new ExerciseFactoryInfo("Жим", null!));
        }

        /// <summary>
        /// Тестирование конструктора при null для обоих параметров.
        /// </summary>
        [Test]
        public void ConstructorTest_BothNull_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(
                () => new ExerciseFactoryInfo(null!, null!));
        }
    }
}
