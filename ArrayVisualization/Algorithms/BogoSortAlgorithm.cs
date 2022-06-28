using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayVisualization.Algorithms
{
    public class BogoSortAlgorithm : Algorithm
    {
        public BogoSortAlgorithm(Array array) : base(array)
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
