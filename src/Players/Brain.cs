using System;
using System.Collections.Generic;
using Game2.Engine;
using PokerPlayer.RiskConfigs;

namespace PokerPlayer.Players
{
    public class Brain
    {
        public Guid PlayerId;

        private readonly IPlayerRiskConfig RiskConfig;

        public Brain(Guid playerId, IPlayerRiskConfig riskConfig)
        {
            this.PlayerId = playerId;
            this.RiskConfig = riskConfig;
        }

        /*
         * Determine if the player should bet, check, or fold
         * 
         */
        public string GetAction(List<Card> dealtCards)
        {
            return "check";
        }
    }
}
