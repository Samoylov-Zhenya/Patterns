//Фабричный метод — это порождающий паттерн проектирования,
//который определяет общий интерфейс для создания объектов
//в суперклассе, позволяя подклассам изменять
//тип создаваемых объектов.

new Aviary("Lion");
new Aviary("Jackal");
Console.WriteLine();



public class Aviary
{
    public Aviary(string i)
    {
        if (i == "Lion")
            animal = new ConcreteCreatorLion().FactoryMethod();
        else
            animal = new ConcreteCreatorJackal().FactoryMethod();

        Console.WriteLine(animal.Go());
    }
    IAnimal animal;
}


public interface IAnimal
{
    string Name { get; set; }
    public string Go();
}
public abstract class Creator
{
    public abstract IAnimal FactoryMethod();
}

public class ConcreteCreatorLion : Creator
{
    public override IAnimal FactoryMethod()
    {
        return new ConcreteProductLion();
    }
}
public class ConcreteProductLion : IAnimal
{
    public string Name { get; set; }

    public string Go()
    {
        return "LionGo";
    }
}
///////////////////////////////////////
public class ConcreteCreatorJackal : Creator
{
    public override IAnimal FactoryMethod()
    {
        return new ConcreteProductJackal();
    }
}
public class ConcreteProductJackal : IAnimal
{
    public string Name { get; set; }

    public string Go()
    {
        return "JackalGo";
    }
}
