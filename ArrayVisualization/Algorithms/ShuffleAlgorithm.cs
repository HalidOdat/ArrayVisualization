using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayVisualization.Algorithms
{
    public class ShuffleAlgorithm : Algorithm
    {
        public static Random RANDOM = new Random();

        public ShuffleAlgorithm(Array array) : base("Shuffle", array)
        {
        }

        protected override IEnumerator<AlgorithmState> CreateEnumerator()
        {
            int n = Array.Count;
            while (n > 1)
            {
                int k = RANDOM.Next(n--);
                yield return new AlgorithmState(new List<int> { n, k });
                Array.Swap(n, k);
            }
        }
    }
}
