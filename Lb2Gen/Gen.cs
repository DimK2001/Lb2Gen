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
        public Gen(List<bool>? exons = null)
        {
            Exons = exons ?? new List<bool>();
        }
        public void SetValue(List<bool> exons)
        {
            Exons = exons;
        }
        public void SetValue(double num)
        {
            bool[] exons = new bool[16];
            int n = Convert.ToInt32(num);
            string grey = Convert.ToString(n ^ (n >> 1), 2);
            for (int i = 0; i < grey.Length; ++i)
            {
                if (grey[i] == '0')
                {
                    exons[16 - (grey.Length - i)] = false;
                }
                else if (grey[i] == '1')
                {
                    exons[16 - (grey.Length - i)] = true;
                }
            }
            Exons = exons.ToList();
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
