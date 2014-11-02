using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleRenderer
{
    public class GameBoard : List<List<Cell>>
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public GameBoard(int width, int height)
        {
            Width = width;
            Height = height;
            for (var y = 0; y < height; y++)
            {
                var row = new List<Cell>(width);
                for (var x = 0; x < width; x++)
                {
                    row.Add(new Cell(x, y));
                }

                Add(row);
            }
        }

        public CellAndNeighbours GetCellAndNeighbours(Location loc)
        {
            var cell = this[loc.Y][loc.X];
            var neighbours = new List<Cell>();

            var lowerX = loc.X - 1;
            var lowerY = loc.Y - 1;
            var upperX = loc.X + 1;
            var upperY = loc.Y + 1;

            if (upperX >= this.First().Count)
            {
                upperX = this.First().Count - 1;
            }

            if (lowerX < 0)
            {
                lowerX = 0;
            }

            if (upperY >= Count)
            {
                upperY = Count - 1;
            }

            if (lowerY < 0)
            {
                lowerY = 0;
            }

            for (var xx = lowerX; xx <= upperX; xx++)
            {
                for (var yy = lowerY; yy <= upperY; yy++)
                {
                    var nCell = this[yy][xx];
                    neighbours.Add(nCell);
                }
            }

            neighbours.RemoveAll(item => item.Location.X == loc.X && item.Location.Y == loc.Y);

            return new CellAndNeighbours(cell, neighbours);
        }

        public class CellAndNeighbours
        {
            public Cell Cell { get; set; }
            public List<Cell> Neighbours { get; set; }

            public CellAndNeighbours(Cell cell, List<Cell> neighbours)
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
}