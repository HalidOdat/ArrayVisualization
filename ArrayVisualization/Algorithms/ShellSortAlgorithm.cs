using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayVisualization.Algorithms
{
    /// <summary>
    /// Implementation of the Shell Sort Algorithm.
    /// 
    /// More Info: https://en.wikipedia.org/wiki/Shell_sort
    /// </summary>
    public class ShellSortAlgorithm : Algorithm
    {
        public ShellSortAlgorithm(Array array) : base("Shell Sort", array)
        {
        }

        protected override IEnumerator<AlgorithmState> CreateEnumerator()
        {
            int i, inc = 3;
            while (inc > 0)
            {
                for (i = 0; i < Array.Count; i++)
                {
                    yield return new AlgorithmState(new List<int> { i });

                    int j = i;
                    var temp = Array[i];
                    while ((j >= inc) && (Array[j - inc] > temp))
                    {
                        yield return new AlgorithmState(new List<int> { i, j - inc });
                        Array[j] = Array[j - inc];
                        j = j - inc;
                    }
                    yield return new AlgorithmState(new List<int> { i, j });

                    Array[j] = temp;

                    yield return new AlgorithmState(new List<int> { i, j });
                }
                if (inc / 2 != 0)
                    inc = inc / 2;
                else if (inc == 1)
                    inc = 0;
                else
                    inc = 1;
            }
        }
    }
}
