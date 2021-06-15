using PokerPlayer.Games.GameTypes;
using PokerPlayer.Table;

namespace PokerPlayer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var tableManager = new TableManager(4, 500);
            tableManager.Game = new TexasHoldEm(tableManager.Players);
            tableManager.Play();
        }
    }
}
