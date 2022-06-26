using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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

            this.timer.Start();
        }

        private void MainFrom_Paint(object sender, PaintEventArgs e)
        {
            this.scene.Draw(e.Graphics);
        }

        private void MainFrom_ResizeEnd(object sender, EventArgs e)
        {
            this.scene.Width = this.ClientRectangle.Width;
            this.scene.Height = this.ClientRectangle.Height;
            Invalidate();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            var el = sw.Elapsed;
            
            for (int i = 0; i < el.Ticks / 100000; i++)
            {
                this.scene.Tick();
                Invalidate();
            }

            sw.Stop();
            sw.Start();
        }

        private void MainFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (this.timer.Interval - 20 <= 0)
                {
                    this.timer.Interval = 1;
                    return;
                }
                this.timer.Interval -= 20;
            } else if (e.KeyCode == Keys.Down)
            {
                this.timer.Interval += 20;
            }
        }
    }
}
