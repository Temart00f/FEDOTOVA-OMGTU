using System;
using Number_1;
using Number_2;
using Number_3;
namespace General
{
    class General
    {
        static void Main() 
        {
            Console.WriteLine("Номер 1");
            Number_1.Program_1.First();
            Console.WriteLine("Номер 2");
            Number_2.Program_2.Second();
            Console.WriteLine("Номер 3");
            Number_3.Program_3.Third();
            Console.ReadKey();
        }
    }
}