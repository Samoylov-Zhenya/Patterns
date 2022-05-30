// Facade
// Фасад — это структурный паттерн проектирования,
// который предоставляет простой интерфейс к сложной
// системе классов, библиотеке или фреймворку.

Console.WriteLine("Facade \n\n");
var zoo = new ZOO();
zoo.AnimalAdd();
Console.WriteLine("\n\n");
zoo.AnimalDel();


class Animal
{
    public void BringAnimal()
      => Console.WriteLine("Bring Animal");
    public void BuyAnimal()
    => Console.WriteLine("Buy Animal");
}
class Aviary
{
    public void AddAnimal()
    => Console.WriteLine("Add AviaryAnimal");
    public void DelAnimal()
    => Console.WriteLine("Del AviaryAnimal"); 
}
class BD
{
    public void InsertAnimal()
   => Console.WriteLine("Insert BDAnimal");
    public void DelAnimal()
   => Console.WriteLine("Del BDAnimal");
}

class ZOO
{
    private Animal animal ;
    private Aviary aviary;
    private BD bd;

    public ZOO()
    {
        animal = new Animal();
        aviary = new Aviary();
        bd = new BD();
    }
    public void AnimalAdd()
    {
        animal.BringAnimal();
        aviary.AddAnimal();
        bd.InsertAnimal();
    }
    public void AnimalDel()
    {
        animal.BuyAnimal();
        aviary.DelAnimal();
        bd.DelAnimal();
    }
}
