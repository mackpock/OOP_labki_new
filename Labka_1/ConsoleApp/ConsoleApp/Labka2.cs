using PersonClasses;


/// <summary>
/// Класс Labka2
/// </summary>
public class Labka2
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
    private static void ShowList(PersonList list, string listName)
    {
        Console.WriteLine($"\n{listName}");
        
        if (list.Count == 0)
        {
            Console.WriteLine("Список пуст!");
            return;
        }

        for (int i = 0; i < list.Count; i++)
        {
            var person = list.GetFromIndex(i);
            Console.WriteLine($"{i + 1}. {person.GetInfo()}");
        }
    }

    /// <summary>
    /// Основной метод
    /// </summary>
    /// <param name="args"></param>
    /// <exception cref="Exception"></exception>
    private static void Main(string[] args)
    {
        const int fourthPersonIndex = 3;
        const int randomPersonCount = 7;

        // 5.a. Создание списка PersonList, состоящего из рандомного кол-ва
        // взрослых и детей
        PersonList personList = new PersonList();

        Console.WriteLine("Генерация рандомного списка взрослых и детей");

        Random random = new Random();

        for (int i = 0; i < randomPersonCount; i++)
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

        // 5.c. Демонстрация полиморфизма: определение типа объекта 
        // и вызов методов, специфичных для конкретного класса наследника
        if (personList.Count > fourthPersonIndex)
        {
            var fourthPerson = personList.GetFromIndex(fourthPersonIndex); 
            Console.WriteLine($"Анализ четвертого персонажа (индекс" +
                $" {fourthPersonIndex + 1})");
            Console.WriteLine($"Тип персонажа: {fourthPerson.GetType().Name}");
            Console.WriteLine($"Информация: {fourthPerson.GetInfo()}");
            switch (fourthPerson)
            {
                //TODO: {}
                case Adult adult:
                    if (adult.Partner != null)
                    {
                        Console.WriteLine($"Партнёр:" +
                            $" {adult.Partner.GetInfo()}");
                    }
                    break;

                case Child child:
                    // никакая доп. информация не нужна
                    break;

            }

        }
        else
        {
            Console.WriteLine($"\nВ списке меньше {fourthPersonIndex + 1}" +
                $" персонажей, анализ невозможен.");
        }
        PressButton();
    }
}