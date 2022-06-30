using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayVisualization.Algorithms
{
    public class CycleSortAlgorithm : Algorithm
    {
        public CycleSortAlgorithm(Array array) : base("Cycle Sort", array)
        {
        }

        protected override IEnumerator<AlgorithmState> CreateEnumerator()
        {
            // count number of memory writes
            int writes = 0;

            // traverse array elements and
            // put it to on the right place
            for (int cycle_start = 0; cycle_start <= Array.Count - 2; cycle_start++)
            {
                // initialize item as starting point
                var item = Array[cycle_start];

                yield return new AlgorithmState(new List<int> { cycle_start });

                // Find position where we put the item.
                // We basically count all smaller elements
                // on right side of item.
                int pos = cycle_start;
                for (int i = cycle_start + 1; i < Array.Count; i++)
                {
                    if (Array[i] < item)
                    {
                        pos++;
                    }
                        
                    yield return new AlgorithmState(new List<int> { cycle_start, pos, i });
                }
                    

                // If item is already in correct position
                if (pos == cycle_start)
                    continue;

                // ignore all duplicate elements
                while (item == Array[pos])
                {
                    pos += 1;
                }

                // put the item to it's right position
                if (pos != cycle_start)
                {
                    yield return new AlgorithmState(new List<int> { cycle_start, pos });
                    var temp = item;
                    item = Array[pos];
                    Array[pos] = temp;
                    yield return new AlgorithmState(new List<int> { cycle_start, pos });
                    writes++;
                }

                // Rotate rest of the cycle
                while (pos != cycle_start)
                {
                    pos = cycle_start;

                    // Find position where we put the element
                    for (int i = cycle_start + 1; i < Array.Count; i++)
                    {
                        yield return new AlgorithmState(new List<int> { cycle_start, pos, i });
                        if (Array[i] < item)
                            pos += 1;

                        yield return new AlgorithmState(new List<int> { cycle_start, pos, i });
                    }
                        

                    // ignore all duplicate elements
                    while (item == Array[pos])
                    {
                        yield return new AlgorithmState(new List<int> { cycle_start, pos });
                        pos += 1;
                    }
                        

                    // put the item to it's right position
                    if (item != Array[pos])
                    {
                        yield return new AlgorithmState(new List<int> { cycle_start, pos });
                        var temp = item;
                        item = Array[pos];
                        Array[pos] = temp;
                        yield return new AlgorithmState(new List<int> { cycle_start, pos });
                        writes++;
                    }
                }
            }

            yield break;
        }
    }
}
