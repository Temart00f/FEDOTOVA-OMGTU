using System;

class Car
{
    public int Year;
    public string Name;
    public bool Wash;

    public Car(int year, string name, bool wash)
    {
        Year = year;
        Name = name;
        Wash = wash;
    }
}

class Garage
{
    public List<Car> Cars;
}

class CarWash
{
    public static void Wash(Car car)
    {
        if (car.Wash == true)
        {
            Console.WriteLine($"������ {car.Name} ��� ������");
            return;
        }

        car.Wash = true;
        Console.WriteLine($"������ {car.Name} ���� ������");
    }
}

delegate void Wash_car(Car car);
class Program
{
    static void Main()
    {
        Wash_car wash_car = new Wash_car(CarWash.Wash);

        Garage garage = new Garage();
        garage.Cars = new List<Car>();

        Console.Write("������� ���������� �����: ");
        int count = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            Console.Write("������� ��� �������: ");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.Write("������� ��������: ");
            string name = Console.ReadLine();
            Console.Write("������ ������? (1/0 - ��/���): ");
            int wash = Convert.ToInt32(Console.ReadLine());

            Car car = new Car(year, name, Convert.ToBoolean(wash));
            garage.Cars.Add(car);
            Console.WriteLine($"������ {i + 1} ���������!");
        }

        for (int i = 0; i < garage.Cars.Count; i++)
        {
            wash_car(garage.Cars[i]);
        }
    }
}