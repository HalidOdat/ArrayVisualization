using ArrayVisualization.Elements;
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

        private delegate void KeyDownHandle(Form f);

        public MainFrom()
        {
            InitializeComponent();
            DoubleBuffered = true;

            this.scene = new Scene(this.ClientRectangle.Width - this.pControls.Width, this.ClientRectangle.Height);

            this.pControls.BackColor = Color.DarkGray;
            this.pControls.Padding = new Padding(5, 10, 5, 10);

            this.timer.Interval = 20;
            this.timer.Start();
        }

        public int I { get; set; } = 1;

        private void MainFrom_Paint(object sender, PaintEventArgs e)
        {
            this.scene.Draw(e.Graphics, (float)timer.Interval / I);
        }

        private void MainFrom_ResizeEnd(object sender, EventArgs e)
        {
            this.scene.Width = this.ClientRectangle.Width - this.pControls.Width;
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

            if (!this.scene.Algorithm.HasFinished())
            {
                this.nudN.Enabled = false;
            } else
            {
                this.nudN.Enabled = true;
            }
            nudN.Value = this.scene.Array.Count;
        }

        // https://stackoverflow.com/questions/3172731/forms-not-responding-to-keydown-events
        protected override bool ProcessCmdKey(ref Message msg, Keys key)
        {
            switch (key)
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
                case Keys.Control | Keys.M:
                    this.cycleMode();
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
                case Keys.G:
                    this.scene.SetAlgorithm("gnome-sort");
                    break;
                case Keys.J:
                    this.scene.SetAlgorithm("bogo-sort");
                    break;
                case Keys.K:
                    this.scene.SetAlgorithm("in-place-merge-sort");
                    break;
                case Keys.D:
                    this.scene.SetAlgorithm("cycle-sort");
                    break;
                case Keys.Y:
                    this.scene.SetAlgorithm("introspective-sort");
                    break;
                case Keys.T:
                    this.scene.SetAlgorithm("tim-sort");
                    break;
                case Keys.V:
                    this.scene.Colored = !this.scene.Colored;
                    cbColored.Checked = this.scene.Colored;
                    break;
                case Keys.Up:
                    if (this.timer.Interval - 5 <= 0)
                    {
                        this.timer.Interval = 1;
                        if (I < 60)
                        {
                            I += 1;
                        }
                    }
                    else
                    {
                        this.timer.Interval -= 5;
                    }
                    break;
                case Keys.Down:
                    if (I > 1)
                    {
                        I -= 1;
                    }
                    else
                    {
                        this.timer.Interval += 5;
                    }
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, key);
            }

            Invalidate();

            return true;
        }

        private void cycleMode()
        {
            if (rbBarMode.Checked)
            {
                rbBarMode.Checked = false;
                rbPointMode.Checked = true;
            } else if (rbPointMode.Checked)
            {
                rbBarMode.Checked = true;
                rbPointMode.Checked = false;
            }
        }

        private void cbColored_CheckedChanged(object sender, EventArgs e)
        {
            this.scene.Colored = cbColored.Checked;
            Invalidate();
        }

        private void rbBarMode_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBarMode.Checked)
            {
                this.scene.BarMode = true;
                Invalidate();
            }
        }

        private void rbPointMode_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPointMode.Checked)
            {
                this.scene.BarMode = false;
                Invalidate();
            }
        }

        private void nudN_ValueChanged(object sender, EventArgs e)
        {
            if (this.scene.Algorithm.HasFinished())
            {
                var elements = new List<Element>();
                for(int i = 0; i < nudN.Value; i++)
                {
                    elements.Add(new NumberElement(i));
                }
                this.scene.Array = new Array(elements);
            }
        }
    }
}
