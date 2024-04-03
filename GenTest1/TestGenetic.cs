using Lb2Gen;
namespace GenTest1
{
    public class TestGenetic
    {
        [Fact]
        public void CrossingoverTest()
        {
            Population p = new Population();
            List<List<bool>> exons = p.crossingover(
                new List<bool> { true, false, false, true, false, false },
                new List<bool> { false, false, true, false, true, true },
                new List<int> { 2, 4, 5 } );
            Assert.Equal(new List<List<bool>> {
            new List<bool> {true, false, true, false, false, true},
            new List<bool> { false, false, false, true, true, false }
            }, exons);
        }
        [Fact]
        public void MutationTest()
        {
            List<bool> exons = new List<bool>();
            for (int i = 0; i < 16; i++)
            {
                exons.Add(true);
            }
            Gen gen = new Gen(exons);
            gen.Mutation();
            var ex = gen.Exons;
            int amount = 0;
            foreach (var e in ex)
            {
                if (e)
                {
                    amount++;
                }
            }
            Assert.Equal(exons.Count - 2, amount);
        }
        [Fact]
        public void FitnessTest()
        {
            List<bool> exons = new List<bool>();
            Individual individual = new Individual(exons);
            Assert.Equal(0, individual.Fitness(0, 0));
        }
    }
}