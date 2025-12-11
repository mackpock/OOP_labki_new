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
                throw new Exception($"{fieldName} не должен быть пустой");

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