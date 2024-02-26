using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb2Gen
{
    internal class Population
    {
        List<Individual> individuals = new List<Individual>();
        public void NewIndovidual (List<bool> exons)
        {
            Individual individual = new Individual(exons);
            individuals.Add(individual);
        }
        public List<Individual> SelectPair()
        {
            
        }
        public List<Individual> Crossingover (List<Individual> parents)
        {
            
        }
        public void Clean()
        {
            individuals.Clear();
        }
    }
}
