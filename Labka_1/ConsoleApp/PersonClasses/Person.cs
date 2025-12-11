using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
                _name = NameSurnameValidation(value, "Имя");
                OnlyOneLanguageNaming();
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
                _surname = NameSurnameValidation(value, "Фамилия");
                OnlyOneLanguageNaming();
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

        private static bool EnglishCheck (string text)
        {
            const string allowedChars = "abcdefghijklmnopqrstuvwxyz" +
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            foreach (char symbol in text)
            {
                if (symbol != ' ' && symbol != '-' && allowedChars.IndexOf(symbol) == -1)
                    return false;
            }
            return true;
        }
        private static bool RussianCheck(string text)
        {
            const string allowedChars = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя" +
                "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            foreach (char symbol in text)
            {
                if (symbol != ' ' && symbol != '-' && allowedChars.IndexOf(symbol) == -1)
                    return false;
            }
            return true;
        }


        private void OnlyOneLanguageNaming()
        {
            if (string.IsNullOrWhiteSpace(_name) || string.IsNullOrWhiteSpace(_surname))
                return;

            bool nameIsEng = EnglishCheck(_name);
            bool nameIsRus = RussianCheck(_name);
            bool surnameIsEng = EnglishCheck(_surname);
            bool surnameIsRus = RussianCheck(_surname);


            if (!nameIsEng && !nameIsRus)
                throw new Exception("Имя содержит недопустимые символы)");

            if (!surnameIsEng && !surnameIsRus)
                throw new Exception("Фамилия содержит недопустимые символы)");

            if ((nameIsEng && surnameIsEng) || (nameIsRus && surnameIsRus))
                return;


            throw new Exception("Имя и фамилия должны быть на одном языке (только русский или только английский).");
        }
        private static string NameSurnameValidation(string input, string fieldName)
        {
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