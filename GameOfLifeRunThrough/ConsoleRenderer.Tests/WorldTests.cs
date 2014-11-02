using System.Linq;
using NUnit.Framework;

namespace ConsoleRenderer.Tests
{
    [TestFixture]
    public class WorldTests
    {
        [Test]
        public void Ctor_DoesntThrow()
        {
            var world = new GameState(0, 0, null);

            Assert.That(world, Is.Not.Null);
        }

        [Test]
        public void Ctor_CreatesUniverseOfCorrectDimensions()
        {
            var world = new GameState(4, 5, null);

            Assert.That(world.GameBoard.Count, Is.EqualTo(5));
            Assert.That(world.GameBoard.First().Count, Is.EqualTo(4));
        }

        [Test]
        public void Ctor_CellsCreatedDeadOrEmpty()
        {
            var world = new GameState(1, 1, null);

            Assert.That(world.GameBoard[0][0].State, Is.EqualTo(State.DeadOrEmpty));
        }

        [Test]
        public void Ctor_CellsCreatedKnowWhereTheyLive()
        {
            var world = new GameState(1, 2, null);

            Assert.That(world.GameBoard[1][0].Location.X, Is.EqualTo(0));
            Assert.That(world.GameBoard[1][0].Location.Y, Is.EqualTo(1));
        }

        [Test]
        public void Step_EvaluatesEachRule()
        {
            var fakeRule = new FakeRule();
            var world = new GameState(1, 1, fakeRule);

            world.Step();

            Assert.That(fakeRule.Called, Is.True);
        }
    }
}
