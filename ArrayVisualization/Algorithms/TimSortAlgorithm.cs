using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayVisualization.Algorithms
{
    public class TimSortAlgorithm : Algorithm
    {
        public TimSortAlgorithm(Array array) : base("Timsort", array)
        {
        }

        private const int RUN = 32;

        protected override IEnumerator<AlgorithmState> CreateEnumerator()
        {
            int n = Array.Count;

            // Sort individual subarrays of size RUN
            for (int i = 0; i < n; i += RUN)
            {
                foreach (var state in InsertionSort(i, Math.Min((i + RUN - 1), (n - 1))))
                {
                    yield return state;
                }
            }

            // Start merging from size RUN (or 32).
            // It will merge
            // to form size 64, then
            // 128, 256 and so on ....
            for (int size = RUN; size < n; size = 2 * size)
            {

                // Pick starting point of
                // left sub array. We
                // are going to merge
                // arr[left..left+size-1]
                // and arr[left+size, left+2*size-1]
                // After every merge, we increase
                // left by 2*size
                for (int left = 0; left < n; left += 2 * size)
                {

                    // Find ending point of left sub array
                    // mid+1 is starting point of
                    // right sub array
                    int mid = left + size - 1;
                    int right = Math.Min((left + 2 * size - 1), (n - 1));

                    // Merge sub array arr[left.....mid] &
                    // arr[mid+1....right]
                    if (mid < right)
                    {
                        foreach (var state in Merge(left, mid, right))
                        {
                            yield return state;
                        }
                    }
                }
            }
        }

        // This function sorts array from left index to
        // to right index which is of size atmost RUN
        private IEnumerable<AlgorithmState> InsertionSort(int left, int right)
        {
            for (int i = left + 1; i <= right; i++)
            {
                var temp = Array[i];
                int j = i - 1;
                yield return new AlgorithmState(new List<int> { i, j });

                while (j >= left && Array[j] > temp)
                {
                    Array[j + 1] = Array[j];
                    yield return new AlgorithmState(new List<int> { i, j, j + 1 });
                    j--;
                }
                Array[j + 1] = temp;
                yield return new AlgorithmState(new List<int> { i, j + 1 });
            }
        }

        // merge function merges the sorted runs
        private IEnumerable<AlgorithmState> Merge(int l, int m, int r)
        {
            // original array is broken in two parts
            // left and right array
            int len1  = m - l + 1, len2 = r - m;
            var left  = new Element[len1];
            var right = new Element[len2];

            for (int x = 0; x < len1; x++)
            {
                left[x] = Array[l + x];
                yield return new AlgorithmState(new List<int> { l + x });
            }

            for (int x = 0; x < len2; x++)
            {
                right[x] = Array[m + 1 + x];
                yield return new AlgorithmState(new List<int> { m + 1 + x });
            }

            int i = 0;
            int j = 0;
            int k = l;

            // After comparing, we merge those two array
            // in larger sub array
            while (i < len1 && j < len2)
            {
                yield return new AlgorithmState(new List<int> { k });
                if (left[i] <= right[j])
                {
                    Array[k] = left[i];
                    i++;
                }
                else
                {
                    Array[k] = right[j];
                    j++;
                }
                yield return new AlgorithmState(new List<int> { k });
                k++;
            }

            // Copy remaining elements
            // of left, if any
            while (i < len1)
            {
                yield return new AlgorithmState(new List<int> { k });
                Array[k] = left[i];
                yield return new AlgorithmState(new List<int> { k });
                k++;
                i++;
            }

            // Copy remaining element
            // of right, if any
            while (j < len2)
            {
                yield return new AlgorithmState(new List<int> { k });
                Array[k] = right[j];
                yield return new AlgorithmState(new List<int> { k });
                k++;
                j++;
            }
        }
    }
}
