using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2_GeneticAlgorithms.Utils
{
    class Ind
    {
        // Individual consists of 18 integers and one pregnant boolean
        public string binary;
        public Boolean pregnant;

        public Ind() { }

        public Ind(string attributes)
        {
            binary = attributes;
        }

        public Ind(string attributes, Boolean Pregnant)
        {
            binary = attributes;
            pregnant = Pregnant;
        }

        public void AddAttribute(string attribute)
        {
            binary += attribute;
        }

    }
}
