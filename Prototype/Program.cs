// Prototype
//Прототип — это порождающий паттерн проектирования,
//который позволяет копировать объекты, не вдаваясь
//в подробности их реализации.


public class Lion
{
    public int Age;
    public DateTime BirthDate;
    public string Name;
    public IdInfo IdInfo;

    public Lion ShallowCopy()
    {
        return (Lion)this.MemberwiseClone();
    }

    public Lion DeepCopy()
    {
        Lion clone = (Lion)this.MemberwiseClone();
        clone.IdInfo = new IdInfo(IdInfo.IdNumber);
        clone.Name = String.Copy(Name);
        return clone;
    }
    public override string ToString()
    {
        return
            $"Name: {Name}, \t" +
            $"Age: {Age}, \t" +
            $"BirthDate: {BirthDate.ToString("MM/dd/yy")} \t" +
            $"ID#: {IdInfo.IdNumber}\n";
    }
}

public class IdInfo
{
    public int IdNumber;

    public IdInfo(int idNumber)
    {
        IdNumber = idNumber;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Lion l1 = new Lion()
        {
            Age = 42,
            BirthDate = Convert.ToDateTime("2003-03-03"),
            Name = "xypma",
            IdInfo = new IdInfo(333),
        };

        // поверхностное копирование
        Lion l2 = l1.ShallowCopy();
        // глубокое копирование
        Lion l3 = l1.DeepCopy();

        // Вывести значения p1, p2 и p3.
        Console.WriteLine("Original");
        Console.Write(l1);
        Console.Write(l2);
        Console.Write(l3);

        // Изменить значение свойств p1 и отобразить значения p1, p2 и p3.
        l1.Age = 32;
        l1.BirthDate = Convert.ToDateTime("2000-01-01");
        l1.Name = "xypma42";
        l1.IdInfo.IdNumber = 4242;
        Console.WriteLine("\nValues");
        Console.Write(l1);
        Console.Write(l2);
        Console.Write(l3);
    }
}