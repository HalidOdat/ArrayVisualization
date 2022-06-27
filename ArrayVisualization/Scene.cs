using ArrayVisualization.Algorithms;
using ArrayVisualization.Elements;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayVisualization
{
    public class Scene
    {
        public static Random RANDOM = new Random();

        public int Width { get; set; }
        public int Height { get; set; }

        public Algorithm Algorithm { get; set; }

        public Array Array { get; set; }

        public bool Paused { get; set; } = false;

        public Scene(int width, int height)
        {
            this.Width = width;
            this.Height = height;

            var array = new List<Element>();
            for (int i = 0; i < 500; i++)
            {
                array.Add(new NumberElement(i));
            }
            this.Array = new Array(array);

            // RANDOM.Shuffle(this.Array);

            this.Algorithm = new ReverseAlgorithm(this.Array);
        }

        public AlgorithmState lastState = new AlgorithmState();

        public bool BarMode { get; set; } = true;

        public void SetAlgorithm(string type)
        {
            switch (type)
            {
                case "shuffle":
                    this.Algorithm = new ShuffleAlgorithm(this.Array);
                    break;
                case "reverse":
                    this.Algorithm = new ReverseAlgorithm(this.Array);
                    break;
                case "merge-sort":
                    this.Algorithm = new MergeSortAlgorithm(this.Array);
                    break;
                case "bubble-sort":
                    this.Algorithm = new BubbleSortAlgorithm(this.Array);
                    break;
                case "quick-sort":
                    this.Algorithm = new QuickSortAlgorithm(this.Array);
                    break;
                case "selection-sort":
                    this.Algorithm = new SelectionSortAlgorithm(this.Array);
                    break;
                case "insertion-sort":
                    this.Algorithm = new InsertionSortAlgorithm(this.Array);
                    break;
                case "heap-sort":
                    this.Algorithm = new HeapSortAlgorithm(this.Array);
                    break;
                case "shell-sort":
                    this.Algorithm = new ShellSortAlgorithm(this.Array);
                    break;
                case "exchange-sort":
                    this.Algorithm = new ExchangeSortAlgorithm(this.Array);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public void Pause()
        {
            this.Paused = !this.Paused;
        }

        internal void Tick()
        {
            if (this.Paused)
            {
                return;
            }
            var state = this.Algorithm.Current;
            if (this.Algorithm.MoveNext() && state != null)
            {
                this.lastState = state;
            } else
            {
                this.lastState = new AlgorithmState(new List<int>());
            }
        }

        public void Draw(Graphics g)
        {
            g.Clear(Color.Black);

            var redBrush   = new SolidBrush(Color.Red);
            var greenBrush = new SolidBrush(Color.Green);
            var yellowBrush = new SolidBrush(Color.Yellow);
            var whiteBrush = new SolidBrush(Color.White);

            var colors = new SolidBrush[] { redBrush, greenBrush, yellowBrush };

            var whitePen   = new Pen(Color.Gray, 1);

            var w = (float)Width / this.Algorithm.Array.Count;
            var hh = (float)Height / this.Algorithm.Array.Count;


            for (int i = 0; i < this.Algorithm.Array.Count; ++i)
            {
                var item = this.Algorithm.Array.Elements[i];
                var value = ((NumberElement)item).Value;

                var x = i * w;
                var y = Height - value * hh;

                var h = Height - y;


                var brush = whiteBrush;

                for (var j = 0; j < lastState.Indices.Count; ++j)
                {
                    
                    if (lastState.Indices[j] == i)
                    {
                        brush = colors[j];
                    }
                }

                if (this.BarMode)
                {
                    g.FillRectangle(brush, (float)x, y, (float)w, h);
                } else
                {
                    g.FillRectangle(brush, (float)x, y, w, w);
                }
               
                //g.DrawRectangle(whitePen, (float)x, y, (float)w, h);
            }

            
            g.DrawString(String.Format("N: {0}, Accesses: {1}", this.Algorithm.Array.Count, this.Algorithm.Array.Accesses), new Font("Arial", 8), whiteBrush, 10, 10);
            whiteBrush.Dispose();
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
