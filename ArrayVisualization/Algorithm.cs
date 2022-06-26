using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArrayVisualization
{
    public class AlgorithmState {
        public List<int> Indices { get; }

        public AlgorithmState(List<int> indices)
        {
            this.Indices = indices;
        }
    }

    public abstract class Algorithm
    {
        public Array Array { get; set; }

        public Algorithm(Array array)
        {
            this.Array = array;
        }

        public abstract IEnumerator<AlgorithmState> Run();
    }
}
