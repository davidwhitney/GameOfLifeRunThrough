using System;
using System.Threading;

namespace ConsoleRenderer
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new GameState(20, 20, new GameOfLifeRule());
            game.Populate();

            /*game.GameBoard[0][2].State = State.Alive;
            game.GameBoard[1][2].State = State.Alive;
            game.GameBoard[2][2].State = State.Alive;
            game.GameBoard[2][1].State = State.Alive;
            game.GameBoard[1][0].State = State.Alive;*/


            for (var generation = 0; generation <= 50; generation++)
            {
                foreach (var row in game.GameBoard)
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

                Console.WriteLine("Generation: " + generation);
                Thread.Sleep(new TimeSpan(0, 0, 0, 1));
                
                if (generation <= 50)
                {
                    game.Step();
                    Console.Clear();
                }
            }

            Console.WriteLine("Game over");
            Console.ReadLine();
        }
    }
}
