using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PersonClasses
{
    public class Person
    {
        private string _name;
        private string _surname;
        private int _age;
        
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="age"></param>
        public Person(string  name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }

        public string Name
        {
            get { return _name; }
            set 
            {
                if (string.IsNullOrEmpty(value)) 
                {
                    throw new Exception($"{nameof(Name)} не может быть пустым " +
                        $"или незаполненным!");
                }
                _name = value; 
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception($"{nameof(Surname)} не может быть пустым " +
                        $"или незаполненным!");
                }
                _surname = value;
            }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                const int minAge = 0;
                const int maxAge = 124;
                if (value < minAge || value > maxAge)
                {
                    throw new Exception($"{nameof(Age)} не может быть меньше {minAge}" +
                        $" или больше {maxAge}!");
                }
                _age = value;
            }
        }

        public Gender Gender { get; set; }
       
        

    }
}

