namespace ChessPairer.Models
{
    public class Round
    {
        public Guid Id { get; set; } = new Guid();

        public Guid TournamentId { get; set; }
        public Tournament Tournament { get; set; }

        public int Number { get; set; }
    }
}
