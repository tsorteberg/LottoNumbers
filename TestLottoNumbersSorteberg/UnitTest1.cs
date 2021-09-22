using LottoNumbersSorteberg.Models;
using System;
using Xunit;

namespace TestLottoNumbersSorteberg
{
    public class UnitTest1
    {
        [Fact]
        public void TestValidObjectInput()
        {
            //ARRANGE
            Lotto n = new Lotto("5", "5", "5", "5");

            // ACT
            int expected1 = 5;
            int expected2 = 5;
            int expected3 = 5;
            int expected4 = 5;

            // ASSERT
            Assert.Equal(expected1, n.FirstNumber);
            Assert.Equal(expected2, n.SecondNumber);
            Assert.Equal(expected3, n.ThirdNumber);
            Assert.Equal(expected4, n.FourthNumber);
        }
        [Fact]
        public void TestInvalidObjectInput()
        {
            // ARRANGE
            string num1 = "a";
            string num2 = "5";
            string num3 = "5";
            string num4 = "5";

            // ACT
            //ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => new Lotto(num1, num2, num3, num4));
        }
        [Fact]
        public void TestInvalidObjectRange()
        {
            // ARRANGE
            string num1 = "73";
            string num2 = "5";
            string num3 = "5";
            string num4 = "5";

            // ACT
            //ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => new Lotto(num1, num2, num3, num4));
        }
        [Fact]
        public void TestInvalidWinningNumbersArraySize()
        {
            // ARRANGE
            Lotto n = new Lotto();
            int num1 = 5;
            int num2 = 5;
            int num3 = 5;


            // ACT
            // ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => n.WinningNumbers = new int[] { num1, num2, num3 });
        }
        [Fact]
        public void TestValidCheckTicketOne()
        {
            // ARRANGE
            Lotto n = new Lotto("5", "5", "5", "5");
            n.WinningNumbers = new int[] { 5, 6, 7, 8 };
            int expected = 1;
            int actual;

            // ACT
            actual = n.Compare();

            //ASSERT
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestValidCheckTicketTwo()
        {
            // ARRANGE
            Lotto n = new Lotto("5", "5", "5", "5");
            n.WinningNumbers = new int[] { 5, 5, 6, 7 };
            int expected = 2;
            int actual;

            // ACT
            actual = n.Compare();

            //ASSERT
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestValidCheckTicketThree()
        {
            // ARRANGE
            Lotto n = new Lotto("5", "5", "5", "5");
            n.WinningNumbers = new int[] { 5, 5, 5, 6 };
            int expected = 3;
            int actual;

            // ACT
            actual = n.Compare();

            //ASSERT
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestValidCheckTicketFour()
        {
            // ARRANGE
            Lotto n = new Lotto("5", "5", "5", "5");
            n.WinningNumbers = new int[] { 5, 5, 5, 5 };
            int expected = 4;
            int actual;

            // ACT
            actual = n.Compare();

            //ASSERT
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestDisplayTicket()
        {
            //ARRANGE
            Lotto n = new Lotto("5", "5", "5", "5");
            n.WinningNumbers = new int[] { 5, 5, 5, 5 };
            string expected = "{5,5,5,5}";
            string actual;

            // ACT
            actual = n.DisplayTicket();

            // ASSERT
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestOverrideToString()
        {
            // ARRANGE
            Lotto n = new Lotto("5", "5", "5", "5");
            n.WinningNumbers = new int[] { 5, 5, 5, 5 };
            string expected = "Winning Numbers: {5,5,5,5}, Ticket Numbers: 5,5,5,5, Matching Numbers: 4";
            string actual;

            //ACT
            actual = n.ToString();

            // ASSERT
            Assert.Equal(expected, actual);
        }
    }
}