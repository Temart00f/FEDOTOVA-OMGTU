using System;

public class Phone
{
    public string Number { get; private set; }
    public string Provider { get; private set; }

    public Phone(string number, string provider)
    {
        Number = number;
        Provider = provider;
    }
}

class Program
{
    static void Main()
    {
        List<Phone> phones = new List<Phone>();
        phones.Add(new Phone("+56465326225", "tele2"));
        phones.Add(new Phone("+87456874658", "mega"));
        phones.Add(new Phone("+29017120565", "mts"));
        phones.Add(new Phone("+98365691596", "beeline"));
        phones.Add(new Phone("+29835603965", "tele2"));
        phones.Add(new Phone("+32894572938", "mts"));
        phones.Add(new Phone("+89018203756", "mega));

        Dictionary<string, int> nums_dict = new Dictionary<string, int>();

        foreach (var p in phones)
        {
            if (!nums_dict.TryAdd(p.Operator, 1))
            {
                nums_dict[p.Operator] += 1;
            }
        }

        int data = 0;
        string prov = "";

        foreach (var p in nums_dict)
        {
            if (p.Value > data)
            {
                prov = p.Key;
                data = p.Value;
            }
        }

        Console.WriteLine($"результат: {prov}  количество: {data}");
    }
}