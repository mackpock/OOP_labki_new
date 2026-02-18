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
    public abstract class PersonBase
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
        public virtual int MinAge => 0;

        /// <summary>
        /// Максимальный возраст
        /// </summary>
        public virtual int MaxAge => 124;

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
        public PersonBase(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }

        /// <summary>
        /// Конструктор с явным указанием пола 
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="gender">Пол</param>
        public PersonBase(string name, string surname, int age, Gender gender) :
            this(name, surname, age)
        {
            Gender = gender;
        }


        /// <summary>
        /// Конструктор по умолчанию - создаёт персону
        /// </summary>
        public PersonBase() : this("Default", "Person", 18) { }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Имя не может быть пустым!");
                }

                if (!IsRussian(value) && !IsEnglish(value))
                {
                    throw new Exception("Имя должно быть либо полностью" +
                        " на русском, либо полностью на английском!");
                }

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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Фамилия не может быть пустой!");
                }

                if (!IsRussian(value) && !IsEnglish(value))
                {
                    throw new Exception("Фамилия должна быть либо полностью" +
                        " на русском, либо полностью на английском!");
                }

                if ((IsRussian(_name) && !IsRussian(value))
                 || (IsEnglish(_name) && !IsEnglish(value)))
                {
                    throw new Exception("Имя и фамилия должны быть на одном языке!");
                }


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
                if (value < MinAge || value > MaxAge)
                {
                    throw new Exception($"{nameof(Age)} " +
                        $"не может быть меньше {MinAge} или больше {MaxAge}!");
                }

                _age = value;
            }
        }


        /// <summary>
        /// Абстрактный метод получения информации о персоне
        /// </summary>
        /// <returns>Строка с информацией о персоне</returns>
        public abstract string GetInfo();

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