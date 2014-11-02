using System;
using System.Threading;

namespace ConsoleRenderer
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new GameState(50, 20, new GameOfLifeRule());
            Populate(game.GameBoard);

            //game.GameBoard.SetCellState(2, 0, State.Alive);
            //game.GameBoard.SetCellState(2, 1, State.Alive);
            //game.GameBoard.SetCellState(2, 2, State.Alive);
            //game.GameBoard.SetCellState(1, 2, State.Alive);
            //game.GameBoard.SetCellState(0, 1, State.Alive);

            while(true)
            {
                foreach (var row in game.GameBoard.Rows)
                {
                    foreach (var cell in row)
                    {
                        if (cell.State == State.Alive)
                        {
                            Console.Write("☻");
                        }
                        if (cell.State == State.DeadOrEmpty)
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.Write(Environment.NewLine);
                }

                Console.WriteLine("Generation: " + game.Generation);
                Thread.Sleep(new TimeSpan(0, 0, 0, 0, 100));

                game.Step();
                Console.SetCursorPosition(0,0);
            }
        }

        public static void Populate(GameBoard board)
        {
            var max = board.Width * board.Height;
            var alive = max / 4;

            var rnd = new Random();

            for (var count = 0; count < alive; count++)
            {
                var x = rnd.Next(0, board.Width);
                var y = rnd.Next(0, board.Height);

                board.SetCellState(new Location(x, y), State.Alive);
            }
        }
    }
}
