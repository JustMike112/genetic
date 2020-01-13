using System;
using System.Collections.Generic;
using System.Text;
using Assignment2_GeneticAlgorithms.Utils;

namespace Assignment2_GeneticAlgorithms.Algorithms
{
    class DoublePointCrossover : ICrossover
    {
        private int firstCrossoverPoint;
        private int secondCrossoverPoint;

        public DoublePointCrossover(int FirstCrossoverPoint, int SecondCrossoverPoint)
        {
            firstCrossoverPoint = FirstCrossoverPoint;
            secondCrossoverPoint = SecondCrossoverPoint;
        }

        public Tuple<Seed, Seed> Crossover(Seed parent1, Seed parent2)
        {
            List<double> child1 = new List<double>();
            List<double> child2 = new List<double>();
            for (int i = 0; i < 19; i++)
            {
                if (i + 1 < firstCrossoverPoint)
                {
                    child1.Add(parent1.attributes[i]);
                    child2.Add(parent2.attributes[i]);
                }
                else if (i + 1 < secondCrossoverPoint)
                {
                    child1.Add(parent2.attributes[i]);
                    child2.Add(parent1.attributes[i]);
                }
                else
                {
                    child1.Add(parent1.attributes[i]);
                    child2.Add(parent2.attributes[i]);
                }
            }

            return new Tuple<Seed, Seed>(new Seed(child1), new Seed(child2));
        }
    }
}
