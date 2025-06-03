using System;
using System.Collections.Generic;

unsafe class Program
{
    static void Main()
    {
        string input = @"apple
                        lenovo
                        lenovo
                        asus
                        msi
                        apple
                        apple";

        string[] lines = input.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        int max_possible_size = lines.Length;
        int* counts = stackalloc int[max_possible_size];
        char** string_pointers = stackalloc char*[max_possible_size];
        int* string_lengths = stackalloc int[max_possible_size];
        int count = 0;

        fixed (char* p_input = input)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                bool found = false;

                for (int j = 0; j < count; j++)
                {
                    bool match = true;
                    if (string_lengths[j] != line.Length)
                    {
                        match = false;
                    }
                    else
                    {
                        for (int k = 0; k < line.Length; k++)
                        {
                            if (string_pointers[j][k] != line[k])
                            {
                                match = false;
                                break;
                            }
                        }
                    }

                    if (match)
                    {
                        counts[j]++;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    fixed (char* p_line = line)
                    {
                        string_pointers[count] = pLine;
                        string_lengths[count] = line.Length;
                        counts[count] = 1;
                        count++;
                    }
                }
            }
        }

        string[][] finalResult = new string[count][];
        for (int i = 0; i < count; i++)
        {
            finalResult[i] = new string[2];
            finalResult[i][0] = new string(string_pointers[i], 0, string_lengths[i]);
            finalResult[i][1] = counts[i].ToString();
        }

        foreach (var pair in finalResult)
        {
            Console.WriteLine($"{pair[0]}: {pair[1]}");
        }
    }
}