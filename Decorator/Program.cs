// Decorator 
//Декоратор — это структурный паттерн проектирования,
//который позволяет динамически добавлять объектам
//новую функциональность, оборачивая их в полезные «обёртки».


public abstract class Animal
{
    public abstract string Operation();
}

class AnimalGetUp : Animal
{
    public override string Operation()
    {
        return "Animal встал";
    }
}

abstract class Decorator : Animal
{
    protected Animal _component;

    public Decorator(Animal component)
    {
        this._component = component;
    }

    public void SetComponent(Animal component)
    {
        this._component = component;
    }

    public override string Operation()
    {
        if (this._component != null)
        {
            return this._component.Operation();
        }
        else
        {
            return string.Empty;
        }
    }
}

class DecoratorGo : Decorator
{
    public DecoratorGo(Animal comp) : base(comp)
    {
    }
    public override string Operation()
    {
        return $"пройтись ({base.Operation()})";
    }
}

class DecoratorJump : Decorator
{
    public DecoratorJump(Animal comp) : base(comp)
    {
    }

    public override string Operation()
    {
        return $"прыгнуть ({base.Operation()})";
    }
}

public class Client
{
    public void ClientCode(Animal component)
    {
        Console.WriteLine("ret: " + component.Operation());
    }
}

class Program
{
    static void Main(string[] args)
    {
        var client = new Client();

        var simple = new AnimalGetUp();
        client.ClientCode(simple);
        Console.WriteLine();


        var decorator1 = new DecoratorGo(simple);
        var decorator2 = new DecoratorJump(decorator1);
        client.ClientCode(decorator2);
    }
}