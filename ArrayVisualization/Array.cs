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

        public Array(List<Element> elements)
        {
            this.Elements = elements;
        }

        public int Count
        {
            get { return Elements.Count; }
        }

        public Element this[int i]
        {
            get { return Elements[i]; }
            set { Elements[i] = value; }
        }

        public void Swap(int i, int j)
        {
            var tmp = this.Elements[i];
            this.Elements[i] = this.Elements[j];
            this.Elements[j] = tmp;
        }
    }
}
