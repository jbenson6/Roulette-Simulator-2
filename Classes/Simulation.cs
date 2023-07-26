using Roulette_Simulator_2.Classes;
using RouletteSimulator.Enumerations;

namespace RouletteSimulator.Classes
{
    public class Simulation
    {
        private BettingSystem _bettingSystem;
        private int _winningThreshold;
        private int _losingThreshold;
        private int _startingBalance;
        private int _desiredTrials;
        private int _wins;
        private int _losses;
        private long _totalWagered;
        private long _totalWinnings;
        private string _percentSuccess;
        private string _percentLoss;
        private int _totalBet;
        private double _avgBet;
        private double _avgWalkAwayMoney;
        private long _totalSpins;
        int[] Red = { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };
        int[] Black = { 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 };

        public BettingSystem BettingSystem
        { get { return _bettingSystem; } set { _bettingSystem = value; } }

        public int TotalBet { get => _totalBet; set => _totalBet = value; }

        public Simulation(BettingSystem bettingSystem, int winningThreshold, int startingBalance, int desiredTrials, int losingThreshold)
        {
            _bettingSystem = bettingSystem;
            _winningThreshold = winningThreshold;
            _startingBalance = startingBalance;
            _desiredTrials = desiredTrials;
            _losingThreshold = losingThreshold;
        }

        public SimulationResults PerformSimulation()
        {
            _wins = 0;
            _losses = 0;
            _totalWagered = 0;
            _totalWinnings = 0;
            _avgBet = 0;
            _avgWalkAwayMoney = 0;
            _totalSpins = 0;

            int lastIndex;
            if (BettingSystem.WheelType == WheelType.DoubleZero)
                lastIndex = 38;
            else
                lastIndex = 37;

            double avgSpinsLoss = 0;
            double avgSpinsWin = 0;

            for (int i = 0; i < _desiredTrials; i++)
            {
                Random random = new Random();
                int _currentBalance = _startingBalance;
                int spins = 0;
                while (_currentBalance < _winningThreshold && _currentBalance > _losingThreshold)
                {
                    spins++;
                    int numberRolled = random.Next(0, lastIndex);
                    _currentBalance = CalculateWinnings(numberRolled, _currentBalance);
                }
                if (_currentBalance <= _losingThreshold)
                {
                    _losses++;
                    avgSpinsLoss += spins;

                }
                else if (_currentBalance >= _winningThreshold)
                {
                    _wins++;
                    avgSpinsWin += spins;
                }
                _totalSpins += spins;
                _totalWinnings += _currentBalance - _startingBalance;
                _avgWalkAwayMoney += _currentBalance;
            }
            if (_wins > 0)
                avgSpinsWin /= _wins;
            if (_losses > 0)
                avgSpinsLoss /= _losses;

            _avgBet = _totalWagered / _totalSpins;
            _avgWalkAwayMoney /= _desiredTrials;

            _percentSuccess = ((float)_wins / (float)_desiredTrials).ToString("0.00%");
            _percentLoss = ((float)_totalWinnings / (float)_totalWagered).ToString("0.00%");
            return new SimulationResults(_desiredTrials, _totalWinnings, _totalWagered, _percentLoss, _wins, _losses, _percentSuccess, avgSpinsWin, avgSpinsLoss, 0, _avgBet, _avgWalkAwayMoney);

        }

        private int CalculateWinnings(int numberRolled, int currentBalance)
        {

            foreach (BettingTier bt in BettingSystem.BettingTiers)
            {
                if (!bt.IsActive)
                    continue;
                foreach (BettingPattern bp in bt.BettingPatterns)
                {
                    _totalWagered += bp.TotalBet;
                    foreach (KeyValuePair<Wager, int> kp in bp.Wagers)
                    {
                        if (kp.Value == 0)
                            continue;

                        string value = kp.Key.ToString().Substring(4);
                        string[] values = value.Split('_');

                        if (numberRolled == 37)
                        {
                            if (values.Contains("00"))
                            {
                                string multiplier = kp.Key.ToString().Substring(1, 2);
                                multiplier = multiplier.TrimStart('0');
                                currentBalance += kp.Value * int.Parse(multiplier);
                            }
                            else
                            {
                                currentBalance -= kp.Value;
                            }
                        }
                        else if (values[0] == "Doz")
                        {
                            int dozenSelected = int.Parse(values[1]);
                            if ((numberRolled >= (dozenSelected - 1) * 12 + 1) && (numberRolled <= (dozenSelected * 12)))
                                currentBalance += 2 * kp.Value;
                            else
                                currentBalance -= kp.Value;
                        }
                        else if (values[0] == "Col")
                        {
                            int colSelected = int.Parse(values[1]);
                            if (colSelected == 1)
                            {
                                if (numberRolled % 3 == 1)
                                    currentBalance += 2 * kp.Value;
                                else
                                    currentBalance -= kp.Value;
                            }
                            else if (colSelected == 2)
                            {
                                if (numberRolled % 3 == 2)
                                    currentBalance += 2 * kp.Value;
                                else
                                    currentBalance -= kp.Value;
                            }
                            else
                            {
                                if (numberRolled % 3 == 0)
                                    currentBalance += 2 * kp.Value;
                                else
                                    currentBalance -= kp.Value;
                            }
                        }
                        else if (values[0] == "Red")
                        {
                            if (!Red.Contains(numberRolled))
                                currentBalance -= kp.Value;
                            else
                                currentBalance += kp.Value;
                        }
                        else if (values[0] == "Black")
                        {
                            if (!Black.Contains(numberRolled))
                                currentBalance -= kp.Value;
                            else
                                currentBalance += kp.Value;
                        }
                        else if (values[0] == "Odd")
                        {
                            if (numberRolled % 2 != 1)
                                currentBalance -= kp.Value;
                            else
                                currentBalance += kp.Value;
                        }
                        else if (values[0] == "Even")
                        {
                            if (numberRolled != 0 && numberRolled % 2 != 0)
                                currentBalance -= kp.Value;
                            else
                                currentBalance += kp.Value;
                        }
                        else if (values.Contains(numberRolled.ToString()))
                        {
                            string multiplier = kp.Key.ToString().Substring(1, 2);
                            multiplier = multiplier.TrimStart('0');
                            currentBalance += kp.Value * int.Parse(multiplier);
                        }
                        else
                        {
                            currentBalance -= kp.Value;
                        }
                    }
                }

            }
            return currentBalance;

        }

    }
}

