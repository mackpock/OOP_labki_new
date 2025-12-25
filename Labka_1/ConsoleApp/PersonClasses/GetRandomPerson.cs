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
        //TODO: RSDN +
        /// <summary>
        /// Минимальный возраст
        /// </summary>
        private const int MinAge = 0;

        //TODO: RSDN +

        /// <summary>
        /// Максимальный возраст
        /// </summary>
        private const int MaxAge = 124;
        
        //TODO: RSDN +

        /// <summary>
        /// Мужские имена
        /// </summary>
        private static readonly string[] MaleNames =
        {
            "Артём",  "Кирилл", "Егор", "Тимофей", "Михаил",
            "Степан", "Глеб",   "Лев",  "Фёдор",   "Платон"
        };

        //TODO: RSDN +
        /// <summary>
        /// Женские имена
        /// </summary>
        private static readonly string[] FemaleNames =
        {
            "София", "Полина", "Алиса", "Ева", "Милана",
            "Арина", "Ульяна", "Дарья", "Вера"
        };

        //TODO: RSDN +
        /// <summary>
        /// Мужские фамилии
        /// </summary>
        private static readonly string[] MaleSurnames =
        {
            "Морозов", "Белов",  "Крылов",  "Ермаков", "Федоров",
            "Лебедев", "Громов", "Соколов", "Макаров", "Никитин"
        };

        /// <summary>
        /// Женские фамилии
        /// </summary>
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
            Gender gender = Random.Next(2) == 0 
                ? Gender.Male 
                : Gender.Female;

            string name = gender == Gender.Male
                ? MaleNames[Random.Next(MaleNames.Length)]
                : FemaleNames[Random.Next(FemaleNames.Length)];

            string surname = gender == Gender.Male
                ? MaleSurnames[Random.Next(MaleSurnames.Length)]
                : FemaleSurnames[Random.Next(FemaleSurnames.Length)];

            int age = Random.Next(MinAge, MaxAge); 

            return new Person(name, surname, age, gender);
        }
    }

}
