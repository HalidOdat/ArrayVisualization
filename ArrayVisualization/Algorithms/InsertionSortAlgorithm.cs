using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayVisualization.Algorithms
{
    /// <summary>
	/// Implementation of the Insertion Sort Algorithm.
    /// 
	/// More Info: https://en.wikipedia.org/wiki/Insertion_sort
	/// </summary>
    public class InsertionSortAlgorithm : Algorithm
    {
        public InsertionSortAlgorithm(Array array) : base("Insertion Sort", array)
        {
        }

        protected override IEnumerator<AlgorithmState> CreateEnumerator()
        {
            for (int i = 0; i < Array.Count - 1; i++)
            {
                yield return new AlgorithmState(new List<int> { i });
                for (int j = i + 1; j > 0; j--)
                {
                    yield return new AlgorithmState(new List<int> { i, j });
                    if (Array[j - 1] > Array[j])
                    {
                        Array.Swap(j - 1, j);
                        yield return new AlgorithmState(new List<int> { i, j, j - 1 });
                    }
                }
            }

            yield break;
        }
    }
}
