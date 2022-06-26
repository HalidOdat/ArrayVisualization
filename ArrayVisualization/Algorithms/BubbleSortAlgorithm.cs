using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayVisualization.Algorithms
{
    public class BubbleSortAlgorithm : Algorithm
    {
        public BubbleSortAlgorithm(Array array) : base(array)
        {
        }

        public override IEnumerator<AlgorithmState> Run()
        {
            for (int i = 0; i <= Array.Count - 2; i++)
            {
                for (int j = 0; j <= Array.Count - 2; j++)
                {
                    yield return new AlgorithmState(new List<int>() { i, j });

                    if (Array[j] > Array[j + 1])
                    {
                        Array.Swap(j, j + 1);
                    }
                }
            }

            yield break;
        }
    }
}
