using System;
using System.Collections.Generic;
using System.Text;
using Assignment2_GeneticAlgorithms.Utils;

namespace Assignment2_GeneticAlgorithms.Algorithms
{
    interface ISelection
    {
        Seed[] Selection(Seed[] population, int size);
    }
}
