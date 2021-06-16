using System.Collections.Generic;
using Game2.Engine;
using PokerPlayer.Services;
using PokerPlayer.Table;
using Shouldly;
using Xunit;

namespace PokerPlayer.Tests
{
    public class HandTypeCheckerTests
    {
        public HandTypeCheckerTests()
        {
        }

        [Fact]
        public void EvaluateRoyalFlush()
        {
            List<Card> fakeHand = new List<Card>()
            {
                new Card(Suit.Spades, Rank.Ten),
                new Card(Suit.Spades, Rank.King)
            };

            List<Card> fakeCommunityCards = new List<Card>()
            {
                new Card(Suit.Diamonds, Rank.King),
                new Card(Suit.Spades, Rank.Queen),
                new Card(Suit.Hearts, Rank.Nine),
                new Card(Suit.Spades, Rank.Jack),
                new Card(Suit.Spades, Rank.Ace)
            };

            var result = HandAnalyzer.GetHandType(fakeHand, fakeCommunityCards);

            result.HandName.ShouldBe("Royal Flush");
        }

        [Fact]
        public void EvaluateStraightFlush()
        {
            List<Card> fakeHand = new List<Card>()
            {
                new Card(Suit.Spades, Rank.Five),
                new Card(Suit.Spades, Rank.Three)
            };

            List<Card> fakeCommunityCards = new List<Card>()
            {
                new Card(Suit.Diamonds, Rank.King),
                new Card(Suit.Spades, Rank.Six),
                new Card(Suit.Hearts, Rank.Nine),
                new Card(Suit.Spades, Rank.Four),
                new Card(Suit.Spades, Rank.Seven)
            };

            var result = HandAnalyzer.GetHandType(fakeHand, fakeCommunityCards);

            result.HandName.ShouldBe("Straight Flush");
        }

        [Fact]
        public void EvaluateFlush()
        {
            List<Card> fakeHand = new List<Card>()
            {
                new Card(Suit.Spades, Rank.Seven),
                new Card(Suit.Spades, Rank.Three)
            };

            List<Card> fakeCommunityCards = new List<Card>()
            {
                new Card(Suit.Diamonds, Rank.King),
                new Card(Suit.Spades, Rank.Ace),
                new Card(Suit.Hearts, Rank.Nine),
                new Card(Suit.Spades, Rank.Queen),
                new Card(Suit.Spades, Rank.Ten)
            };

            var result = HandAnalyzer.GetHandType(fakeHand, fakeCommunityCards);

            result.HandName.ShouldBe("Flush");
        }

        [Fact]
        public void EvaluateOnePair()
        {
            List<Card> fakeHand = new List<Card>()
            {
                new Card(Suit.Clubs, Rank.Five),
                new Card(Suit.Spades, Rank.Seven)
            };

            List<Card> fakeCommunityCards = new List<Card>()
            {
                new Card(Suit.Diamonds, Rank.King),
                new Card(Suit.Clubs, Rank.Three),
                new Card(Suit.Hearts, Rank.Nine),
                new Card(Suit.Hearts, Rank.Seven),
                new Card(Suit.Clubs, Rank.Ace)
            };

            var result = HandAnalyzer.GetHandType(fakeHand, fakeCommunityCards);

            result.HandName.ShouldBe("Pair");
        }
    }
}
