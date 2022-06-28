using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayVisualization.Algorithms
{
    public class GnomeSortAlgorithm : Algorithm
    {
        public GnomeSortAlgorithm(Array array) : base("Gnome Sort", array)
        {
        }

        protected override IEnumerator<AlgorithmState> CreateEnumerator()
        {
			for (int i = 1; i < Array.Count;)
			{
				yield return new AlgorithmState(new List<int> { i });
				if (Array[i - 1] <= Array[i])
				{
					++i;
				}
				else
				{
					Array.Swap(i,  i - 1);
					yield return new AlgorithmState(new List<int> { i });

					--i;
					if (i == 0) 
						i = 1;
				}
				yield return new AlgorithmState(new List<int> { i });
			}
		}
    }
}
