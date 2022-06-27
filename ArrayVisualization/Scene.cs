﻿using ArrayVisualization.Algorithms;
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

        private Algorithm Algorithm { get; set; }

        public Scene(int width, int height)
        {
            this.Width = width;
            this.Height = height;

            var array = new List<Element>();
            for (int i = 0; i < 1000; i++)
            {
                array.Add(new NumberElement(i));
            }

            // RANDOM.Shuffle(array);

            this.Algorithm = new ReverseAlgorithm(new Array(array));
        }

        private AlgorithmState lastState = new AlgorithmState(new List<int>());

        internal void Tick()
        {
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

               // g.FillRectangle(brush, (float)x, y, w, w);
               g.FillRectangle(brush, (float)x, y, (float)w, h);
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