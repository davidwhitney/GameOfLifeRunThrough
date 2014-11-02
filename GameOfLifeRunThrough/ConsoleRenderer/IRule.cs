namespace ConsoleRenderer
{
    public interface IRule
    {
        State Evaluate(Location cellToEvaluate, GameBoard board);
    }
}