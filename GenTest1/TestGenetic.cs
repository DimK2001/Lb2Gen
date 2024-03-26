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
    }
}