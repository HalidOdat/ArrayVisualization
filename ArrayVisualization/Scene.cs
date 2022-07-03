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
    /// <summary>
    /// This class represents the scene, that shows the algorithm in a graphical way.
    /// </summary>
    public class Scene
    {
        /// <summary>
        /// This is the viewable part of the screen that the scene can be drawn on.
        /// </summary>
        public Rectangle ViewRectangle { get; set; }

        /// <summary>
        /// The current algorithm that is being visualized.
        /// </summary>
        public Algorithm Algorithm { get; set; }

        /// <summary>
        /// The array that is beign manipulated by the algorithm.
        /// </summary>
        public Array Array { get; set; }

        /// <summary>
        /// Flag for stoping an starting the scene.
        /// </summary>
        public bool Paused { get; set; } = false;

        /// <summary>
        /// Construct a scene with a view rectangle.
        /// </summary>
        /// <param name="viewRectangle">The view rectangle</param>
        public Scene(Rectangle viewRectangle)
        {
            this.ViewRectangle = viewRectangle;
            this.Array = new Array(new List<int>());
            this.Algorithm = new ReverseAlgorithm(this.Array);
        }

        /// <summary>
        /// Flag that indicates wether to display in bars or points.
        /// </summary>
        public bool BarMode { get; set; } = true;

        /// <summary>
        /// Flag that indicates whether to color the bars/points.
        /// </summary>
        public bool Colored { get; set; } = false;

        /// <summary>
        /// Pause/resume the animation of the current algorithm.
        /// </summary>
        public void Pause()
        {
            this.Paused = !this.Paused;
        }

        /// <summary>
        /// If not paused, it goes to the next step of the algorithm.
        /// </summary>
        internal void Tick()
        {
            if (this.Paused)
            {
                return;
            }
            var state = this.Algorithm.Current;
            this.Algorithm.MoveNext();
        }

        /// <summary>
        /// Draws the current algorithm step.
        /// </summary>
        /// <param name="g">The graphics to draw on.</param>
        /// <param name="delay">The current delay between algorithm steps.</param>
        public void Draw(Graphics g, float delay)
        {
            g.Clear(Color.Black);

            var redBrush   = new SolidBrush(Color.Red);
            var greenBrush = new SolidBrush(Color.Green);
            var yellowBrush = new SolidBrush(Color.Yellow);
            var blueBrush = new SolidBrush(Color.Blue);
            var whiteBrush = new SolidBrush(Color.White);

            var colors = new SolidBrush[] { redBrush, greenBrush, yellowBrush, blueBrush };

            var grayPen = new Pen(Color.Gray, 0.5f);

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
                    brush = new SolidBrush(Utils.HSL2RGB((double)value / this.Array.Count, 1, 0.5));
                }

                // If there are indices draw them.
                if (!this.Algorithm.HasFinished() && this.Algorithm.Current != null)
                {
                    for (var j = 0; j < this.Algorithm.Current.Indices.Count; ++j)
                    {
                        if (this.Algorithm.Current.Indices[j] == i)
                        {
                            brush = colors[j % colors.Length];
                        }
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

            // Display the status string.
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
}
