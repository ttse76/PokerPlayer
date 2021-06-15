using Game2.Engine;
using PokerPlayer.Players;
using PokerPlayer.Services;
using System;
using System.Collections.Generic;

namespace PokerPlayer.Games.GameTypes
{
    public class TexasHoldEm : IGame
    {
        public int NumCardsInHand { get; set; }

        private int Increment { get; set; }

        public List<Deal> DealIncrements { get; set; }

        public Deck CardDeck { get; set; }

        public List<Player> Players { get; set; }

        public List<Card> CommunityCards { get; set; }

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
            this.CommunityCards = new List<Card>();
            this.Players = players;
            this.Increment = 0;
        }

        public int GetNumberOfDeals()
        {
            return this.DealIncrements.Count;
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

        public bool DealCommunityCards()
        {
            if(this.CommunityCards == null || this.CommunityCards.Count != 0)
            {
                return false;
            }

            foreach(Deal deal in this.DealIncrements)
            {
                for(int i = 0; i < deal.NumCards; i++)
                {
                    this.CommunityCards.Add(this.CardDeck.Draw());
                }
            }

            return true;
        }

        public bool RunGame()
        {
            if(this.CommunityCards.Count == 0)
            {
                return false;
            }
            Console.WriteLine("Opening Betting...\n");
            if(!this.OpenBetting(this.DealIncrements[this.Increment]))
            {
                Console.WriteLine("Error with betting");
                return false;
            }
            Console.WriteLine("\nClosing Betting...\n");

            Console.WriteLine("Dealing Flop...\n");
            for(int i = 0; i < 3; i++)
            {
                Console.WriteLine(this.CommunityCards[i]);
            }

            Console.WriteLine("\nOpening Betting...\n");
            if (!this.OpenBetting(this.DealIncrements[this.Increment]))
            {
                Console.WriteLine("Error with betting");
                return false;
            }
            Console.WriteLine("\nClosing Betting...\n");
            this.Increment++;

            Console.WriteLine("Dealing Turn...\n");
            Console.WriteLine(this.CommunityCards[3] + "\n");

            Console.WriteLine("Opening Betting...\n");
            if (!this.OpenBetting(this.DealIncrements[this.Increment]))
            {
                Console.WriteLine("Error with betting");
                return false;
            }
            Console.WriteLine("\nClosing Betting...\n");
            this.Increment++;

            Console.WriteLine("Dealing River...\n");
            Console.WriteLine(this.CommunityCards[4] + "\n");

            Console.WriteLine("Opening Betting...\n");
            if (!this.OpenBetting(this.DealIncrements[this.Increment]))
            {
                Console.WriteLine("Error with betting");
                return false;
            }
            Console.WriteLine("\nClosing Betting...\n");

            Console.WriteLine("\nCommunity Cards:");
            foreach(Card card in this.CommunityCards)
            {
                Console.WriteLine(card);
            }
            Console.WriteLine();
            foreach(Player player in this.Players)
            {
                Console.WriteLine($"Cards for player {player.PlayerId}");
                player.Hand.Sort(delegate (Card a, Card b)
                {
                    return a.Rank.CompareTo(b.Rank) * -1;
                });
                foreach(Card card in player.Hand)
                {
                    Console.WriteLine(card);
                }
                Console.WriteLine();
            }

            foreach(Player p in this.Players)
            {
                var handType = HandAnalyzer.GetHandType(p.Hand, this.CommunityCards);
                Console.WriteLine($"Player {p.PlayerId} has {handType.HandName}");
            }

            return true;
        }

        public bool OpenBetting(Deal dealInfo)
        {
            foreach(Player player in this.Players)
            {
                if(true)
                {
                    player.MakeBet(dealInfo.StartBet);
                    Console.WriteLine($"{player.PlayerId} make a bet of {dealInfo.StartBet} chips with a total bet of {player.Bet}");
                }
            }
            return true;
        }
    }
}
