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
            Console.WriteLine(pop.Count);


            List<Customer> preg = new List<Customer>();
            List<Customer> notPreg = new List<Customer>();

            for (int i = 0; i < pop.Count; i++)
            {
                if (pop[i].pregnant == 1)
                    preg.Add(pop[i]);
                else
                    notPreg.Add(pop[i]);

            }

            var customers = preg.Take(5).ToList();
            customers.AddRange(notPreg.Take(5).ToList());
            GeneticAlgorithm gen = new GeneticAlgorithm(customers);
            gen.main();

            Console.ReadLine();
        }

        private static double randomized(int min, int max)
        {
            Random random = new Random();
            return random.NextDouble() * (max - min) + min;
        }
    }
}
