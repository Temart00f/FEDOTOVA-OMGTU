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
            Console.WriteLine($"Машина {car.Name} уже помыта");
            return;
        }

        car.Wash = true;
        Console.WriteLine($"Машина {car.Name} была помыта");
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

        Console.Write("Введите количество машин: ");
        int count = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            Console.Write("Введите год выпуска: ");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите название: ");
            string name = Console.ReadLine();
            Console.Write("Машина помыта? (1/0 - да/нет): ");
            int wash = Convert.ToInt32(Console.ReadLine());

            Car car = new Car(year, name, Convert.ToBoolean(wash));
            garage.Cars.Add(car);
            Console.WriteLine($"Машина {i + 1} добавлена!");
        }

        for (int i = 0; i < garage.Cars.Count; i++)
        {
            wash_car(garage.Cars[i]);
        }
    }
}