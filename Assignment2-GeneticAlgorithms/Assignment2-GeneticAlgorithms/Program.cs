using System;
using System.Linq;
using System.Collections.Generic;
using Assignment2_GeneticAlgorithms.Algorithms;
using Assignment2_GeneticAlgorithms.Utils;

namespace Assignment2_GeneticAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            //double[] attributes = new double[19];

            //for (int i = 0; i < 19; i++)
            //{
            //    attributes[i] = randomized(-1, 1);
            //    Console.WriteLine(i + " " + attributes[i]);
            //}
            List<Customer> pop = Parser.Parse(';', "RetailMart.csv");


            List<Customer> pregnant = new List<Customer>();
            List<Customer> notPregnant = new List<Customer>();

            for (int i = 0; i < pop.Count; i++)
            {
                if (pop[i].pregnant == 1)
                    pregnant.Add(pop[i]);
                else
                    notPregnant.Add(pop[i]);
            }

            var customers = pregnant.Take(50).ToList();
            customers.AddRange(notPregnant.Take(50).ToList());
            GeneticAlgorithm gen = new GeneticAlgorithm(customers);
            gen.Main();

            var f = gen.Prediction(pop.Last());
            Console.WriteLine(f);
            Console.WriteLine(f == pop.Last().pregnant);

            var predictions = new List<int>();
            var correct = new List<bool>();
            var wrong = new List<bool>();
            for (int i = 0; i < pop.Count; i++)
            {
                var p = gen.Prediction(pop[i]);
                if (p == pop[i].pregnant)
                {
                    if (p == 1)
                        correct.Add(true);
                    else
                        correct.Add(false);
                }
                else
                {
                    wrong.Add(false);
                }

            }

            Console.WriteLine(correct.Count);


            //Console.WriteLine(19 / 2);

            //Seed x = new Seed(new List<double> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            //Seed y = new Seed(new List<double> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 });
            //Seed z = new Seed(new List<double> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1 });

            //x.fitness = 5.2;
            //y.fitness = 8.6;
            //z.fitness = 17.2;
            //var population = new List<Seed>() { x, y, z };

            //List<Seed> selected = new List<Seed>();
            //Random random = new Random();
            //population = population.OrderBy(i => i.fitness).ToList();
            //int maxCumulative = (population.Count * (population.Count + 1)) / 2; // max value for boundaries -> (n * (n+2)) / 2

            //for (int i = 0; i < population.Count; i++) // loop to get an entire new population
            //{
            //    int cumulative = 0;
            //    int randomValue = random.Next(0, maxCumulative); // random value between 0 and max cumulative value (all boundaries added together)
            //    Console.WriteLine(randomValue);

            //    for (int j = 0; j < population.Count; j++) // loop to add one new seed to the new population
            //    {
            //        cumulative += (population.Count - j);
            //        if (cumulative > randomValue)
            //        {
            //            selected.Add(population[j]);
            //            break;
            //        }
            //    }
            //}

            //Console.WriteLine(maxCumulative);

            //var max = population.Sum(i => i.fitness);

            //List<double> boundaryValues = new List<double>();
            //for (int i = 0; i < population.Count; i++)
            //{
            //    boundaryValues.Add(1 - (population[i].fitness / max));
            //}

            //var selected = new List<Seed>();
            //Random random = new Random();
            //for (int i = 0; i < population.Count; i++)
            //{
            //    var cumulative = 0.0;
            //    var randomValue = random.NextDouble() * boundaryValues.Sum();
            //    for (int j = 0; j < boundaryValues.Count; j++)
            //    {
            //        cumulative += boundaryValues[j];
            //        if (cumulative > randomValue)
            //        {
            //            selected.Add(population[j]);
            //            break;
            //        }
            //    }
            //}

            //for (int i = 0; i < selected.Count; i++)
            //{
            //    Console.WriteLine(selected[i].fitness);
            //}

            //ICrossover crossover = new DoublePointCrossover(6, 13);
            //Tuple<Seed, Seed> xy = crossover.Crossover(x, y);

            //Console.WriteLine(x.attributes.Count);
            //for (int i = 0; i < xy.Item1.attributes.Count; i++)
            //{
            //    Console.WriteLine(xy.Item1.attributes[i]);
            //}

            Console.ReadLine();
        }

        private static double randomized(int min, int max)
        {
            Random random = new Random();
            return random.NextDouble() * (max - min) + min;
        }
    }
}
