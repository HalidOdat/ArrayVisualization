using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayVisualization.Algorithms
{
    public class InPlaceMergeSortAlgorithm : Algorithm
    {
        public InPlaceMergeSortAlgorithm(Array array) : base("In-Place Merge Sort", array)
        {
        }

        protected override IEnumerator<AlgorithmState> CreateEnumerator()
        {
            foreach (var state in Sort(0, Array.Count - 1))
            {
                yield return state;
            }

            yield break;
        }

        /* l is for left index and r is right index of the
        sub-array of arr to be sorted */
        private IEnumerable<AlgorithmState> Sort(int l, int r)
        {
            if (l < r)
            {

                // Same as (l + r) / 2, but avoids overflow
                // for large l and r
                int m = l + (r - l) / 2;

                // Sort first and second halves
                foreach (var state in Sort(l, m)) yield return state;
                foreach (var state in Sort(m + 1, r)) yield return state;

                foreach (var state in Merge(l, m, r)) yield return state;
            }
        }

        // Merges two subarrays of arr[].
        // First subarray is arr[l..m]
        // Second subarray is arr[m+1..r]
        // Inplace Implementation
        private IEnumerable<AlgorithmState> Merge(int start, int mid, int end)
        {
            int start2 = mid + 1;

            // If the direct merge is already sorted
            if (Array[mid] <= Array[start2])
            {
                yield break;
            }

            // Two pointers to maintain start
            // of both arrays to merge
            while (start <= mid && start2 <= end)
            {

                yield return new AlgorithmState(new List<int> { start, start2 });

                // If element 1 is in right place
                if (Array[start] <= Array[start2])
                {
                    start++;
                }
                else
                {
                    var value = Array[start2];
                    int index = start2;

                    // Shift all the elements between element 1
                    // element 2, right by 1.
                    while (index != start)
                    {
                        yield return new AlgorithmState(new List<int> { index, index - 1 });
                        Array[index] = Array[index - 1];
                        index--;
                    }
                    Array[start] = value;

                    yield return new AlgorithmState(new List<int> { start });

                    // Update all the pointers
                    start++;
                    mid++;
                    start2++;
                }
            }
        }
    }
}
