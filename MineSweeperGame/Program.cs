using System;

namespace MineSweeperGame
{
    class Program
    {
        static void Main(string[] args)
        {
            MineSweeper mineSweeper = new MineSweeper(3);
            mineSweeper.LoadMines(new string[] { "A1", "A2", "B3", "B4" });
            //ToDo: Load numbers and empty squres need to be implemented
            mineSweeper.Play();
            Console.ReadLine();
        }
    }
}
