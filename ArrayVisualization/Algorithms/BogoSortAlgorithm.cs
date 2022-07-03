using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayVisualization.Algorithms
{
    /// <summary>
    /// Implementation of the Bogo Sort (also known as permutation sort, stupid sort, or slowsort) Algorithm.
    /// 
    /// More Info: https://en.wikipedia.org/wiki/Bogosort
    /// </summary>
    public class BogoSortAlgorithm : Algorithm
    {
        public BogoSortAlgorithm(Array array) : base("Bogo Sort", array)
        {
        }

        protected override IEnumerator<AlgorithmState> CreateEnumerator()
        {
            while (!IsSorted())
            {
                yield return new AlgorithmState(new List<int> { });
                foreach (var state in new ShuffleAlgorithm(Array))
                {
                    yield return state;
                }
            }
        }

        /// <summary>
        /// Helper method to check if the array is sorted.
        /// </summary>
        /// <returns>Returns true if is sorted, false otherwise.</returns>
		private bool IsSorted()
		{
			int count = Array.Count;

            while (--count >= 1)
            {
                if (Array[count] < Array[count - 1]) return false;
            }

			return true;
		}
	}
}
