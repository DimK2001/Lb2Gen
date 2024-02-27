using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb2Gen
{
    internal class Chromosome
    {
        public List<Gen> Gens = new List<Gen>();
        public Chromosome(List<Gen>? gens = null)
        {
            Gens = gens ?? new List<Gen>();
        }
        //mb wrong
        public List<bool> GetExons()
        {
            List<bool> exons = new List<bool>();
            foreach (var gene in Gens)
            {
                exons.AddRange(gene.Exons);
            }
            return exons;
        }
    }
}
