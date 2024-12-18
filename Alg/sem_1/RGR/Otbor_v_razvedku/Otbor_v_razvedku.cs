using System;

class Otbor_v_razvedku
{
    static int Group_Counter(int n)
    {
        if (n < 3 || n == 4) return 0;
        if (n == 3) return 1;

        int group_1 = n / 2;
        int group_2 = n - group_1;

        return Group_Counter(group_1) + Group_Counter(group_2);
    }

    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine(Group_Counter(n));
    } 

}