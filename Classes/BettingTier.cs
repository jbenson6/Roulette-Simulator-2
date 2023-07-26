namespace RouletteSimulator.Classes
{
    public class BettingTier
    {
        private List<BettingPattern> _bettingPatterns;
        private bool _isActive;

        public List<BettingPattern> BettingPatterns
        { get { return _bettingPatterns; } set { _bettingPatterns = value; } }

        public bool IsActive { get => _isActive; set => _isActive = value; }

        public BettingTier(List<BettingPattern> bettingPatterns)
        {
            _bettingPatterns = bettingPatterns;
            IsActive = true;
        }

        public BettingTier(List<BettingPattern> bettingPatterns, bool isActive)
        {
            _bettingPatterns = bettingPatterns;
            IsActive = isActive;
        }
    }
}
