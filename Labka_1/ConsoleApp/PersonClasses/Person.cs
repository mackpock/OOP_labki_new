using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace PersonClasses
{
    /// <summary>
    /// Класс показывает ФИ, возраст, пол
    /// </summary>
    public class Person
    {
        private string _name;
        private string _surname;
        private int _age;
        private const int minAge = 0;
        private const int maxAge = 124;
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="age"></param>
        public Person(string  name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
            
        }

        /// <summary>
        /// Конструктор с явным указанием пола (чтобы работала первая часть задания)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="age"></param>
        /// <param name="gender"></param>
        public Person(string name, string surname, int age, Gender gender) :
            this(name, surname, age) { Gender = gender; }
        

        /// <summary>
        /// Конструктор по умолчанию - создаёт персону
        /// </summary>
        public Person(): this("Default", "Person", 18) { }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name
        {
            get { return _name; }
            set 
            {
                if (string.IsNullOrEmpty(value)) 
                {
                    throw new Exception($"{nameof(Name)} не может быть пустым " +
                        $"или незаполненным!");
                }
                _name = value; 
            }
        }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname
        {
            get { return _surname; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception($"{nameof(Surname)} не может быть пустым " +
                        $"или незаполненным!");
                }
                _surname = value;
            }
        }

        /// <summary>
        /// Возраст
        /// </summary>
        public int Age
        {
            get { return _age; }
            set
            {
                if (value < minAge || value > maxAge)
                {
                    throw new Exception($"{nameof(Age)} не может быть меньше {minAge}" +
                        $" или больше {maxAge}!");
                }
                _age = value;
            }
        }

        /// <summary>
        /// Пол
        /// </summary>
        public Gender Gender { get; set; }


        /// <summary>
        /// Формирование текстового описания указанного персонажа
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public string SayAbout(Person person)
        {
            string gender = string.Empty;
            switch (person.Gender) 
            {
                case Gender.Male: 
                {
                        gender = "Мужчина";
                        break;
                }
                case Gender.Female:
                {
                        gender = "Женщина";
                        break;
                }
                default:
                {
                        gender = "Введите корректный пол";
                        break;
                }
            }
            return $"Получился персонаж: \nИмя: {person.Name} \nФамилия:" +
                $" {person.Surname} \nВозраст: {person.Age} \nПол: {gender}";
        }

        /// <summary>
        /// Метод набора случайных персонажей
        /// </summary>
        /// <returns></returns>
        public static Person GetRandomPerson()
        {
            var random = new Random();
            string[] maleNames = { "Артём", "Кирилл", "Егор", "Тимофей", 
                "Михаил", "Степан", "Глеб", "Лев", "Фёдор", "Платон" };
            string[] femaleNames = { "София", "Полина", "Алиса", "Василиса", 
                "Ева", "Милана", "Арина", "Ульяна", "Дарья", "Вера" };
            string[] maleSurname = { "Морозов", "Белов", "Крылов", "Ермаков",
                "Федоров", "Лебедев", "Громов", "Соколов", "Макаров", "Никитин" };
            string[] femaleSurname = { "Морозова", "Белова", "Крылова", "Ермакова",
                "Федорова", "Лебедева", "Громова", "Соколова", "Макарова", "Никитина" };

            Gender gender;
            switch (random.Next(2))
            {
                case 0: gender = Gender.Male; break;
                case 1: gender = Gender.Female; break;
                default: gender = Gender.Male; break;
            }
            
            string name;
            string surname;
            if (gender == Gender.Male)
            {
                name = maleNames[random.Next(maleNames.Length)];
                surname = maleSurname[random.Next(maleSurname.Length)];
            }
            else
            {
                name = femaleNames[random.Next(femaleNames.Length)];
                surname = femaleSurname[random.Next(femaleSurname.Length)];
            }
            int age = random.Next(minAge, maxAge);
            return new Person(name, surname, age, gender);
        }
    }
}

