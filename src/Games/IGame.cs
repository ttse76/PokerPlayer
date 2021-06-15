using Game2.Engine;
using PokerPlayer.Players;
using System.Collections.Generic;

namespace PokerPlayer.Games
{
    public interface IGame
    {
        // Number of cards each player should have in their hand
        int NumCardsInHand { get; set; }

        // List for how many times a dealer deals and how many cards each time
        List<Deal> DealIncrements { get; set; }

        Deck CardDeck { get; set; }

        List<Player> Players { get; set; }

        // GET methods
        // Returns number of times there is a deal
        int GetNumberOfDeals();

        string GetGameName();

        // Actions

        // Dealer action
        bool Deal();

        // Deals out hands to players
        bool DealHands();


    }
}
