using System;
using PokerPlayer.Games.GameTypes;
using PokerPlayer.Table;

namespace PokerPlayer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var tableManager = new TableManager(4, 500);
            while(true)
            {
                tableManager.Game = new TexasHoldEm(tableManager.Players);
                tableManager.Play();
                Console.WriteLine("Continue (Y/N)? ");
                var cont = Console.ReadLine();

                if (cont.ToLower().Equals("n"))
                {
                    break;
                }
            }
        }
    }
}
