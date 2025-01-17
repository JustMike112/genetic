﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2_GeneticAlgorithms.Utils
{
    class Seed
    {
        public List<double> attributes;
        public double fitness;
        private readonly double min = -1;
        private readonly double max = 1;

        public Seed()
        {
            attributes = new List<double>();
            FillAttributes();
        }

        public Seed(List<double> attributes)
        {
            this.attributes = attributes;
        }

        public Seed(List<double> attributes, double fitness)
        {
            this.attributes = attributes;
            this.fitness = fitness;
        }

        public double RandomAttribute()
        {
            Random random = new Random();
            return random.NextDouble() * (max - min) + min;
        }

        private void FillAttributes()
        {
            for (int i = 0; i < 20; i++)
            {
                attributes.Add(RandomAttribute());
            }
        }
    }
}
