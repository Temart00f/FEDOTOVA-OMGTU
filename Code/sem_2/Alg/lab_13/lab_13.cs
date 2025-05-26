using System;

public class Product(int id, string name)
{
    public int Id { get; } = id;
    public string Name { get; } = name;
}

public class Supplier(int id, string name)
{
    public int Id { get; } = id;
    public string Name { get; } = name;
}

public class Product_movement(int productId, int providerId, int count, bool isIncoming, double price, string date)
{
    public int ProductId { get; set; } = productId;
    public int ProviderId { get; set; } = providerId;
    public int Quantity { get; set; } = count;
    public bool IsIncoming { get; set; } = isIncoming;
    public double PricePerUnit { get; set; } = price;
    public string Date { get; set; } = date;
}

class Warehouse
{
    public static List<Product> Products { get; set; } = new();
    public static List<Supplier> Suppliers { get; set; } = new();
    public static List<Product_movement> Movements { get; set; } = new();

    static void Main()
    {
        Product product1 = new Product(1, "Product1");
        Product product2 = new Product(2, "Product2");

        Supplier supplier1 = new Supplier(1, "Supplier1");
        Supplier supplier2 = new Supplier(2, "Supplier2");

        Product_movement pm1 = new Product_movement
        (
            product1.Id,
            supplier1.Id,
            10,
           true,
            50000,
            "2023:4:5"
        );

        Product_movement pm2 = new Product_movement
        (
            product2.Id,
            supplier2.Id,
            5,
            true,
            15000,
            "2023:4:5"
        );

        Product_movement pm3 = new Product_movement
        (
            product1.Id,
            supplier2.Id,
            5,
            true,
            48000,
            "2023:4:6"
        );

        Product_movement pm4 = new ProductMovement
        (
            product1.Id,
            -1,
            8,
            false,
            100000,
            "2023:4:6"
        );

        Products.Add(product1);
        Products.Add(product2);

        Suppliers.Add(supplier1);
        Suppliers.Add(supplier2);

        Movements.Add(pm1);
        Movements.Add(pm2);
        Movements.Add(pm3);
        Movements.Add(pm4);

        bool work = true;

        while (work)
        {
            Console.WriteLine("\n1. ������������� ������ �� �����\n2. ������������ �� ����������, ������������� �� ����\n3. ������ ������� �� ������\n4. ����� ����� �������� �������\n5. ������� ������\n6. �����");

            int action = int.Parse(Console.ReadLine());

            switch (action)
            {
                case 1:
                    GetIncomingByDate();
                    break;
                case 2:
                    GetProvidersByDate();
                    break;
                case 3:
                    GetAllProducts();
                    break;
                case 4:
                    GetAllIncomingSum();
                    break;
                case 5:
                    GetAllIncome();
                    break;
                case 6:
                    work = false;
                    break;
            }
        }
    }
    public static void GetIncomingByDate()
    {
        var grouped = Movements
            .Where(m => m.IsIncoming)
            .GroupBy(m => m.Date);

        Console.WriteLine("����������� ��������������� �� ����:");
        foreach (var group in grouped)
        {
            Console.WriteLine($"����: {group.Key}");
            foreach (var m in group)
            {
                Console.WriteLine($"�����: {m.ProductId}, ����������: {m.Quantity}, ����: {m.PricePerUnit}");
            }
        }
    }

    public static void GetProvidersByDate()
    {
        var grouped = Movements
            .Where(m => m.IsIncoming && m.ProviderId != -1)
            .GroupBy(m => m.ProviderId);

        Console.WriteLine("����������� ��������������� �� ����������� � ����:");
        foreach (var group in grouped)
        {
            Console.WriteLine($"����: {group.Key}");
            foreach (var m in group)
            {
                Console.WriteLine($"���������: {m.ProviderId}, �����: {m.ProductId}");
            }
        }
    }

    public static void GetAllProducts()
    {
        Console.WriteLine("������� �� ������:");
        foreach (var product in Products)
        {
            int incoming = Movements.Where(m => m.ProductId == product.Id && m.IsIncoming).Sum(m => m.Quantity);
            int outgoing = Movements.Where(m => m.ProductId == product.Id && !m.IsIncoming).Sum(m => m.Quantity);
            int stock = incoming - outgoing;

            if (stock > 0)
            {
                Console.WriteLine($"{product.Name}: {stock} ����");
            }
        }
    }

    public static void GetAllIncomingSum()
    {
        var total = Movements
            .Where(m => !m.IsIncoming)
            .Sum(m => m.Quantity * m.PricePerUnit);
        Console.WriteLine($"����� ��������� ������ = {total}");
    }

    public static void GetAllIncome()
    {
        double profit = 0;

        var productGroups = Movements
            .GroupBy(m => m.ProductId);

        foreach (var group in productGroups)
        {
            var incoming = group.Where(m => m.IsIncoming).ToList();
            var outgoing = group.Where(m => !m.IsIncoming).ToList();

            double totalIncomingCost = incoming.Sum(m => m.Quantity * m.PricePerUnit);
            double totalOutgoingRevenue = outgoing.Sum(m => m.Quantity * m.PricePerUnit);

            profit += totalOutgoingRevenue - totalIncomingCost;
        }

        Console.WriteLine($"������� ������ = {profit} ���.");
    }
}