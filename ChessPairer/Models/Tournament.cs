using System.Diagnostics.Contracts;

namespace ChessPairer.Models
{
    public class Tournament
    {
        public Guid ID { get; set; } = new Guid();
        public string Name { get; set; }
        public TournamentType TournamentType { get; set; }
        public PairingType PairingType { get; set; }
        public List<PlayerGroup>PlayerGroups { get; set; } = new List<PlayerGroup>();
        public TournamentStatus Status { get; set; } = TournamentStatus.Created;
        public List<Player>Players { get; set; } = new List<Player>();

    }

    public enum TournamentType
    {
        Group = 1,
        SinglePlayer = 2, 
    }

    public enum PairingType
    {
        Classic = 1,
        Swiss = 2,
    }

    public enum TournamentStatus
    {
        Created = 1,
        Active = 2,
        Closed =3, 
    }
}
