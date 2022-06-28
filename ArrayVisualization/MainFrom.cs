using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrayVisualization
{
    public partial class MainFrom : Form
    {
        private Scene scene;

        Stopwatch sw = new Stopwatch();

        public MainFrom()
        {
            InitializeComponent();
            DoubleBuffered = true;

            this.scene = new Scene(this.ClientRectangle.Width, this.ClientRectangle.Height);

            this.timer.Interval = 50;
            this.timer.Start();

        }

        public int I { get; set; } = 1;

        private void MainFrom_Paint(object sender, PaintEventArgs e)
        {
            this.scene.Draw(e.Graphics, (float)timer.Interval / I);
        }

        private void MainFrom_ResizeEnd(object sender, EventArgs e)
        {
            this.scene.Width = this.ClientRectangle.Width;
            this.scene.Height = this.ClientRectangle.Height;
            Invalidate();
        }

        private void timer_Tick(object sender, EventArgs e)
        {   
           for (int i = 0; i < I; i++)
           {
                this.scene.Tick();
                Invalidate();
           }
        }

        private void MainFrom_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.Space:
                    this.scene.Pause();
                    break;
                case Keys.S:
                    this.scene.SetAlgorithm("shuffle");
                    break;
                case Keys.R:
                    this.scene.SetAlgorithm("reverse");
                    break;
                case Keys.M:
                    this.scene.SetAlgorithm("merge-sort");
                    break;
                case Keys.B:
                    this.scene.SetAlgorithm("bubble-sort");
                    break;
                case Keys.Q:
                    this.scene.SetAlgorithm("quick-sort");
                    break;
                case Keys.N:
                    this.scene.SetAlgorithm("selection-sort");
                    break;
                case Keys.I:
                    this.scene.SetAlgorithm("insertion-sort");
                    break;
                case Keys.H:
                    this.scene.SetAlgorithm("heap-sort");
                    break;
                case Keys.L:
                    this.scene.SetAlgorithm("shell-sort");
                    break;
                case Keys.E:
                    this.scene.SetAlgorithm("exchange-sort");
                    break;
                case Keys.C:
                    this.scene.SetAlgorithm("cocktail-sort");
                    break;
                case Keys.O:
                    this.scene.SetAlgorithm("odd-even-sort");
                    break;
                case Keys.A:
                    this.scene.SetAlgorithm("comb-sort");
                    break;
                case Keys.P:
                    this.scene.BarMode = !this.scene.BarMode;
                    break;
                case Keys.Up:
                    if (this.timer.Interval - 5 <= 0)
                    {
                        this.timer.Interval = 1;
                        if (I < 60)
                        {
                            I += 1;
                        }
                    } else
                    {
                        this.timer.Interval -= 5;
                    }
                    break;
                case Keys.Down:
                    if (I > 1)
                    {
                        I -= 1;
                    } else
                    {
                        this.timer.Interval += 5;
                    }
                    break;
            }

            Invalidate();
        }
    }
}
