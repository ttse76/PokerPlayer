using System;

namespace PokerPlayer.RiskConfigs
{
    public interface IPlayerRiskConfig
    {
        public Guid PlayerId { get; set; }

        public string ConfigName { get; set; }
    }
}
