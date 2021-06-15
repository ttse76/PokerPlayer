using System.Collections.Generic;
using System.Linq;
using Game2.Engine;

namespace PokerPlayer.Services
{
    public static class HandTypeChecker
    {
        private static List<Card> CombineHands(List<Card> playerCards, List<Card> communityCards)
        {
            var allCards = playerCards.Concat(communityCards).ToList();
            allCards.Sort(delegate (Card a, Card b)
            {
                return a.Rank.CompareTo(b.Rank) * -1;
            });

            return allCards;
        }

        public static bool IsRoyalFlush(List<Card> playerCards, List<Card> communityCards)
        {
            var allCards = CombineHands(playerCards, communityCards);

            int tenAt = 0;
            bool has10 = false;

            for(int i = 0; i < allCards.Count; i++)
            {
                if(allCards[i].Rank.Value == 10)
                {
                    if(allCards.Count - i < 5)
                    {
                        return false;
                    }
                    tenAt = i;
                    has10 = true;
                    break;
                }
            }

            if(!has10)
            {
                return false;
            }

            if(allCards[tenAt + 1].Rank == Rank.Jack && allCards[tenAt + 1].Suit == allCards[tenAt].Suit)
            {
                if (allCards[tenAt + 2].Rank == Rank.Queen && allCards[tenAt + 2].Suit == allCards[tenAt].Suit)
                {
                    if (allCards[tenAt + 3].Rank == Rank.King && allCards[tenAt + 3].Suit == allCards[tenAt].Suit)
                    {
                        if (allCards[tenAt + 4].Rank == Rank.Ace && allCards[tenAt + 4].Suit == allCards[tenAt].Suit)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static bool IsFlush(List<Card> playerCards, List<Card> communityCards)
        {
            var allCards = CombineHands(playerCards, communityCards);

            for(int i = 0; i < allCards.Count; i++)
            {
                int numSameSuit = 1;
                var currentSuit = allCards[i].Suit;
                for(int j = 0; j < allCards.Count; j++)
                {
                    if(i != j && allCards[j].Suit == currentSuit)
                    {
                        numSameSuit++;
                    }
                }
                if(numSameSuit == 5)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsStraight(List<Card> playerCards, List<Card> communityCards)
        {
            var allCards = CombineHands(playerCards, communityCards);
            int consecutive = 1;

            for(int i = 1; i < allCards.Count; i++)
            {
                if(consecutive == 5)
                {
                    return true;
                }
                if(allCards[i-1].Rank.Value == allCards[i].Rank.Value - 1)
                {
                    consecutive++;
                }
                else
                {
                    consecutive = 1;
                }
            }
            if (consecutive == 5)
            {
                return true;
            }
            return false;
        }

        public static bool IsTwoPair(List<Card> playerCards, List<Card> communityCards)
        {
            var allCards = CombineHands(playerCards, communityCards);

            int numPairs = 0;

            for(int i = 1; i < allCards.Count; i++)
            {
                if(allCards[i-1].Rank == allCards[i].Rank)
                {
                    numPairs++;
                }

                if(numPairs == 2)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsPair(List<Card> playerCards, List<Card> communityCards)
        {
            var allCards = CombineHands(playerCards, communityCards);

            for(int i = 0; i < allCards.Count; i++)
            {
                for(int j = i + 1; j < allCards.Count; j++)
                {
                    if(allCards[i].Rank.Value == allCards[j].Rank.Value)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
