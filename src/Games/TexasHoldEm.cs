using System.Collections.Generic;

namespace PokerPlayer.Games
{
    public class TexasHoldEm : IGame
    {
        public int NumCardsInHand { get; set; }

        public List<int> DealIncrements { get; set; }

        public TexasHoldEm()
        {
            this.NumCardsInHand = 2;
            this.DealIncrements = new List<int>
            {
                3,
                1,
                1
            };
        }
    }
}
