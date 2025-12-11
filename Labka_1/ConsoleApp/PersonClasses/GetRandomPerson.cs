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

        private const int _minAge = 0;

        //TODO: RSDN +

        private const int _maxAge = 124;
        
        //TODO: RSDN +
        private static readonly string[] _maleNames =
        {
            "Артём",  "Кирилл", "Егор", "Тимофей", "Михаил",
            "Степан", "Глеб",   "Лев",  "Фёдор",   "Платон"
        };

        //TODO: RSDN +

        private static readonly string[] _femaleNames =
        {
            "София", "Полина", "Алиса", "Ева", "Милана",
            "Арина", "Ульяна", "Дарья", "Вера"
        };

        //TODO: RSDN +

        private static readonly string[] _maleSurnames =
        {
            "Морозов", "Белов",  "Крылов",  "Ермаков", "Федоров",
            "Лебедев", "Громов", "Соколов", "Макаров", "Никитин"
        };

        private static readonly string[] _femaleSurnames =
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
                ? _maleNames[Random.Next(_maleNames.Length)]
                : _femaleNames[Random.Next(_femaleNames.Length)];

            string surname = gender == Gender.Male
                ? _maleSurnames[Random.Next(_maleSurnames.Length)]
                : _femaleSurnames[Random.Next(_femaleSurnames.Length)];

            int age = Random.Next(_minAge, _maxAge); 

            return new Person(name, surname, age, gender);
        }
    }

}
