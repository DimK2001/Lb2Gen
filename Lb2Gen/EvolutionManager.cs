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
        public void GetNewGeneration()
        {
            double loss = double.MaxValue;
            double bestX = 0;
            double bestY = 0;
            Population currentPopulation = populations[populations.Count - 1];
            List<Individual> winners = new List<Individual>();
            Population newPopulation = new Population();
            for (int i = 0; i < currentPopulation.individuals.Count / 3; i++)
            {
                int winner = i * 3;
                double winnerVal = double.MaxValue;
                for (int j = i * 3; j < i * 3 + 3; ++j)
                {
                    if (currentPopulation.individuals[j].GetFitness() < winnerVal)
                    {
                        winner = j;
                        winnerVal = currentPopulation.individuals[j].GetFitness();
                        if (loss > winnerVal)
                        {
                            loss = winnerVal;
                            bestX = currentPopulation.individuals[j].Chromosome.Gens[0].GetDouble(-5, 5);
                            bestY = currentPopulation.individuals[j].Chromosome.Gens[1].GetDouble(-5, 5);
                        }
                    }
                }
                winners.Add(currentPopulation.individuals[winner]);
            }
            if (currentPopulation.individuals.Count % 3 > 0)
            {
                int winner = currentPopulation.individuals.Count;
                double winnerVal = double.MaxValue;
                for (int j = currentPopulation.individuals.Count - 3;
                    j < currentPopulation.individuals.Count; ++j)
                {
                    if (currentPopulation.individuals[j].GetFitness() < winnerVal)
                    {
                        winner = j;
                        winnerVal = currentPopulation.individuals[j].GetFitness();
                        if (loss > winnerVal)
                        {
                            loss = winnerVal;
                            bestX = currentPopulation.individuals[j].Chromosome.Gens[0].GetDouble(-5, 5);
                            bestY = currentPopulation.individuals[j].Chromosome.Gens[1].GetDouble(-5, 5);
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
                crossed = newPopulation.Crossingover(new List<Individual>
                { winners[i], winners[i + 2] }, 3);
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
            Console.WriteLine(loss + " " + bestX + " " + bestY);
        }
        public void RemovePopulation()
        {
            
        }
    }
}
