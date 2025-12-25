using System;
using System.Collections.Generic;
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
        private const string _russianPattern = @"^[а-яА-ЯёЁ]+([ -][а-яА-ЯёЁ]+)*$";

        /// <summary>
        /// Латинские символы.
        /// </summary>
        private const string _englishPattern = @"^[a-zA-Z]+([ -][a-zA-Z]+)*$";

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
            get { return _name; }
            set 
            {
                if (!IsSingleLanguage(value))
                    throw new Exception("Имя должно быть либо полностью на русском," +
                        " либо полностью на английском!");
                _name = NameSurnameValidation(value, "Имя");
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
                if (!IsSingleLanguage(value))
                    throw new Exception("Фамилия должна быть либо полностью " +
                        "на русском, либо полностью на английском!");
                if (!AreNameAndSurnameSameLanguage(_name, value))
                    throw new Exception("Имя и фамилия должны быть на одном языке!");

                _surname = NameSurnameValidation(value, "Фамилия");
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
                if (value < _minAge || value > _maxAge)
                {
                    throw new Exception($"{nameof(Age)} не может быть меньше {_minAge}" +
                        $" или больше {_maxAge}!");
                }
                _age = value;
            }
        }

        /// <summary>
        /// Пол
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Проверка, что строка на одном языке.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static bool IsSingleLanguage(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return false;
            return Regex.IsMatch(input, _russianPattern) 
                || Regex.IsMatch(input, _englishPattern);
        }

        /// <summary>
        /// Проверка, что имя и фамилия на одном языке.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <returns></returns>
        private static bool AreNameAndSurnameSameLanguage(string name, string surname)
        {
            bool nameIsRu = Regex.IsMatch(name, _russianPattern);
            bool nameIsEn = Regex.IsMatch(name, _englishPattern);
            bool surnameIsRu = Regex.IsMatch(surname, _russianPattern);
            bool surnameIsEn = Regex.IsMatch(surname, _englishPattern);

            return (nameIsRu && surnameIsRu) || (nameIsEn && surnameIsEn);
        }

        /// <summary>
        /// Метод для разрешенных символов, двойных имён и первой заглавной буквы
        /// </summary>
        /// <param name="input">Ввод</param>
        /// <param name="fieldName">Поле (И или Ф)</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private static string NameSurnameValidation
            (string input, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new Exception($"поле {fieldName} пустое!");

            const string allowedChars =
                "abcdefghijklmnopqrstuvwxyz" +
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                "абвгдеёжзийклмнопрстуфхцчшщъыьэюя" +
                "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ" +
                " -";
            foreach (char symbol in input)
            {
                if (allowedChars.IndexOf(symbol) == -1)
                {
                    throw new Exception($"{fieldName} может быть только" +
                        $" русскими/англ символами, а также с дефисом!");
                }
            }

            //Первая буква - всегда заглавная
            char[] chars = input.ToLower().ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (i == 0 || chars[i - 1] == ' ' || chars[i - 1] == '-')
                {
                    chars[i] = char.ToUpper(chars[i]);
                }
            }

            return new string(chars);
        }
    }
}