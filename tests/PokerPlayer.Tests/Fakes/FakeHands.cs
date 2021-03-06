using Game2.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerPlayer.Tests.Fakes
{
    public static class FakeHands
    {
        public class FakeHand
        {
            public List<Card> PlayerHand { get; set; }

            public List<Card> CommunityCards { get; set; }
        }

        public static FakeHand RoyalFlush = new FakeHand()
        {
            PlayerHand = new List<Card>()
            {
                new Card(Suit.Spades, Rank.Ten),
                new Card(Suit.Spades, Rank.King)
            },
            CommunityCards = new List<Card>()
            {
                new Card(Suit.Diamonds, Rank.King),
                new Card(Suit.Spades, Rank.Queen),
                new Card(Suit.Hearts, Rank.Nine),
                new Card(Suit.Spades, Rank.Jack),
                new Card(Suit.Spades, Rank.Ace)
            }
        };

        public static FakeHand StraightFlush = new FakeHand()
        {
            PlayerHand = new List<Card>()
            {
                new Card(Suit.Spades, Rank.Five),
                new Card(Suit.Spades, Rank.Three)
            },
            CommunityCards = new List<Card>()
            {
                new Card(Suit.Diamonds, Rank.King),
                new Card(Suit.Spades, Rank.Six),
                new Card(Suit.Hearts, Rank.Nine),
                new Card(Suit.Spades, Rank.Four),
                new Card(Suit.Spades, Rank.Seven)
            }
        };

        public static FakeHand FourOfAKind = new FakeHand()
        {
            PlayerHand = new List<Card>()
            {
                new Card(Suit.Spades, Rank.Nine),
                new Card(Suit.Clubs, Rank.Nine)
            },
            CommunityCards = new List<Card>()
            {
                new Card(Suit.Diamonds, Rank.Nine),
                new Card(Suit.Spades, Rank.Six),
                new Card(Suit.Hearts, Rank.Nine),
                new Card(Suit.Spades, Rank.Four),
                new Card(Suit.Spades, Rank.Seven)
            }
        };
    }
}

