using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Assignment2_GeneticAlgorithms.Utils;

namespace Assignment2_GeneticAlgorithms.Algorithms
{
    class RankingSelection : ISelection
    {
        public RankingSelection() {  }

        public List<Seed> Selection(List<Seed> population)
        {
            List<Seed> selected = new List<Seed>();
            Random random = new Random();
            population = population.OrderBy(x => x.fitness).ToList();
            int maxCumulative = (population.Count * (population.Count + 1)) / 2; // max value for boundaries -> (n * (n+2)) / 2

            for (int i = 0; i < population.Count; i++) // loop to get an entire new population
            {
                double cumulative = 0;
                int randomValue = random.Next(0, maxCumulative); // random value between 0 and max cumulative value (all boundaries added together)

                for (int j = 0; j < population.Count; j++) // loop to add one new seed to the new population
                {
                    cumulative += (population.Count - j);
                    if (cumulative > randomValue)
                    {
                        selected.Add(population[j]);
                        break;
                    }
                }
            }

            return selected;
        }

    }
}
