using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayVisualization.Algorithms
{
    /// <summary>
    /// Implementation of the Cocktail (Shaker) Sort Algorithm.
    /// 
    /// Cocktail shaker sort also known as bidirectional bubble sort, cocktail sort,
    /// shaker sort (which can also refer to a variant of selection sort), ripple sort,
    /// shuffle sort, or shuttle sort, is an extension of bubble sort.
    /// 
    /// More Info: https://en.wikipedia.org/wiki/Cocktail_shaker_sort
    /// </summary>
    public class CocktailSortAlgorithm : Algorithm
    {
        public CocktailSortAlgorithm(Array array) : base("Cocktail (Shaker) Sort", array)
        {
        }

        protected override IEnumerator<AlgorithmState> CreateEnumerator()
        {
            bool swapped = true;
            int start = 0;
            int end = Array.Count;

            while (swapped == true)
            {

                // reset the swapped flag on entering the
                // loop, because it might be true from a
                // previous iteration.
                swapped = false;

                // loop from bottom to top same as
                // the bubble sort
                for (int i = start; i < end - 1; ++i)
                {
                    yield return new AlgorithmState(new List<int> { i });
                    if (Array[i] > Array[i + 1])
                    {
                        Array.Swap(i, i + 1);
                        swapped = true;

                        yield return new AlgorithmState(new List<int> { i, i + 1 });
                    }
                }

                // if nothing moved, then array is sorted.
                if (swapped == false)
                    break;

                // otherwise, reset the swapped flag so that it
                // can be used in the next stage
                swapped = false;

                // move the end point back by one, because
                // item at the end is in its rightful spot
                end = end - 1;

                // from top to bottom, doing the
                // same comparison as in the previous stage
                for (int i = end - 1; i >= start; i--)
                {
                    yield return new AlgorithmState(new List<int> { i });
                    if (Array[i] > Array[i + 1])
                    {
                        Array.Swap(i, i + 1);
                        swapped = true;

                        yield return new AlgorithmState(new List<int> { i, i + 1 });
                    }
                }

                // increase the starting point, because
                // the last stage would have moved the next
                // smallest number to its rightful spot.
                start = start + 1;
            }
        }
    }
}
