// Adapter   
//Адаптер — это структурный паттерн проектирования,
//который позволяет объектам с несовместимыми
//интерфейсами работать вместе.

//var l1 = new Lion1()
//{
//    Age = 42,
//    BirthDate = Convert.ToDateTime("2003-03-03"),
//    Name = "xypma",
//};
Provider1 provider1 = new  Provider1();
var controller = new Controller(provider1);
controller.F();

var adapter = new Lion2To1Adapter(new Provider2());
var controller2 = new Controller(adapter);
controller2.F();

public interface ILionProvider1
{
    public Lion1 GetLion1();
}
public interface ILionProvider2
{
    public Lion2 GetLion2();
}

public class Provider1 : ILionProvider1
{
    public Provider1()
    {
    }
    public Lion1 GetLion1()
    {
        var l1 = new Lion1()
        {
            Age = 42,
            BirthDate = Convert.ToDateTime("2003-03-03"),
            Name = "xypma",
        };
        return l1;
    }
}
public class Provider2 : ILionProvider2
{
    public Lion2 GetLion2()
    {
        var l2 = new Lion2()
        {
            Nickname = "myrca",
            Year = 44
        };
        return l2;
    }
}
public class Lion2To1Adapter : ILionProvider1
{
    public ILionProvider2 LionProvider2 { get;  }
    
    public Lion2To1Adapter(ILionProvider2 lionProvider2)
    {
        LionProvider2 = lionProvider2;
    }

    public Lion1 GetLion1()
    {
        var model = LionProvider2.GetLion2();
        var l1 =new Lion1()
        {
            Age= model.Year,
            Name = model.Nickname
        };

        return l1;
    }
}
public class Controller
{

    public ILionProvider1 LionProvider1 { get; }

    public Controller(ILionProvider1 lionProvider1)
    {
        LionProvider1 = lionProvider1;
    }

    public void F()
    {
        var Line1 = LionProvider1.GetLion1();
    }
}
public class Lion1 
{
    public int Age;
    public DateTime BirthDate;
    public string Name;

    public override string ToString()
    {
        return
            $"Name: {Name}, \t" +
            $"Age: {Age}, \t" +
            $"BirthDate: {BirthDate.ToString("MM/dd/yy")} \n";
    }
}
public class Lion2
{
    public int Year;
    public string Nickname;

    public override string ToString()
    {
        return
            $"Name: {Nickname}, \t" +
            $"Year: {Year}, \n";
    }
}

//public class AdapterLion1ToLion2
//{
//    public Lion2 f(Lion1 lion1)
//    {
//        if (lion1 == null)
//            return null;
//        var l2 = new Lion2()
//        {
//            Year = lion1.Age,
//            Nickname = lion1.Name,
//        };
//        return l2;
//    }
//}