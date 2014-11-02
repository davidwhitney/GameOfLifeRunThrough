using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleRenderer
{
    public class GameOfLifeRule : IRule
    {
        public State Evaluate(Location cellLocation, GameBoard board)
        {
            var selection = board.GetCellAndNeighbours(cellLocation);
            var rules = new Dictionary<Func<State, int, bool>, State>
            {
                {(state, lnc) => state == State.Alive && lnc < 2, State.DeadOrEmpty},
                {(state, lnc) => state == State.Alive && lnc > 3, State.DeadOrEmpty},
                {(state, lnc) => state == State.Alive && (lnc == 2 || lnc == 3), State.Alive},
                {(state, lnc) => state == State.DeadOrEmpty && lnc == 3, State.Alive},
                {(state, lnc) => state == State.DeadOrEmpty, State.DeadOrEmpty},
            };

            var match = rules.First(x => x.Key(selection.Cell.State, selection.LiveNeighbours));
            return match.Value;
        }
    }
}