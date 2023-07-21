using Microsoft.AspNetCore.Mvc;
using Roulette_Simulator_2.Classes;
using RouletteSimulator.Classes;
using RouletteSimulator.Enumerations;

namespace Roulette_Simulator_2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SimulationController : ControllerBase
    {
        private readonly ILogger<SimulationController> _logger;
        private Simulation simulation;

        public SimulationController(ILogger<SimulationController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<SimulationResults> Simulate(int desiredTrials, int startingBalance, int winningThreshold, int losingThreshold, int wheelType)
        {
            BettingSystem bettingSystem = new BettingSystem(wheelType);
            simulation = new Simulation(bettingSystem, winningThreshold, startingBalance, desiredTrials, losingThreshold);

            //Populate Wagers to 0
            Dictionary<Wager, int> bets = new Dictionary<Wager, int>();
            foreach(Wager wager in Enum.GetValues(typeof(Wager)))
            {
                bets.Add(wager, 0);
            }

            //Populate Bets Placed
            bets[Wager.X02_Doz_2] = 7;
            bets[Wager.X02_Doz_3] = 7;
            bets[Wager.X08_1_2_4_5] = 2;
            bets[Wager.X08_7_8_10_11] = 2;


            simulation.TotalBet = 18;

            List<BettingPattern> bettingPatterns = new List<BettingPattern>();
            bettingPatterns.Add(new BettingPattern(bets));

            simulation.BettingSystem.BettingTiers.Add(new BettingTier(bettingPatterns));

            SimulationResults results = simulation.PerformSimulation();

            return results;
        }

    }
}