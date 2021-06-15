using System;
using System.Collections.Generic;
using Game2.Engine;
using PokerPlayer.Games;
using PokerPlayer.Players;

namespace PokerPlayer.Table
{
    public class TableManager
    {
        public List<Player> Players { get; set; }

        private Deck CardDeck { get; set; }

        public IGame Game { get; set; }

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

        public void Play()
        {
            if(this.Game == null)
            {
                Console.WriteLine("[ERROR] TableManager has no game set");
                return;
            }

            this.Game.DealHands();
            this.Game.DealCommunityCards();
            if(this.Game.RunGame())
            {
                this.Players = this.Game.Players;
            }
            else
            {
                Console.WriteLine("There was an error with running the game");
            }
        }
    }
}
