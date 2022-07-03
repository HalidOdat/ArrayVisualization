using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayVisualization.Algorithms
{
    public class MergeSortAlgorithm : Algorithm
    {
        public MergeSortAlgorithm(Array array) : base("Merge Sort", array)
        {
        }

        protected override IEnumerator<AlgorithmState> CreateEnumerator()
        {
            foreach (var x in SortArray(Array, 0, Array.Count - 1))
            {
                yield return x;
            }

            yield break;
        }

        public IEnumerable<AlgorithmState> SortArray(Array array, int left, int right)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;
                foreach (var x in SortArray(array, left, middle))
                {
                    yield return x;
                }
                foreach (var x in SortArray(array, middle + 1, right))
                {
                    yield return x;
                }
                foreach (var x in MergeArray(array, left, middle, right))
                {
                    yield return x;
                }
            }
        }

        public IEnumerable<AlgorithmState> MergeArray(Array array, int left, int middle, int right)
        {
            var leftArrayLength = middle - left + 1;
            var rightArrayLength = right - middle;
            var leftTempArray = new int[leftArrayLength];
            var rightTempArray = new int[rightArrayLength];
            int i, j;
            for (i = 0; i < leftArrayLength; ++i)
            {
                yield return new AlgorithmState(new List<int>() { i });
                leftTempArray[i] = array[left + i];
                yield return new AlgorithmState(new List<int>() { i });
            }
            for (j = 0; j < rightArrayLength; ++j)
            {
                yield return new AlgorithmState(new List<int>() { j, middle + 1 + j });
                rightTempArray[j] = array[middle + 1 + j];
                yield return new AlgorithmState(new List<int>() { j, middle + 1 + j });
            }
                
            i = 0;
            j = 0;
            int k = left;
            while (i < leftArrayLength && j < rightArrayLength)
            {
                yield return new AlgorithmState(new List<int>() { i, j, k });
                if (leftTempArray[i] <= rightTempArray[j])
                {
                    array[k++] = leftTempArray[i++];
                }
                else
                {   
                    array[k++] = rightTempArray[j++];
                }
                yield return new AlgorithmState(new List<int>() { i, j, k });
            }

            while (i < leftArrayLength)
            {
                yield return new AlgorithmState(new List<int>() { i, j, k });
                array[k++] = leftTempArray[i++];
                yield return new AlgorithmState(new List<int>() { i, j, k });
            }
            while (j < rightArrayLength)
            {
                yield return new AlgorithmState(new List<int>() { i, j, k });
                array[k++] = rightTempArray[j++];
                yield return new AlgorithmState(new List<int>() { i, j, k });
            }
        }
    }
}
