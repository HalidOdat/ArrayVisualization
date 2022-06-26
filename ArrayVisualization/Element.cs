using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayVisualization
{
    public abstract class Element
    {
        public static bool operator ==(Element a, Element b) => a.Equal(b);
        public static bool operator !=(Element a, Element b) => !a.Equal(b);

        public static bool operator <(Element a, Element b) => a.LessThan(b);
        public static bool operator <=(Element a, Element b) => a.LessThan(b) || a.Equal(b);

        public static bool operator >(Element a, Element b) => a.GreaterThan(b);
        public static bool operator >=(Element a, Element b) => a.GreaterThan(b) || a.Equal(b);

        protected abstract bool Equal(Element rhs);
        protected abstract bool LessThan(Element rhs);
        protected abstract bool GreaterThan(Element rhs);

        public abstract override string ToString();
    }
}
