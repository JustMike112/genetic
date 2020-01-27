using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Assignment2_GeneticAlgorithms.Utils
{
    static class Parser
    {
        public static List<Customer> Parse(char delimiter, string path)
        {
            var result = File.ReadAllLines(path);
            List<Customer> population = new List<Customer>();

            foreach (var line in result)
            {
                var x = line.Split(delimiter);
                List<double> attributes = new List<double>();
                Customer customer = new Customer();
                var item = 0;
                foreach (var column in x)
                {
                    item++;
                    if (item < 20)
                    {
                        attributes.Add(double.Parse(column, System.Globalization.CultureInfo.InvariantCulture));
                    }
                    else
                    {
                        if (column == "0")
                            customer.pregnant = 0;
                        else
                            customer.pregnant = 1;
                    }
                }
                attributes.Add(1); // intercept
                customer.attributes = attributes;
                population.Add(customer);
            }

            return population;
        }
    }
}
