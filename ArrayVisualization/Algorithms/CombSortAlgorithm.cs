using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayVisualization.Algorithms
{
    public class CombSortAlgorithm : Algorithm
    {
        public CombSortAlgorithm(Array array) : base("Comb Sort", array)
        {
        }

        protected override IEnumerator<AlgorithmState> CreateEnumerator()
        {
			double gap = Array.Count;
			bool swaps = true;

			while (gap > 1 || swaps)
			{
				gap /= 1.247330950103979;

				if (gap < 1)
					gap = 1;

				int i = 0;
				swaps = false;

				while (i + gap < Array.Count)
				{
					int igap = i + (int)gap;

					yield return new AlgorithmState(new List<int> { i, igap });
					if (Array[i] > Array[igap])
					{
						Array.Swap(i, igap);
						swaps = true;

						yield return new AlgorithmState(new List<int> { i, igap });
					}

					++i;
				}
			}
		}
    }
}
