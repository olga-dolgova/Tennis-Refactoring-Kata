namespace Tennis.TennisGame2
{
    internal class TennisPlayer
    {
        public string Name { get; }
        public int Points { get; private set; }

        public TennisPlayer(string name)
        {
            Name = name;
            Points = 0;
        }

        public void AddPoint()
        {
            Points++;
        }

        public bool IsPlayerPointsDeuceOrMore()
        {
            var deucePoints = 4;
            return Points >= deucePoints;
        }
    }
}
