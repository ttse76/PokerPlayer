using System.Collections.Generic;
using Game2.Engine;
using PokerPlayer.Services;
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
        public void EvaluateIfRoyalFlush()
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
        public void EvaluateIfStraightFlush()
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
        public void EvaluateIfFourOfAKind()
        {
            List<Card> fakeHand = new List<Card>()
            {
                new Card(Suit.Spades, Rank.Nine),
                new Card(Suit.Clubs, Rank.Nine)
            };

            List<Card> fakeCommunityCards = new List<Card>()
            {
                new Card(Suit.Diamonds, Rank.Nine),
                new Card(Suit.Spades, Rank.Six),
                new Card(Suit.Hearts, Rank.Nine),
                new Card(Suit.Spades, Rank.Four),
                new Card(Suit.Spades, Rank.Seven)
            };

            var result = HandAnalyzer.GetHandType(fakeHand, fakeCommunityCards);

            result.HandName.ShouldBe("Four Of A Kind");
        }

        [Fact]
        public void EvaluateFullHouse()
        {
            List<Card> fakeHand = new List<Card>()
            {
                new Card(Suit.Spades, Rank.Nine),
                new Card(Suit.Clubs, Rank.Nine)
            };

            List<Card> fakeCommunityCards = new List<Card>()
            {
                new Card(Suit.Diamonds, Rank.Nine),
                new Card(Suit.Spades, Rank.Six),
                new Card(Suit.Hearts, Rank.Five),
                new Card(Suit.Diamonds, Rank.Six),
                new Card(Suit.Spades, Rank.Seven)
            };

            var result = HandAnalyzer.GetHandType(fakeHand, fakeCommunityCards);

            result.HandName.ShouldBe("Full House");
        }

        [Fact]
        public void EvaluateIfFlush()
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
        public void EvaluateIfStraight()
        {
            List<Card> fakeHand = new List<Card>()
            {
                new Card(Suit.Spades, Rank.Jack),
                new Card(Suit.Hearts, Rank.Ten)
            };

            List<Card> fakeCommunityCards = new List<Card>()
            {
                new Card(Suit.Diamonds, Rank.Eight),
                new Card(Suit.Spades, Rank.Ace),
                new Card(Suit.Hearts, Rank.Nine),
                new Card(Suit.Diamonds, Rank.Queen),
                new Card(Suit.Clubs, Rank.Ten)
            };

            var result = HandAnalyzer.GetHandType(fakeHand, fakeCommunityCards);

            result.HandName.ShouldBe("Straight");
        }

        [Fact]
        public void EvaluateIfThreeOfAKind()
        {
            List<Card> fakeHand = new List<Card>()
            {
                new Card(Suit.Spades, Rank.Jack),
                new Card(Suit.Hearts, Rank.Ten)
            };

            List<Card> fakeCommunityCards = new List<Card>()
            {
                new Card(Suit.Diamonds, Rank.Ten),
                new Card(Suit.Spades, Rank.Ace),
                new Card(Suit.Hearts, Rank.Nine),
                new Card(Suit.Diamonds, Rank.Queen),
                new Card(Suit.Clubs, Rank.Ten)
            };

            var result = HandAnalyzer.GetHandType(fakeHand, fakeCommunityCards);

            result.HandName.ShouldBe("Three of a Kind");
        }

        [Fact]
        public void EvaluateTwoPair()
        {
            List<Card> fakeHand = new List<Card>()
            {
                new Card(Suit.Spades, Rank.Jack),
                new Card(Suit.Hearts, Rank.Ten)
            };

            List<Card> fakeCommunityCards = new List<Card>()
            {
                new Card(Suit.Diamonds, Rank.Jack),
                new Card(Suit.Spades, Rank.Ace),
                new Card(Suit.Hearts, Rank.Nine),
                new Card(Suit.Diamonds, Rank.Queen),
                new Card(Suit.Clubs, Rank.Ten)
            };

            var result = HandAnalyzer.GetHandType(fakeHand, fakeCommunityCards);

            result.HandName.ShouldBe("Two Pair");
        }

        [Fact]
        public void EvaluateIfOnePair()
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
