using RouletteSimulator.Enumerations;

namespace RouletteSimulator.Classes
{
    public class BettingPattern
    {
        private Dictionary<Wager, int> _wagers;
        private int _totalBet;

        public Dictionary<Wager, int> Wagers
        { get { return _wagers; } set { _wagers = value; } }

        public int TotalBet { get => _totalBet; set => _totalBet = value; }

        public BettingPattern(Dictionary<Wager, int> wagers, int totalBet)
        {
            _wagers = wagers;
            TotalBet = totalBet;
        }
    }
}
