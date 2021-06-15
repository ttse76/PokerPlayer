using System.Collections.Generic;
using Game2.Engine;
using PokerPlayer.Players;

namespace PokerPlayer.Services
{
    public static class HandAnalyzer
    {
        public class HandType
        {
            public string HandName { get; set; }

            public List<Card> HandCards { get; set; }

            public int HandRank { get; set; }

            /*public HandType(string handName, List<Card> handCards, int handRank)
            {
                this.HandName = handName;
                this.HandCards = handCards;
                this.HandRank = handRank;
            }*/
        }
        public static void CompareHands(Player p1, Player p2, List<Card> communityCards)
        {
        }

        public static HandType GetHandType(List<Card> playerHand, List<Card> communityCards)
        {
            if(HandTypeChecker.IsRoyalFlush(playerHand, communityCards))
            {
                return new HandType()
                {
                    HandName = "Royal Flush",
                    HandCards = playerHand,
                    HandRank = 1
                };
            }

            if(HandTypeChecker.IsFlush(playerHand, communityCards))
            {
                return new HandType()
                {
                    HandName = "Flush",
                    HandCards = playerHand,
                    HandRank = 1
                };
            }

            if (HandTypeChecker.IsStraight(playerHand, communityCards))
            {
                return new HandType()
                {
                    HandName = "Straight",
                    HandCards = playerHand,
                    HandRank = 1
                };
            }

            if (HandTypeChecker.IsPair(playerHand, communityCards))
            {
                return new HandType()
                {
                    HandName = "Pair",
                    HandCards = playerHand,
                    HandRank = 2
                };
            }

            return new HandType()
            {
                HandName = "Nothing",
                HandCards = playerHand,
                HandRank = 999999999
            };
        }
    }
}
