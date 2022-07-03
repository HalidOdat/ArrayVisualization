namespace ArrayVisualization
{
    partial class MainFrom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.pControls = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbAllowDuplicates = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.trbSpeed = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.nudN = new System.Windows.Forms.NumericUpDown();
            this.gbVisualizationModes = new System.Windows.Forms.GroupBox();
            this.rbPointMode = new System.Windows.Forms.RadioButton();
            this.rbBarMode = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbAlgorithms = new System.Windows.Forms.ListBox();
            this.btnPause = new System.Windows.Forms.Button();
            this.cbColored = new System.Windows.Forms.CheckBox();
            this.pControls.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudN)).BeginInit();
            this.gbVisualizationModes.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // pControls
            // 
            this.pControls.AutoSize = true;
            this.pControls.ColumnCount = 1;
            this.pControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pControls.Controls.Add(this.groupBox2, 0, 1);
            this.pControls.Controls.Add(this.gbVisualizationModes, 0, 0);
            this.pControls.Controls.Add(this.groupBox1, 0, 2);
            this.pControls.Dock = System.Windows.Forms.DockStyle.Left;
            this.pControls.Location = new System.Drawing.Point(0, 0);
            this.pControls.Name = "pControls";
            this.pControls.Padding = new System.Windows.Forms.Padding(5, 10, 0, 0);
            this.pControls.RowCount = 3;
            this.pControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.84615F));
            this.pControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.15385F));
            this.pControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 299F));
            this.pControls.Size = new System.Drawing.Size(175, 561);
            this.pControls.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnPause);
            this.groupBox2.Controls.Add(this.cbAllowDuplicates);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.trbSpeed);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.nudN);
            this.groupBox2.Controls.Add(this.cbColored);
            this.groupBox2.Location = new System.Drawing.Point(8, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(164, 173);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Visualization Properties";
            // 
            // cbAllowDuplicates
            // 
            this.cbAllowDuplicates.AutoSize = true;
            this.cbAllowDuplicates.Location = new System.Drawing.Point(6, 42);
            this.cbAllowDuplicates.Name = "cbAllowDuplicates";
            this.cbAllowDuplicates.Size = new System.Drawing.Size(104, 17);
            this.cbAllowDuplicates.TabIndex = 6;
            this.cbAllowDuplicates.Text = "Allow Duplicates";
            this.cbAllowDuplicates.UseVisualStyleBackColor = true;
            this.cbAllowDuplicates.CheckedChanged += new System.EventHandler(this.cbAllowDuplicates_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Speed";
            // 
            // trbSpeed
            // 
            this.trbSpeed.LargeChange = 20;
            this.trbSpeed.Location = new System.Drawing.Point(45, 94);
            this.trbSpeed.Maximum = 1000;
            this.trbSpeed.Minimum = -1000;
            this.trbSpeed.Name = "trbSpeed";
            this.trbSpeed.Size = new System.Drawing.Size(113, 45);
            this.trbSpeed.SmallChange = 5;
            this.trbSpeed.TabIndex = 4;
            this.trbSpeed.TickFrequency = 200;
            this.trbSpeed.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trbSpeed.Value = 1;
            this.trbSpeed.ValueChanged += new System.EventHandler(this.trbSpeed_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Length";
            // 
            // nudN
            // 
            this.nudN.Location = new System.Drawing.Point(45, 63);
            this.nudN.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudN.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudN.Name = "nudN";
            this.nudN.Size = new System.Drawing.Size(113, 20);
            this.nudN.TabIndex = 2;
            this.nudN.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudN.ValueChanged += new System.EventHandler(this.nudN_ValueChanged);
            // 
            // gbVisualizationModes
            // 
            this.gbVisualizationModes.Controls.Add(this.rbPointMode);
            this.gbVisualizationModes.Controls.Add(this.rbBarMode);
            this.gbVisualizationModes.Location = new System.Drawing.Point(8, 13);
            this.gbVisualizationModes.Name = "gbVisualizationModes";
            this.gbVisualizationModes.Size = new System.Drawing.Size(164, 66);
            this.gbVisualizationModes.TabIndex = 4;
            this.gbVisualizationModes.TabStop = false;
            this.gbVisualizationModes.Text = "Visualization Modes";
            // 
            // rbPointMode
            // 
            this.rbPointMode.AutoSize = true;
            this.rbPointMode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbPointMode.Location = new System.Drawing.Point(7, 43);
            this.rbPointMode.Name = "rbPointMode";
            this.rbPointMode.Size = new System.Drawing.Size(60, 18);
            this.rbPointMode.TabIndex = 1;
            this.rbPointMode.Text = "Points";
            this.rbPointMode.UseVisualStyleBackColor = true;
            this.rbPointMode.CheckedChanged += new System.EventHandler(this.rbPointMode_CheckedChanged);
            // 
            // rbBarMode
            // 
            this.rbBarMode.AutoSize = true;
            this.rbBarMode.BackColor = System.Drawing.Color.Transparent;
            this.rbBarMode.Checked = true;
            this.rbBarMode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbBarMode.Location = new System.Drawing.Point(7, 20);
            this.rbBarMode.Name = "rbBarMode";
            this.rbBarMode.Size = new System.Drawing.Size(52, 18);
            this.rbBarMode.TabIndex = 0;
            this.rbBarMode.TabStop = true;
            this.rbBarMode.Text = "Bars";
            this.rbBarMode.UseVisualStyleBackColor = false;
            this.rbBarMode.CheckedChanged += new System.EventHandler(this.rbBarMode_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbAlgorithms);
            this.groupBox1.Location = new System.Drawing.Point(8, 264);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 291);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Algorithms";
            // 
            // lbAlgorithms
            // 
            this.lbAlgorithms.FormattingEnabled = true;
            this.lbAlgorithms.Location = new System.Drawing.Point(7, 19);
            this.lbAlgorithms.Name = "lbAlgorithms";
            this.lbAlgorithms.Size = new System.Drawing.Size(151, 264);
            this.lbAlgorithms.TabIndex = 1;
            this.lbAlgorithms.SelectedIndexChanged += new System.EventHandler(this.lbAlgorithms_SelectedIndexChanged);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(7, 139);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(151, 23);
            this.btnPause.TabIndex = 7;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // cbColored
            // 
            this.cbColored.AutoSize = true;
            this.cbColored.Location = new System.Drawing.Point(7, 19);
            this.cbColored.Name = "cbColored";
            this.cbColored.Size = new System.Drawing.Size(80, 17);
            this.cbColored.TabIndex = 1;
            this.cbColored.TabStop = false;
            this.cbColored.Text = "Color Mode";
            this.cbColored.UseVisualStyleBackColor = true;
            this.cbColored.CheckedChanged += new System.EventHandler(this.cbColored_CheckedChanged);
            // 
            // MainFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.pControls);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "MainFrom";
            this.Text = "Array Algorithm Visualizer";
            this.ResizeEnd += new System.EventHandler(this.MainFrom_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.MainFrom_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainFrom_Paint);
            this.pControls.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudN)).EndInit();
            this.gbVisualizationModes.ResumeLayout(false);
            this.gbVisualizationModes.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TableLayoutPanel pControls;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gbVisualizationModes;
        private System.Windows.Forms.RadioButton rbPointMode;
        private System.Windows.Forms.RadioButton rbBarMode;
        private System.Windows.Forms.NumericUpDown nudN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trbSpeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbAlgorithms;
        private System.Windows.Forms.CheckBox cbAllowDuplicates;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.CheckBox cbColored;
    }
}

