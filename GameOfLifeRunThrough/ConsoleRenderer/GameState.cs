using System;
using System.Collections.Generic;

namespace ConsoleRenderer
{
    public class GameState
    {
        private readonly IRule _rule;

        public GameBoard GameBoard { get; private set; }
        public int Generation { get; private set; }

        public GameState(int width, int height, IRule rule)
        {
            _rule = rule;
            CreateUniverse(width, height);
        }

        private void CreateUniverse(int width, int height)
        {
            GameBoard = new GameBoard(width, height);
        }

        public void Step()
        {
            var newStates = new Dictionary<Location, State>();

            foreach (var row in GameBoard)
            {
                foreach (var cell in row)
                {
                    var result = _rule.Evaluate(cell.Location, GameBoard);
                    newStates.Add(cell.Location, result);
                }
            }

            foreach (var state in newStates)
            {
                GameBoard[state.Key.Y][state.Key.X].State = state.Value;
            }

            Generation++;
        }

        public void Populate()
        {
            var max = GameBoard.Width*GameBoard.Height;
            var alive = max/4;

            var rnd = new Random();

            for (var count = 0; count < alive; count++)
            {
                var x = rnd.Next(0, GameBoard.Width);
                var y = rnd.Next(0, GameBoard.Height);

                GameBoard[y][x].State = State.Alive;
            }
        }
    }
}
