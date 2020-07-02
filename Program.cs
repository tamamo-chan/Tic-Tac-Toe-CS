using System;

namespace TicTacToe 
{ 

    class Tile
    {
        Player owner = null;
        public Tile(Player p)
        {
            owner = p;
        }

        public string GetOwner()
        {
            return owner.ID;
        }

        public void SetOwner(Player p)
        {
            owner = p;
        }
    }

    class Player
    {
        public string name;
        public string ID;

        public Player(string name, string ID)
        {
            this.name = name;
            this.ID = ID;
        }

        public string GetName()
        {
            return name;
        }
    }

    class Board
    {

        public static Tile[,] board = new Tile[3, 3];

        public Board()
        {
            int count = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Player test = new Player("Board", count.ToString());
                    Tile temp = new Tile(test);
                    board[i, j] = temp;
                    count++;

                }
            }
        }
        
        public void PrintBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                Console.WriteLine($"{board[i, 0].GetOwner()}|{board[i, 1].GetOwner()}|{board[i, 2].GetOwner()}");
            }
        }

        static void SetOwner(int i, int j, Player player)
        {
            Tile tile = new Tile(player);
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.PrintBoard();
            
            Player p1 = new Player("Player 1", "X");
            Player p2 = new Player("Player 2", "O");
        }
    }
}
