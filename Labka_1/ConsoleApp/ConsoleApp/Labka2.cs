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
    /// <param name="list">Список </param>
    /// <param name="listName">Название списка</param>
    private static void ShowList(PersonList list, string listName)
    {
        Console.WriteLine($"\n{listName}");

        if (list.Count == 0)
        {
            Console.WriteLine("Список пуст!");
            return;
        }
        ;

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
            Console.WriteLine($"\nТип четвертого человека: " +
                $"{fourthPerson.GetType().Name}");

            switch (fourthPerson)
            {
                case Adult adult:
                    {
                        Console.WriteLine($"Четвертый взрослый: " +
                            $"{adult.Surname} {adult.Name}");

                        // Дополнительная информация для взрослого
                        string marriageStatus = adult.Partner != null
                            ? "женат/замужем"
                            : "не женат/не замужем";
                        Console.WriteLine($"Семейное положение: {marriageStatus}");

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
                        Console.WriteLine($"Четвертый ребенок:" +
                            $" {child.Surname} {child.Name}");

                        // Дополнительная информация для ребенка
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

        PressButton();


    }


}