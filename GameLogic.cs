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

        public Player GetPlayer()
        {
            return owner;
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

        public Tile[,] board = new Tile[3, 3];

        public Board()
        {
            int count = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Player test = new Player(null, count.ToString());
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

        public void SetOwner(int i, int j, Player player)
        {
            Tile tile = new Tile(player);
            board[i, j] = tile;
        }
    }



    class GameLogic
    {
        static public int turn = 1;

        static public Player p1 = new Player("Player 1", "X");
        static public Player p2 = new Player("Player 2", "O");

        static private Player GetPlayer(int i)
        {
            if (i.Equals(1))
            {
                return p1;
            }
            else return p2;
        }

        static bool ValidChoice(Tile t)
        {
            if (t.GetPlayer().name == null)
            {
                return true;
            }
            return false;
        }

        static Player CheckWinner(Board b)
        {
            for (int i = 0; i < b.board.GetLength(0); i++)
            {
                // Horizontal check
                if (String.Equals(b.board[i, 0].GetOwner(), b.board[i, 1].GetOwner()) & String.Equals(b.board[i, 2].GetOwner(), b.board[i, 0].GetOwner()))
                {
                    return b.board[i, 0].GetPlayer();
                }
                // Vertical check
                if (String.Equals(b.board[0, i].GetOwner(), b.board[1, i].GetOwner()) & String.Equals(b.board[2, i].GetOwner(), b.board[0, i].GetOwner()))
                {
                    return b.board[i, 0].GetPlayer();
                }

            }
            // Top left to bottom right diagonal
            if (String.Equals(b.board[0, 0].GetOwner(), b.board[1, 1].GetOwner()) & String.Equals(b.board[2, 2].GetOwner(), b.board[0, 0].GetOwner()))
            {
                return b.board[0, 0].GetPlayer();
            }

            // Top right to bottom left diagonal
            if (String.Equals(b.board[0, 2].GetOwner(), b.board[1, 1].GetOwner()) & String.Equals(b.board[2, 0].GetOwner(), b.board[0, 2].GetOwner()))
            {
                return b.board[0, 2].GetPlayer();
            }
            return null;
        }

        static private void NewTurn(Board b)
        {
            Player current = GetPlayer(turn % 2);
            Console.WriteLine($"{current.name}'s turn.");
            Console.WriteLine("Please write the number of the tile you want to occupy: ");
            string input = Console.ReadLine();
            int number;

            bool success = int.TryParse(input, out number);

            if (!success | number < 1 | number > 9)
            {
                Console.WriteLine("You did not enter a correct number, try again.");
                NewTurn(b);
                return;
            }


            int column = (number - 1) % 3;

            int row = (number - 1) / 3;

            if (column < 0)
            {
                column = 0;
            }

            Tile t = b.board[row, column];

            if (ValidChoice(t))
            {
                b.SetOwner(row, column, GetPlayer(turn % 2));
            }
            else
            {
                Console.WriteLine("You did not enter a correct number, try again.");
                NewTurn(b);
                return;
            }

            b.PrintBoard();
            Console.WriteLine();

            Player winner = CheckWinner(b);

            if (winner != null)
            {
                Console.WriteLine($"The winner is {winner.name}");
                return;
            }
            turn++;
            NewTurn(b);


        }

        static void StartGame()
        {
            Board board = new Board();
            board.PrintBoard();
            Console.WriteLine();
            NewTurn(board);

        }

        static void Main(string[] args)
        {
            StartGame();
        }
    }
}
