using System;

namespace PokerPlayer.Players
{
    public class Player
    {
        public Guid PlayerId { get; set; }

        public int ChipCount { get; set; }

        public int Bet { get; set; }

        public Player(int chipCount)
        {
            this.PlayerId = Guid.NewGuid();
            this.ChipCount = chipCount;
            this.Bet = 0;
        }
    }
}
