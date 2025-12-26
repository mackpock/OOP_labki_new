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
        /// <summary>
        /// Минимальный возраст
        /// </summary>
        private const int MinAge = 0;

        /// <summary>
        /// Максимальный возраст
        /// </summary>
        private const int MaxAge = 124;
        
        //TODO: RSDN +
        /// <summary>
        /// Мужские имена
        /// </summary>
        private static readonly string[] _maleNames =
        {
            "Артём",  "Кирилл", "Егор", "Тимофей", "Михаил",
            "Степан", "Глеб",   "Лев",  "Фёдор",   "Платон"
        };

        //TODO: RSDN +
        /// <summary>
        /// Женские имена
        /// </summary>
        private static readonly string[] _femaleNames =
        {
            "София", "Полина", "Алиса", "Ева", "Милана",
            "Арина", "Ульяна", "Дарья", "Вера"
        };

        //TODO: RSDN +
        /// <summary>
        /// Мужские фамилии
        /// </summary>
        private static readonly string[] _maleSurnames =
        {
            "Морозов", "Белов",  "Крылов",  "Ермаков", "Федоров",
            "Лебедев", "Громов", "Соколов", "Макаров", "Никитин"
        };

        //TODO: RSDN +
        /// <summary>
        /// Женские фамилии
        /// </summary>
        private static readonly string[] _femaleSurnames =
        {
            "Морозова", "Белова",  "Крылова",  "Ермакова", "Федорова",
            "Лебедева", "Громова", "Соколова", "Макарова", "Никитина"
        };

        //TODO: RSDN +
        private static readonly Random _random = new Random();

        /// <summary>
        /// Генерирует случайного человека.
        /// </summary>
        public static Person GetRandomPerson()
        {
            Gender gender = _random.Next(2) == 0 
                ? Gender.Male 
                : Gender.Female;

            string name = gender == Gender.Male
                ? _maleNames[_random.Next(_maleNames.Length)]
                : _femaleNames[_random.Next(_femaleNames.Length)];

            string surname = gender == Gender.Male
                ? _maleSurnames[_random.Next(_maleSurnames.Length)]
                : _femaleSurnames[_random.Next(_femaleSurnames.Length)];

            int age = _random.Next(MinAge, MaxAge); 

            return new Person(name, surname, age, gender);
        }
    }

}
