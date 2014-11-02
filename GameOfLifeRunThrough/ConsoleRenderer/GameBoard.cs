using System.Collections.Generic;
using System.Linq;

namespace ConsoleRenderer
{
    public class GameBoard
    {
        private readonly List<List<Cell>> _storage;
 
        public int Width { get; private set; }
        public int Height { get; private set; }

        public GameBoard(int width, int height)
        {
            Width = width;
            Height = height;

            _storage = new List<List<Cell>>();
            for (var y = 0; y < height; y++)
            {
                var row = new List<Cell>(width);
                for (var x = 0; x < width; x++)
                {
                    row.Add(new Cell(x, y));
                }

                _storage.Add(row);
            }
        }
        
        public IEnumerable<List<Cell>> Rows
        {
            get { return _storage; }
        } 

        public IEnumerable<Cell> AllCells
        {
            get { return _storage.SelectMany(cells => cells); }
        } 

        public Cell CellAt(Location loc)
        {
            return CellAt(loc.X, loc.Y);
        }

        public Cell CellAt(int x, int y)
        {
            return _storage[y][x];
        }

        public void SetCellState(Location loc, State state)
        {
            CellAt(loc).State = state;
        }

        public void SetCellState(int x, int y, State state)
        {
            CellAt(x, y).State = state;
        }

        public CellLookup GetCellAndNeighbours(Location loc)
        {
            var cell = CellAt(loc);
            var neighbours = new List<Cell>();

            var lowerX = loc.X - 1;
            var lowerY = loc.Y - 1;
            var upperX = loc.X + 1;
            var upperY = loc.Y + 1;

            if (upperX >= _storage.First().Count)
            {
                upperX = _storage.First().Count - 1;
            }

            if (lowerX < 0)
            {
                lowerX = 0;
            }

            if (upperY >= _storage.Count)
            {
                upperY = _storage.Count - 1;
            }

            if (lowerY < 0)
            {
                lowerY = 0;
            }

            for (var xx = lowerX; xx <= upperX; xx++)
            {
                for (var yy = lowerY; yy <= upperY; yy++)
                {
                    var nCell = CellAt(xx, yy);
                    neighbours.Add(nCell);
                }
            }

            neighbours.RemoveAll(item => item.Location.X == loc.X && item.Location.Y == loc.Y);

            return new CellLookup(cell, neighbours);
        }
    }
}