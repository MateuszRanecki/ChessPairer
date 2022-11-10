using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChessPairer.Models
{
    public class Player
    {
        public Guid Id { get; set; } = new Guid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double PointsCount { get; set; } = 0;
        public Sex Sex { get; set; }
        public Board Board { get; set; }
        public Guid? GroupId { get; set; }
        [ForeignKey("GroupId")]
        public PlayerGroup? playerGroup { get; set; }
        public Guid TournamentId { get; set; }
        [ForeignKey("TournamentId")]
        public Tournament Tournament { get; set; }
        public int? startNumber { get; set; }

    }


    public enum Sex {
        Male = 1,
        Female = 2,
    }

    public enum Board {
        First = 1,
        Second = 2,
        Third = 3,
        Fourth = 4,
        Reserve = 5,
    }
}
