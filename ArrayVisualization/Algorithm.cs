using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArrayVisualization
{
    public abstract class Algorithm
    {
        public Array Array { get; set; }

        public Algorithm(Array array)
        {
            this.Array = array;
        }

        public abstract IEnumerator<List<int>> Run();
    }
}
