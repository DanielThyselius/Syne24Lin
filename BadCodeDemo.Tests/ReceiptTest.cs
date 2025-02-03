using System.Diagnostics;

namespace BadCodeDemo.Tests
{
    public class ReceiptTest
    {
        [Fact]
        public void UsesDiscountOnFriday()
        {
            var item = "Book";
            var quantity = 2;

            // Arrange 
            var expected = $"""
                   ********************************
                   KVITTO
                   Book(5) x 2
                   rabatt: 25,00%
                   Total price: 7,50:-
                   ~~~~~~~~~~~~~~~~~~~~~ 
                   2024-01-05 12:00:00
                   ********************************
                   """;
            var db = new TestDb();
            var timeWrapper = new TestTimeWrapper();
            var sut = new ReceiptService(db, timeWrapper);

            // Act
            var actual = sut.CreateReceipt(item, quantity);


            // Assert
            Assert.Equal(expected, actual);
        }

        //[Fact]
        //public void CalculatesTotalRiceWithDiscount()
        //{
        //    // TODO: How do we test total logic
        //    var item = "Book";
        //    var price = 10;
        //    var quantity = 2;
        //    var discount = 0;
        //    var total = 200;
        //    var now = DateTime.Now;
        //    // Arrange 
        //    var expected = $"""
        //           ********************************
        //           KVITTO
        //           {item}({price}) x {quantity}
        //           rabatt: {discount}%
        //           Total price: {total}:-
        //           ~~~~~~~~~~~~~~~~~~~~~ 
        //           {now}
        //           ********************************
        //           """;
        //    var db = new TestDb();
        //    var sut = new ReceiptService(db);

        //    // Act
        //    var actual = sut.CreateReceipt(item, price, quantity, discount, total, now);


        //    // Assert
        //    Assert.Equal(expected, actual);
        //}
    }
    public class TestDb : IDatabase
    {
        public float GetItemPrice(string id)
        {
            switch (id)
            {
                case "Book":
                    return 5;
                default:
                    return 10;
            }
        }
    }

    public class TestTimeWrapper : IDateTimeWrapper
    {
        // Always return 2024-01-01 12:00:00
        public DateTime Now => DateTime.Parse("2024-01-05 12:00:00");
    }

}