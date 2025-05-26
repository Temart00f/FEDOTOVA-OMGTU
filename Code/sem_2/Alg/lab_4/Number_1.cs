using System;

class Number_1
{
    static void Error()
    {
        Console.WriteLine("Ошибка");
        Environment.Exit(1);
    }
    static void Main()
    {
        string input = Console.ReadLine();
        Stack<int> stack = new Stack<int>();

        string num = string.Empty;

        for (int i = 0; i < input.Length; i++)
        {
            if (Char.IsDigit(input[i]))
            {
                num += input[i];
            }

            else
            {
                if (input[i] == ' ')
                {
                    int value;
                    if (int.TryParse(num, out value))
                    {
                        stack.Push(value);
                        num = string.Empty;
                    }
                    continue;
                }

                if (input[i] == '+')
                {
                    if (stack.Count < 2)
                        Error();

                    int a = stack.Pop();
                    int b = stack.Pop();

                    stack.Push(a + b);
                    continue;
                }

                if (input[i] == '*')
                {
                    if (stack.Count < 2)
                        Error();

                    int a = stack.Pop();
                    int b = stack.Pop();

                    stack.Push(a * b);
                    continue;
                }

                if (input[i] == '-')
                {
                    if (stack.Count < 2)
                        Error();

                    int a = stack.Pop();
                    int b = stack.Pop();

                    stack.Push(a - b);
                    continue;
                }

                if (input[i] == '/')
                {
                    if (stack.Count < 2)
                        Error();

                    int a = stack.Pop();
                    int b = stack.Pop();

                    if (b == 0)
                        Error();

                    stack.Push(a / b);
                    continue;
                }
            }
        }

        if (stack.Count > 1 || stack.Count == 0)
        {
            Console.WriteLine("Неверный формат");
            return;
        }

        Console.WriteLine(stack.Pop());
        return;
    }
}