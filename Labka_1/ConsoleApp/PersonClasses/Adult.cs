

namespace PersonClasses
{
    /// <summary>
    /// Класс взрослого человека
    /// </summary>
    public class Adult : PersonBase
    {
        /// <summary>
        /// Минимальный возраст для взрослого
        /// </summary>
        public override int MinAge => 18;

        /// <summary>
        /// Максимальный возраст для взрослого
        /// </summary>
        public override int MaxAge => 124;

        /// <summary>
        /// Номер паспорта
        /// </summary>
        private const int PassportNumberLength = 6;

        /// <summary>
        /// Серия паспорта
        /// </summary>
        private const int PassportSeriesLength = 4;

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
        /// Номер паспорта
        /// </summary>
        public string PassportNumber
        {
            get => _passportNumber;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    //TODO: RSDN +
                    throw new ArgumentException("Номер паспорта" +
                        " не может быть пустым!");
                }
                //TODO: magic (to const) +
                if (value.Length != PassportNumberLength)
                {
                    //TODO: RSDN +
                    throw new ArgumentException("Номер паспорта" +
                        " должен содержать 6 цифр!");
                }

                foreach (char digit in value)
                {
                    if (!char.IsDigit(digit))
                    {
                        //TODO: RSDN +
                        throw new ArgumentException("Номер паспорта " +
                            "должен содержать только цифры!");
                    }
                }

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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Серия паспорта" +
                        " не может быть пустой!");
                }
                //TODO: magic (to const) +
                if (value.Length != PassportSeriesLength)
                {
                    //TODO: RSDN +
                    throw new ArgumentException("Серия паспорта" +
                        " должна содержать 4 цифры!");
                }

                //TODO: rename +
                foreach (char digit in value)
                {
                    if (!char.IsDigit(digit))
                    {
                        //TODO: RSDN +
                        throw new Exception("Серия паспорта" +
                            " должна содержать только цифры!");
                    }
                }

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
                    //TODO: RSDN +
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
        {//TODO: duplication +
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
