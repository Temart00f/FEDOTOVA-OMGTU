using System;

class Program
{
    static void Main()
    {
        string input = "input.txt";
        string output = "output.txt";

        var lines = File.ReadAllLines(input);
        var new_lines = new List<string>();

        foreach (var line in lines)
        {
            string number = "";

            foreach (char c in line)
            {
                if (char.IsDigit(c))
                {
                    number += c;
                }

                else
                {
                    if (number.Length > 0)
                    {
                        if (int.Parse(number) % 2 == 0)
                        {
                            new_lines.Add(line);
                            number = "";
                            continue;
                        }

                    }

                }

            }

            if (number.Length > 0)
            {
                if (int.Parse(number) % 2 == 0)
                {
                    new_lines.Add(line);
                    number = "";
                }

            }

        }

        File.WriteAllLines(output, new_lines);
    }
}