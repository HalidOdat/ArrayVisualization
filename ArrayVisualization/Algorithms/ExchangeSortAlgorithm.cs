using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayVisualization.Algorithms
{
    public class ExchangeSortAlgorithm : Algorithm
    {
        public ExchangeSortAlgorithm(Array array) : base("Exchange Sort", array)
        {
        }

        protected override IEnumerator<AlgorithmState> CreateEnumerator()
        {
			for (int i = 0; i < Array.Count - 1; ++i)
			{
				yield return new AlgorithmState(new List<int> { i });
				for (int j = i + 1; j < Array.Count; ++j)
				{
					yield return new AlgorithmState(new List<int> { i, j });
					if (Array[i] > Array[j])
					{
						Array.Swap(i, j);
						yield return new AlgorithmState(new List<int> { i, j });
					}
				}
			}
		}
    }
}
