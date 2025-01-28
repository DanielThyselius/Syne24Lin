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
    }
}
