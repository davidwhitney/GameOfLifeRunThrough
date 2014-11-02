using NUnit.Framework;

namespace ConsoleRenderer.Tests
{
    [TestFixture]
    public class GameOfLifeRuleTests
    {
        private GameBoard _gb;
        private GameOfLifeRule _rule;

        [SetUp]
        public void SetUp()
        {
            _gb = new GameBoard(3, 3);
            _rule = new GameOfLifeRule();
        }

        [Test]
        public void Evaluate_Alive_LessThanTwoLiveNeighbours_Dies()
        {
            _gb[1][1].State = State.Alive;

            var state = _rule.Evaluate(new Location(1, 1), _gb);

            Assert.That(state, Is.EqualTo(State.DeadOrEmpty));
        }

        [Test]
        public void Evaluate_Alive_TwoLiveNeighbours_Alive()
        {
            _gb[1][1].State = State.Alive;
            
            _gb[0][1].State = State.Alive;
            _gb[0][2].State = State.Alive;

            var state = _rule.Evaluate(new Location(1, 1), _gb);

            Assert.That(state, Is.EqualTo(State.Alive));
        }

        [Test]
        public void Evaluate_Alive_ThreeLiveNeighbours_Alive()
        {
            _gb[1][1].State = State.Alive;
            
            _gb[0][1].State = State.Alive;
            _gb[0][2].State = State.Alive;
            _gb[1][2].State = State.Alive;

            var state = _rule.Evaluate(new Location(1, 1), _gb);

            Assert.That(state, Is.EqualTo(State.Alive));
        }

        [Test]
        public void Evaluate_Alive_MoreThanThreeLiveNeighbours_Dies()
        {
            _gb[1][1].State = State.Alive;
            
            _gb[0][1].State = State.Alive;
            _gb[0][2].State = State.Alive;
            _gb[1][2].State = State.Alive;
            _gb[0][0].State = State.Alive;

            var state = _rule.Evaluate(new Location(1, 1), _gb);

            Assert.That(state, Is.EqualTo(State.DeadOrEmpty));
        }

        [Test]
        public void Evaluate_Dead_ThreeLiveNeighbours_Alive()
        {
            _gb[1][1].State = State.DeadOrEmpty;

            _gb[0][1].State = State.Alive;
            _gb[0][2].State = State.Alive;
            _gb[1][2].State = State.Alive;

            var state = _rule.Evaluate(new Location(1, 1), _gb);

            Assert.That(state, Is.EqualTo(State.Alive));
        }
    }
}