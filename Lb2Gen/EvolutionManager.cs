using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                List<bool> genes = new List<bool>();
                //TODO: randomize genes
                population.NewIndovidual(genes);
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
