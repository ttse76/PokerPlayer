using PokerPlayer.Players;
using Shouldly;
using Xunit;

namespace PokerPlayer.Tests.Players
{
    public class PlayerTests
    {
        [Fact]
        public void OnPlayerCreation_VerifyChipCount()
        {
            var chipCount = 500;
            var player = new Player(chipCount);
            player.ChipCount.ShouldBe(chipCount);
        }
    }
}
