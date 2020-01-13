using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2_GeneticAlgorithms.Utils
{
    class Seed
    {
        public List<double> attributes;
        public double fitness;

        public Seed()
        {
            attributes = new List<double>();
            FillAttributes();
        }

        public Seed(List<double> attributes)
        {
            this.attributes = attributes;
        }

        private double RandomAttribute(int min, int max)
        {
            Random random = new Random();
            return random.NextDouble() * (max - min) + min;
        }

        private void FillAttributes()
        {
            for (int i = 0; i < 19; i++)
            {
                attributes.Add(RandomAttribute(-1, 1));
            }
        }
    }
}
