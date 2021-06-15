using Game2.Engine;
using PokerPlayer.Players;
using System;
using System.Collections.Generic;

namespace PokerPlayer.Games.GameTypes
{
    public class TexasHoldEm : IGame
    {
        public int NumCardsInHand { get; set; }

        public List<Deal> DealIncrements { get; set; }

        public Deck CardDeck { get; set; }

        public List<Player> Players { get; set; }

        public TexasHoldEm(List<Player> players)
        {
            this.NumCardsInHand = 2;
            this.DealIncrements = new List<Deal>
            {
                new Deal(3, 5),
                new Deal(1, 10),
                new Deal(1, 10)
            };

            this.CardDeck = new Deck();
            this.Players = players;
        }

        public int GetNumberOfDeals()
        {
            return this.DealIncrements.Count;
        }

        public bool Deal()
        {
            if(this.Players == null)
            {
                return false;
            }
            return true;
        }

        public string GetGameName()
        {
            return "Texas Hold'em";
        }

        public bool DealHands()
        {
            if (this.Players == null)
            {
                return false;
            }
            for (int i = 0; i < 2; i++)
            {
                foreach (Player player in this.Players)
                {
                    player.AddToHand(this.CardDeck.Draw());
                }
            }
            return true;
        }
    }
}
