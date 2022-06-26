using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayVisualization
{
    public class Array
    {
        public List<Element> Elements { get; set; }
        public UInt64 Accesses { get; set; } = 0;

        public Array(List<Element> elements)
        {
            this.Elements = elements;
            this.Accesses = 0;
        }

        public int Count
        {
            get { return Elements.Count; }
        }

        public Element this[int i]
        {
            get { this.Accesses++; return Elements[i]; }
            set { this.Accesses++; Elements[i] = value; }
        }

        public void Swap(int i, int j)
        {
            this.Accesses += 4;
            var tmp = this.Elements[i];
            this.Elements[i] = this.Elements[j];
            this.Elements[j] = tmp;
        }
    }
}
