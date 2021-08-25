using MineSweeperGame;
using NUnit.Framework;

namespace MineSweeperGameTest
{
    public class Tests
    {
        MineSweeper mineSweeper = new MineSweeper(3);

        [SetUp]
        public void Setup()
        {
            mineSweeper.LoadMines(new string[] { "A1", "A2", "B3", "B4" });
        }

        [TestCase("D3", "L", "C3")]
        [TestCase("D4", "R", "E4")]
        [TestCase("H5", "U", "H6")]
        [TestCase("A5", "D", "A4")]
        [TestCase("A3", "L", "")]
        [TestCase("H5", "R", "")]
        public void TestMove(string position, string moveDirection, string expectedPosition)
        {
            string resultingPosition = mineSweeper.Move(position, moveDirection);
            Assert.AreEqual(resultingPosition, expectedPosition);
        }

        [TestCase("A1", true)]
        [TestCase("B4", true)]
        [TestCase("C8", false)]
        public void TestMine(string position, bool expected)
        {
            bool hasmine = mineSweeper.HasMine(position);
            Assert.AreEqual(expected, hasmine);
        }
    }
}