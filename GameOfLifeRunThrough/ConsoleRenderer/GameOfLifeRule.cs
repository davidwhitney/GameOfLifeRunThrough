using System.Linq;

namespace ConsoleRenderer
{
    public class GameOfLifeRule : IRule
    {
        public State Evaluate(Location cellToEvaluate, GameBoard board)
        {
            var cellAndNeighbours = board.GetCellAndNeighbours(cellToEvaluate.X, cellToEvaluate.Y);
            var liveNeighbours = cellAndNeighbours.Item2.Count(x => x.State == State.Alive);

            switch (cellAndNeighbours.Item1.State)
            {
                case State.Alive:
                    if (liveNeighbours < 2)
                    {
                        return State.DeadOrEmpty;
                    }
                    else if (liveNeighbours == 2)
                    {
                        return State.Alive;
                    }
                    else if (liveNeighbours == 3)
                    {
                        return State.Alive;
                    }
                    else if (liveNeighbours > 3)
                    {
                        return State.DeadOrEmpty;
                    }
                    break;
                case State.DeadOrEmpty:
                    if (liveNeighbours == 3)
                    {
                        return State.Alive;
                    }
                    break;
            }

            return State.DeadOrEmpty;
        }
    }
}