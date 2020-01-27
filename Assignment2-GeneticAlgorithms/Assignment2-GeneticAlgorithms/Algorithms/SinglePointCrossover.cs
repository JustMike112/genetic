using System;
using System.Collections.Generic;
using System.Text;
using Assignment2_GeneticAlgorithms.Utils;

namespace Assignment2_GeneticAlgorithms.Algorithms
{
    class SinglePointCrossover : ICrossover
    {
        private int crossoverPoint;
        private double crossoverRate;
        private Random random = new Random();

        public SinglePointCrossover(int crossoverPoint, double crossoverRate)
        {
            this.crossoverPoint = crossoverPoint;
            this.crossoverRate = crossoverRate;
        }

        public Tuple<Seed, Seed> Crossover(Seed parent1, Seed parent2)
        {
            if (random.NextDouble() >= crossoverRate)
                return new Tuple<Seed, Seed>(parent1, parent2);

            List<double> child1 = new List<double>();
            List<double> child2 = new List<double>();
            for (int i = 0; i < parent1.attributes.Count; i++)
            {
                if (i + 1 < crossoverPoint)
                {
                    child1.Add(parent1.attributes[i]);
                    child2.Add(parent2.attributes[i]);
                }
                else
                {
                    child1.Add(parent2.attributes[i]);
                    child2.Add(parent1.attributes[i]);
                }
            }

            return new Tuple<Seed, Seed>(new Seed(child1), new Seed(child2));
        }
    }
}
