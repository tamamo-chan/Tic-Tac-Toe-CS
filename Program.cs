using System;

namespace TicTacToe 
{ 

    class TTTile
    {
        Player owner = null;
        public TTTile(Player s)
        {
            owner = s;
        }

        public Player getOwner()
        {
            return owner;
        }
    }

    class Player
    {
        string name;
        string sign;

        public Player(string s, string mark)
        {
            name = s;
            sign = mark;
        }

        public string getName()
        {
            return name;
        }
    }

    class TTTBoard
    {

        public static TTTile[,] board = new TTTile[3, 3];

        public void initialize()
        {
            int count = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Player test = new Player(null, count.ToString());
                    TTTile temp = new TTTile(test);
                    board[i, j] = temp;
                    count++;

                }
            }
        }
        
        public void printBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                Console.WriteLine($"{board[i, 0].getOwner().getName()}|{board[i, 1].getOwner().getName()}|{board[i, 2].getOwner().getName()}");
            }
        }

        static void setOwner(int i, int j, Player player)
        {
            TTTile tile = new TTTile(player);
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            TTTile[,] board = new TTTile[3, 3];

            int count = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Player test = new Player(null, count.ToString());
                    TTTile temp = new TTTile(test);
                    board[i, j] = temp;
                    count++;

                }
            }
            for (int i = 0; i < board.GetLength(0); i++)
            {
                Console.WriteLine($"{board[i, 0].getOwner().getName()}|{board[i, 1].getOwner().getName()}|{board[i, 2].getOwner().getName()}");
            }
        }
    }
}
