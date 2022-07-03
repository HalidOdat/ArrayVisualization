using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayVisualization.Algorithms
{
    /// <summary>
    /// Implementation of the Bubble Sort Algorithm.
    /// 
    /// More Info: https://en.wikipedia.org/wiki/Bubble_sort
    /// </summary>
    public class BubbleSortAlgorithm : Algorithm
    {
        public BubbleSortAlgorithm(Array array) : base("Bubble Sort", array)
        {
        }

        protected override IEnumerator<AlgorithmState> CreateEnumerator()
        {
            for (int i = 0; i <= Array.Count - 2; i++)
            {
                yield return new AlgorithmState(new List<int>() { i });
                for (int j = 0; j <= Array.Count - 2; j++)
                {
                    yield return new AlgorithmState(new List<int>() { i, j });

                    if (Array[j] > Array[j + 1])
                    {
                        Array.Swap(j, j + 1);
                        yield return new AlgorithmState(new List<int>() { i, j, j + 1 });
                    }
                }
            }

            yield break;
        }
    }
}
