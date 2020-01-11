using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Assignment2_GeneticAlgorithms.Utils;

namespace Assignment2_GeneticAlgorithms.Algorithms
{
    class GeneticAlgorithm
    {
        private List<Customer> trainingData = new List<Customer>();
        private int k = 100;
        private int size = 40;
        private double selectionRate = 0.85;
        private double mutationRate = 0.05;

        public GeneticAlgorithm(List<Customer> customers)
        {
            trainingData = customers;
        }

        public void main()
        {
            // Main loop
            List<Seed> population = GeneratePopulation(size);
            List<double> fitnesses = new List<double>();
            for (int i = 0; i < population.Count; i++)
            {
                population[i].fitness = Fitness(population[i]);
            }

            population = population.OrderBy(x => x.fitness).ToList();

            for (int i = 0; i < population.Count; i++)
            {
                Console.WriteLine(i + " " + population[i].fitness);
            }

            //for (int i = 0; i < k; i++)
            //{
            //    // fitness
            //    // selection
            //    // crossover
            //    // mutation
            //    // use elitism to bring the best solution to the next population
            //}
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

        //public Tuple<Ind, Ind> Selection(ISelection selectionMethod)
        //{
        //    // Select individuals for crossover
        //    return selectionMethod.Selection(population, 50);
        //}

        public Tuple<Seed, Seed> Crossover(Seed parent1, Seed parent2)
        {
            // Crossover, with elitism, and create two children

            Seed child1 = new Seed(/* attributes */);
            Seed child2 = new Seed();

            return new Tuple<Seed, Seed>(child1, child2);
        }


    }
}
