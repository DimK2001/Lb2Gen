using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb2Gen
{
    internal class Individual
    {
        public Chromosome Chromosome;
        public Individual(List<bool> exons)
        {

        }
        public void SetChromosome(List<bool> exons)
        {

        }
        public double Fitness(double x, double y)
        {
            return -20 * Math.Exp(-0.2 * Math.Sqrt(0.5 * (x * x + y * y))) -
                    Math.Exp(0.5 * (Math.Cos(2 * Math.PI * x) + Math.Cos(2 * Math.PI * y))) +
                    Math.E + 20;
        }
        /*Tuple<double, double> xLimits1 = new(-5, 5);
        Tuple<double, double> yLimits1 = new(-5, 5);
        Tuple<double, double> globalExtremes = new(0, 0);*/
        public void Mutation()
        {
            Random random = new Random();
            Chromosome.Gens[random.Next(Chromosome.Gens.Count())].Mutation();
        }
        public List<bool> GetExons()
        {

        }
    }
}
