using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        public MainFrom()
        {
            InitializeComponent();
            DoubleBuffered = true;

            this.scene = new Scene(Width, Height);

            this.timer.Interval = 200;
            this.timer.Start();
        }

        private void MainFrom_Paint(object sender, PaintEventArgs e)
        {
            this.scene.Draw(e.Graphics);
        }

        private void MainFrom_ResizeEnd(object sender, EventArgs e)
        {
            this.scene.Width = Width;
            this.scene.Height = Height;
            Invalidate();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                this.scene.Tick();
            } catch
            {

            }
            
            Invalidate();
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
