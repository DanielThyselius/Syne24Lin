using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tests
{
    public class TestData
    {
        public static IEnumerable<object[]> SubtractionData()
        {
            // Here we can do whatever we want
            // Maybe get the values from a csv or database

            return new List<object[]> {
            new object[] {2, 1, 1},
            new object[] {2, 3, -1},
            new object[] {new Book() , 2, 0},
            new object[] {2, 0, 2},
            new object[] {0, 5, -5}
        };
        }
        public static IEnumerable<object[]> AdditionData => new List<object[]> {
            new object[] {2, 1, 3},
            new object[] {2, 3, 5},
            new object[] {2, 2, 4},
            new object[] {2, 0, 2},
            new object[] {0, 5, 5},
            new object[] {-0, -5, -5},
            new object[] {-2, -5, -7},
            new object[] {-3, 5, 2},
        };
    }
}
