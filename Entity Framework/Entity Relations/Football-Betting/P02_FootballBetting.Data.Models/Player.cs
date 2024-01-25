namespace P02_FootballBetting.Data.Models
{
    public class Player
    {
        public Player()
        {
            this.PlayerStatistics = new HashSet<PlayerStatistic>();
        }

        public int PlayerId { get; set; }

        public string Name { get; set; }

        public byte SquadNumber { get; set; }

        public string Assists { get; set; }

        public int TownId { get; set; }
        public Town Town { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }

        public bool IsInjured { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }

        public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; }
    }
}
