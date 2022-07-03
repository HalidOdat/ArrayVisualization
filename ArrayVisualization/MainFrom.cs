using ArrayVisualization.Algorithms;
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
        private static Random RANDOM = new Random();

        public MainFrom()
        {
            InitializeComponent();
            DoubleBuffered = true;

            this.scene = new Scene(this.ClientRectangle.Width - this.pControls.Width, this.ClientRectangle.Height);

            this.pControls.BackColor = Color.DarkGray;
            this.pControls.Padding = new Padding(5, 10, 5, 10);

            this.GenerateAlgorithmList();

            this.trbSpeed.Value = -50;
            this.nudN.Value = 400;
            this.timer.Start();
        }

        private void GenerateAlgorithmList()
        {
            var algorithms = new List<Algorithm>() {
                new ShuffleAlgorithm(this.scene.Array),
                new ReverseAlgorithm(this.scene.Array),
                new BubbleSortAlgorithm(this.scene.Array),
                new MergeSortAlgorithm(this.scene.Array),
                new InPlaceMergeSortAlgorithm(this.scene.Array),
                new HeapSortAlgorithm(this.scene.Array),
                new SelectionSortAlgorithm(this.scene.Array),
                new InsertionSortAlgorithm(this.scene.Array),
                new QuickSortAlgorithm(this.scene.Array),
                new ExchangeSortAlgorithm(this.scene.Array),
                new CocktailSortAlgorithm(this.scene.Array),
                new CombSortAlgorithm(this.scene.Array),
                new ShellSortAlgorithm(this.scene.Array),
                new OddEvenSortAlgorithm(this.scene.Array),
                new GnomeSortAlgorithm(this.scene.Array),
                new TimSortAlgorithm(this.scene.Array),
                new IntrospectiveSortAlgorithm(this.scene.Array),
                new CycleSortAlgorithm(this.scene.Array),
                new BogoSortAlgorithm(this.scene.Array),
            };

            this.lbAlgorithms.Items.Clear();
            foreach (var algorithm in algorithms)
            {
                this.lbAlgorithms.Items.Add(algorithm);
            }
        }

        public int I { get; set; } = 1;

        private const int MIN_SPEED = -1000;
        private const int MAX_SPEED = 1000;

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
                    trbSpeed.Value = (trbSpeed.Value + 10).Clamp(MIN_SPEED, MAX_SPEED);
                    break;
                case Keys.Down:
                    trbSpeed.Value = (trbSpeed.Value - 10).Clamp(MIN_SPEED, MAX_SPEED);
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

        private void trbSpeed_ValueChanged(object sender, EventArgs e)
        {
            var value = trbSpeed.Value != 0 ? trbSpeed.Value : 1;
            if (value > 0)
            {
                this.timer.Interval = 1;
                this.I = value;
            } else
            {
                this.timer.Interval = -value;
                this.I = 1;
            }
        }

        private void lbAlgorithms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbAlgorithms.SelectedIndex == -1)
            {
                return;
            }
            var algorithm = (Algorithm)lbAlgorithms.SelectedItem;
            algorithm.Reset();
            this.scene.Algorithm = algorithm;
        }

        private void GenerateArray()
        {
            this.scene.Array.Elements.Clear();

            for (int i = 0; i < nudN.Value; i++)
            {
                int value = i;
                if (this.cbAllowDuplicates.Checked)
                {
                    value = RANDOM.Next(0, (int)nudN.Value);
                }
                this.scene.Array.Elements.Add(new NumberElement(value));
            }
        }

        private void nudN_ValueChanged(object sender, EventArgs e)
        {
            GenerateArray();
        }

        private void cbAllowDuplicates_CheckedChanged(object sender, EventArgs e)
        {
            GenerateArray();
        }
    }
}
