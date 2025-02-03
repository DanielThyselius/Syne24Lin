// This is NOT how you should be coding!
namespace BadCodeDemo;
public class Program
{
    private static void Main(string[] args)
    {
        var db = new Database();
        var service = new ReceiptService(db);

        float total = service.GetTotal();
        var receipt = service.CreateReceipt(total);

        Console.WriteLine(receipt);
    }

}



public class Database
{
    // Let's pretend this actually connects to a database
    public float GetItemPrice(string id) => new Random().Next(1, 10);
}