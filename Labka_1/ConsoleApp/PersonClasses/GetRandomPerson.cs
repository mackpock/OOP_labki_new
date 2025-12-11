using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonClasses
{
    /// <summary>
    /// класс для генерации случайных объектов 
    /// </summary>
    public static class GetRandomPersonClass
    {
        private const int MinAge = 0;
        private const int MaxAge = 124;
        //TODO: RSDN +
        private static readonly string[] MaleNames =
        {
            "Артём",  "Кирилл", "Егор", "Тимофей", "Михаил",
            "Степан", "Глеб",   "Лев",  "Фёдор",   "Платон"
        };

        private static readonly string[] FemaleNames =
        {
            "София", "Полина", "Алиса", "Ева", "Милана",
            "Арина", "Ульяна", "Дарья", "Вера"
        };

        private static readonly string[] MaleSurnames =
        {
            "Морозов", "Белов",  "Крылов",  "Ермаков", "Федоров",
            "Лебедев", "Громов", "Соколов", "Макаров", "Никитин"
        };

        private static readonly string[] FemaleSurnames =
        {
            "Морозова", "Белова",  "Крылова",  "Ермакова", "Федорова",
            "Лебедева", "Громова", "Соколова", "Макарова", "Никитина"
        };

        private static readonly Random Random = new Random();

        /// <summary>
        /// Генерирует случайного человека.
        /// </summary>
        public static Person GetRandomPerson()
        {
            //TODO: rsdn +
            Gender gender = Random.Next(2) == 0 ? Gender.Male : Gender.Female;

            string name = gender == Gender.Male
                ? MaleNames[Random.Next(MaleNames.Length)]
                : FemaleNames[Random.Next(FemaleNames.Length)];
            //TOOD: refactor +
            string surname = gender == Gender.Male
                ? MaleSurnames[Random.Next(MaleSurnames.Length)]
                : FemaleSurnames[Random.Next(FemaleSurnames.Length)];

            int age = Random.Next(MinAge, MaxAge); 

            return new Person(name, surname, age, gender);
        }
    }

}
