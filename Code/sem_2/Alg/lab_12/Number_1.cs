using System;

class Phone
{
    public string Name { get; set; }
    public string Phone_number { get; set; }
    public string Provider { get; set; }
    public int Year { get; set; }

    public Phone(string name, string phone_number, string provider, int year)
    {
        Name = name;
        Phone_number = phone_number;
        Provider = provider;
        Year = year;
    }
}

class Program
{
    static void Main()
    {
        List<Phone> phones =
        [
            new Phone("n1", "+89081027769", "tele2", 2006),
            new Phone("n2", "+82423523523", "mts", 1997),
            new Phone("n3", "+84875757574", "beeline", 1999),
            new Phone("n4", "+83452194500", "mega", 2002),
            new Phone("n5", "+89985885858", "tele2", 2001),
            new Phone("n6", "+89998777777", "mts", 2009),
        ];

        bool work = true;

        while (work)
        {
            Console.WriteLine("\n0 - группировка по году\n1 - группировка по оператору\n2 - выдать телефон по имени\n3 - выход");
            int value = int.Parse(Console.ReadLine());

            switch (value)
            {
                case 0:
                    Sort_by_ear(phones);
                    break;
                case 1:
                    Sort_by_provider(phones);
                    break;
                case 2:
                    Find_by_name(phones);
                    break;
                case 3:
                    work = false;
                    break;
            }
        }
    }

    private static void Sort_by_ear(List<Phone> phones)
    {
        var sorted = phones.GroupBy(x => x.Year);

        foreach (var group in sorted)
        {
            Console.WriteLine($"год: {group.Key}");
            foreach (var phone in group)
            {
                Console.WriteLine($"  номер: {phone.Phone_number}, имя: {phone.Name}, оператор: {phone.Provider}");
            }
        }
    }

    private static void Sort_by_provider(List<Phone> phones)
    {
        var sorted = phones.GroupBy(x => x.Provider);

        foreach (var group in sorted)
        {
            Console.WriteLine($"оператор: {group.Key}");
            foreach (var phone in group)
            {
                Console.WriteLine($"  номер: {phone.Phone_number}, имя: {phone.Name}, год подключения: {phone.Year}");
            }
        }
    }

    private static void Find_by_name(List<Phone> phones)
    {
        Console.Write("Введите имя: ");
        string searc_name = Console.ReadLine();

        var found = phones.Where(x => x.Name == search_name).ToList();

        if (found.Count == 0)
        {
            Console.WriteLine("Не найдено");
            return;
        }

        foreach (Phone phone in found)
        {
            Console.WriteLine($"  номер: {phone.Phone_number}, имя: {phone.Name}, год подключения: {phone.Year}, оператор: {phone.Provider}");
        }
    }
}