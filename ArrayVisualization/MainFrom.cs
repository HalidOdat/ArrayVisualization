using ArrayVisualization.Algorithms;
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

            this.scene = new Scene(GetViewableRectangle());

            this.pControls.BackColor = Color.DarkGray;
            this.pControls.Padding = new Padding(5, 10, 5, 10);

            this.GenerateAlgorithmList();

            this.trbSpeed.Value = -30;
            this.nudN.Value = 400;
            this.cbColored.Checked = true;

            this.timer.Start();
        }

        private Rectangle GetViewableRectangle()
        {
            var point = new Point(pControls.Width, 30);
            return new Rectangle(point.X, point.Y, this.ClientRectangle.Width - point.X, this.ClientRectangle.Height - point.Y);
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

        /// <summary>
        /// Defines how many times steps in the current algorithm will be taken in 1ms.
        /// </summary>
        public int I { get; set; } = 1;

        private const int MIN_SPEED = -1000;
        private const int MAX_SPEED = 1000;

        private void MainFrom_Paint(object sender, PaintEventArgs e)
        {
            this.scene.Draw(e.Graphics, (float)timer.Interval / I);
        }

        private void MainFrom_ResizeEnd(object sender, EventArgs e)
        {
            this.scene.ViewRectangle = GetViewableRectangle();
            Invalidate();
        }

        private void MainFrom_SizeChanged(object sender, EventArgs e)
        {
            this.scene.ViewRectangle = GetViewableRectangle();
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
                this.cbAllowDuplicates.Enabled = false;
                this.nudN.Enabled = false;
            } else
            {
                this.cbAllowDuplicates.Enabled = true;
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
                    btnPause.PerformClick();
                    break;
                case Keys.Control | Keys.M:
                    this.cycleMode();
                    break;
                case Keys.Control | Keys.C:
                    this.scene.Colored = !this.scene.Colored;
                    cbColored.Checked = this.scene.Colored;
                    break;
                case Keys.Control | Keys.S:
                    this.lbAlgorithms.SelectedIndex = 0;
                    break;
                case Keys.Up:
                    trbSpeed.Value = Utils.Clamp(trbSpeed.Value + 5, MIN_SPEED, MAX_SPEED);
                    break;
                case Keys.Down:
                    trbSpeed.Value = Utils.Clamp(trbSpeed.Value - 5, MIN_SPEED, MAX_SPEED);
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, key);
            }

            Invalidate();

            return true;
        }

        /// <summary>
        /// Cycles through the visualization modes.
        /// </summary>
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
            this.scene.Array.Accesses = 0;
            this.scene.Algorithm = (Algorithm)lbAlgorithms.SelectedItem;
            this.scene.Algorithm.Reset();
        }

        /// <summary>
        /// Generate and populate array according to control flags
        /// </summary>
        private void GenerateArray()
        {
            this.scene.Array.Elements.Clear();
            for (int i = 1; i <= (int)nudN.Value; i++)
            {
                int value = i;
                if (this.cbAllowDuplicates.Checked)
                {
                    value = RANDOM.Next(1, (int)nudN.Value);
                }
                this.scene.Array.Elements.Add(value);
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

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (this.scene.Paused)
            {
                this.btnPause.Text = "Pause";
            } else
            {
                this.btnPause.Text = "Resume";
            }
            this.scene.Pause();
        }
    }
}
