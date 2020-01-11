using System;
using System.Collections.Generic;
using System.Text;
using Assignment2_GeneticAlgorithms.Utils;

namespace Assignment2_GeneticAlgorithms.Algorithms
{
    interface ICrossover
    {
        Tuple<Seed, Seed> Crossover(Seed parent1, Seed parent2);
    }
}
