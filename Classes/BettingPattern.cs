using RouletteSimulator.Enumerations;

namespace RouletteSimulator.Classes
{
    public class BettingPattern
    {
        private Dictionary<Wager, int> _wagers;

        public Dictionary<Wager, int> Wagers
        { get { return _wagers; } set { _wagers = value; } }

        public BettingPattern (Dictionary<Wager, int> wagers)
        {
            _wagers = wagers;
        }
    }
}
