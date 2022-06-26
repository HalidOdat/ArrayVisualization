using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayVisualization.Algorithms
{
    public class ReverseAlgorithm : Algorithm
    {
        public ReverseAlgorithm(Array array) : base(array)
        {
        }

        public override IEnumerator<AlgorithmState> Run()
        {
            int n = Array.Count;
            for (int i = 0; i < n / 2; i++)
            {
                Array.Swap(i, n - i - 1);
                yield return new AlgorithmState(new List<int> { i, n - i - 1 });
            }
        }
    }
}
