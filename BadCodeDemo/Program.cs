// This is NOT how you should be coding!

var db = new Database();
var now = DateTime.Now;
var discount = (now.DayOfWeek == DayOfWeek.Friday) ? 25f : 0f;
Console.WriteLine("Vad vill du köpa?");
var item = Console.ReadLine();
var price = db.GetItemPrice(item);
Console.WriteLine("Hur många?");
var quantity = float.Parse(Console.ReadLine());



var total = price * quantity * (1 - (discount / 100));

Console.WriteLine($"""
                   ********************************
                   KVITTO
                   {item}({price}) x {quantity}
                   rabatt: {discount}%
                   Total price: {total}:-
                   ~~~~~~~~~~~~~~~~~~~~~ 
                   {now}
                   ********************************
                   """);




public class Database
{
    // Let's pretend this actually connects to a database
    public float GetItemPrice(string id) => new Random().Next(1, 10);
}