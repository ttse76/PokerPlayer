namespace PokerPlayer.Cards
{
    class Card
    {
        public string Value { get; set; }

        public string Suit { get; set; }

        public Card(string value, string suit)
        {
            this.Value = value;
            this.Suit = suit;
        }
    }
}
