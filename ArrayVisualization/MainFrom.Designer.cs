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
            this.cbColored = new System.Windows.Forms.CheckBox();
            this.gbVisualizationModes = new System.Windows.Forms.GroupBox();
            this.rbPointMode = new System.Windows.Forms.RadioButton();
            this.rbBarMode = new System.Windows.Forms.RadioButton();
            this.nudN = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.trbSpeed = new System.Windows.Forms.TrackBar();
            this.pControls.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbVisualizationModes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // pControls
            // 
            this.pControls.ColumnCount = 1;
            this.pControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pControls.Controls.Add(this.groupBox2, 0, 1);
            this.pControls.Controls.Add(this.gbVisualizationModes, 0, 0);
            this.pControls.Dock = System.Windows.Forms.DockStyle.Left;
            this.pControls.Location = new System.Drawing.Point(0, 0);
            this.pControls.Name = "pControls";
            this.pControls.Padding = new System.Windows.Forms.Padding(5, 10, 0, 0);
            this.pControls.RowCount = 3;
            this.pControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.24324F));
            this.pControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.75676F));
            this.pControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 328F));
            this.pControls.Size = new System.Drawing.Size(152, 561);
            this.pControls.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.trbSpeed);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.nudN);
            this.groupBox2.Controls.Add(this.cbColored);
            this.groupBox2.Location = new System.Drawing.Point(8, 109);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(141, 120);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Visualization Properties";
            // 
            // cbColored
            // 
            this.cbColored.AutoSize = true;
            this.cbColored.Location = new System.Drawing.Point(4, 19);
            this.cbColored.Name = "cbColored";
            this.cbColored.Size = new System.Drawing.Size(80, 17);
            this.cbColored.TabIndex = 1;
            this.cbColored.TabStop = false;
            this.cbColored.Text = "Color Mode";
            this.cbColored.UseVisualStyleBackColor = true;
            this.cbColored.CheckedChanged += new System.EventHandler(this.cbColored_CheckedChanged);
            // 
            // gbVisualizationModes
            // 
            this.gbVisualizationModes.Controls.Add(this.rbPointMode);
            this.gbVisualizationModes.Controls.Add(this.rbBarMode);
            this.gbVisualizationModes.Location = new System.Drawing.Point(8, 13);
            this.gbVisualizationModes.Name = "gbVisualizationModes";
            this.gbVisualizationModes.Size = new System.Drawing.Size(141, 90);
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
            this.rbPointMode.Size = new System.Drawing.Size(76, 18);
            this.rbPointMode.TabIndex = 1;
            this.rbPointMode.Text = "Point Plot";
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
            this.rbBarMode.Size = new System.Drawing.Size(67, 18);
            this.rbBarMode.TabIndex = 0;
            this.rbBarMode.TabStop = true;
            this.rbBarMode.Text = "Bar plot";
            this.rbBarMode.UseVisualStyleBackColor = false;
            this.rbBarMode.CheckedChanged += new System.EventHandler(this.rbBarMode_CheckedChanged);
            // 
            // nudN
            // 
            this.nudN.Location = new System.Drawing.Point(45, 39);
            this.nudN.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudN.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudN.Name = "nudN";
            this.nudN.Size = new System.Drawing.Size(90, 20);
            this.nudN.TabIndex = 2;
            this.nudN.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudN.ValueChanged += new System.EventHandler(this.nudN_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Length:";
            // 
            // trbSpeed
            // 
            this.trbSpeed.Location = new System.Drawing.Point(4, 69);
            this.trbSpeed.Name = "trbSpeed";
            this.trbSpeed.Size = new System.Drawing.Size(131, 45);
            this.trbSpeed.TabIndex = 4;
            // 
            // MainFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.pControls);
            this.Name = "MainFrom";
            this.Text = "Array Visualization by Haled Odat";
            this.ResizeEnd += new System.EventHandler(this.MainFrom_ResizeEnd);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainFrom_Paint);
            this.pControls.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbVisualizationModes.ResumeLayout(false);
            this.gbVisualizationModes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbSpeed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TableLayoutPanel pControls;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbColored;
        private System.Windows.Forms.GroupBox gbVisualizationModes;
        private System.Windows.Forms.RadioButton rbPointMode;
        private System.Windows.Forms.RadioButton rbBarMode;
        private System.Windows.Forms.NumericUpDown nudN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trbSpeed;
    }
}

