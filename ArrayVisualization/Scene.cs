using ArrayVisualization.Algorithms;
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

        public Rectangle ViewRectangle { get; set; }

        public Scene(Rectangle viewRectangle)
        {
            this.ViewRectangle = viewRectangle;
            this.Array = new Array(new List<int>());

            // RANDOM.Shuffle(this.Array);

            this.Algorithm = new ReverseAlgorithm(this.Array);
        }

        public AlgorithmState lastState = new AlgorithmState();

        public bool BarMode { get; set; } = true;

        public bool Colored { get; set; } = false;

        public void SetAlgorithm(string type)
        {
            // if (!this.Algorithm.HasFinished())
            // {
            //     return;
            // }
            this.Array.Accesses = 0;
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
                case "in-place-merge-sort":
                    this.Algorithm = new InPlaceMergeSortAlgorithm(this.Array);
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
                case "cocktail-sort":
                    this.Algorithm = new CocktailSortAlgorithm(this.Array);
                    break;
                case "odd-even-sort":
                    this.Algorithm = new OddEvenSortAlgorithm(this.Array);
                    break;
                case "comb-sort":
                    this.Algorithm = new CombSortAlgorithm(this.Array);
                    break;
                case "gnome-sort":
                    this.Algorithm = new GnomeSortAlgorithm(this.Array);
                    break;
                case "cycle-sort":
                    this.Algorithm = new CycleSortAlgorithm(this.Array);
                    break;
                case "introspective-sort":
                    this.Algorithm = new IntrospectiveSortAlgorithm(this.Array);
                    break;
                case "tim-sort":
                    this.Algorithm = new TimSortAlgorithm(this.Array);
                    break;
                case "bogo-sort":
                    this.Algorithm = new BogoSortAlgorithm(this.Array);
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

        // This function will take an HSL value in the ranges of 0-1 and return a color object.  I use this function all the time.
        // Given H,S,L in range of 0-1
        // Returns a Color (RGB struct) in range of 0-255
        public static Color HSL2RGB(double h, double sl, double l)
        {
            double v;
            double r, g, b;

            r = l;   // default to gray
            g = l;
            b = l;
            v = (l <= 0.5) ? (l * (1.0 + sl)) : (l + sl - l * sl);

            if (v > 0)
            {
                double m;
                double sv;
                int sextant;
                double fract, vsf, mid1, mid2;

                m = l + l - v;
                sv = (v - m) / v;
                h *= 6.0;
                sextant = (int)h;
                fract = h - sextant;
                vsf = v * sv * fract;
                mid1 = m + vsf;
                mid2 = v - vsf;

                switch (sextant)
                {
                    case 0:
                        r = v;
                        g = mid1;
                        b = m;
                        break;
                    case 1:
                        r = mid2;
                        g = v;
                        b = m;
                        break;
                    case 2:
                        r = m;
                        g = v;
                        b = mid1;
                        break;
                    case 3:
                        r = m;
                        g = mid2;
                        b = v;
                        break;
                    case 4:
                        r = mid1;
                        g = m;
                        b = v;
                        break;
                    case 5:
                        r = v;
                        g = m;
                        b = mid2;
                        break;
                }
            }

            return Color.FromArgb(Convert.ToByte(r * 255.0f), Convert.ToByte(g * 255.0f), Convert.ToByte(b * 255.0f));
        }

        public void Draw(Graphics g, float delay)
        {
            g.Clear(Color.Black);

            var redBrush   = new SolidBrush(Color.Red);
            var greenBrush = new SolidBrush(Color.Green);
            var yellowBrush = new SolidBrush(Color.Yellow);
            var whiteBrush = new SolidBrush(Color.White);

            var colors = new SolidBrush[] { redBrush, greenBrush, yellowBrush };

            var grayPen = new Pen(Color.Gray, 1);

            var w = (float)this.ViewRectangle.Width / this.Array.Count;
            var hh = (float)this.ViewRectangle.Height / this.Array.Count;

            for (int i = 0; i < this.Array.Count; ++i)
            {
                var value = this.Array.Elements[i];

                var x = i * w + this.ViewRectangle.X;
                var y = this.ViewRectangle.Height + this.ViewRectangle.Y - value * hh;

                var h = this.ViewRectangle.Height + this.ViewRectangle.Y - y;

                var brush = whiteBrush;
                if (this.Colored)
                {
                    brush = new SolidBrush(HSL2RGB((double)value / this.Array.Count, 1, 0.5));
                }

                for (var j = 0; j < lastState.Indices.Count; ++j)
                {
                    
                    if (lastState.Indices[j] == i)
                    {
                        brush = colors[j % colors.Length];
                    }
                }

                if (this.BarMode)
                {
                    g.FillRectangle(brush, (float)x, y, (float)w, h);
                } else
                {
                    g.FillRectangle(brush, (float)x, y, w, w);
                }
               
                if (w > 4)
                {
                    if (this.BarMode)
                    {
                        g.DrawRectangle(grayPen, (float)x, y, (float)w, h);
                    } else
                    {
                        g.DrawRectangle(grayPen, (float)x, y, (float)w, w);
                    }
                }
            }

            string delayString;
            if (delay > 1.0f && delay < 1000.0f)
            {
                delayString = String.Format("{0:0}ms", delay);
            } else if (delay > 1000.0f)
            {
                delayString = String.Format("{0:0.##}s", delay / 1000.0f);
            } else
            {
                delayString = String.Format("{0:0.##}ns", delay * 1000.0f);
            }
            g.DrawString(String.Format("N: {0}, Algorithm Name: {1} {4}, Delay: {2}, Array Accesses: {3}", this.Array.Count, this.Algorithm.Name, delayString, this.Algorithm.Array.Accesses, "State: " + (this.Algorithm.HasFinished() ? "[Finished]": "[In Progress]")), new Font("Arial", 8), whiteBrush, 200, 10);
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
