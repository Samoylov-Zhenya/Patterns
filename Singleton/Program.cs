//Singleton
//Одиночка — это порождающий паттерн проектирования,
//который гарантирует, что у класса есть только один
//экземпляр, и предоставляет к нему глобальную точку доступа.

Console.WriteLine(Aviary.c);
var a1 = Aviary.Initalize();
Console.WriteLine(a1.GetHashCode());
Console.WriteLine(Aviary.c);
var a2 = Aviary.Initalize();
Console.WriteLine(a2.GetHashCode());

Console.WriteLine(Aviary.c);
Console.WriteLine(Aviary.c);


public class Aviary
{
    private static Aviary aviary = null;
    protected Aviary(){
        ++c;
    }
    public static int c = 0;
    public static Aviary Initalize()
    {
        if (aviary == null)
            aviary = new Aviary();
        else
            throw new Exception();
        
        return aviary;
    }
}