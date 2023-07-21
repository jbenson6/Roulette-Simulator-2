using RouletteSimulator.Enumerations;
using System.Collections;

namespace RouletteSimulator.Classes
{
    public class BettingSystem
    {
        private WheelType _wheelType;
        private List<BettingTier> _bettingTiers;

        public List<BettingTier> BettingTiers
        { get { return _bettingTiers; } set { _bettingTiers = value;  } }

        public WheelType WheelType
        { get { return _wheelType; } set { _wheelType = value; } }

        public BettingSystem (int wheelType)
        {
            _wheelType = (WheelType) wheelType;
            _bettingTiers = new List<BettingTier>();
        }
    }
}
