

namespace PersonClasses
{
    /// <summary>
    /// Класс взрослого человека
    /// </summary>
    public class Adult : PersonBase
    {
        /// <summary>
        /// Минимальный возраст
        /// </summary>
        public const int MinAgeValue = 18;

        /// <summary>
        /// Максимальный возраст
        /// </summary>
        public const int MaxAgeValue = 124;

        /// <summary>
        /// Минимальный возраст override
        /// </summary>
        public override int MinAge => MinAgeValue;

        /// <summary>
        /// Максимальный возраст override
        /// </summary>
        public override int MaxAge => MaxAgeValue;
        
        /// <summary>
        /// Номер паспорта
        /// </summary>
        public const int PassportNumberLength = 6;

        /// <summary>
        /// Серия паспорта
        /// </summary>
        public const int PassportSeriesLength = 4;

        /// <summary>
        /// Номер паспорта
        /// </summary>
        private string _passportNumber;

        /// <summary>
        /// Серия паспорта
        /// </summary>
        private string _passportSeries;

        /// <summary>
        /// Партнер
        /// </summary>
        private Adult _partner;

        /// <summary>
        /// Место работы
        /// </summary>
        private string _job;

        /// <summary>
        /// Значение по умолчанию для места работы
        /// </summary>
        private const string DefaultJob = "Безработный";

        /// <summary>
        /// Конструктор класса Adult
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="gender">Пол</param>
        /// <param name="passportNumber">Номер паспорта</param>
        /// <param name="passportSeries">Серия паспорта</param>
        /// <param name="partner">Партнер</param>
        /// <param name="job">Место работы</param>
        public Adult(string name, string surname, int age, Gender gender,
            string passportNumber, string passportSeries,
            Adult partner, string job)
            : base(name, surname, age, gender)
        {
            PassportNumber = passportNumber;
            PassportSeries = passportSeries;
            Partner = partner;
            Job = job;
        }

        /// <summary>
        /// Дефолт конструктор
        /// </summary>
        public Adult() : base()
        {
            _passportNumber = "000000";
            _passportSeries = "0000";
            _partner = null;
            _job = DefaultJob;
        }

        /// <summary>
        /// Валидация строки паспортных данных (только цифры, нужная длина)
        /// </summary>
        /// <param name="value">Проверяемое значение</param>
        /// <param name="length">Ожидаемая длина</param>
        /// <param name="fieldName">Название поля для сообщения об ошибке</param>
        /// <exception cref="ArgumentException">
        /// Если значение не проходит валидацию</exception>
        private static void ValidatePassportDigits(string value,
            int length, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"{fieldName}" +
                    $" не может быть пустым!", nameof(value));
            }

            if (value.Length != length)
            {
                throw new ArgumentException(
                    $"{fieldName} должен содержать {length} цифр!",
                    nameof(value));
            }

            foreach (char digit in value)
            {
                if (!char.IsDigit(digit))
                {
                    throw new ArgumentException(
                        $"{fieldName} должен содержать только цифры!",
                        nameof(value));
                }
            }
        }

        /// <summary>
        /// Номер паспорта
        /// </summary>
        public string PassportNumber
        {
            get => _passportNumber;
            set
            {
                ValidatePassportDigits(value, PassportNumberLength,
                    "Номер паспорта");
                _passportNumber = value;
            }
        }

        /// <summary>
        /// Серия паспорта
        /// </summary>
        public string PassportSeries
        {
            get => _passportSeries;
            set
            {
                ValidatePassportDigits(value, PassportSeriesLength,
                    "Серия паспорта");
                _passportSeries = value;
            }
        }

        /// <summary>
        /// Партнер
        /// </summary>
        public Adult Partner
        {
            get => _partner;
            set
            {
                if (value != null && value.Gender == this.Gender)
                {
                    throw new InvalidOperationException("Партнер" +
                        " должен быть противоположного пола!");
                }

                if (value != null)
                {
                    value._partner = this;
                }

                _partner = value;
            }
        }

        /// <summary>
        /// Место работы
        /// </summary>
        public string Job
        {
            get => _job;
            set => _job = string.IsNullOrWhiteSpace(value) 
                ? DefaultJob 
                : value;
        }

        /// <summary>
        /// Реализация абстрактного метода получения информации
        /// </summary>
        /// <returns>Строка с информацией о взрослом человеке</returns>
        public override string GetInfo()
        {
            string partnerInfo = Partner != null
                 ? (Gender == Gender.Male
                 ? $"женился на {Partner.Surname} {Partner.Name}"
                 : $"вышла замуж за {Partner.Surname} {Partner.Name}")
                 : (Gender == Gender.Male ? "не женат" : "не замужем");

            string jobInfo = Job == DefaultJob ? "безработный" : Job;

            return $"{Name} {Surname}, возраст: {Age}, " +
                 $"пол: {(Gender == Gender.Male 
                 ? "мужчина" 
                 : "женщина")}, " +
                 $"паспорт: {PassportSeries} {PassportNumber}, " +
                 $"СП: {partnerInfo}, " +
                 $"работа: {jobInfo}";
        }
    }
}
