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

            foreach (var cell in GameBoard.AllCells)
            {
                var result = _rule.Evaluate(cell.Location, GameBoard);
                newStates.Add(cell.Location, result);
            }

            foreach (var state in newStates)
            {
                GameBoard.SetCellState(state.Key, state.Value);
            }

            Generation++;
        }
    }
}
