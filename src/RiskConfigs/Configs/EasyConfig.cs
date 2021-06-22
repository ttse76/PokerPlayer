using System;

namespace PokerPlayer.RiskConfigs.Configs
{
    public class EasyConfig : IPlayerRiskConfig
    {
        public Guid PlayerId { get; set; }

        public string ConfigName { get; set; }

        public EasyConfig(Guid playerId)
        {
            this.PlayerId = playerId;
            this.ConfigName = "Easy";
        }
    }
}
