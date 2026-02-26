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
        Console.WriteLine(new string('-', 50));

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
        //TODO: RSDN +
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
            Console.WriteLine($"Тип объекта: {fourthPerson.GetType().Name}");
            
            switch (fourthPerson)
            {
                //TOOD: отступы +
                case Adult adult:
                {
                    Console.WriteLine($"Четвертый взрослый: " +
                        $"{adult.Surname} {adult.Name}");
                    Console.WriteLine($"Семейное положение: " +
                        $"{(adult.Partner != null
                        ? "женат/замужем" 
                        : "не женат/не замужем")}");

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
                    Console.WriteLine($"Четвертый ребенок: {child.Surname}" +
                        $" {child.Name}");
                    Console.WriteLine($"Мама: {(child.Mother != null 
                        ? $"{child.Mother.Surname} {child.Mother.Name}" 
                        : "неизвестна")}");
                    Console.WriteLine($"Папа: {(child.Father != null 
                        ? $"{child.Father.Surname} {child.Father.Name}" 
                        : "неизвестен")}");
                    Console.WriteLine($"Учеба: {child.PlaceOfStudy}");
                    break;
                }

                default:
                {
                    Console.WriteLine($"Обычный человек: {fourthPerson.Surname}" +
                        $" {fourthPerson.Name}");
                    Console.WriteLine($"Возраст: {fourthPerson.Age}, " +
                        $"Пол: {(fourthPerson.Gender == Gender.Male 
                        ? "Мужчина" 
                        : "Женщина")}");
                    break;
                }
            }
        }
        else
        {
            //TODO: magic (to const) +
            
            Console.WriteLine($"\nВ списке меньше {fourthPersonIndex + 1}" +
                $" персонажей, анализ невозможен.");
        }
        PressButton();
    }
}