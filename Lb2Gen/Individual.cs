using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb2Gen
{
    public class Individual
    {
        public Chromosome Chromosome;
        public Individual(List<bool> exons)
        {
            SetChromosome(exons);
        }
        public void SetChromosome(List<bool> exons)
        {
            Gen firstGene = new Gen(exons.Take(16).ToList());
            Gen secondGene = new Gen(exons.Skip(16).Take(16).ToList());
            List<Gen> genes = new List<Gen>() { firstGene, secondGene };
            Chromosome = new Chromosome(genes);
        }
        public double Fitness(double x, double y)
        {
            return -20 * Math.Exp(-0.2 * Math.Sqrt(0.5 * (x * x + y * y))) -
                    Math.Exp(0.5 * (Math.Cos(2 * Math.PI * x) + Math.Cos(2 * Math.PI * y))) +
                    Math.E + 20;
        }
        Tuple<double, double> xLimits1 = new(-5, 5);
        Tuple<double, double> yLimits1 = new(-5, 5);
        Tuple<double, double> globalExtremes = new(0, 0);
        public void Mutation()
        {
            foreach (var g in Chromosome.Gens)
            {
                Random random = new Random();
                float probability = random.Next(900, 995);
                if (random.Next(0, 10000) < probability)
                {
                    g.Mutation();
                }
            }
        }
        /*public List<bool> GetExons()
        {

        }*/
    }
}
