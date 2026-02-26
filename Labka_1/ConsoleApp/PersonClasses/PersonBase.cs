using System.Globalization;
using System.Text.RegularExpressions;


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
        protected PersonBase(string name, string surname, int age,
            Gender gender) : this(name, surname, age)
        {
            Gender = gender;
        }

        /// <summary>
        /// Конструктор по умолчанию - создаёт персону
        /// </summary>
        protected PersonBase() : this("Default", "Person", 18) { }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                //TODO: duplication
                if (_surname != null && !string.IsNullOrWhiteSpace(value))
                {
                    if ((IsRussian(value) && !IsRussian(_surname)) ||
                        (IsEnglish(value) && !IsEnglish(_surname)))
                    {
                        throw new ArgumentException("Имя и фамилия " +
                            "должны быть на одном языке!");
                    }
                }
                _name = ValidateAndFormatName(value, nameof(Name));
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
                //TODO: duplication
                //TOOD: отступы
            if (_name != null && !string.IsNullOrWhiteSpace(value))
            {
               if ((IsRussian(_name) && !IsRussian(value)) ||
                   (IsEnglish(_name) && !IsEnglish(value)))
               {
                   throw new ArgumentException
                            ("Имя и фамилия должны быть на одном языке!");
               }
            }
              _surname = ValidateAndFormatName(value, nameof(Surname));
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
               throw new ArgumentOutOfRangeException($"{nameof(Age)} " +
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
        private static bool IsRussian(string s) 
            => Regex.IsMatch(s, _russianPattern);

        /// <summary>
        /// Соответствие Латинскому языку. Вспомогательный метод
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static bool IsEnglish(string s) 
            => Regex.IsMatch(s, _englishPattern);

        /// <summary>
        /// Валидация и форматирование имени/фамилии
        /// </summary>
        /// <param name="value">Проверяемое значение</param>
        /// <param name="paramName">Имя параметра для сообщения об ошибке</param>
        /// <returns>Отформатированная строка</returns>
        /// <exception cref="ArgumentException">Если значение не проходит валидацию</exception>
        private static string ValidateAndFormatName(string value, string paramName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                //TODO: RSDN
                throw new ArgumentException($"{paramName} не может быть пустым!", paramName);
            }

            if (!IsRussian(value) && !IsEnglish(value))
            {
                throw new ArgumentException(
                    //TODO: RSDN
                    $"{paramName} должен быть либо полностью на русском, либо полностью на английском!",
                    paramName);
            }

            return FormatName(value);
        }

        /// <summary>
        /// "оЛеГ" -> "Олег" 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static string FormatName(string name)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase
                (name.ToLower());
        }
    }
}