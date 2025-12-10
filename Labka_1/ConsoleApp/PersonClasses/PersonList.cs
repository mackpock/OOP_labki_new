using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PersonClasses
{
    /// <summary>
    /// Описание абстракции писка
    /// </summary>
    public class PersonList
    {
        
        /// <summary>
        /// Объявление списка объектов _person (приватный)
        /// </summary>
        private List<Person> _person;

        /// <summary>
        /// Конструктор внутреннего списка (паблик)
        /// </summary>
        public PersonList()
        {
            _person = new List<Person>();
        }

        /// <summary>
        /// Добавление персонажа
        /// </summary>
        /// <param name="person"></param>
        /// <exception cref="Exception"></exception>
        /// Исключение, если индекс находится за допустимыми пределами
        public void Add(Person person) 
        {
            if (person == null) throw new Exception($"{nameof(person)}" +
                $" не может быть null!");
            _person.Add(person);
        }

        /// <summary>
        /// Удалить персонажа
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public bool Remove(Person person) 
        {
            return _person.Remove(person);
        }

        /// <summary>
        /// Удалить персонажа по индексу
        /// </summary>
        /// <param name="index"></param>
        /// <exception cref="Exception"></exception>
        /// Исключение, если индекс находится за допустимыми пределами
        public void RemoveAt(int index) 
        {
            if (index < 0 || index >= _person.Count) 
                throw new Exception($"{nameof(index)} введите корректный индекс!");
            _person.RemoveAt(index);
        }

        /// <summary>
        /// Получить персонажа по индексу
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        /// Исключение, если индекс находится за допустимыми пределами
        public Person GetFromIndex(int index)
        {
            if (index <0 || index  >= _person.Count)
                throw new Exception($"{nameof(index)} введите корректный индекс!");
            return _person[index]; 
        }

        /// <summary>
        /// Получить индекс по персонажу
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public int IndexOf(Person person) 
        {
            if (person == null) throw new Exception($"{nameof(person)} " +
                $"не может быть null!");
            return _person.IndexOf(person);
        }

        /// <summary>
        /// Очистка списка
        /// </summary>
        public void Clear() 
        {
            _person.Clear();
        }

        public int Count => _person.Count;
    }
}
