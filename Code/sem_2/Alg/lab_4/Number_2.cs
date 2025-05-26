using System;

class Number_2
{
    static void Main()
    {
        List<string> list = Console.ReadLine().Split().ToList<string>();
        HashSet<string> set = list.ToHashSet();

        foreach (string str in set)
        {
            Console.Write($"{str} ");
        }

        Console.WriteLine("\n");

        Dictionary<string, int> dict = new Dictionary<string, int>();

        foreach (string str in list)
        {
            if (!dict.Keys.Contains(str))
                dict[str] = 1;

            else
                dict[str]++;
        }

        foreach (string str in dict.Keys)
        {
            Console.Write($"\"{str}\" - {dict[str]}; ");
        }

        return;
    }
}