using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tests
{
    public class BookTest
    {
        [Fact]
        public void CreateBooking()
        {
            // Arrange
            var sut = new Book();
            var expected = "John";
            // Act
            sut.CreateBooking(expected);

            // Assert
            Assert.False(sut.IsAvailable);
            Assert.Equal(expected, sut.BookedBy);
        }

        [Fact]
        public void CreateBookingNeedsName()
        {
            // Arrange
            var sut = new Book();
            var expected = "";
            // Act
            sut.CreateBooking(expected);

            // Assert
            Assert.True(sut.IsAvailable);
            Assert.Null(sut.BookedBy);
        }

        [Fact]
        public void CreateBookingNeedsString()
        {
            // Arrange
            var sut = new Book();

            // Act
            sut.CreateBooking(null);

            // Assert
            Assert.True(sut.IsAvailable);
            Assert.Null(sut.BookedBy);
        }

        [Fact]
        public void CancelBooking()
        {
            // Arrange
            var sut = new Book();
            sut.CreateBooking("John");

            // Act
            sut.CancelBooking();

            // Assert
            Assert.True(sut.IsAvailable);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(21, 0)]
        [InlineData(20, 0)]
        [InlineData(22, 10)]
        [InlineData(31, 100)]
        [InlineData(51, 300)]
        [InlineData(52, 300)]
        public void LateFeeCalculatesCorrectly( int days, int expected)
        {
            // Låneperiod: 21 dagar
            // Förseningsavgift: 10 kr / dag
            // Maxavgift: 300 kr(30 + dagar)

            // Arrange
            var book = new Book()
            {
                Name = "Test"
            };
            var actual = 0;

            // Act
            if (book is IBookable sut)
            {
                actual = sut.GetLateFee(days);
            }

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
