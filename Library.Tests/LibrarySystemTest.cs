using Library.Tests.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tests
{
    public class LibrarySystemTest : IClassFixture<LibraryFixture>
    {
        private LibrarySystem _sut;

        public LibrarySystemTest(LibraryFixture fixture)
        {
            _sut = fixture.Library;
        }

        [Fact]
        public void HasDemoResources()
        {
            // Arrange
            // Act
            // Assert
            Assert.NotEmpty(_sut.Resources);
            Assert.Equal(4, _sut.Resources.Count);
        }

        [Fact]
        public void CreateBooking()
        {
            // Arrange
            var expected = "John";

            // Act
            var actual = _sut.BookResource(1, expected);
            var resource = _sut.GetResource(1);

            // Assert
            Assert.True(actual);
            Assert.Equal(expected, resource.BookedBy);
            Assert.False(resource.IsAvailable);
        }

        [Fact]
        public void CreateBookingNeedsName()
        {
            // Arrange
            var expected = "";

            // Act
            var actual = _sut.BookResource(1, expected);
            var resource = _sut.GetResource(1);

            // Assert
            Assert.False(actual);
            Assert.Null(resource.BookedBy);
            Assert.True(resource.IsAvailable);
        }

        [Fact]
        public void CreateBookingNeedsString()
        {
            // Arrange
            // Act
            var actual = _sut.BookResource(1, null);
            var resource = _sut.GetResource(1);

            // Assert
            Assert.False(actual);
            Assert.Null(resource.BookedBy);
            Assert.True(resource.IsAvailable);
        }

        [Fact]
        public void CancelBooking()
        {
            // Arrange
            _sut.BookResource(1, "John");

            // Act
            var actual = _sut.CancelBooking(1);
            var resource = _sut.GetResource(1);

            // Assert
            Assert.True(actual);
            Assert.True(resource.IsAvailable);
            Assert.Null(resource.BookedBy);
        }
    }
}
