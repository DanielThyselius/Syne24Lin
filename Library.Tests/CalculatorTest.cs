using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tests
{
    public class CalculatorTest
    {
        [Fact]
        public void CanAddNumbers()
        {
            // Arrange 
             var sut = new Calculator();

            // Act
            var actual = sut.Add(1, 2);

            // Assert
            Assert.Equal(3, actual);
        }

        [Fact]
        public void CanSubtractNumbers()
        {
            // Arrange 
            var sut = new Calculator();
            var expected = 1;

            // Act
            var actual = sut.Subtract(3, 2);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanMultiplyFractions()
        {
            // Arrange 
            var sut = new Calculator();
            var expected = 6.4;

            // Act
            var actual = sut.Multiply(3.2f, 2);

            // Assert
            Assert.Equal(expected, actual, 5);
        }

    }
}
