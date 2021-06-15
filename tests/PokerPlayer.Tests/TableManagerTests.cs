using PokerPlayer.Games.GameTypes;
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

        [Fact]
        public void WhenGameSetToHoldEm_PlayersAreDealtCorrectNumberOfCards()
        {
            var numPlayers = 4;
            var chipCount = 500;

            var tableManager = new TableManager(numPlayers, chipCount);

            tableManager.Game = new TexasHoldEm(tableManager.Players);

            var result = tableManager.Game.DealHands();

            result.ShouldBeTrue();

            foreach(Player player in tableManager.Game.Players)
            {
                player.Hand.Count.ShouldBe(2);
            }
        }
    }
}
