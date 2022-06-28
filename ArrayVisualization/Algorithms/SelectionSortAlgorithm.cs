using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayVisualization.Algorithms
{
    public class SelectionSortAlgorithm : Algorithm
    {
        public SelectionSortAlgorithm(Array array) : base("Selection Sort", array)
        {
        }

        protected override IEnumerator<AlgorithmState> CreateEnumerator()
        {
            var arrayLength = Array.Count;
            for (int i = 0; i < Array.Count - 1; i++)
            {
                yield return new AlgorithmState(new List<int> { i });
                var smallestValue = i;
                for (int j = i + 1; j < Array.Count; j++)
                {
                    yield return new AlgorithmState(new List<int> { i, j });
                    if (Array[j] < Array[smallestValue])
                    {
                        smallestValue = j;
                    }
                }
                Array.Swap(i, smallestValue);
                yield return new AlgorithmState(new List<int> { i, smallestValue });
            }

            yield break;
        }
    }
}
