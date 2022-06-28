using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayVisualization.Algorithms
{
    public class OddEvenSortAlgorithm : Algorithm
    {
        public OddEvenSortAlgorithm(Array array) : base("Odd Even Sort", array)
        {
        }

        protected override IEnumerator<AlgorithmState> CreateEnumerator()
        {
            bool isSorted = false;

            while (!isSorted)
            {
                isSorted = true;

                //Swap i and i+1 if they are out of order, for i == odd numbers
                for (int i = 1; i <= Array.Count - 2; i = i + 2)
                {
                    yield return new AlgorithmState(new List<int> { i });
                    if (Array[i] > Array[i + 1])
                    {
                        Array.Swap(i, i + 1);
                        isSorted = false;

                        yield return new AlgorithmState(new List<int> { i, i + 1 });
                    }
                }

                //Swap i and i+1 if they are out of order, for i == even numbers
                for (int i = 0; i <= Array.Count - 2; i = i + 2)
                {
                    yield return new AlgorithmState(new List<int> { i });

                    if (Array[i] > Array[i + 1])
                    {
                        Array.Swap(i, i + 1);
                        isSorted = false;

                        yield return new AlgorithmState(new List<int> { i, i + 1 });
                    }
                }
            }
        }
    }
}
