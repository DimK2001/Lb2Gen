using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Lb2Gen
{
    internal class EvolutionManager
    {
        List<Population> populations = new List<Population>();
        Random rnd = new Random();
        public void InitPipolation (int populationCount)
        {
            Population population = new Population();
            for (int i = 0; i < populationCount; i++)
            {
                List<bool> exons = new List<bool>();
                for (int j = 0; j < 16; ++j)
                {
                    exons.Add(rnd.NextDouble() > 0.5);
                }
                population.NewIndovidual(exons);
            }
            populations.Add(population);
        }
        public void GetNewGeneration()
        {

        }
        public void RemovePopulation()
        {

        }
    }
}
