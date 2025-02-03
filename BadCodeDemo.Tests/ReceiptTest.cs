using System.Diagnostics;

namespace BadCodeDemo.Tests
{
    public class ReceiptTest
    {
        [Fact]
        public void GeneratesReceiptProperly()
        {
            var item = "Book";
            var price = 10;
            var quantity = 2;
            var discount = 25;
            var total = 200;
            var now = DateTime.Now;
            // Arrange 
            var expected = $"""
                   ********************************
                   KVITTO
                   {item}({price}) x {quantity}
                   rabatt: 25,00%
                   Total price: {total}:-
                   ~~~~~~~~~~~~~~~~~~~~~ 
                   2024-01-01 12:00:00
                   ********************************
                   """;

            var sut = new ReceiptService();

            // Act
            var actual = sut.CreateReceipt(item, price, quantity, discount, total, now);
            

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculatesTotalRiceWithDiscount()
        {
            // TODO: How do we test total logic
            var item = "Book";
            var price = 10;
            var quantity = 2;
            var discount = 0;
            var total = 200;
            var now = DateTime.Now;
            // Arrange 
            var expected = $"""
                   ********************************
                   KVITTO
                   {item}({price}) x {quantity}
                   rabatt: {discount}%
                   Total price: {total}:-
                   ~~~~~~~~~~~~~~~~~~~~~ 
                   {now}
                   ********************************
                   """;

            var sut = new ReceiptService();

            // Act
            var actual = sut.CreateReceipt(item, price, quantity, discount, total, now);


            // Assert
            Assert.Equal(expected, actual);
        }
    }
}