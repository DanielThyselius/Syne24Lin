using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadCodeDemo
{
    public class ReceiptService
    {
        private Database db;
        private DateTime now;
        private float discount;
        private float price;
        private float quantity;
        private string item;

        public ReceiptService(Database database)
        {
            db = database;
            now = DateTime.Now;
            discount = now.DayOfWeek == DayOfWeek.Friday ? 25f : 0f;

            Console.WriteLine("Vad vill du köpa?");
            item = Console.ReadLine();
            price = db.GetItemPrice(item);

            Console.WriteLine("Hur många?");
            quantity = float.Parse(Console.ReadLine());
        }

        public float GetTotal()
        {
            return price * quantity * (1 - discount / 100);
        }

        public string CreateReceipt(float total)
        {
            var format = new CultureInfo("sv-SE", false).NumberFormat;
            return $"""
                       ********************************
                       KVITTO
                       {item}({price}) x {quantity}
                       rabatt: {discount.ToString("F2", format)}%
                       Total price: {total}:-
                       ~~~~~~~~~~~~~~~~~~~~~ 
                       {now}
                       ********************************
                       """;
        }
    }
}
