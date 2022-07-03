using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArrayVisualization
{
    /// <summary>
    /// This class represents the state of an algorithm at a given point in time.
    /// </summary>
    public class AlgorithmState {
        /// <summary>
        /// Contains all the indices that point to the array, like i, j, k, etc.
        /// </summary>
        public List<int> Indices { get; }

        /// <summary>
        /// Constructor that creates a new AlgorithmState.
        /// </summary>
        public AlgorithmState() { Indices = new List<int>(); }

        /// <summary>
        /// Constructor that creates an AlgorithmState with a list of specified indices.
        /// </summary>
        /// <param name="indices">The indices that accassed the array, like i, j, k, etc.</param>
        public AlgorithmState(List<int> indices)
        {
            this.Indices = indices;
        }
    }

    /// <summary>
    /// This abstract class represents an argorithm, all algorithms must inherit from this class.
    /// 
    /// It implements the the IEnumerable and IEnumerator interfaces returning an Algorithm state on enumeration,
    /// which represents the steps the algorithm takes.
    /// </summary>
    public abstract class Algorithm : IEnumerable<AlgorithmState>, IEnumerator<AlgorithmState>
    {
        /// <summary>
        /// The array that the algorithm is operating on.
        /// </summary>
        public Array Array { get; set; }

        /// <summary>
        /// The name of the algorithm.
        /// </summary>
        public string Name { get; }
        
        /// <summary>
        /// This flag determins whether the algorithm has finished all its steps.
        /// </summary>
        private bool hasFinished = false;

        /// <summary>
        /// The current state of the algorithm is represented as an enumerator that returns a state
        /// on each iteration (the steps that the algorithm takes).
        /// 
        /// This is done so we can call IEnumerator methods on the Algorithm instance itself.
        /// </summary>
        private IEnumerator<AlgorithmState> enumerator = null;

        /// <summary>
        /// This is from the IEnumerator interface, which represents the current state.
        /// </summary>
        public AlgorithmState Current => this.GetEnumerator().Current;

        /// <summary>
        /// This is from the IEnumerator interface, which represents the current state.
        /// </summary>
        object IEnumerator.Current => this.Current;

        /// <summary>
        /// An abstract constructor of the Algorithm class.
        /// </summary>
        /// <param name="name">The name of the algorithm</param>
        /// <param name="array">The array that is manipulated</param>
        public Algorithm(string name, Array array)
        {
            this.Name = name;
            this.Array = array;
        }

        /// <summary>
        /// This methods must be override by all algorithms that inherit from this class.
        /// 
        /// It represent the actual algorithm. When you want to record the state of the algorithm,
        /// you must `yield return` the state. Which will pause the execution of the method and return.
        /// When called again it will continue where it left off.
        /// </summary>
        /// <returns></returns>
        protected abstract IEnumerator<AlgorithmState> CreateEnumerator();

        /// <summary>
        /// This is from the IEnumerable interface. Helper method for getting the enumerator.
        /// </summary>
        /// <returns>The algorithm enumerator</returns>
        public IEnumerator<AlgorithmState> GetEnumerator()
        {
            if (this.enumerator == null)
            {
                this.enumerator = this.CreateEnumerator();
            }
            return this.enumerator;
        }

        /// <summary>
        /// This is from the IEnumerable interface. Helper method for getting the enumerator.
        /// </summary>
        /// <returns>The algorithm enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        /// <summary>
        /// Dispose the current enumerator if it exists.
        /// </summary>
        public void Dispose()
        {
            if (this.enumerator != null)
            {
                this.enumerator.Dispose();
            }
        }

        /// <summary>
        /// Move to next state.
        /// </summary>
        /// <returns>Returns true if moved, false otherwise.</returns>
        public bool MoveNext()
        {
            bool moved = this.GetEnumerator().MoveNext();
            if (!moved)
            {
                this.hasFinished = true;
            }
            return moved;
        }

        /// <summary>
        /// Reset the algorithm.
        /// </summary>
        public void Reset()
        {
            this.Dispose();
            this.enumerator = this.CreateEnumerator();
            this.hasFinished = false;
        }

        /// <summary>
        /// Check if the algorithm is finished.
        /// </summary>
        /// <returns>Returns true if it has finished, false otherwise.</returns>
        public bool HasFinished()
        {
            return hasFinished;
        }

        /// <summary>
        /// String converter method.
        /// </summary>
        /// <returns>Returns string representation.</returns>
        public override string ToString()
        {
            return this.Name + " Algorithm";
        }
    }
}
