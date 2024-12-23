using System;
using System.Data;

class Tau_kita
{
    static string enc_words(string word)
    {
        int m = word.Length / 2;
        string current = "";

        for (int i = 0; i < word.Length; i++)
        {
            if (i % 2 == 1)
            {
                m = m - i;
                current = current + word[m];
            }
            else
            {
                m = m + i;
                current = current + word[m];
            }
        }
        return current;
    }
    static void Main()
    {
        Console.WriteLine("   Input:");
        string[] encrypted = Console.ReadLine().Split(" ");
        string[] decrypted = new string[encrypted.Length];

        int n = encrypted.Length / 2;

        for (int i = 0; i < encrypted.Length; i++)
        {
            if (i % 2 == 1)
            {
                n = n - i;
                decrypted[i] = enc_words(encrypted[n]);
            }
            
            else
            {
                n = n + i;
                decrypted[i] = enc_words(encrypted[n]);
            }
        }   
        string input = string.Join(" ", decrypted);
        Console.WriteLine("\n   Output:");
        Console.WriteLine(input);
    }
}

