using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonClasses
{
    /// <summary>
    /// Класс ребенка
    /// </summary>
    public class Child : PersonBase
    {
        /// <summary>
        /// Минимальный возраст для ребенка
        /// </summary>
        public override int MinAge => 0;

        /// <summary>
        /// Максимальный возраст для ребенка
        /// </summary>
        public override int MaxAge => 17;

        /// <summary>
        /// Мама
        /// </summary>
        private Adult _mother;

        /// <summary>
        /// Папа
        /// </summary>
        private Adult _father;

        /// <summary>
        /// Место учебы
        /// </summary>
        private string _placeOfStudy;

        /// <summary>
        /// Конструктор класса ребёнка Child
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="gender">Пол</param>
        /// <param name="mother">Мама</param>
        /// <param name="father">Папа</param>
        /// <param name="placeOfStudy">Место учебы</param>
        public Child(string name, string surname, int age, Gender gender,
            Adult mother, Adult father, string placeOfStudy)
            : base(name, surname, age, gender)
        {
            Mother = mother;
            Father = father;
            PlaceOfStudy = placeOfStudy;
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Child() : base()
        {
            _mother = null;
            _father = null;
            _placeOfStudy = "не указано";
        }

        /// <summary>
        /// Мама
        /// </summary>
        public Adult Mother
        {
            get => _mother;
            set
            {
                if (value != null && value.Gender != Gender.Female)
                {
                    throw new Exception("Мама должна быть женского пола!)");
                }
                _mother = value;
            }
        }

        /// <summary>
        /// Папа
        /// </summary>
        public Adult Father
        {
            get => _father;
            set
            {
                if (value != null && value.Gender != Gender.Male)
                {
                    throw new Exception("Папа должен быть мужского пола!");
                }
                _father = value;
            }
        }

        /// <summary>
        /// Место учебы
        /// </summary>
        public string PlaceOfStudy
        {
            get => _placeOfStudy;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Место учебы не может быть пустым!");
                }
                _placeOfStudy = value;
            }
        }

        /// <summary>
        /// Реализация абстрактного метода получения информации
        /// </summary>
        /// <returns>Строка с информацией о ребенке</returns>
        public override string GetInfo()
        {
            string motherInfo = Mother != null
                ? $"{Mother.Surname} {Mother.Name}"
                : "Нет информации о матери";

            string fatherInfo = Father != null
                ? $"{Father.Surname} {Father.Name}"
                : "Нет информации об отце";

            return

            $"{Name} {Surname}, возраст: {Age}, " +
            $"пол: " +
            $"{(Gender == Gender.Male
                    ? "мальчик"
                    : "девочка")}," +
            $"мама: {motherInfo}, " +
            $"папа: {fatherInfo}, " +
            $"учеба: {PlaceOfStudy}";
        }
    }
}
