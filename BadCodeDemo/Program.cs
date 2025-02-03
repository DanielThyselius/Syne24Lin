// This is NOT how you should be coding!
using System.Diagnostics;

namespace BadCodeDemo;
public class Program
{
    private static void Main(string[] args)
    {
        var db = new Database();
        var timeWrapper = new DateTimeWrapper();
        var service = new ReceiptService(db, timeWrapper);

        Console.WriteLine("Vad vill du köpa?");
        var item = Console.ReadLine();
        

        Console.WriteLine("Hur många?");
        var quantity = float.Parse(Console.ReadLine());

        var receipt = service.CreateReceipt(item, quantity);

        Console.WriteLine(receipt);
    }

}

public interface IDatabase
{
    float GetItemPrice(string id);
}

public class Database : IDatabase
{
    // Let's pretend this actually connects to a database
    public float GetItemPrice(string id) => new Random().Next(1, 10);
}