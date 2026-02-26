using System.Text;


namespace PersonClasses
{
    /// <summary>
    /// класс для генерации случайных объектов 
    /// </summary>
    public static class GetRandomPersonClass
    {
        /// <summary>
        /// Мужские имена
        /// </summary>
        private static readonly string[] _maleNames =
        {
            "Артём",  "Кирилл", "Егор", "Тимофей", "Михаил",
            "Степан", "Глеб",   "Лев",  "Фёдор",   "Платон"
        };

        /// <summary>
        /// Женские имена
        /// </summary>
        private static readonly string[] _femaleNames =
        {
            "София", "Полина", "Алиса", "Ева", "Милана",
            "Арина", "Ульяна", "Дарья", "Вера"
        };

        /// <summary>
        /// Мужские фамилии
        /// </summary>
        private static readonly string[] _maleSurnames =
        {
            "Морозов", "Белов",  "Крылов",  "Ермаков", "Федоров",
            "Лебедев", "Громов", "Соколов", "Макаров", "Никитин"
        };

        /// <summary>
        /// Женские фамилии
        /// </summary>
        private static readonly string[] _femaleSurnames =
        {
            "Морозова", "Белова",  "Крылова",  "Ермакова", "Федорова",
            "Лебедева", "Громова", "Соколова", "Макарова", "Никитина"
        };

        /// <summary>
        /// Места работы
        /// </summary>
        private static readonly string[] _jobPlaces =
        {
            "Газпром нефть", "Роснефть", "Магнит",   "Росатом",
            "Почта России",  "Россети",  "Сбер",     "Роскосмос",
            "Норникель",     "Русгидро", "Тинькофф", "Яндекс",
        };

        /// <summary>
        /// Места учебы
        /// </summary>
        private static readonly string[] _studyPlaces =
        {
            "МБОУ СОШ 1",  "МБОУ СОШ 4",
            "МБОУ СОШ 2",  "МБОУ СОШ 5",
            "МБОУ СОШ 6",  "МБОУ СОШ 7",
            "МБОУ СОШ 9",  "Гимназия 228",
        };

        /// <summary>
        /// Случайные персонажи.
        /// </summary>
        private static readonly Random _random = new Random();

        /// <summary>
        /// Генерирует случайного взрослого с определенным полом
        /// </summary>
        /// <param name="gender">Пол взрослого</param>
        /// <returns>Объект класса Adult</returns>
        public static Adult GetRandomAdult(Gender gender)
        {
            string name = gender == Gender.Male
                ? _maleNames[_random.Next(_maleNames.Length)]
                : _femaleNames[_random.Next(_femaleNames.Length)];

            string surname = gender == Gender.Male
                ? _maleSurnames[_random.Next(_maleSurnames.Length)]
                : _femaleSurnames[_random.Next(_femaleSurnames.Length)];

            //TODO: get from adult +
            int age = _random.Next(Adult.MinAgeValue, Adult.MaxAgeValue);

            // Рандом ПД
            //TODO: get from adult +
            string passportSeries = GeneratePassportData
                (Adult.PassportSeriesLength);
            string passportNumber = GeneratePassportData
                (Adult.PassportNumberLength);

            // Рандом работа
            string job = _jobPlaces[_random.Next(_jobPlaces.Length)];

            // Пусть будет партнёр с 50% шансом
            Adult partner = null;
            Gender partnerGender = gender == Gender.Male
                ? Gender.Female
                : Gender.Male;
            // 50% шанс наличия партнера
            if (_random.Next(2) == 0) 
            {
                partner = GetRandomAdult(partnerGender);
            }

            Adult adult = new Adult(name, surname, age, gender,
                passportNumber, passportSeries, partner, job);

            return adult;
        }

        /// <summary>
        /// Генерирует случайного взрослого
        /// </summary>
        /// <returns>Объект класса Adult</returns>
        public static Adult GetRandomAdult()
        {
            Gender gender = (Gender)_random.Next(2);
            return GetRandomAdult(gender);
        }

        /// <summary>
        /// Генерирует случайного ребенка
        /// </summary>
        /// <returns>Объект класса Child</returns>
        public static Child GetRandomChild()
        {
            Gender gender = (Gender)_random.Next(2);

            string name = gender == Gender.Male
                ? _maleNames[_random.Next(_maleNames.Length)]
                : _femaleNames[_random.Next(_femaleNames.Length)];

            int age = _random.Next(0, 18);

            // Присваиваем маму папу
            Adult father = GetRandomAdult(Gender.Male);
            Adult mother = GetRandomAdult(Gender.Female);

            //TODO: redo +
            // Даём ребёнку фамилию отца 
            string surname = father.Surname;

            // Выбор места учебы
            string placeOfStudy = _studyPlaces[_random.Next(_studyPlaces.Length)];

            Child child = new Child(name, surname, age, gender,
                mother, father, placeOfStudy);

            return child;
        }

        /// <summary>
        /// Генерирует паспортные данные (серия или номер)
        /// </summary>
        /// <param name="digitsCount">Количество цифр</param>
        /// <returns>Строка с паспортными данными</returns>
        private static string GeneratePassportData(int digitsCount)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < digitsCount; i++)
            {
                result.Append(_random.Next(0, 10));
            }
            return result.ToString();
        }
    }
}