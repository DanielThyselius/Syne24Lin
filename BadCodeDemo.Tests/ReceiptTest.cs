using Moq;
using System.Diagnostics;

namespace BadCodeDemo.Tests
{
    public class ReceiptTest
    {
        [Fact]
        public void UsesDiscountOnFriday()
        {
            // Arrange 
            var item = "Book";
            var quantity = 2;
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

            // setup mocks here
            var mockDb = new Mock<IDatabase>();
            mockDb.Setup(_ => _.GetItemPrice(It.IsAny<string>())).Returns(10);
            mockDb.Setup(_ => _.GetItemPrice("Book")).Returns(5);
            //mockDb.SetupProperty(x => x.Name);

            var mockTimeWrapper = new Mock<IDateTimeWrapper>();
            mockTimeWrapper.Setup(_ => _.Now).Returns(DateTime.Parse("2024-01-05 12:00:00"));
           
            // Create sut with mocks
            var sut = new ReceiptService(mockDb.Object, mockTimeWrapper.Object);

            // NEVER DO THIS! the sut cannot be a mock!
            // var sut = new Mock<ReceiptService>(mockDb.Object, mockTimeWrapper.Object);
            //sut.Setup(x => x.CreateReceipt(item, quantity)).Returns(expected);

            // Act
            var actual = sut.CreateReceipt(item, quantity);

            // Assert
            Assert.Equal(expected, actual); // state verification

            //mockDb.Verify(_ => _.GetItemPrice("Book"), Times.Once); // behaviour verification
        }
    }

    //public class TestTimeWrapper : IDateTimeWrapper
    //{
    //    // Always return 2024-01-01 12:00:00
    //    public DateTime Now => DateTime.Parse("2024-01-05 12:00:00");
    //}

}