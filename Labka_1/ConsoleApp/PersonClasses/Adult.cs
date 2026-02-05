using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonClasses
{
    /// <summary>
    /// Класс взрослого человека
    /// </summary>
    public class Adult : Person
    {
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
            _job = "Безработный";
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
                    throw new Exception("Номер паспорта не может быть пустым!");
                }

                if (value.Length != 6)
                {
                    throw new Exception("Номер паспорта должен содержать 6 цифр!");
                }

                foreach (char c in value)
                {
                    if (!char.IsDigit(c))
                    {
                        throw new Exception("Номер паспорта должен содержать только цифры!");
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
                    throw new Exception("Серия паспорта не может быть пустой!");
                }

                if (value.Length != 4)
                {
                    throw new Exception("Серия паспорта должна содержать 4 цифры!");
                }

                foreach (char c in value)
                {
                    if (!char.IsDigit(c))
                    {
                        throw new Exception("Серия паспорта должна содержать только цифры!");
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
                    throw new Exception("Партнер должен быть противоположного пола!");
                }

                // Если устанавливаем нового партнера то у старого надо удалить ссылку
                if (_partner != null && _partner.Partner == this)
                {
                    _partner._partner = null;
                }

                
                if (value != null)
                {
                    // Если у нового партнера уже был другой партнер убираем ссылку
                    if (value._partner != null && value._partner != this)
                    {
                        value._partner._partner = null;
                    }
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
            set
            {
                _job = string.IsNullOrWhiteSpace(value) ? "Безработный" : value;
            }
        }

        /// <summary>
        /// Метод получения информации о взрослом человеке
        /// </summary>
        /// <returns>Строка с информацией</returns>
        public string GetAdultInfo()
        {
            string partnerInfo = "Нет партнера";
            if (Partner != null)
            {
                partnerInfo = $"{Partner.Surname} {Partner.Name}";
            }

            string maritalStatus = Gender == Gender.Male ?
                (Partner != null ? "Женат" : "Не женат") :
                (Partner != null ? "Замужем" : "Не замужем");

            return $"{base.Name} {base.Surname}, возраст: {base.Age}, " +
                   $"пол: {(base.Gender == Gender.Male ? "Мужчина" : "Женщина")}, " +
                   $"серия паспорта: {PassportSeries}, " +
                   $"номер паспорта: {PassportNumber}, " +
                   $"статус: {maritalStatus}, " +
                   $"партнер: {partnerInfo}, " +
                   $"работа: {Job}";
        }
    }
}
