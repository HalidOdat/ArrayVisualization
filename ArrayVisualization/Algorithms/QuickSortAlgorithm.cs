using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayVisualization.Algorithms
{
    public class QuickSortAlgorithm : Algorithm
    {
        public QuickSortAlgorithm(Array array) : base(array)
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

        public IEnumerable<AlgorithmState> SortArray(Array array, int leftIndex, int rightIndex)
        {
            var i = leftIndex;
            var j = rightIndex;
            var pivot = array[leftIndex];
            while (i <= j)
            {
                while (array[i] < pivot)
                {
                    yield return new AlgorithmState(new List<int>() { i, j });
                    i++;
                }

                while (array[j] > pivot)
                {
                    yield return new AlgorithmState(new List<int>() { i, j });
                    j--;
                }
                if (i <= j)
                {
                    yield return new AlgorithmState(new List<int>() { i, j });
                    array.Swap(i, j);

                    yield return new AlgorithmState(new List<int>() { i, j });
                    i++;
                    yield return new AlgorithmState(new List<int>() { i, j });
                    j--;
                    yield return new AlgorithmState(new List<int>() { i, j });
                }
            }

            if (leftIndex < j)
            {
                foreach (var item in SortArray(array, leftIndex, j))
                {
                    yield return item;
                }
            }

            if (i < rightIndex)
            {
                foreach (var item in SortArray(array, i, rightIndex))
                {
                    yield return item;
                }
            }
        }
    }
}
