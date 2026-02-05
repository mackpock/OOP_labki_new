using PersonClasses;
using System;
using System.Security.Principal;

/// <summary>
/// Класс Labka1
/// </summary>
public class Labka1
{
    /// <summary>
    /// Метод ReadKey чтобы продолжить
    /// </summary>
    public static void PressButton()
    {
        Console.WriteLine("Нажмите любую клавишу для продолжения");
        Console.ReadKey();
    }

    /// <summary>
    /// Метод для вывода списка
    /// </summary>
    /// <param name="list">Список </param>
    /// <param name="listName">Название списка</param>
    private static void ShowList(PersonList list, string listName) 
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

    /// <summary>
    /// Основной метод
    /// </summary>
    /// <param name="args"></param>
    /// <exception cref="Exception"></exception>
    private static void Main(string[] args)
    {
       // 5.a. Создание списка PersonList, состоящего из рандомного кол-ва
        // взрослых и детей
        PersonList personList = new PersonList();

        Console.WriteLine("Рандомный список взрослых и детей:\n");

        Random random = new Random();

        for (int i = 0; i < 7; i++)
        {
            if (random.NextDouble() < 0.5)
            {
                personList.Add(GetRandomPersonClass.GetRandomAdult());
            }
            else
            {
                personList.Add(GetRandomPersonClass.GetRandomChild());
            }
        }

        // 5.b. Вывод на экран описания всех людей списка.
        // Демонстрация того, что для различных типов людей описания
        // содержат разную информацию
        ShowList(personList, "Список персонажей (взрослые и дети):");
        PressButton();

        // 5.c. Определение типа четвертого человека в списке
        // и выполнения методов, присущих этому классу.
        if (personList.Count > 3)
        {
            var fourthPerson = personList.GetFromIndex(3);
            Console.WriteLine($"\nТип четвертого человека: {fourthPerson.GetType().Name}");

            switch (fourthPerson)
            {
                case Adult adult:
                    {
                        Console.WriteLine($"Четвертый взрослый: {adult.Surname} {adult.Name}");
                        
                        // Дополнительная информация для взрослого
                        string maritalStatus = adult.Partner != null ? 
                            "женат/замужем" : "не женат/не замужем";
                        Console.WriteLine($"Семейное положение: {maritalStatus}");
                        
                        if (adult.Partner != null)
                        {
                            Console.WriteLine($"Партнер: {adult.Partner.Surname}" +
                                $" {adult.Partner.Name}");
                        }
                        
                        Console.WriteLine($"Работа: {adult.Job}");
                        Console.WriteLine($"Паспорт: {adult.PassportSeries}" +
                            $" {adult.PassportNumber}");
                        break;
                    }
                case Child child:
                    {
                        Console.WriteLine($"Четвертый ребенок: {child.Surname} {child.Name}");
                        
                        // Дополнительная информация для ребенка
                        Console.WriteLine($"Мама: {(child.Mother != null ? 
                            $"{child.Mother.Surname} {child.Mother.Name}" : "неизвестна")}");
                        Console.WriteLine($"Папа: {(child.Father != null ? 
                            $"{child.Father.Surname} {child.Father.Name}" : "неизвестен")}");
                        Console.WriteLine($"Учеба: {child.PlaceOfStudy}");
                        break;
                    }
                default:
                    {
                        Console.WriteLine($"Обычный человек: {fourthPerson.Surname}" +
                            $" {fourthPerson.Name}");
                        Console.WriteLine($"Возраст: {fourthPerson.Age}, " +
                            $"Пол: {(fourthPerson.Gender == Gender.Male ? "Мужчина" : "Женщина")}");
                        break;
                    }
            }
        }

        PressButton();

        Console.WriteLine("Демонстрация работы с отдельными объектами:");
        
        // Создание конкретных примеров
        Adult adultExample = new Adult("Иван", "Иванов", 30, Gender.Male, "1234", "567890", null, "Инженер");
        Child childExample = new Child("Мария", "Иванова", 10, Gender.Female, 
            new Adult("Анна", "Иванова", 30, Gender.Female, "1111", "222333", null, "Учитель"), 
            new Adult("Иван", "Иванов", 32, Gender.Male, "4444", "555666", null, "Программист"), 
            "Школа №1");
        
        Console.WriteLine("\nПример взрослого:");
        Console.WriteLine(adultExample.GetInfo());
        
        Console.WriteLine("\nПример ребенка:");
        Console.WriteLine(childExample.GetInfo());
        
        PressButton();
        
        Console.WriteLine("Для завершения программы нажмите на любую клавишу...");
        Console.ReadKey();
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