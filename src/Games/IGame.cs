using System.Collections.Generic;

namespace PokerPlayer.Games
{
    public interface IGame
    {
        // Number of cards each player should have in their hand
        int NumCardsInHand { get; set; }

        // List for how many times a dealer deals and how many cards each time
        // Example: Texas Hold'em: [3, 1, 1]
        List<int> DealIncrements { get; set; }
    }
}
