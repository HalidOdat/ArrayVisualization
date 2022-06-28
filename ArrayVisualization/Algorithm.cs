using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArrayVisualization
{
    public class AlgorithmState {
        public List<int> Indices { get; }

        public AlgorithmState() { Indices = new List<int>(); }

        public AlgorithmState(List<int> indices)
        {
            this.Indices = indices;
        }
    }

    public abstract class Algorithm : IEnumerable<AlgorithmState>, IEnumerator<AlgorithmState>
    {
        public Array Array { get; set; }
        public string Name { get; }

        private IEnumerator<AlgorithmState> enumerator { get; set; } = null;

        public AlgorithmState Current => this.GetEnumerator().Current;

        object IEnumerator.Current => this.Current;

        public Algorithm(string name, Array array)
        {
            this.Name = name;
            this.Array = array;
        }


        protected abstract IEnumerator<AlgorithmState> CreateEnumerator();

        public IEnumerator<AlgorithmState> GetEnumerator()
        {
            if (this.enumerator == null)
            {
                this.enumerator = this.CreateEnumerator();
            }
            return this.enumerator;
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public void Dispose()
        {
            if (this.enumerator != null)
            {
                this.enumerator.Dispose();
            }
        }

        public bool MoveNext()
        {
            return this.GetEnumerator().MoveNext();
        }

        public void Reset()
        {
            this.Dispose();
            this.enumerator = this.CreateEnumerator();
        }
    }
}
