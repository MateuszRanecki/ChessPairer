using System.ComponentModel.DataAnnotations;

namespace ChessPairer.Models
{
    public class Game
    {
        public Guid Id { get; set; } = new Guid();
        public Guid WhitePlayer { get; set; }
        public Guid BlackPlayer { get; set; }
        public GameScore? Score { get; set; }
        public Guid RoundId { get; set; }
        public Round Round { get; set; }
    }

    public enum GameScore {
        WhiteWon = 1,
        BlackWon = 2,
        Draw = 3,
    }
}
