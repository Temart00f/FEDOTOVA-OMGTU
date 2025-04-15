class Number
{
    public string Phone { get; set; }
    public string Provider { get; set; }
    public int Year { get; set; }
    public Number(string phone, string provider, int year)
    {
        Phone = phone;
        Provider = provider;
        Year = year;
    }
}
class User
{
    public string Name { get; set; }
    public Number[] Phones { get; set; }
    public string City { get; set; }

    public User(string name, Number[] phones, string city)
    {
        Name = name;
        Phones = phones;
        City = city;
    }
}
class Program
{
    static User[] users = new User[100];
    static int count = 0;

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Заполнение данных об абоненте");
            Console.WriteLine("2. Поиск по оператору связи");
            Console.WriteLine("3. Поиск по году подключения");
            Console.WriteLine("4. Поиск по номеру телефона");
            Console.WriteLine("5. Выход");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Fill_user_data();
                    break;

                case "2":
                    Search_by_provider();
                    break;

                case "3":
                    Search_by_year();
                    break;

                case "4":
                    Search_by_number();
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Некорректный ввод. Пожалуйста, попробуйте снова.");
                    break;
            }
        }
    }

    static void Fill_user_data()
    {
        if (count >= users.Length)
        {
            Console.WriteLine("Массив полон.");
            return;
        }

        Console.Write("Введите ФИО абонента: ");
        string name = Console.ReadLine();
        Console.Write("Введите город проживания: ");
        string city = Console.ReadLine();
        Console.Write("Введите количество номеров абонента: ");
        int number_count = Convert.ToInt32(Console.ReadLine());
        Number[] all_phones = new Number[number_count];
        for (int i = 0; i < number_count; i++)
        {
            Console.Write("Введите номер телефона абонента: ");
            string number = Console.ReadLine();
            Console.Write("Введите оператора связи: ");
            string provider = Console.ReadLine();
            Console.Write("Введите год подключения: ");
            int year = Convert.ToInt32(Console.ReadLine());
            Number phone = new Number(number, provider, year);
            all_phones[i] = phone;
            Console.WriteLine("Номер успешно добавлен.");
        }

        users[count] = new User(name, all_phones, city);
        count++;
        Console.WriteLine("Данные абонента добавлены.");
    }

    static void Search_by_provider()
    {
        Console.Write("Введите оператора связи: ");
        string provider_name = Console.ReadLine();

        bool found = false;

        foreach (var user in users)
        {
            if (user != null)
            {
                foreach (var phone in user.Phones)
                {
                    if (phone.Provider.Equals(provider_name, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"ФИО: {user.Name}, Номер телефона: {phone.Phone}, Год подключения: {phone.Year}, Город: {user.City}");
                        found = true;
                    }
                }
            }
        }
        if (!found)
        {
            Console.WriteLine("Абоненты с указанным оператором связи не найдены.");
        }
    }
    static void Search_by_year()
    {
        Console.Write("Введите год подключения: "); 

        if (!int.TryParse(Console.ReadLine(), out int year))
        {
            Console.WriteLine("Некорректный ввод года подключения.");
            return;
        }

        bool found = false;

        foreach (var user in users)
        {
            if (user != null)
            {
                foreach (var phone in user.Phones)
                {
                    if (phone.Year == year)
                    {
                        Console.WriteLine($"ФИО: {user.Name}, Номер телефона: {phone.Phone}, Оператор: {phone.Provider}, Город: {user.City}");
                        found = true;
                    }
                }
            }
        }

        if (!found)
        {
            Console.WriteLine("Абоненты с указанным годом подключения не найдены.");
        }
    }

    static void Search_by_number()
    {
        Console.Write("Введите номер телефона: ");
        string Phone_input = Console.ReadLine();

        bool found = false;

        foreach (var user in users)
        {
            if (user != null)
            {
                foreach (var phone in user.Phones)
                {
                    if (phone.Phone.Equals(Phone_input))
                    {
                        Console.WriteLine($"ФИО: {user.Name}, Оператор: {phone.Provider}, Год подключения: {phone.Year}, Город: {user.City}");
                        found = true;
                    }
                }
            }
        }

        if (!found)
        {
            Console.WriteLine("Абоненты с указанным номером телефона не найдены.");
        }
    }
}