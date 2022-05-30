// Flyweight
//Легковес — это структурный паттерн проектирования,
//который позволяет вместить бóльшее количество
//объектов в отведённую оперативную память. Легковес
//экономит память, разделяя общее состояние объектов
//между собой, вместо хранения одинаковых данных в
//каждом объекте.

using System.Collections;

Console.WriteLine("Flyweight\n\n");



public struct KindOfAnimal
{
    private string kind;
    private string animal;
    public KindOfAnimal(string Kind, string Animal)
    {
        kind = Kind;
        animal = Animal;
    }
    public string Kind { get => kind; }
    public string Animal { get => animal; }
}
public struct AnimalStruct
{
    public string Name { get; set; }
    public string Id { get; set; }
    public AnimalStruct(string name, string id)
    {
        Name = name;
        Id = id;
    }
}

public class Flyweight
{
    private KindOfAnimal _kindOfAnimal;
    public Flyweight (KindOfAnimal kindOfAnimal) => _kindOfAnimal = kindOfAnimal;
    public void Animal(AnimalStruct animalStruct)
    {
        Console.WriteLine("new animal: Id {0}\tName {1}", animalStruct.Id, animalStruct.Name);
    }
    public string GetData() => $"Kind {_kindOfAnimal.Kind}\tAnimal {_kindOfAnimal.Animal}";
}
public class FlyweightFactory
{
    private Hashtable Flyweights;

}