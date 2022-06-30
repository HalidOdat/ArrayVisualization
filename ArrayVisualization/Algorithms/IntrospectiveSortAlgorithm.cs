using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayVisualization.Algorithms
{
    public class IntrospectiveSortAlgorithm : Algorithm
    {
        public IntrospectiveSortAlgorithm(Array array) : base("Introspective Sort", array)
        {
        }

        protected override IEnumerator<AlgorithmState> CreateEnumerator()
        {
			int left = 0;
			int right = Array.Count - 1;
			int partitionSize;
			{
				yield return new AlgorithmState(new List<int> { right });
				var pivot = Array[right];
				partitionSize = left;

				for (int j = left; j < right; ++j)
				{
					yield return new AlgorithmState(new List<int> { right, j });
					if (Array[j] <= pivot)
					{
						yield return new AlgorithmState(new List<int> { right, j, partitionSize });
						Array.Swap(partitionSize, j);
						yield return new AlgorithmState(new List<int> { right, j, partitionSize });
						partitionSize++;
					}
				}

				Array[right] = Array[partitionSize];
				yield return new AlgorithmState(new List<int> { right, partitionSize });
				Array[partitionSize] = pivot;
				yield return new AlgorithmState(new List<int> { right, partitionSize });
			}

			if (partitionSize < 16)
			{
				foreach (var state in InsertionSort())
					yield return state;
			}
			else if (partitionSize > (2 * Math.Log(Array.Count)))
			{
				foreach (var state in HeapSort())
					yield return state;
			}
			else
			{
				foreach (var state in QuickSortRecursive(0, Array.Count - 1))
					yield return state;
			}

			yield break;
		}

		private IEnumerable<AlgorithmState> InsertionSort()
		{
			for (int i = 1; i < Array.Count; ++i)
			{
				int j = i;
				yield return new AlgorithmState(new List<int> { i, j });

				while ((j > 0))
				{
					yield return new AlgorithmState(new List<int> { j - 1, j });
					if (Array[j - 1] > Array[j])
					{
						Array.Swap(j - 1, j);
						yield return new AlgorithmState(new List<int> { j - 1, j });
						--j;
					}
					else
					{
						break;
					}
				}
			}
		}

		private IEnumerable<AlgorithmState> HeapSort()
		{
			int heapSize = Array.Count;

			for (int p = (heapSize - 1) / 2; p >= 0; --p)
				foreach (var state in MaxHeapify(heapSize, p))
					yield return state;

			for (int i = Array.Count - 1; i > 0; --i)
			{
				Array.Swap(0, i);
				yield return new AlgorithmState(new List<int> { 0, i });

				--heapSize;
				foreach (var state in MaxHeapify(heapSize, 0))
					yield return state;
			}
		}

		private IEnumerable<AlgorithmState> MaxHeapify(int heapSize, int index)
		{
			int left = (index + 1) * 2 - 1;
			int right = (index + 1) * 2;
			int largest = 0;

			yield return new AlgorithmState(new List<int> { left, index });
			if (left < heapSize && Array[left] > Array[index])
				largest = left;
			else
				largest = index;

			if (right < heapSize && Array[right] > Array[largest])
            {
				yield return new AlgorithmState(new List<int> { right, largest });
				largest = right;
			}

			if (largest != index)
			{
				yield return new AlgorithmState(new List<int> { index, largest });
				Array.Swap(index, largest);
				
				foreach (var state in MaxHeapify(heapSize, largest))
					yield return state;
			}
		}

		private IEnumerable<AlgorithmState> QuickSortRecursive(int left, int right)
		{
			if (left < right)
			{
				int q;
                {
					yield return new AlgorithmState(new List<int> { right });
					var pivot = Array[right];
					q = left;

					for (int j = left; j < right; ++j)
					{
						yield return new AlgorithmState(new List<int> { right, j });
						if (Array[j] <= pivot)
						{
							yield return new AlgorithmState(new List<int> { right, j, q });
							Array.Swap(q, j);
							yield return new AlgorithmState(new List<int> { right, j, q });
							q++;
						}
					}

					Array[right] = Array[q];
					yield return new AlgorithmState(new List<int> { right, q });
					Array[q] = pivot;
					yield return new AlgorithmState(new List<int> { right, q });
				}

				foreach (var state in QuickSortRecursive(left, q - 1))
					yield return state;

				foreach (var state in QuickSortRecursive(q + 1, right))
					yield return state;
			}
		}
	}
}
