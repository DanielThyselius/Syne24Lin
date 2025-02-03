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
        private readonly IDatabase _db;
        private readonly IDateTimeWrapper _timeWrapper;
        private float Discount => _timeWrapper.Now.DayOfWeek == DayOfWeek.Friday ? 25f : 0f;


        public ReceiptService(IDatabase database, IDateTimeWrapper timeWrapper)
        {
            _db = database;
            _timeWrapper = timeWrapper;
        }

        public float GetTotal(float price, float quantity)
        {
            return price * quantity * (1 - Discount / 100);
        }
        public float GetPrice(string item)
        {
            return _db.GetItemPrice(item);
        }

        public string CreateReceipt(string item, float quantity)
        {
            var price = GetPrice(item);
            var total = GetTotal(price, quantity);
            var format = new CultureInfo("sv-SE", false).NumberFormat;
            return $"""
                       ********************************
                       KVITTO
                       {item}({price}) x {quantity}
                       rabatt: {Discount.ToString("F2", format)}%
                       Total price: {total.ToString("F2", format)}:-
                       ~~~~~~~~~~~~~~~~~~~~~ 
                       {_timeWrapper.Now}
                       ********************************
                       """;
        }
    }
}
