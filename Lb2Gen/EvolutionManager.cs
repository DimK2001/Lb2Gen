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
                for (int j = 0; j < 32; ++j)
                {
                    exons.Add(rnd.NextDouble() > 0.5);
                }
                population.NewIndovidual(exons);
            }
            populations.Add(population);
        }
        public double GetNewGeneration()
        {
            double loss = double.MaxValue;
            double bestX = 0;
            double bestY = 0;
            Population currentPopulation = populations[populations.Count - 1];
            List<Individual> winners = new List<Individual>();
            Population newPopulation = new Population();
            for (int i = 0; i < currentPopulation.individuals.Count; i++)
            {
                int winner = 0;
                double winnerVal = double.MaxValue;
                for (int j = 0; j < 3; ++j)
                {
                    int spc = rnd.Next(currentPopulation.individuals.Count);
                    if (currentPopulation.individuals[spc].GetFitness() < winnerVal)
                    {
                        winner = spc;
                        winnerVal = currentPopulation.individuals[spc].GetFitness();
                        if (loss > winnerVal)
                        {
                            loss = winnerVal;
                            bestX = currentPopulation.individuals[spc].Chromosome.Gens[0].GetDouble(-5, 5);
                            bestY = currentPopulation.individuals[spc].Chromosome.Gens[1].GetDouble(-5, 5);
                        }
                    }
                }
                winners.Add(currentPopulation.individuals[winner]);
            }
            for (int i = 0; i < winners.Count / 2; ++i)
            {
                List<Individual> crossed = newPopulation.Crossingover(new List<Individual> 
                { winners[i * 2], winners[i * 2 + 1] }, 3);
                newPopulation.NewIndovidual(crossed[0].Chromosome.GetExons());
                newPopulation.NewIndovidual(crossed[1].Chromosome.GetExons());
            }
            if (winners.Count % 2 > 0)
            {
                List<Individual> crossed = newPopulation.Crossingover(new List<Individual>
                { winners[winners.Count - 1], winners[winners.Count - 2] }, 3);
                newPopulation.NewIndovidual(crossed[0].Chromosome.GetExons());
                newPopulation.NewIndovidual(crossed[1].Chromosome.GetExons());
            }
            foreach (Individual individual in newPopulation.individuals)
            {
                individual.Mutation();
            }
            populations.Add(newPopulation);
            Console.WriteLine(populations.Count - 1 + " Error: " + loss + " X=" + bestX + " Y=" + bestY);
            return loss;
        }
        public void RemovePopulation()
        {
            
        }
    }
}
