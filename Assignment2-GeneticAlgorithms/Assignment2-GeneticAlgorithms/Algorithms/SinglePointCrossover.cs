using System;
using System.Collections.Generic;
using System.Text;
using Assignment2_GeneticAlgorithms.Utils;

namespace Assignment2_GeneticAlgorithms.Algorithms
{
    class SinglePointCrossover : ICrossover
    {
        private int crossoverPoint;

        public SinglePointCrossover() { }

        public SinglePointCrossover(int CrossoverPoint)
        {
            crossoverPoint = CrossoverPoint;
        }

        public Tuple<Seed, Seed> Crossover(Seed parent1, Seed parent2)
        {
            List<double> child1 = new List<double>();
            List<double> child2 = new List<double>();
            for (int i = 0; i < 19; i++)
            {
                if (i + 1 < crossoverPoint)
                {
                    child1[i] = parent1.attributes[i];
                    child2[i] = parent2.attributes[i];
                }
                else
                {
                    child1[i] = parent2.attributes[i];
                    child2[i] = parent1.attributes[i];
                }
            }

            return new Tuple<Seed, Seed>(new Seed(child1), new Seed(child2));
        }
    }
}
