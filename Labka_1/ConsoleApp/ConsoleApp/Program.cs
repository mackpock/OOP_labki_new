using PersonClasses;
using System;
using System.Security.Principal;

class Program
{
    static void pressButton()
    {
        Console.WriteLine("Нажмите любую клавишу для продолжения");
        Console.ReadKey();
    }

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
        Person p5 = new Person("Абдулбек", "Алексеев", 47, Gender.Female);
        Person p6 = new Person("Цыцыгма", "Армяновна", 19, Gender.Male);

        list1.Add(p1);
        list1.Add(p2);
        list1.Add(p3); 

        list2.Add(p4);
        list2.Add(p5);
        list2.Add(p6);

        Console.WriteLine("Созданы два списка по 3 человека!");
        pressButton();

        ShowList(list1, "Горожане");
        ShowList(list2, "Призжие");
        pressButton();

        
        var p7 = new Person("Кирилл", "Накипелов", 19 , Gender.Male);
        list1.Add(p7);
        Console.WriteLine("\nВ список 1 добавлен новый персонаж! (4)");
        ShowList(list1, "\nТеперь первый список выглядит так:");
        pressButton();

        var secondPersonFromList1 = list1.GetFromIndex(1);
        list2.Add(secondPersonFromList1);
        Console.WriteLine("\nВторой человек из первого списка добавлен во второй!");
        ShowList(list1, "Горожане");
        ShowList(list2, "Призжие");
        pressButton();

        list1.RemoveAt(1);
        Console.WriteLine("\nВторой человек удален из первого списка");
        ShowList(list1, "Горожане");
        ShowList(list2, "Призжие");
        pressButton();

        list2.Clear();
        Console.WriteLine("\nВторой список очищен");
        ShowList(list1, "Горожане");
        ShowList(list2, "Призжие");
        pressButton();

    }



}