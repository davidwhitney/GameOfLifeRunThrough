using NUnit.Framework;

namespace ConsoleRenderer.Tests
{
    [TestFixture]
    public class GameBoardTests
    {
        [Test]
        public void GetCellAndNeighbours_ReturnsExpectedCell()
        {
            var gameboard = new GameBoard(3, 3);

            var cellAndNeighbours = gameboard.GetCellAndNeighbours(1, 1);

            Assert.That(cellAndNeighbours.Item1.Location.X, Is.EqualTo(1));
            Assert.That(cellAndNeighbours.Item1.Location.Y, Is.EqualTo(1));
        }

        [Test]
        public void GetCellAndNeighbours_ReturnsExpectedNeighbours()
        {
            var gameboard = new GameBoard(3, 3);

            var cellAndNeighbours = gameboard.GetCellAndNeighbours(1, 1);

            Assert.That(cellAndNeighbours.Item2.Count, Is.EqualTo(8));
            CollectionAssert.DoesNotContain(cellAndNeighbours.Item2, gameboard[1][1]);
        }

        [Test]
        public void GetCellAndNeighbours_WhenAtEdgeOfTheBoard_DoesntCrash()
        {
            var gameboard = new GameBoard(1, 1);

            var cellAndNeighbours = gameboard.GetCellAndNeighbours(0, 0);

            Assert.That(cellAndNeighbours.Item2.Count, Is.EqualTo(0));
            CollectionAssert.DoesNotContain(cellAndNeighbours.Item2, gameboard[0][0]);
        }
    }
}