namespace ConsoleRenderer
{
    public class Cell
    {
        public State State { get; set; }
        public Location Location { get; private set; }

        public Cell(int x, int y)
        {
            State = State.DeadOrEmpty;
            Location = new Location(x, y);
        }
    }
}