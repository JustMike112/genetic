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
        private readonly int size = 60;
        private readonly double crossoverRate = 0.85;
        private readonly double mutationRate = 0.05;
        private ISelection selection;
        private ICrossover crossover;
        public Seed topSeed;

        public GeneticAlgorithm(List<Customer> customers)
        {
            trainingData = customers;
        }

        public void Main()
        {
            // Main loop
            List<Seed> population = GeneratePopulation(size);
            selection = new RouletteSelection();
            crossover = new SinglePointCrossover(population.First().attributes.Count / 2, crossoverRate);
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
                //Console.WriteLine("elite = " + elite.fitness + ", fitness = " + population.OrderBy(x => x.fitness).ToList().First().fitness);
            }

            if (topSeed == null || topSeed.fitness < population.OrderBy(x => x.fitness).ToList().First().fitness)
                topSeed = new Seed(population.OrderBy(x => x.fitness).ToList().First().attributes, population.OrderBy(x => x.fitness).ToList().First().fitness);
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
                double prediction = 0.0;
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

        public int Prediction(Customer customer)
        {
            double prediction = 0.0;
            double cutoffRate = 0.85;
            for (int i = 0; i < customer.attributes.Count; i++)
            {
                prediction += customer.attributes[i] * topSeed.attributes[i];
            }

            Console.WriteLine("Genetic Algorithms");
            Console.WriteLine("population size: " + size);
            Console.WriteLine("generations: " + k);
            Console.WriteLine("crossover rate: " + crossoverRate);
            Console.WriteLine("mutation rate: " + mutationRate);
            Console.WriteLine("selection method: " + selection.GetType().Name);
            Console.WriteLine("crossover method: " + crossover.GetType().Name);
            Console.WriteLine("size of training data: " + trainingData.Count);
            Console.WriteLine();
            Console.WriteLine("the best fitness value (" + topSeed.fitness + ") belongs to the following seed:");
            Console.Write("[");
            for (int i = 0; i < topSeed.attributes.Count; i++)
            {
                if (i < topSeed.attributes.Count - 1)
                {
                    Console.Write(Math.Round(topSeed.attributes[i], 3) + ", ");
                } else
                {
                    Console.Write(Math.Round(topSeed.attributes[i], 3) + "]");
                }
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("The customer that was input has the following attributes:");
            Console.Write("[");
            for (int i = 0; i < customer.attributes.Count; i++)
            {
                if (i < customer.attributes.Count - 1)
                {
                    Console.Write(customer.attributes[i] + ", ");
                }
                else
                {
                    Console.Write(customer.attributes[i] + "]");
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("After multiplying the customer with the top seed we receive the following prediction: " + prediction);

            if (prediction > cutoffRate)
            {
                Console.WriteLine("The prediction is greater than the cutoffrate (" + cutoffRate + ")");
                Console.WriteLine("We can therefore assume that this customer is pregnant");
                return 1;
            }
            else
            {
                Console.WriteLine("The prediction is lower than the cutoffrate (" + cutoffRate + ")");
                Console.WriteLine("We can therefore assume that this customer is not pregnant");
                return 0;
            }
        }
    }
}
