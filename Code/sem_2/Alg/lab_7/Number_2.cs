using System;

class Cockroach
{
    public string name { get; set; }
    public double position { get; set; }

    public Cockroach(string name, double pos)
    {
        this.name = name;
        position = pos;
    }
}

delegate void Finish_handler(string name);

class Finish_event
{
    public event Finish_handler Event;

    public void On_event(string name)
    {
        if (Event != null)
            Event(name);
    }
}

class Finish_event_demo
{
    public static void Handler(string name)
    {
        Console.WriteLine($"{name} победил!\n");
        Environment.Exit(0);
    }
}

class Program
{
    static void Main()
    {
        Finish_event evt = new FinishEvent();
        evt.Event += Finish_event_demo.Handler;

        Random r = new Random();
        double finish = 100;

        List<Cockroach> racers = new List<Cockroach>();
        racers.Add(new Cockroach("Таракан Гоша", 0));
        racers.Add(new Cockroach("Таракан Андрюха", 0));
        racers.Add(new Cockroach("Таракан Анатолий", 0));

        for (; ; )
        {
            foreach (Cockroach cockroach in racers)
            {
                cockroach.position += r.NextDouble();

                if (cockroach.position > finish)
                    evt.OnEvent(cockroach.name);

            }
        }
    }
}