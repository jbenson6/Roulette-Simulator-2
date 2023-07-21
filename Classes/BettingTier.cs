namespace RouletteSimulator.Classes
{
    public class BettingTier
    {
        private List<BettingPattern> _bettingPatterns;

        public List<BettingPattern> BettingPatterns
        { get { return _bettingPatterns; } set { _bettingPatterns = value; } }

        public BettingTier(List<BettingPattern> bettingPatterns)
        {
            _bettingPatterns = bettingPatterns;
        }
    }
}
