using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            var newStates = new ConcurrentDictionary<Location, State>();
            var tasks = new List<Task>();

            foreach (var cell in GameBoard.AllCells)
            {
                var cell1 = cell;
                var t = Task.Factory.StartNew(() =>
                {
                    var result = _rule.Evaluate(cell1.Location, GameBoard);
                    newStates.AddOrUpdate(cell1.Location, result, (location, state) => result);
                });
                tasks.Add(t);
            }

            Task.WaitAll(tasks.ToArray());

            foreach (var state in newStates)
            {
                GameBoard.SetCellState(state.Key, state.Value);
            }

            Generation++;
        }
    }
}
