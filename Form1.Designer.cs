namespace Beehive
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.simulationStarten = new System.Windows.Forms.ToolStripButton();
            this.zurücksetzen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label12 = new System.Windows.Forms.Label();
            this.FrameRate = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.PassedFrames = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.NectarInFlowers = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.HoneyInHive = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Flowers = new System.Windows.Forms.Label();
            this.Bees = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.simulationStarten,
            this.zurücksetzen,
            this.toolStripSeparator,
            this.openToolStripButton,
            this.saveToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(252, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // simulationStarten
            // 
            this.simulationStarten.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.simulationStarten.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.simulationStarten.Name = "simulationStarten";
            this.simulationStarten.Size = new System.Drawing.Size(94, 22);
            this.simulationStarten.Text = "Start simulation";
            this.simulationStarten.Click += new System.EventHandler(this.simulationStarten_Click);
            // 
            // zurücksetzen
            // 
            this.zurücksetzen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.zurücksetzen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zurücksetzen.Name = "zurücksetzen";
            this.zurücksetzen.Size = new System.Drawing.Size(39, 22);
            this.zurücksetzen.Text = "Reset";
            this.zurücksetzen.Click += new System.EventHandler(this.reset_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "&Open";
            this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 206);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(252, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(110, 17);
            this.toolStripStatusLabel1.Text = "Simulation stopped";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.54237F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.45763F));
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.FrameRate, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.PassedFrames, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.NectarInFlowers, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.HoneyInHive, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Flowers, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Bees, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 23);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(247, 74);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(2, 75);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Frame-Rate";
            // 
            // FrameRate
            // 
            this.FrameRate.AutoSize = true;
            this.FrameRate.Location = new System.Drawing.Point(131, 75);
            this.FrameRate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FrameRate.Name = "FrameRate";
            this.FrameRate.Size = new System.Drawing.Size(59, 13);
            this.FrameRate.TabIndex = 10;
            this.FrameRate.Text = "FrameRate";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(2, 60);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Passed frames";
            // 
            // PassedFrames
            // 
            this.PassedFrames.AutoSize = true;
            this.PassedFrames.Location = new System.Drawing.Point(131, 60);
            this.PassedFrames.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PassedFrames.Name = "PassedFrames";
            this.PassedFrames.Size = new System.Drawing.Size(76, 13);
            this.PassedFrames.TabIndex = 8;
            this.PassedFrames.Text = "PassedFrames";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 45);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Nectar in feld";
            // 
            // NectarInFlowers
            // 
            this.NectarInFlowers.AutoSize = true;
            this.NectarInFlowers.Location = new System.Drawing.Point(131, 45);
            this.NectarInFlowers.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NectarInFlowers.Name = "NectarInFlowers";
            this.NectarInFlowers.Size = new System.Drawing.Size(84, 13);
            this.NectarInFlowers.TabIndex = 6;
            this.NectarInFlowers.Text = "NectarInFlowers";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 30);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Honey in hive";
            // 
            // HoneyInHive
            // 
            this.HoneyInHive.AutoSize = true;
            this.HoneyInHive.Location = new System.Drawing.Point(131, 30);
            this.HoneyInHive.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.HoneyInHive.Name = "HoneyInHive";
            this.HoneyInHive.Size = new System.Drawing.Size(69, 13);
            this.HoneyInHive.TabIndex = 4;
            this.HoneyInHive.Text = "HoneyInHive";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Amount of flowers";
            // 
            // Flowers
            // 
            this.Flowers.AutoSize = true;
            this.Flowers.Location = new System.Drawing.Point(131, 15);
            this.Flowers.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Flowers.Name = "Flowers";
            this.Flowers.Size = new System.Drawing.Size(43, 13);
            this.Flowers.TabIndex = 2;
            this.Flowers.Text = "Flowers";
            // 
            // Bees
            // 
            this.Bees.AutoSize = true;
            this.Bees.Location = new System.Drawing.Point(131, 0);
            this.Bees.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Bees.Name = "Bees";
            this.Bees.Size = new System.Drawing.Size(31, 13);
            this.Bees.TabIndex = 1;
            this.Bees.Text = "Bees";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Amount of bees";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.ExecuteFramce);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(5, 102);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(242, 95);
            this.listBox1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 228);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Beehive-Simulator";
            this.Move += new System.EventHandler(this.Form1_Move);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton simulationStarten;
        private System.Windows.Forms.ToolStripButton zurücksetzen;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label FrameRate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label PassedFrames;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label NectarInFlowers;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label HoneyInHive;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Flowers;
        private System.Windows.Forms.Label Bees;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
    }
}

