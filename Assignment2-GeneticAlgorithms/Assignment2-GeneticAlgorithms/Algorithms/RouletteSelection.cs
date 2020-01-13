using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Assignment2_GeneticAlgorithms.Utils;

namespace Assignment2_GeneticAlgorithms.Algorithms
{
    class RouletteSelection : ISelection
    {
        public RouletteSelection() { }

        public List<Seed> Selection(List<Seed> population)
        {
            Random random = new Random();
            double allFitnesses = population.Sum(x => x.fitness);
            population = population.OrderBy(x => x.fitness).ToList();
            List<Seed> selected = new List<Seed>();
            List<double> boundaryValues = new List<double>();

            for (int i = 0; i < population.Count; i++)
            {
                boundaryValues.Add(1 - (population[i].fitness / allFitnesses));
            }

            double sum = boundaryValues.Sum();
            for (int i = 0; i < population.Count; i++)
            {
                double cumulative = 0.0;
                double randomValue = random.NextDouble() * sum;
                for (int j = 0; j < boundaryValues.Count; j++)
                {
                    cumulative += boundaryValues[j];
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
