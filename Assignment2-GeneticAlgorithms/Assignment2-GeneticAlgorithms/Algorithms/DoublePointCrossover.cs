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
            //string child1 = parent1.binary.Substring(0, firstCrossoverPoint);
            //child1 += parent2.binary.Substring(firstCrossoverPoint, secondCrossoverPoint);
            //child1 += parent1.binary.Substring(secondCrossoverPoint);

            //string child2 = parent2.binary.Substring(0, firstCrossoverPoint);
            //child2 += parent1.binary.Substring(firstCrossoverPoint, secondCrossoverPoint);
            //child2 += parent2.binary.Substring(secondCrossoverPoint);

            return new Tuple<Seed, Seed>(new Seed(), new Seed());
        }
    }
}
