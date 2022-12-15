
namespace Conway_s_Game_of_Life
{
    partial class mainWindow
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
            this.boardPictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.startButton = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseButton = new System.Windows.Forms.ToolStripMenuItem();
            this.stopButton = new System.Windows.Forms.ToolStripMenuItem();
            this.setIntervalButton = new System.Windows.Forms.ToolStripMenuItem();
            this.bgWorkerForGeneration = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.boardPictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // boardPictureBox
            // 
            this.boardPictureBox.Location = new System.Drawing.Point(12, 37);
            this.boardPictureBox.Name = "boardPictureBox";
            this.boardPictureBox.Size = new System.Drawing.Size(710, 662);
            this.boardPictureBox.TabIndex = 0;
            this.boardPictureBox.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startButton,
            this.pauseButton,
            this.stopButton,
            this.setIntervalButton});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(734, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // startButton
            // 
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(43, 20);
            this.startButton.Text = "Start";
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Enabled = false;
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(50, 20);
            this.pauseButton.Text = "Pause";
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(43, 20);
            this.stopButton.Text = "Stop";
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // setIntervalButton
            // 
            this.setIntervalButton.Name = "setIntervalButton";
            this.setIntervalButton.Size = new System.Drawing.Size(77, 20);
            this.setIntervalButton.Text = "Set Interval";
            this.setIntervalButton.Click += new System.EventHandler(this.setIntervalButton_Click);
            // 
            // bgWorkerForGeneration
            // 
            this.bgWorkerForGeneration.WorkerReportsProgress = true;
            this.bgWorkerForGeneration.WorkerSupportsCancellation = true;
            this.bgWorkerForGeneration.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerForGeneration_DoWork);
            this.bgWorkerForGeneration.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorkerForGeneration_ProgressChanged);
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 711);
            this.Controls.Add(this.boardPictureBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mainWindow";
            this.Text = "Conway\'s Game of Life; {gameState}; {timeInterval}ms Interval; Generation {genera" +
    "tionNumber}";
            ((System.ComponentModel.ISupportInitialize)(this.boardPictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox boardPictureBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem startButton;
        private System.Windows.Forms.ToolStripMenuItem stopButton;
        private System.Windows.Forms.ToolStripMenuItem setIntervalButton;
        private System.ComponentModel.BackgroundWorker bgWorkerForGeneration;
        private System.Windows.Forms.ToolStripMenuItem pauseButton;
    }
}

