using PokerPlayer.Players;
using PokerPlayer.Table;
using Shouldly;
using Xunit;

namespace PokerPlayer.Tests
{
    public class TableManagerTests
    {
        public TableManagerTests()
        {
        }

        [Fact]
        public void WhenTableManagerCreated_VerifyNumberOfPlayersCorrectAndChipCountCorrect()
        {
            var numPlayers = 4;
            var chipCount = 500;

            var tableManager = new TableManager(numPlayers, chipCount);

            tableManager.Players.Count.ShouldBe(numPlayers);

            foreach(Player player in tableManager.Players)
            {
                player.ChipCount.ShouldBe(chipCount);
            }
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(5)]
        public void WhenTableManagerDeals_VerifyPlayersHaveCorrectNumberOfCards(int numCards)
        {
            var numPlayers = 4;
            var chipCount = 500;

            var tableManager = new TableManager(numPlayers, chipCount);

            tableManager.Deal(numCards);

            foreach(Player player in tableManager.Players)
            {
                player.Hand.Count.ShouldBe(numCards);
            }
        }
    }
}
