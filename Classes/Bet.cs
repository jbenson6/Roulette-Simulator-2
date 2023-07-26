using RouletteSimulator.Enumerations;

namespace Roulette_Simulator_2.Classes
{
    public class Bet
    {
        private string wager;
        private int amount;
        public Bet(string wager, int bet)
        {
            this.Wager = wager;
            this.Amount = bet;
        }

        public int Amount { get => amount; set => amount = value; }
        public string Wager { get => wager; set => wager = value; }
    }

}
