using System;

class Student
{
    public string Name { get; set; }
    public int Year { get; set; }
    public string Cls { get; set; }
    public string Phone { get; set; }

    public override string ToString()
    {
        return $"Имя: {Name}, Год рождения: {Year}, Класс: {Cls}, Номер: {Phone}";
    }
    
}

class Program
{
    static void show_menu()
    {
        Console.Clear();
        Console.WriteLine("Меню\n" +
            "1) Добавить студента\n" +
            "2) Выброка по году рождения\n" +
            "3) Выборка по классу\n" +
            "4) Выйти из программы\n\n" +
            "Выберите желаемое действие: ");
    }

    static void add_student(ref Student[] students, ref int students_count)
    {
        if (students_count <= students.Length)
        {
            Console.Write("Введите ФИО: ");
            string name = Console.ReadLine();
            Console.Write("Введите год рождения: ");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите класс: ");
            string cls = Console.ReadLine();
            Console.Write("Введите номер телефона: ");
            string phone = Console.ReadLine();

            students[students_count] = new Student();
            students[students_count].Name = name;
            students[students_count].Year = year;
            students[students_count].Cls = cls;
            students[students_count].Phone = phone;
            students_count++;

            Console.WriteLine("Новый студент добавлен.");
        }

        else
        {
            Console.WriteLine("База данных переполнена.");
            return;
        }

    }

    static void select_be_year(Student[] students, int students_count)
    {
        if (students_count !=0)
        {
            Console.WriteLine("Введите год рождения: ");
            int year = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < students_count; i++)
            {
                if (students[i].Year == year)
                {
                    Console.WriteLine(students[i].ToString());
                }
            }
        }
        else
        {
            Console.WriteLine("В базе данных нет студентов");
        }
    }

    static void select_be_cls(Student[] students, int students_count)
    {
        if (students_count != 0)
        {
            Console.WriteLine("Введите класс: ");
            string cls = Console.ReadLine();

            for (int i = 0; i < students_count; i++)
            {
                if (students[i].Cls == cls)
                {
                    Console.WriteLine(students[i].ToString());
                }
            }
        }
        else
        {
            Console.WriteLine("В базе данных нет студентов");
        }
    }

    static void go_to_menu()
    {
        Console.WriteLine("\n");
        Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в меню: ");
        Console.ReadKey();
        show_menu();
    }

    static void Main()
    {
        const int max_students = 30;
        Student[] students = new Student[max_students];
        int students_count = 0;

        show_menu();

        while (true)
        {
            int action = Convert.ToInt32(Console.ReadLine());

            switch (action)
            {
                case 1:
                    Console.WriteLine("\n");
                    add_student(ref students, ref students_count);
                    go_to_menu();
                    break;
                case 2:
                    Console.WriteLine("\n");
                    select_be_year(students, students_count);
                    go_to_menu();
                    break;
                case 3:
                    Console.WriteLine("\n");
                    select_be_cls(students, students_count);
                    go_to_menu();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;

            }
        }

   
    }
}