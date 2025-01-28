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

        [Theory]
        [MemberData(nameof(TestData.AdditionData), MemberType = typeof(TestData))]
        public void CanAddNumbers(float a, float b, float expected)
        {
            // Arrange 
            var sut = new Calculator();

            // Act
            var actual = sut.Add(a, b);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData.SubtractionData), MemberType = typeof(TestData))]
        [InlineData(float.MinValue, float.MaxValue, float.NegativeInfinity)]
        public void CanSubtractNumbers(float a, float b, float expected)
        {
            // Arrange 
            var sut = new Calculator();

            // Act
            var actual = sut.Subtract(a, b);

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
