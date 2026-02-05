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
    public class Child : Person
    {
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
        /// Метод получения информации о ребенке
        /// </summary>
        /// <returns>Строка с информацией</returns>
        public string GetChildInfo()
        {
            string motherInfo = "Нет матери)";
            if (Mother != null)
            {
                motherInfo = $"{Mother.Surname} {Mother.Name}";
            }

            string fatherInfo = "Нет отца";
            if (Father != null)
            {
                fatherInfo = $"{Father.Surname} {Father.Name}";
            }

            return $"{base.Name} {base.Surname}, возраст: {base.Age}, " +
                   $"пол: {(base.Gender == Gender.Male ? "Мальчик" : "Девочка")}, " +
                   $"мама: {motherInfo}, " +
                   $"папа: {fatherInfo}, " +
                   $"учеба: {PlaceOfStudy}";
        }
    }
}
