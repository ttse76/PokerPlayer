using System;
using System.Collections.Generic;
using Game2.Engine;

namespace PokerPlayer.Players
{
    public class Player
    {
        public Player(int chipCount, bool isHuman)
        {
            this.PlayerId = Guid.NewGuid();
            this.ChipCount = chipCount;
            this.IsHuman = isHuman;
            this.Hand = new List<Card>();
            this.Bet = 0;
        }

        public Guid PlayerId { get; set; }

        public int ChipCount { get; set; }

        public int Bet { get; set; }

        public bool IsHuman { get; set; }

        public List<Card> Hand { get; set; }

        public void AddToHand(Card card)
        {
            this.Hand.Add(card);
        }

        public void ClearHand()
        {
            this.Hand.Clear();
        }

        public void ClearBet()
        {
            this.Bet = 0;
        }

        public override string ToString()
        {
            if(this.Hand.Count == 0)
            {
                return $"Player {this.PlayerId} has no cards";
            }
            var output = "Hand:\n";

            foreach(Card card in this.Hand)
            {
                output += card + "\n";
            }
            return output;
        }

        public bool MakeBet(int betAmount)
        {
            if(betAmount > this.ChipCount)
            {
                return false;
            }

            this.Bet += betAmount;
            this.ChipCount -= betAmount;

            return true;
        }
    }
}
