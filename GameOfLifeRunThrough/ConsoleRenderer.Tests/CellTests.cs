using NUnit.Framework;

namespace ConsoleRenderer.Tests
{
    [TestFixture]
    public class CellTests
    {
        [Test]
        public void Ctor_State_IsDeadOrEmpty()
        {
            var cell = new Cell(0, 0);

            Assert.That(cell.State, Is.EqualTo(State.DeadOrEmpty));
        }

        [Test]
        public void Ctor_Location_IsCorrect()
        {
            var cell = new Cell(1, 5);

            Assert.That(cell.Location.X, Is.EqualTo(1));
            Assert.That(cell.Location.Y, Is.EqualTo(5));
        }
    }
}