using PersonClasses;
using System;
using System.Security.Principal;

class Program
{
    static void PressButton()
    {
        Console.WriteLine("Нажмите любую клавишу для продолжения");
        Console.ReadKey();
    }

    /// <summary>
    /// Метод для вывода списка
    /// </summary>
    /// <param name="list"></param>
    /// <param name="listName"></param>
    static void ShowList(PersonList list, string listName) 
    {
        Console.WriteLine($"\n{listName}");
        if (list.Count == 0) { Console.WriteLine("Список пуст!"); return; };

        for (int i = 0; i < list.Count; i++) 
        { 
            var p = list.GetFromIndex(i);
            Console.WriteLine($"{i + 1}. {p.Name} {p.Surname}, " +
             $"возраст: {p.Age}, пол: {p.Gender}"); 
        }
    }

    static void Main(string[] args)
    {
        PersonList list1 = new PersonList();
        PersonList list2 = new PersonList();

        Person p1 = new Person("Олег", "Олегович", 44, Gender.Male);
        Person p2 = new Person("Максим", "Покацкий", 23, Gender.Male);
        Person p3 = new Person("Ольга", "Святая", 18, Gender.Female);

        Person p4 = new Person("Мехродж", "Демьянов", 67, Gender.Male);
        Person p5 = new Person("Абдулбек", "Алексеев", 47, Gender.Male);
        Person p6 = new Person("Цыцыгма", "Армяновна", 19, Gender.Female);

        list1.Add(p1);
        list1.Add(p2);
        list1.Add(p3); 

        list2.Add(p4);
        list2.Add(p5);
        list2.Add(p6);

        //a+b
        Console.WriteLine("Созданы два списка по 3 человека!");
        ShowList(list1, "Горожане");
        ShowList(list2, "Призжие");
        PressButton();

        //c
        var p7 = new Person("Кирилл", "Накипелов", 19 , Gender.Male);
        list1.Add(p7);
        Console.WriteLine("\nВ список 1 добавлен новый персонаж! (4)");
        ShowList(list1, "\nТеперь первый список выглядит так:");
        PressButton();

        //d
        var secondPersonFromList1 = list1.GetFromIndex(1);
        list2.Add(secondPersonFromList1);
        Console.WriteLine("\nВторой человек из первого списка добавлен во второй!");
        ShowList(list1, "Горожане");
        ShowList(list2, "Призжие");
        PressButton();

        //e
        list1.RemoveAt(1);
        Console.WriteLine("\nВторой человек удален из первого списка");
        ShowList(list1, "Горожане");
        ShowList(list2, "Призжие");
        PressButton();

        //f
        list2.Clear();
        Console.WriteLine("\nВторой список очищен");
        ShowList(list1, "Горожане");
        ShowList(list2, "Призжие");
        PressButton();

        Console.WriteLine("\nТеперь можно ввести своего персонажа!");
        PressButton();

        
        Person person1 = new Person();
        var actionDictionary = new Dictionary<string, Action>()
        {
            {
                "Имя",
                new Action(() =>
                    {
                        person1.Name = Console.ReadLine();
                    })
            },
            {
                "Фамилия",
                new Action(() =>
                    {
                        person1.Surname = Console.ReadLine();
                    })
            },
            {
                "Возраст",
                new Action(() =>
                    {
                        if (int.TryParse(Console.ReadLine(), out int age))
                        {
                            person1.Age = age;
                        }
                        else
                        {
                            throw new Exception(
                                "Возраст не может быть нецелым!");
                        }
                    })

            },

        };

        foreach (var actionHandler in actionDictionary)
        {
            ActionHander(actionHandler.Value, actionHandler.Key);
        }

        person1.Gender = Gender.Male; 
        var person2 = new Person();
        Console.WriteLine(person2.SayAbout(person1));

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