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

        private static List<Card> FilterBySuit(List<Card> hand, Suit suit)
        {
            var newHand = new List<Card>();

            foreach(Card card in hand)
            {
                if(card.Suit == suit)
                {
                    newHand.Add(card);
                }
            }

            newHand.Sort(delegate (Card a, Card b)
            {
                return a.Rank.CompareTo(b.Rank) * -1;
            });

            return newHand;
        }

        private static List<Card> FilterByRank(List<Card> hand, Rank rank)
        {
            var newHand = new List<Card>();

            foreach (Card card in hand)
            {
                if (card.Rank == rank)
                {
                    newHand.Add(card);
                }
            }

            newHand.Sort(delegate (Card a, Card b)
            {
                return a.Rank.CompareTo(b.Rank) * -1;
            });

            return newHand;
        }

        private static List<Rank> FilterUnique(List<Card> hand)
        {
            var cardSet = new HashSet<Rank>();

            foreach(Card card in hand)
            {
                cardSet.Add(card.Rank);
            }
            return cardSet.ToList<Rank>();
        }

        public static bool IsRoyalFlush(List<Card> playerCards, List<Card> communityCards)
        {
            var allCards = CombineHands(playerCards, communityCards);

            for(int i = 0; i < allCards.Count; i++)
            {
                if(allCards[i].Rank == Rank.Ace)
                {
                    var neededSuit = allCards[i].Suit;
                    var subHand = new List<Card>()
                    {
                        allCards[i]
                    };
                    for(int j = i; j < allCards.Count; j++)
                    {
                        if(allCards[j].Suit == neededSuit && (allCards[j].Rank == Rank.Jack || allCards[j].Rank == Rank.Queen || allCards[j].Rank == Rank.King || allCards[j].Rank == Rank.Ten))
                        {
                            subHand.Add(allCards[j]);
                        }
                    }
                    if(subHand.Count == 5)
                    {
                        if(subHand[4].Rank == Rank.Ten)
                        {
                            if (subHand[3].Rank == Rank.Jack)
                            {
                                if (subHand[2].Rank == Rank.Queen)
                                {
                                    if (subHand[1].Rank == Rank.King)
                                    {
                                        if (subHand[0].Rank == Rank.Ace)
                                        {
                                            return true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        public static bool IsStraightFlush(List<Card> playerCards, List<Card> communityCards)
        {
            var allCards = CombineHands(playerCards, communityCards);

            for(int i = 0; i < allCards.Count; i++)
            {
                bool flag = false;

                var selectedCard = allCards[i];

                var filteredHand = FilterBySuit(allCards, selectedCard.Suit);

                if(filteredHand.Count < 5)
                {
                    continue;
                }

                for(int j = 0; j < filteredHand.Count - 1; j++)
                {
                    if(filteredHand[j].Rank.Value - 1 != filteredHand[j + 1].Rank.Value)
                    {
                        break;
                    }

                    if(j == filteredHand.Count - 2)
                    {
                        flag = true;
                    }
                }

                if(flag)
                {
                    return true;
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

            var filteredHand = FilterUnique(allCards);

            if(filteredHand.Count < 5)
            {
                return false;
            }

            int numConsecutive = 1;

            for(int i = 1; i < filteredHand.Count; i++)
            {
                if(filteredHand[i].Value == filteredHand[i - 1].Value - 1)
                {
                    numConsecutive++;
                }
                else
                {
                    numConsecutive = 1;
                }
                if(numConsecutive == 5)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsThreeOfAKind(List<Card> playerCards, List<Card> communityCards)
        {
            var allCards = CombineHands(playerCards, communityCards);
            
            for(int i = 0; i < allCards.Count - 2; i++)
            {
                if (allCards[i].Rank == allCards[i + 1].Rank && allCards[i].Rank == allCards[i + 2].Rank)
                {
                    return true;
                }
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
