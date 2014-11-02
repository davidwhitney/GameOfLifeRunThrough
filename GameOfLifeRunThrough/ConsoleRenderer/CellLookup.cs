using System.Collections.Generic;
using System.Linq;

namespace ConsoleRenderer
{
    public class CellLookup
    {
        public Cell Cell { get; set; }
        public List<Cell> Neighbours { get; set; }

        public CellLookup(Cell cell, List<Cell> neighbours)
        {
            Cell = cell;
            Neighbours = neighbours;
        }

        public int LiveNeighbours
        {
            get { return Neighbours.Count(x => x.State == State.Alive); }
        }
    }
}