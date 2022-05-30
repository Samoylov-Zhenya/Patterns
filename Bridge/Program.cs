// Bridge
//Мост — это структурный паттерн проектирования,
//который разделяет один или несколько классов
//на две отдельные иерархии — абстракцию и реализацию,
//позволяя изменять их независимо друг от друга.
Console.WriteLine("Bridge\n\n");

Sender Sender = new EMALISender(new DataBD());
Sender.Send();
Sender.SetDataReader(new DataFile());
Sender.Send();
Console.WriteLine("\n\n");
Sender = new TGSender(new DataBD());
Sender.Send();
Sender.SetDataReader(new DataFile());
Sender.Send();





interface IDataReader
{
    void Read();
}
class DataBD : IDataReader
{
    public void Read()
    {
        Console.WriteLine("DataBD");
    }
}
class DataFile : IDataReader
{
    public void Read()
    {
        Console.WriteLine("DataFile");
    }
}

abstract class Sender
{
    protected IDataReader dataReader;
    public Sender(IDataReader dataReader)
    {
        this.dataReader = dataReader;
    }
    public void SetDataReader(IDataReader dataReader)
    {
        this.dataReader = dataReader;
    }
    public abstract void Send();
}
class EMALISender : Sender
{
    public EMALISender(IDataReader dataReader) : base(dataReader)
    {
    }
    public override void Send()
    {
        dataReader.Read();
        Console.WriteLine("Send EMALISender");
    }
}
class TGSender : Sender
{
    public TGSender(IDataReader dataReader) : base(dataReader)
    {
    }
    public override void Send()
    {
        dataReader.Read();
        Console.WriteLine("Send TGSender");
    }
}