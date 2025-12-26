using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        /// <summary>
        /// Имя
        /// </summary>
        private string _name;

        /// <summary>
        /// Фамилия
        /// </summary>
        private string _surname;

        /// <summary>
        /// Возраст
        /// </summary>
        private int _age;
        
        /// <summary>
        /// Минимальный возраст
        /// </summary>
        private const int _minAge = 0;

        /// <summary>
        /// Максимальный возраст
        /// </summary>
        private const int _maxAge = 124;

        /// <summary>
        /// Русские символы
        /// </summary>
        private const string _russianPattern =
            @"^[а-яА-ЯёЁ]+([ -][а-яА-ЯёЁ]+)*$";

        /// <summary>
        /// Латинские символы.
        /// </summary>
        private const string _englishPattern =
            @"^[a-zA-Z]+([ -][a-zA-Z]+)*$";

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        public Person(string  name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }

        /// <summary>
        /// Конструктор с явным указанием пола (чтобы работала первая часть задания)
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="gender">Пол</param>
        public Person(string name, string surname, int age, Gender gender) :
            this(name, surname, age) 
        { 
            Gender = gender; 
        }
        

        /// <summary>
        /// Конструктор по умолчанию - создаёт персону
        /// </summary>
        public Person(): this("Default", "Person", 18) { }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name
        {
            get => _name;
            set 
            {
                //TODO: {}
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Имя не может быть пустым!");

                //TODO: {}
                if (!IsRussian(value) && !IsEnglish(value))
                    throw new Exception("Имя должно быть либо полностью" +
                        " на русском, либо полностью на английском!");

                _name = FormatName(value);
            }
        }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname
        {
            get => _surname;
            set
            {
                //TODO: {}
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Фамилия не может быть пустой!");

                //TODO: {}
                if (!IsRussian(value) && !IsEnglish(value))
                    throw new Exception("Фамилия должна быть либо полностью" +
                        " на русском, либо полностью на английском!");

               
                //TODO: {}
                if ((IsRussian(_name) && !IsRussian(value)) 
                 || (IsEnglish(_name) && !IsEnglish(value)))
                    throw new Exception("Имя и фамилия должны быть на одном языке!");

                _surname = FormatName(value);
            }
        }

        /// <summary>
        /// Возраст
        /// </summary>
        public int Age
        {
            get => _age;
            set
            {
                //TODO: {}
                if (value < _minAge || value > _maxAge)
                    throw new Exception($"{nameof(Age)} " +
                        $"не может быть меньше {_minAge} или больше {_maxAge}!");
                _age = value;
            }
        }

        /// <summary>
        /// Пол
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Соответствие русскому языку. Вспомогательный метод
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static bool IsRussian(string s) => Regex.IsMatch(s, _russianPattern);

        /// <summary>
        /// Соответствие Латинскому языку. Вспомогательный метод
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static bool IsEnglish(string s) => Regex.IsMatch(s, _englishPattern);

        /// <summary>
        /// "оЛеГ" -> "Олег" 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static string FormatName(string name)
        {
             return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower());
        }
    }
}