using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayVisualization.Algorithms
{
    public class MergeSortAlgorithm : Algorithm
    {
        public MergeSortAlgorithm(Array array) : base(array)
        {
        }

        public override IEnumerator<List<int>> Run()
        {
            foreach (var x in SortArray(Array.Elements, 0, Array.Count - 1))
            {
                yield return x;
            }

            yield break;
        }

        public IEnumerable<List<int>> SortArray(List<Element> array, int left, int right)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;
                var elems = SortArray(array, left, middle);
                foreach (var x in elems)
                {
                    yield return x;
                }
                elems = SortArray(array, middle + 1, right);
                foreach (var x in elems)
                {
                    yield return x;
                }
                elems = MergeArray(array, left, middle, right);
                foreach (var x in elems)
                {
                    yield return x;
                }
            }
        }

        public IEnumerable<List<int>> MergeArray(List<Element> array, int left, int middle, int right)
        {
            var leftArrayLength = middle - left + 1;
            var rightArrayLength = right - middle;
            var leftTempArray = new Element[leftArrayLength];
            var rightTempArray = new Element[rightArrayLength];
            int i, j;
            for (i = 0; i < leftArrayLength; ++i)
            {
                leftTempArray[i] = array[left + i];
                yield return new List<int>() { i, 0 };
            }
            for (j = 0; j < rightArrayLength; ++j)
            {
                rightTempArray[j] = array[middle + 1 + j];
                yield return new List<int>() { i, j };
            }
                
            i = 0;
            j = 0;
            int k = left;
            while (i < leftArrayLength && j < rightArrayLength)
            {
                if (leftTempArray[i] <= rightTempArray[j])
                {
                    array[k++] = leftTempArray[i++];
                }
                else
                {
                    array[k++] = rightTempArray[j++];
                }
                yield return new List<int>() { i, j };
            }

            while (i < leftArrayLength)
            {
                array[k++] = leftTempArray[i++];
                yield return new List<int>() { i, j };
            }
            while (j < rightArrayLength)
            {
                array[k++] = rightTempArray[j++];
                yield return new List<int>() { i, j };
            }
        }
    }
}
