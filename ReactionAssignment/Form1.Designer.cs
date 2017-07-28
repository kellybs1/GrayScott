namespace ReactionAssignment
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.numericUpDownFeedA = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownKillB = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxLaplacian = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxShader = new System.Windows.Forms.ComboBox();
            this.panelGridDisplay = new System.Windows.Forms.Panel();
            this.buttonGo = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelIteration = new System.Windows.Forms.Label();
            this.buttonSaveImage = new System.Windows.Forms.Button();
            this.numericUpDownNLoops = new System.Windows.Forms.NumericUpDown();
            this.buttonBatch = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownKillBBatchStart = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownFeedABatchStart = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownFeedABatchEnd = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownKillBBatchEnd = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBoxBatchSim = new System.Windows.Forms.GroupBox();
            this.groupBoxObserveSim = new System.Windows.Forms.GroupBox();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.groupBoxSeed = new System.Windows.Forms.GroupBox();
            this.comboBoxSeed = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFeedA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKillB)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNLoops)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKillBBatchStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFeedABatchStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFeedABatchEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKillBBatchEnd)).BeginInit();
            this.groupBoxBatchSim.SuspendLayout();
            this.groupBoxObserveSim.SuspendLayout();
            this.groupBoxSeed.SuspendLayout();
            this.SuspendLayout();
            // 
            // numericUpDownFeedA
            // 
            this.numericUpDownFeedA.DecimalPlaces = 3;
            this.numericUpDownFeedA.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDownFeedA.Location = new System.Drawing.Point(117, 53);
            this.numericUpDownFeedA.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            196608});
            this.numericUpDownFeedA.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDownFeedA.Name = "numericUpDownFeedA";
            this.numericUpDownFeedA.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownFeedA.TabIndex = 1;
            this.numericUpDownFeedA.Value = new decimal(new int[] {
            25,
            0,
            0,
            196608});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Feed A";
            // 
            // numericUpDownKillB
            // 
            this.numericUpDownKillB.DecimalPlaces = 3;
            this.numericUpDownKillB.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDownKillB.Location = new System.Drawing.Point(117, 98);
            this.numericUpDownKillB.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            196608});
            this.numericUpDownKillB.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDownKillB.Name = "numericUpDownKillB";
            this.numericUpDownKillB.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownKillB.TabIndex = 3;
            this.numericUpDownKillB.Value = new decimal(new int[] {
            56,
            0,
            0,
            196608});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Kill B";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxLaplacian);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(348, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(175, 81);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Laplacian Function";
            // 
            // comboBoxLaplacian
            // 
            this.comboBoxLaplacian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLaplacian.FormattingEnabled = true;
            this.comboBoxLaplacian.Location = new System.Drawing.Point(24, 31);
            this.comboBoxLaplacian.Name = "comboBoxLaplacian";
            this.comboBoxLaplacian.Size = new System.Drawing.Size(121, 25);
            this.comboBoxLaplacian.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxShader);
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(567, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(175, 81);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Shading Algorithm";
            // 
            // comboBoxShader
            // 
            this.comboBoxShader.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShader.FormattingEnabled = true;
            this.comboBoxShader.Location = new System.Drawing.Point(24, 31);
            this.comboBoxShader.Name = "comboBoxShader";
            this.comboBoxShader.Size = new System.Drawing.Size(121, 25);
            this.comboBoxShader.TabIndex = 0;
            // 
            // panelGridDisplay
            // 
            this.panelGridDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGridDisplay.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelGridDisplay.Location = new System.Drawing.Point(311, 121);
            this.panelGridDisplay.Name = "panelGridDisplay";
            this.panelGridDisplay.Size = new System.Drawing.Size(256, 256);
            this.panelGridDisplay.TabIndex = 7;
            // 
            // buttonGo
            // 
            this.buttonGo.Location = new System.Drawing.Point(62, 157);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(175, 23);
            this.buttonGo.TabIndex = 8;
            this.buttonGo.Text = "Start Observable";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelIteration
            // 
            this.labelIteration.AutoSize = true;
            this.labelIteration.Location = new System.Drawing.Point(6, 296);
            this.labelIteration.Name = "labelIteration";
            this.labelIteration.Size = new System.Drawing.Size(69, 17);
            this.labelIteration.TabIndex = 9;
            this.labelIteration.Text = "Iteration 0";
            // 
            // buttonSaveImage
            // 
            this.buttonSaveImage.Location = new System.Drawing.Point(62, 262);
            this.buttonSaveImage.Name = "buttonSaveImage";
            this.buttonSaveImage.Size = new System.Drawing.Size(175, 23);
            this.buttonSaveImage.TabIndex = 10;
            this.buttonSaveImage.Text = "Save Image";
            this.buttonSaveImage.UseVisualStyleBackColor = true;
            this.buttonSaveImage.Click += new System.EventHandler(this.buttonSaveImage_Click);
            // 
            // numericUpDownNLoops
            // 
            this.numericUpDownNLoops.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownNLoops.Location = new System.Drawing.Point(22, 32);
            this.numericUpDownNLoops.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownNLoops.Name = "numericUpDownNLoops";
            this.numericUpDownNLoops.Size = new System.Drawing.Size(138, 22);
            this.numericUpDownNLoops.TabIndex = 11;
            this.numericUpDownNLoops.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonBatch
            // 
            this.buttonBatch.Location = new System.Drawing.Point(56, 262);
            this.buttonBatch.Name = "buttonBatch";
            this.buttonBatch.Size = new System.Drawing.Size(175, 23);
            this.buttonBatch.TabIndex = 12;
            this.buttonBatch.Text = "Batch Processing";
            this.buttonBatch.UseVisualStyleBackColor = true;
            this.buttonBatch.Click += new System.EventHandler(this.buttonBatch_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numericUpDownNLoops);
            this.groupBox3.Location = new System.Drawing.Point(47, 157);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(196, 79);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Iterations per combination";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Kill B";
            // 
            // numericUpDownKillBBatchStart
            // 
            this.numericUpDownKillBBatchStart.DecimalPlaces = 3;
            this.numericUpDownKillBBatchStart.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDownKillBBatchStart.Location = new System.Drawing.Point(68, 97);
            this.numericUpDownKillBBatchStart.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            196608});
            this.numericUpDownKillBBatchStart.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDownKillBBatchStart.Name = "numericUpDownKillBBatchStart";
            this.numericUpDownKillBBatchStart.Size = new System.Drawing.Size(69, 22);
            this.numericUpDownKillBBatchStart.TabIndex = 16;
            this.numericUpDownKillBBatchStart.Value = new decimal(new int[] {
            56,
            0,
            0,
            196608});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Feed A";
            // 
            // numericUpDownFeedABatchStart
            // 
            this.numericUpDownFeedABatchStart.DecimalPlaces = 3;
            this.numericUpDownFeedABatchStart.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDownFeedABatchStart.Location = new System.Drawing.Point(68, 52);
            this.numericUpDownFeedABatchStart.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            196608});
            this.numericUpDownFeedABatchStart.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDownFeedABatchStart.Name = "numericUpDownFeedABatchStart";
            this.numericUpDownFeedABatchStart.Size = new System.Drawing.Size(69, 22);
            this.numericUpDownFeedABatchStart.TabIndex = 14;
            this.numericUpDownFeedABatchStart.Value = new decimal(new int[] {
            25,
            0,
            0,
            196608});
            // 
            // numericUpDownFeedABatchEnd
            // 
            this.numericUpDownFeedABatchEnd.DecimalPlaces = 3;
            this.numericUpDownFeedABatchEnd.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDownFeedABatchEnd.Location = new System.Drawing.Point(183, 52);
            this.numericUpDownFeedABatchEnd.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            196608});
            this.numericUpDownFeedABatchEnd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDownFeedABatchEnd.Name = "numericUpDownFeedABatchEnd";
            this.numericUpDownFeedABatchEnd.Size = new System.Drawing.Size(69, 22);
            this.numericUpDownFeedABatchEnd.TabIndex = 18;
            this.numericUpDownFeedABatchEnd.Value = new decimal(new int[] {
            25,
            0,
            0,
            196608});
            // 
            // numericUpDownKillBBatchEnd
            // 
            this.numericUpDownKillBBatchEnd.DecimalPlaces = 3;
            this.numericUpDownKillBBatchEnd.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDownKillBBatchEnd.Location = new System.Drawing.Point(183, 99);
            this.numericUpDownKillBBatchEnd.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            196608});
            this.numericUpDownKillBBatchEnd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDownKillBBatchEnd.Name = "numericUpDownKillBBatchEnd";
            this.numericUpDownKillBBatchEnd.Size = new System.Drawing.Size(69, 22);
            this.numericUpDownKillBBatchEnd.TabIndex = 19;
            this.numericUpDownKillBBatchEnd.Value = new decimal(new int[] {
            56,
            0,
            0,
            196608});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(78, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "From";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(195, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 17);
            this.label6.TabIndex = 21;
            this.label6.Text = "To";
            // 
            // groupBoxBatchSim
            // 
            this.groupBoxBatchSim.Controls.Add(this.numericUpDownFeedABatchStart);
            this.groupBoxBatchSim.Controls.Add(this.label6);
            this.groupBoxBatchSim.Controls.Add(this.buttonBatch);
            this.groupBoxBatchSim.Controls.Add(this.label5);
            this.groupBoxBatchSim.Controls.Add(this.groupBox3);
            this.groupBoxBatchSim.Controls.Add(this.numericUpDownKillBBatchEnd);
            this.groupBoxBatchSim.Controls.Add(this.label4);
            this.groupBoxBatchSim.Controls.Add(this.numericUpDownFeedABatchEnd);
            this.groupBoxBatchSim.Controls.Add(this.numericUpDownKillBBatchStart);
            this.groupBoxBatchSim.Controls.Add(this.label3);
            this.groupBoxBatchSim.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxBatchSim.Location = new System.Drawing.Point(19, 112);
            this.groupBoxBatchSim.Name = "groupBoxBatchSim";
            this.groupBoxBatchSim.Size = new System.Drawing.Size(269, 319);
            this.groupBoxBatchSim.TabIndex = 22;
            this.groupBoxBatchSim.TabStop = false;
            this.groupBoxBatchSim.Text = "Batch Simulation";
            // 
            // groupBoxObserveSim
            // 
            this.groupBoxObserveSim.Controls.Add(this.buttonPause);
            this.groupBoxObserveSim.Controls.Add(this.numericUpDownFeedA);
            this.groupBoxObserveSim.Controls.Add(this.label1);
            this.groupBoxObserveSim.Controls.Add(this.labelIteration);
            this.groupBoxObserveSim.Controls.Add(this.buttonSaveImage);
            this.groupBoxObserveSim.Controls.Add(this.numericUpDownKillB);
            this.groupBoxObserveSim.Controls.Add(this.label2);
            this.groupBoxObserveSim.Controls.Add(this.buttonGo);
            this.groupBoxObserveSim.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxObserveSim.Location = new System.Drawing.Point(591, 112);
            this.groupBoxObserveSim.Name = "groupBoxObserveSim";
            this.groupBoxObserveSim.Size = new System.Drawing.Size(270, 319);
            this.groupBoxObserveSim.TabIndex = 22;
            this.groupBoxObserveSim.TabStop = false;
            this.groupBoxObserveSim.Text = "Observable Simulation";
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(62, 209);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(175, 23);
            this.buttonPause.TabIndex = 11;
            this.buttonPause.Text = "Pause/Continue";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReset.Location = new System.Drawing.Point(375, 399);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(127, 32);
            this.buttonReset.TabIndex = 23;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // groupBoxSeed
            // 
            this.groupBoxSeed.Controls.Add(this.comboBoxSeed);
            this.groupBoxSeed.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxSeed.Location = new System.Drawing.Point(131, 12);
            this.groupBoxSeed.Name = "groupBoxSeed";
            this.groupBoxSeed.Size = new System.Drawing.Size(175, 81);
            this.groupBoxSeed.TabIndex = 6;
            this.groupBoxSeed.TabStop = false;
            this.groupBoxSeed.Text = "Seed";
            // 
            // comboBoxSeed
            // 
            this.comboBoxSeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSeed.FormattingEnabled = true;
            this.comboBoxSeed.Location = new System.Drawing.Point(24, 31);
            this.comboBoxSeed.Name = "comboBoxSeed";
            this.comboBoxSeed.Size = new System.Drawing.Size(121, 25);
            this.comboBoxSeed.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(880, 458);
            this.Controls.Add(this.groupBoxSeed);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.groupBoxObserveSim);
            this.Controls.Add(this.groupBoxBatchSim);
            this.Controls.Add(this.panelGridDisplay);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Gray-Scott Simulation";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFeedA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKillB)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNLoops)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKillBBatchStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFeedABatchStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFeedABatchEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKillBBatchEnd)).EndInit();
            this.groupBoxBatchSim.ResumeLayout(false);
            this.groupBoxBatchSim.PerformLayout();
            this.groupBoxObserveSim.ResumeLayout(false);
            this.groupBoxObserveSim.PerformLayout();
            this.groupBoxSeed.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numericUpDownFeedA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownKillB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxLaplacian;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxShader;
        private System.Windows.Forms.Panel panelGridDisplay;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelIteration;
        private System.Windows.Forms.Button buttonSaveImage;
        private System.Windows.Forms.NumericUpDown numericUpDownNLoops;
        private System.Windows.Forms.Button buttonBatch;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownKillBBatchStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownFeedABatchStart;
        private System.Windows.Forms.NumericUpDown numericUpDownFeedABatchEnd;
        private System.Windows.Forms.NumericUpDown numericUpDownKillBBatchEnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBoxBatchSim;
        private System.Windows.Forms.GroupBox groupBoxObserveSim;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.GroupBox groupBoxSeed;
        private System.Windows.Forms.ComboBox comboBoxSeed;
    }
}

