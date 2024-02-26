using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb2Gen
{
    internal class Gen
    {
        public double Value;
        public List<bool> Exons = new List<bool>();
        public Gen(List<bool> exons)
        {

        }
        public void SetValue(List<bool> num)
        {

        }
        public void SetValue(double num)
        {

        }
        public void Mutation()
        {
            Random random = new Random();
            bool g1 = Exons[random.Next(Exons.Count())];
            g1 = !g1;
            random = new Random();
            bool g2 = Exons[random.Next(Exons.Count())];
            g2 = !g2;
        }
    }
}
