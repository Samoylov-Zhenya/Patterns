// Builder
// Строитель — это порождающий паттерн проектирования,
// который позволяет создавать сложные объекты пошагово.
// Строитель даёт возможность использовать один и тот же
// код строительства для получения разных представлений объектов.

var mba = new ManagerBuilderAviary();

Console.WriteLine(mba.GetSnowAndLion());



public class Aviary
{
    public IAnimal animal;
    public IWeather weather;
    public override string ToString()
    {
        return $"{animal} {weather}";
    }
}

public class ManagerBuilderAviary
{
    private BuilderAviary builderAviary;
    public ManagerBuilderAviary()
    {
        builderAviary = new BuilderAviary();
    }
    public Aviary GetSnowAndLion()
    {
        builderAviary.SetAnimal(true);
        builderAviary.SetWeather(false);
        return builderAviary.GetAviary();
    }
}

public class BuilderAviary
{
    private Aviary aviary;

    public BuilderAviary()
    {
        aviary = new Aviary();
    }
    public void SetAnimal(bool i)
    {
        if (i)
            aviary.animal = new Lion("L");
        else
            aviary.animal = new Jackal("J");
    }
    public void SetWeather(bool i)
    {
        if (i)
            aviary.weather = new Sunny();
        else
            aviary.weather = new Snow();
    }
    public Aviary GetAviary()
    {
        return aviary;
    }

}

public interface IWeather
{
    string Сondition { get; set; }
}
public class Sunny : IWeather
{
    public string Сondition{ get; set; }
    public Sunny()
    {
        Сondition = "Sunny";
    }
}
public class Snow : IWeather
{
    public string Сondition { get ; set; }
    public Snow()
    {
        Сondition = "Snow";
    }
}

public interface IAnimal
{
    string Name { get; set; }
    public string Go();
}
public class Lion : IAnimal
{
    public Lion(string str)
    {
        Name = str;
    }
    public string Name { get; set; }

    public string Go()
    {
        return "LionGo";
    }
}
public class Jackal : IAnimal
{
    public Jackal(string str)
    {
        Name = str;
    }
    public string Name { get; set; }

    public string Go()
    {
        return "JackalGo";
    }
}