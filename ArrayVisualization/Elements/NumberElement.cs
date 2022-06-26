using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayVisualization.Elements
{
    public class NumberElement : Element
    {
        public int Value { get; set; }

        public NumberElement(int value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return String.Format("{0}", this.Value);
        }

        protected override bool Equal(Element rhs)
        {
            return this.Value == ((NumberElement)rhs).Value;
        }

        protected override bool GreaterThan(Element rhs)
        {
            return this.Value > ((NumberElement)rhs).Value;
        }

        protected override bool LessThan(Element rhs)
        {
            return this.Value < ((NumberElement)rhs).Value;
        }
    }
}
