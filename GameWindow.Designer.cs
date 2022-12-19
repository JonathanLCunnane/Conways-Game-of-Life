
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
            this.editButton = new System.Windows.Forms.ToolStripMenuItem();
            this.bgWorkerForGeneration = new System.ComponentModel.BackgroundWorker();
            this.fileButton = new System.Windows.Forms.ToolStripMenuItem();
            this.exportBoardButton = new System.Windows.Forms.ToolStripMenuItem();
            this.importBoardButton = new System.Windows.Forms.ToolStripMenuItem();
            this.setDimensionsButton = new System.Windows.Forms.ToolStripMenuItem();
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
            this.boardPictureBox.Click += new System.EventHandler(this.boardPictureBox_Click);
            this.boardPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.boardPictureBox_MouseMove);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileButton,
            this.startButton,
            this.pauseButton,
            this.stopButton,
            this.setIntervalButton,
            this.setDimensionsButton,
            this.editButton});
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
            // editButton
            // 
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(73, 20);
            this.editButton.Text = "Edit Board";
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // bgWorkerForGeneration
            // 
            this.bgWorkerForGeneration.WorkerReportsProgress = true;
            this.bgWorkerForGeneration.WorkerSupportsCancellation = true;
            this.bgWorkerForGeneration.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerForGeneration_DoWork);
            this.bgWorkerForGeneration.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorkerForGeneration_ProgressChanged);
            // 
            // fileButton
            // 
            this.fileButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportBoardButton,
            this.importBoardButton});
            this.fileButton.Name = "fileButton";
            this.fileButton.Size = new System.Drawing.Size(37, 20);
            this.fileButton.Text = "File";
            // 
            // exportBoardButton
            // 
            this.exportBoardButton.Name = "exportBoardButton";
            this.exportBoardButton.Size = new System.Drawing.Size(180, 22);
            this.exportBoardButton.Text = "Export Board";
            this.exportBoardButton.Click += new System.EventHandler(this.exportBoardButton_Click);
            // 
            // importBoardButton
            // 
            this.importBoardButton.Name = "importBoardButton";
            this.importBoardButton.Size = new System.Drawing.Size(180, 22);
            this.importBoardButton.Text = "Import Board";
            this.importBoardButton.Click += new System.EventHandler(this.importBoardButton_Click);
            // 
            // setDimensionsButton
            // 
            this.setDimensionsButton.Name = "setDimensionsButton";
            this.setDimensionsButton.Size = new System.Drawing.Size(100, 20);
            this.setDimensionsButton.Text = "Set Dimensions";
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
        private System.Windows.Forms.ToolStripMenuItem editButton;
        private System.Windows.Forms.ToolStripMenuItem fileButton;
        private System.Windows.Forms.ToolStripMenuItem exportBoardButton;
        private System.Windows.Forms.ToolStripMenuItem importBoardButton;
        private System.Windows.Forms.ToolStripMenuItem setDimensionsButton;
    }
}

