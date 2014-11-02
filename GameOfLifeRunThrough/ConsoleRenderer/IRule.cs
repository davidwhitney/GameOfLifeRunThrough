namespace ConsoleRenderer
{
    public interface IRule
    {
        State Evaluate(Location cellLocation, GameBoard board);
    }
}