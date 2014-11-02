namespace ConsoleRenderer.Tests
{
    public class FakeRule: IRule
    {
        public bool Called { get; set; }
        
        public State Evaluate(Location cellLocation, GameBoard board)
        {
            Called = true;
            return State.Alive;
        }
    }
}