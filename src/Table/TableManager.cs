using System.Collections.Generic;
using Game2.Engine;
using PokerPlayer.Players;

namespace PokerPlayer.Table
{
    public class TableManager
    {
        public List<Player> Players { get; set; }

        private Deck CardDeck { get; set; }

        public TableManager(int numPlayers, int chipCount)
        {
            this.Players = new List<Player>();
            for(int i = 0; i < numPlayers - 1; i++)
            {
                var newPlayer = new Player(500, false);
                this.Players.Add(newPlayer);
            }

            this.Players.Add(new Player(chipCount, true));
            this.CardDeck = new Deck();
        }

        public void ShuffleDeck()
        {
            this.CardDeck = new Deck();
        }

        public void Deal(int numCards)
        {
            for (int i = 0; i < numCards; i++)
            {
                foreach (Player player in this.Players)
                {
                    player.AddToHand(this.CardDeck.Draw());
                }
            }
        }
    }
}
