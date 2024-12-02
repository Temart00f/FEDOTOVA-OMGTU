using System;
namespace Number_1
{
    class Number_1
    {
        static void Main()
        {
            Console.WriteLine("Введите колчество цифр в последовательности:");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("//");
            int local_max_count = 0;
            int first_local_max_1 = 0;
            int first_local_max_2 = 0;
            int second_local_max = 0;
            int left_value = 0;
            int central_value = 0;
            int right_value = 0;
            int four_count = 0;
            int current_lenth_even_num = 0;
            int total_lenth_even_num = 0;
            for (int i = 0; i < n; i++)
            {
                int value = Convert.ToInt32(Console.ReadLine());

                if (value%2 == 0)
                {
                    current_lenth_even_num++;
                }
                else if (value%2 != 0)
                {
                    total_lenth_even_num = current_lenth_even_num;
                    current_lenth_even_num = 0;

                }

                if (Math.Abs(value)%10 == 4)
                {
                    four_count++;
                }

                if (i == 0)
                {
                    left_value = value;
                    continue;
                }
                else if (i == 1)
                {
                    central_value = value;
                    continue;
                }
                else if (i == 2)
                {
                    right_value = value;
                    first_local_max_1 = Math.Max(left_value, central_value);
                    first_local_max_1 = Math.Max(first_local_max_1, right_value);
                    second_local_max = Math.Min(left_value, central_value);
                    second_local_max = Math.Min(second_local_max, right_value);
                    local_max_count++;
                    if (left_value < first_local_max_1 && left_value > second_local_max)
                    {
                        Console.WriteLine($"Второй локальный максимум = {left_value}");
                    }
                    else if (central_value < first_local_max_1 && central_value > second_local_max)
                    {
                        Console.WriteLine($"Второй локальный максимум = {central_value}");
                    }
                    else
                    {
                        Console.WriteLine($"Второй локальный максимум = {right_value}");
                    }

                    Console.WriteLine($"Первый локальный максимум = {first_local_max_1}");
                    continue;
                }
                else
                {
                    left_value = central_value;
                    central_value = right_value;
                    right_value = value;

                    first_local_max_2 = Math.Max(left_value, central_value);
                    first_local_max_2 = Math.Max(first_local_max_2, right_value);
                    second_local_max = Math.Min(left_value, central_value);
                    second_local_max = Math.Min(second_local_max, right_value);


                    if (left_value < first_local_max_2 && left_value > second_local_max)
                    {
                        Console.WriteLine($"Второй локальный максимум = {left_value}");
                    }
                    else if (central_value < first_local_max_2 && central_value > second_local_max)
                    {
                        Console.WriteLine($"Второй локальный максимум = {central_value}");
                    }
                    else
                    {
                        Console.WriteLine($"Второй локальный максимум = {right_value}");
                    }

                    if (first_local_max_1 != first_local_max_2)
                    {
                        local_max_count++;
                    }
                    first_local_max_1 = first_local_max_2;
                    Console.WriteLine($"Первый локальный максимум = {first_local_max_1}");
                }
            }
            Console.WriteLine("//");
            Console.WriteLine($"Количество локальных максимумов = {local_max_count}");
            Console.WriteLine($"Количество элементов оканчивающихся на четверку = {four_count}");
            Console.WriteLine($"наибольшая длина подпоследовательности состоящая из четных элементов = {total_lenth_even_num}");
        }
    }
}