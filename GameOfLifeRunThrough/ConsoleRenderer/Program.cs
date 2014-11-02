using System;
using System.Threading;

namespace ConsoleRenderer
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new GameState(50, 20, new GameOfLifeRule());
            game.Populate();

            /*game.GameBoard[0][2].State = State.Alive;
            game.GameBoard[1][2].State = State.Alive;
            game.GameBoard[2][2].State = State.Alive;
            game.GameBoard[2][1].State = State.Alive;
            game.GameBoard[1][0].State = State.Alive;*/

            while(true)
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

                Console.WriteLine("Generation: " + game.Generation);
                Thread.Sleep(new TimeSpan(0, 0, 0, 0, 100));

                game.Step();
                Console.Clear();
            }
        }
    }
}
