namespace ChessPairer.Models
{
    public class PlayerGroup
    {
        public Guid Id { get; set; } = new Guid();
        public string Name { get; set; }
        public int BigPointsCount { get; set; } = 0;
        public double SmallPointsCount { get; set; } = 0;
        public double FirstBoardPointsCount { get; set; } = 0;
        public double Bucholz { get; set; } = 0;
        public int startNumber { get; set; }
        public Guid TournamentId { get; set; }
        public Tournament Tournament { get; set; }
        public List<Player> Players { get; set; } = new List<Player>(); 

    }
}
