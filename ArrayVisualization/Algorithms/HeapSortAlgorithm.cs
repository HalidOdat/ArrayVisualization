using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayVisualization.Algorithms
{
    public class HeapSortAlgorithm : Algorithm
    {
        public HeapSortAlgorithm(Array array) : base(array)
        {
        }

        protected override IEnumerator<AlgorithmState> CreateEnumerator()
        {
            foreach (var state in SortArray())
            {
                yield return state;
            }

            yield break;
        }

        private IEnumerable<AlgorithmState> SortArray()
        {
            int n = Array.Count;
            for (int i = n / 2; i >= 0; i--)
            {
                foreach (var state in Heapify(n - 1, i))
                {
                    yield return state;
                }
            }
            for (int i = n - 1; i >= 0; i--)
            {
                //swap last element of the max-heap with the first element
                Array.Swap(i, 0);

                //exclude the last element from the heap and rebuild the heap 
                foreach (var state in Heapify(i - 1, 0))
                {
                    yield return state;
                }
            }
        }

        // heapify function is used to build the max heap
        // max heap has maximum element at the root which means
        // first element of the array will be maximum in max heap
        private IEnumerable<AlgorithmState> Heapify(int n, int i)
        {
            int max = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            //if the left element is greater than root
            if (left <= n && Array[left] > Array[max])
            {
                max = left;
            }

            //if the right element is greater than root
            if (right <= n && Array[right] > Array[max])
            {
                max = right;
            }

            //if the max is not i
            if (max != i)
            {
                yield return new AlgorithmState(new List<int> { i, max });
                Array.Swap(i, max);

                //Recursively heapify the affected sub-tree
                foreach (var state in Heapify(n, max))
                {
                    yield return state;
                }
            }
        }
    }
}
