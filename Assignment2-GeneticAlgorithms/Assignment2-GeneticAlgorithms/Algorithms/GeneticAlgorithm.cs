using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Assignment2_GeneticAlgorithms.Utils;

namespace Assignment2_GeneticAlgorithms.Algorithms
{
    class GeneticAlgorithm
    {
        private List<Customer> trainingData;
        private readonly int k = 100;
        private readonly int size = 40;
        private readonly double crossoverRate = 0.85;
        private readonly double mutationRate = 0.05;

        public GeneticAlgorithm(List<Customer> customers)
        {
            trainingData = customers;
        }

        public void Main()
        {
            // Main loop
            List<Seed> population = GeneratePopulation(size);
            ISelection selection = new RouletteSelection();
            ICrossover crossover = new SinglePointCrossover(population.First().attributes.Count / 2, crossoverRate);
            Seed elite;

            for (int i = 0; i < population.Count; i++)
            {
                population[i].fitness = Fitness(population[i]);
            }

            for (int i = 0; i < k; i++)
            {
                population = population.OrderBy(x => x.fitness).ToList(); // sort
                elite = new Seed(population.First().attributes, population.First().fitness); // elitism
                population = selection.Selection(population); // selection
                
                for (int j = 0; j < population.Count; j += 2) // crossover
                {
                    Tuple<Seed, Seed> children = crossover.Crossover(population[j], population[j + 1]);
                    population[j] = children.Item1;
                    population[j + 1] = children.Item2;
                }

                for (int j = 0; j < population.Count; j++) // mutate
                {
                    population[j] = Mutate(population[j]);
                }

                for (int j = 0; j < population.Count; j++) // recalculate fitness
                {
                    population[j].fitness = Fitness(population[j]);
                }

                population = population.OrderBy(x => x.fitness).ToList(); // sort again
                population[population.Count - 1] = elite; // replace the worst seed
                Console.WriteLine("elite = " + elite.fitness + ", fitness = " + population.OrderBy(x => x.fitness).ToList().First().fitness);
            }
        }

        private List<Seed> GeneratePopulation(int size)
        {
            List<Seed> population = new List<Seed>();
            for (int i = 0; i < size; i++)
            {
                population.Add(new Seed());
            }

            return population;
        }

        // Calculate the fitness per Individual
        public double Fitness(Seed seed)
        {
            double fitness = 0.0;

            for (int i = 0; i < trainingData.Count; i++)
            {
                double prediction = 1.0;
                double squaredError = 0.0;
                for (int j = 0; j < seed.attributes.Count; j++)
                {
                    prediction += trainingData[i].attributes[j] * seed.attributes[j];
                }
                squaredError = Math.Pow((trainingData[i].pregnant - prediction), 2);
                fitness += squaredError;
            }

            return fitness;
        }

        public Seed Mutate(Seed seed)
        {
            Random random = new Random();
            for (int i = 0; i < seed.attributes.Count; i++)
            {
                double randomValue = random.NextDouble();
                if (randomValue < mutationRate)
                {
                    seed.attributes[i] = seed.RandomAttribute();
                }
            }

            return seed;
        }
    }
}
