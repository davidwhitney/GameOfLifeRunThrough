﻿using System.Linq;
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

            Assert.That(world.GameBoard.Rows.Count(), Is.EqualTo(5));
            Assert.That(world.GameBoard.Rows.First().Count, Is.EqualTo(4));
        }

        [Test]
        public void Ctor_CellsCreatedDeadOrEmpty()
        {
            var world = new GameState(1, 1, null);

            Assert.That(world.GameBoard.CellAt(0,0).State, Is.EqualTo(State.DeadOrEmpty));
        }

        [Test]
        public void Ctor_CellsCreatedKnowWhereTheyLive()
        {
            var world = new GameState(1, 2, null);

            Assert.That(world.GameBoard.CellAt(0, 1).Location.X, Is.EqualTo(0));
            Assert.That(world.GameBoard.CellAt(0, 1).Location.Y, Is.EqualTo(1));
        }

        [Test]
        public void Step_EvaluatesEachRule()
        {
            var fakeRule = new FakeRule();
            var world = new GameState(1, 1, fakeRule);

            world.Step();

            Assert.That(fakeRule.Called, Is.True);
        }

        [Test]
        public void Step_IncrementsGeneration()
        {
            var fakeRule = new FakeRule();
            var world = new GameState(1, 1, fakeRule);

            world.Step();

            Assert.That(world.Generation, Is.EqualTo(1));
        }
    }
}
