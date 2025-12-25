using PersonClasses;
using System;
using System.Security.Principal;

class Labka1
{
    /// <summary>
    /// Метод ReadKey чтобы продолжить
    /// </summary>
    static void PressButton()
    {
        Console.WriteLine("Нажмите любую клавишу для продолжения");
        Console.ReadKey();
    }

    /// <summary>
    /// Метод для вывода списка
    /// </summary>
    /// <param name="list">Список </param>
    /// <param name="listName">Название списка</param>
    static void ShowList(PersonList list, string listName) 
    {
        Console.WriteLine($"\n{listName}");

        if (list.Count == 0) 
        { 
            Console.WriteLine("Список пуст!");
            return; 
        };

        for (int i = 0; i < list.Count; i++) 
        { 
            var person = list.GetFromIndex(i);
            Console.WriteLine($"{i + 1}. {person.Name} {person.Surname}, " +
                $"возраст: {person.Age}, пол: {person.Gender}"); 
        }
    }

    //TODO: RSDN +

    /// <summary>
    /// Основной метод
    /// </summary>
    /// <param name="args"></param>
    /// <exception cref="Exception"></exception>
    static void Main(string[] args)
    {
        PersonList list1 = new PersonList();
        PersonList list2 = new PersonList();

        Person person1 = new Person("Олег", "Олегович", 44, Gender.Male);
        Person person2 = new Person("Максим", "Покацкий", 23, Gender.Male);
        Person person3 = new Person("Ольга", "Святая", 18, Gender.Female);

        Person person4 = new Person("Мехродж", "Демьянов", 67, Gender.Male);
        Person person5 = new Person("Абдулбек", "Алексеев", 47, Gender.Male);
        Person person6 = new Person("Цыцыгма", "Армяновна", 19, Gender.Female);

        list1.Add(person1);
        list1.Add(person2);
        list1.Add(person3); 

        list2.Add(person4);
        list2.Add(person5);
        list2.Add(person6);

        //3 a+b
        Console.WriteLine("Созданы два списка по 3 человека!");
        ShowList(list1, "Горожане");
        ShowList(list2, "Призжие");
        PressButton();

        //3 c
        var person7 = new Person("Кирилл", "Накипелов", 19 , Gender.Male);
        list1.Add(person7);
        Console.WriteLine("\nВ список 1 добавлен новый персонаж! (4)");
        ShowList(list1, "\nТеперь первый список выглядит так:");
        PressButton();

        //3 d
        var secondPersonFromList1 = list1.GetFromIndex(1);
        list2.Add(secondPersonFromList1);
        Console.WriteLine("\nВторой человек из первого списка добавлен во второй!");
        ShowList(list1, "Горожане");
        ShowList(list2, "Призжие");
        PressButton();

        //3 e
        list1.RemoveAt(1);
        Console.WriteLine("\nВторой человек удален из первого списка");
        ShowList(list1, "Горожане");
        ShowList(list2, "Призжие");
        PressButton();

        //3 f
        list2.Clear();
        Console.WriteLine("\nВторой список очищен");
        ShowList(list1, "Горожане");
        ShowList(list2, "Призжие");
        PressButton();

        Console.WriteLine("\nТеперь можно ввести своего персонажа!");
        PressButton();

        //методы чтения персоны с клавиатуры и вывод персоны на экран
        Person personNew = new Person();
        
        var actionDictionary = new Dictionary<string, Action>()
        {
            {
                "Имя",
                new Action(() =>
                    {
                        personNew.Name = Console.ReadLine();
                    })
            },
            {
                "Фамилия",
                new Action(() =>
                    {
                        personNew.Surname = Console.ReadLine();
                    })
            },
            {
                "Возраст",
                new Action(() =>    
                    {
                        
                        //6 b При вводе не должно быть возможности ввода символов

                        string  input = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(input))
                        {
                            throw new Exception("Возраст не может быть пустым!");
                        }

                        foreach (char digit  in input)
                        {
                            if (!char.IsDigit(digit))
                            {
                                throw new Exception ("Возраст должен содержать" +
                                    " ТОЛЬКО цифры!");
                            }
                        }


                        if (int.TryParse(input, out int age))
                        {
                            personNew.Age = age;
                        }
                        else
                        {
                            throw new Exception(
                                "Не удалось преобразовать возраст в чило!");
                        }
                    })

            },

        };

        foreach (var actionHandler in actionDictionary)
        {
            ActionHander(actionHandler.Value, actionHandler.Key);
        }
        
        string genderNewPerson;
        switch(personNew.Gender)
        {
            case Gender.Male:
                genderNewPerson = "Мужчина";
                break;
            case Gender.Female:
                genderNewPerson = "Женщина";
                break;
            default:
                genderNewPerson = "Анон";
                break;

        }
        Console.WriteLine($"\nВы создали персонажа:\n" +
                          $"Имя:     {personNew.Name}\n" +
                          $"Фамилия: {personNew.Surname}\n" +
                          $"Возраст: {personNew.Age}\n" +
                          $"Пол:     {genderNewPerson}");
        PressButton();

        

        //Вывод рандомных персонажей
        Console.WriteLine("\nВывод рандомного списка персонажей:");
        PersonList randomList = new PersonList();
        for (int i = 0; i < 10; i++)
        {
            Person randomPerson = GetRandomPersonClass.GetRandomPerson();
            randomList.Add(randomPerson);
        }
        ShowList(randomList, "Наши случайные персонажи:");
        PressButton();
    }
    
    

    /// <summary>
    /// Метод для выброса исключения при пустом вводе ФИ и возраста
    /// </summary>
    /// <param name="action"></param>
    /// <param name="enteredValue"></param>
    public static void ActionHander(Action action, string enteredValue) 
    {
        while (true) 
        {
            try 
            {
                Console.WriteLine($"Пожалуйста, введите {enteredValue}: \n");
                action.Invoke();
                return;
            }
            catch (Exception exception) 
            {
                Console.WriteLine("\nОшибка: " + exception.Message);
            }
        }
    }
}