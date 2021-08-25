using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperGame
{
    public class MineSweeper
    {
        int NoOfLives;
        Dictionary<string, Square> blocks = new Dictionary<string, Square>();

        //Create board
        //ToDo - x,y cordinates need be implemented via the constructor
        public MineSweeper(int noOfLives)
        {
            for (int j = 8; j >= 1; j--)
            {
                for (char ch = 'A'; ch <= 'H'; ch++)
                {
                    Console.Write("\t" + ch.ToString() + j.ToString());
                    blocks.Add(ch.ToString() + j.ToString(), new Square());
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }
            this.NoOfLives = noOfLives;
        }

        //Loading mines randomly among squares
        public void LoadMines(int noOfMines)
        {
            //No of mines exceeded squares in board?
            if (noOfMines > blocks.Count)
            {
                throw new Exception("No of mines exceeded!");
            }
            int mineListCounter_i = 0;
            List<string> blockKeyList = new List<string>(blocks.Keys);
            while (mineListCounter_i <= noOfMines)
            {
                Random random = new Random();
                string randomKey = blockKeyList[random.Next(blockKeyList.Count)];
                Square block = blocks[randomKey];
                if (!block.HasMine)
                {
                    block.HasMine = true;
                    mineListCounter_i++;
                }
            }
        }

        //Load mines manually using squre reference(xy cordinares example - A1)
        public void LoadMines(String[] mineReferences)
        {
            if (mineReferences == null)
            {
                throw new Exception("Mine references cannot be empty");
            }
            for (int i = 0; i <= mineReferences.Length - 1; i++)
            {
                if (!blocks.ContainsKey(mineReferences[i]))
                {
                    throw new Exception("Mine reference not found");
                }
                Square block = blocks[mineReferences[i]];
                block.HasMine = true;
            }
        }


        public string Move(string position, string moveDirection)
        {
            String result = "";
            char mychar = '\0';
            switch (moveDirection)
            {
                case "L":
                    mychar = Convert.ToChar(position.Substring(0, 1));
                    mychar = (char)(((int)mychar) - 1);
                    result = string.Concat(mychar.ToString(), position.Substring(1));
                    break;
                case "R":
                    mychar = Convert.ToChar(position.Substring(0, 1));
                    mychar = (char)(((int)mychar) + 1);
                    result = string.Concat(mychar.ToString(), position.Substring(1));
                    break;
                case "U":
                    result = position.Substring(0, 1) + (Int32.Parse(position.Substring(1)) + 1).ToString();
                    break;
                case "D":
                    result = position.Substring(0, 1) + (Int32.Parse(position.Substring(1)) - 1).ToString();
                    break;
                default: break;
            }
            return result;
        }

        public bool HasMine(string position)
        {
            bool hasMine = false;
            if (blocks.ContainsKey(position))
            {
                if (blocks[position].HasMine)
                {
                    hasMine = true;
                }
            }
            return hasMine;
        }

            //Play game
            //ToDo: split into different methods for robust testing
        public void Play()
        {
            bool alive = true;
            string position = "";
            int noOfMoves = 0;
            int noOfLivesLeft = this.NoOfLives;

            string positionStartY = "0";
            string positionEndY = "0";
            do
            {
                Console.WriteLine("Enter starting position from the above grid? Entries must be inbetween A1 to H1?");
                position = Console.ReadLine();
                positionStartY = position.Substring(1);
            } while (positionStartY != "1");

            while (alive)
            {
                Console.WriteLine("Enter move L(Left) or R(Right) or U(Up) or D(Down)?");
                string move = Console.ReadLine();
                string result = Move(position, move);
                if (HasMine(result))
                {
                   noOfLivesLeft--;
                }
                noOfMoves++;
                Console.WriteLine("Resulting position " + result);
                Console.WriteLine("No of moves " + noOfMoves);
                Console.WriteLine("No of lives left " + noOfLivesLeft);
                position = result;
                positionEndY = position.Substring(1);
                if (positionEndY == "8")
                {
                    Console.WriteLine("Congratulations! You won.");
                    break;
                }
                if (noOfLivesLeft == 0)
                {
                    Console.WriteLine("Please try again!");
                    break;
                }

            }
        }

    }
}
