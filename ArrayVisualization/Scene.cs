using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayVisualization
{
    public class Scene
    {
        public static Random RANDOM = new Random();
        public List<int> Array { get; set; } = new List<int>();
        public List<Rectangle> Rectangles { get; set; } = new List<Rectangle>();

        public int Width { get; set; }
        public int Height { get; set; }

        public Scene(int width, int height)
        {
            this.Width = width;
            this.Height = height;

            for (int i = 0; i < 50; i++)
            {
                this.Array.Add(i);
            }

            RANDOM.Shuffle(this.Array);
        }

        private int i = 0;
        private int j = 0;
        internal void Tick()
        {
            int n = this.Array.Count;
            if (i < n - 1)
            {
                for (; this.j < n - i - 1; this.j++)
                {
                    if (this.Array[this.j] > this.Array[this.j + 1])
                    {
                        (this.Array[this.j + 1], this.Array[this.j]) = (this.Array[this.j], this.Array[this.j + 1]);
                        throw new Exception();
                    }
                }
                this.j = 0;
            }

            this.i++;
        }

        public void Draw(Graphics g)
        {
            g.Clear(Color.Black);

            var p = new SolidBrush(Color.White);
            var count = this.Array.Count;
            var max = this.Array.Max();
            var heightFactor = 10;
            var widthFactor = 5;

            for (var j = 0; j < this.Array.Count; j++)
            {
                var element = this.Array[j];
                var point = new Point(widthFactor, this.Height - heightFactor * element);
                widthFactor += 15;
                var rect = new Rectangle(point.X, point.Y, 15, this.Height);
                if (this.i != j && this.j != j)
                {
                    g.FillRectangle(p, rect);
                } else if (this.i == j )
                {
                    var b = new SolidBrush(Color.Red);
                    g.FillRectangle(b, rect);
                    b.Dispose();
                } else if (this.j == j)
                {
                    var b = new SolidBrush(Color.Green);
                    g.FillRectangle(b, rect);
                    b.Dispose();
                }
                var pen = new Pen(Color.Gray, 1);
                g.DrawRectangle(pen, rect);
                pen.Dispose();

            }
            p.Dispose();
        }
    }

    static class RandomExtensions
    {
        public static void Shuffle<T>(this Random rng, List<T> array)
        {
            int n = array.Count;
            while (n > 1)
            {
                int k = rng.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
    }
}
