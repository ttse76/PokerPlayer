using System.Collections.Generic;

namespace PokerPlayer.Games
{
    public class Deal
    {
        public int NumCards { get; set; }

        public int StartBet { get; set; }

        public Deal(int numCards, int startBet)
        {
            this.NumCards = numCards;
            this.StartBet = startBet;
        }

    }
}
