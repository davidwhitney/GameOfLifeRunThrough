namespace ConsoleRenderer
{
    public struct Location
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Location(int x, int y) : this()
        {
            X = x;
            Y = y;
        }
    }
}