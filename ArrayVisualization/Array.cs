using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayVisualization
{
    /// <summary>
    /// This class represents the array that operations are performed on.
    /// 
    /// It wraps around a `List<int>`, this is done to collect statisting on array access.
    /// </summary>
    public class Array
    {
        /// <summary>
        /// The internal elements.
        /// </summary>
        public List<int> Elements { get; set; }

        /// <summary>
        /// The count of how many times the array has been accessed.
        /// </summary>
        public UInt64 Accesses { get; set; } = 0;

        /// <summary>
        /// Array constructor with elements.
        /// </summary>
        /// <param name="elements">The elements.</param>
        public Array(List<int> elements)
        {
            this.Elements = elements;
            this.Accesses = 0;
        }

        /// <summary>
        /// Getter that returns the count of the elements.
        /// </summary>
        public int Count
        {
            get { return Elements.Count; }
        }

        /// <summary>
        /// An overloaded this[] operator with access statistics logging.
        /// </summary>
        /// <param name="i">The i-th element</param>
        /// <returns>The element</returns>
        public int this[int i]
        {
            get { this.Accesses++; return Elements[i]; }
            set { this.Accesses++; Elements[i] = value; }
        }

        /// <summary>
        /// Helper function that swaps i-th and j-th element.
        /// </summary>
        /// <param name="i">The i-th element.</param>
        /// <param name="j">The j-th element.</param>
        public void Swap(int i, int j)
        {
            this.Accesses += 4;
            var tmp = this.Elements[i];
            this.Elements[i] = this.Elements[j];
            this.Elements[j] = tmp;
        }
    }
}
