namespace P02_FootballBetting.Data.Models
{
    public class Game
    {
        public Game()
        {
            this.PlayerStatistic = new HashSet<PlayerStatistic>();
            this.Bets = new HashSet<Bet>();
        }

        public int GameId { get; set; }

        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }

        public byte HomeTeamGoals { get; set; }

        public byte AwayTeamGoals { get; set; }

        public DateTime DateTime { get; set; }

        public float HomeTeamBetRate { get; set; }

        public float AwayTeamBetRate { get; set; }

        public float DrawBetRate { get; set; }

        public string Result { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }

        public virtual ICollection<PlayerStatistic> PlayerStatistic { get; set; }

    }
}
