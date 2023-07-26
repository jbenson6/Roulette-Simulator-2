namespace Roulette_Simulator_2.Classes
{
    public class SimulationResults
    {
        private int desiredTrials;
        private long totalWinnings;
        private long totalWagered;
        private string percentLoss;
        private int wins;
        private int losses;
        private string percentSuccess;
        private double spinsWin;
        private double spinsLoss;
        private int chambaLosses;
        private double avgBet;
        private double avgWalkAway;
        private int quickestLoss;
        private int longestLoss;

        public SimulationResults(int desiredTrials, long totalWinnings, long totalWagered, string percentLoss, int wins, int losses, string percentSuccess, double spinsWin, double spinsLoss, int chambaLosses, double avgBet, double avgWalkAway, int quickestLoss, int longestLoss)
        {
            this.DesiredTrials = desiredTrials;
            this.TotalWinnings = totalWinnings;
            this.TotalWagered = totalWagered;
            this.PercentLoss = percentLoss;
            this.Wins = wins;
            this.Losses = losses;
            this.PercentSuccess = percentSuccess;
            this.spinsWin = spinsWin;
            this.SpinsLoss = spinsLoss;
            this.ChambaLosses = chambaLosses;
            this.AvgBet = avgBet;
            this.AvgWalkAway = avgWalkAway;
            this.QuickestLoss = quickestLoss;
            this.LongestLoss = longestLoss;        }

        public int DesiredTrials { get => desiredTrials; set => desiredTrials = value; }
        public long TotalWinnings { get => totalWinnings; set => totalWinnings = value; }
        public long TotalWagered { get => totalWagered; set => totalWagered = value; }
        public string PercentLoss { get => percentLoss; set => percentLoss = value; }
        public int Wins { get => wins; set => wins = value; }
        public int Losses { get => losses; set => losses = value; }
        public string PercentSuccess { get => percentSuccess; set => percentSuccess = value; }
        public double SpinsWin { get => spinsWin; set => spinsWin = value; }
        public double SpinsLoss { get => spinsLoss; set => spinsLoss = value; }
        public int ChambaLosses { get => chambaLosses; set => chambaLosses = value; }
        public double AvgBet { get => avgBet; set => avgBet = value; }
        public double AvgWalkAway { get => avgWalkAway; set => avgWalkAway = value; }
        public int QuickestLoss { get => quickestLoss; set => quickestLoss = value; }
        public int LongestLoss { get => longestLoss; set => longestLoss = value; }
    }
}
