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
            List<Customer> population = Parser.Parse(';', "RetailMart.csv");
            List<Customer> pregnant = new List<Customer>();
            List<Customer> notPregnant = new List<Customer>();

            for (int i = 0; i < population.Count; i++)
            {
                if (population[i].pregnant == 1)
                    pregnant.Add(population[i]);
                else
                    notPregnant.Add(population[i]);
            }

            List<Customer> customers = pregnant.Take(50).ToList();
            customers.AddRange(notPregnant.Take(50).ToList());
            GeneticAlgorithm gen = new GeneticAlgorithm(customers);
            gen.Main();

            Customer chosenCustomer = population[50]; 

            int prediction = gen.Prediction(chosenCustomer);

            if (chosenCustomer.pregnant == prediction)
            {
                Console.WriteLine("The prediction was correct!");
            } else
            {
                Console.WriteLine("The prediction was false!");
            }

            Console.ReadLine();
        }
    }
}
