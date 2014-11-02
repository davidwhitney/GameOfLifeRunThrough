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

        public Tuple<Cell, List<Cell>> GetCellAndNeighbours(int x, int y)
        {
            var cell = this[y][x];
            var neighbours = new List<Cell>();

            var lowerX = x - 1;
            var lowerY = y - 1;
            var upperX = x + 1;
            var upperY = y + 1;

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

            neighbours.RemoveAll(item => item.Location.X == x && item.Location.Y == y);

            return new Tuple<Cell, List<Cell>>(cell, neighbours);
        }
    }
}