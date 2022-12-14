using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Conway_s_Game_of_Life
{
    public partial class mainWindow : Form
    {
        int width = 100;
        int height = 100;
        Board board;
        Stopwatch frameTimer = new Stopwatch();
        int frameNum = 0;
        int frameInterval = 37;
        string gameState = "Paused";
        int timeInterval = 1000;
        bool noInterval = false;
        int generationNumber = 0;

        public mainWindow()
        {
            InitializeComponent();
            // Get new board
            board = new Board(width, height, boardPictureBox.Width, boardPictureBox.Height);
            boardPictureBox.Image = board.boardBmp;
            updateWindow();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            // Common window updates
            startButton.Enabled = false;
            stopButton.Enabled = true;
            setIntervalButton.Enabled = false;
            gameState = "Playing";
            updateWindow();
            // If interval is not zero
            if (!noInterval)
            {
                Console.Write("Starting timers ... ");
                generationIntervalTimer.Start();
                frameTimer.Start();
                Console.WriteLine("DONE");
            }
            // Otherwise if interval is zero and the worker is not busy
            else if (!bgWorkerForGeneration.IsBusy)
            {
                bgWorkerForGeneration.RunWorkerAsync();
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            // Common window updates
            startButton.Enabled = true;
            stopButton.Enabled = false;
            setIntervalButton.Enabled = true;
            gameState = "Paused";
            generationNumber = 0;
            updateWindow();
            // If interval is not zero
            if (!noInterval)
            {
                Console.Write("Stopping timers ... ");
                generationIntervalTimer.Stop();
                frameTimer.Stop();
                Console.WriteLine("DONE");
                frameNum = 0;
            }
            // Otherwise if interval is zero cancel worker
            else
            {
                bgWorkerForGeneration.CancelAsync();
            }
            boardPictureBox.Image = board.boardBmp;
        }

        private void generationIntervalTimer_Tick(object sender, EventArgs e)
        {
            board.nextGeneration();
            generationNumber += 1;
            if (frameTimer.ElapsedMilliseconds >= frameNum * frameInterval)
            {
                frameNum += 1;
                
                boardPictureBox.Image = board.boardBmp;
                updateWindow();
            }
        }

        private void bgWorkerForGeneration_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bgWorker = sender as BackgroundWorker;
            Stopwatch bgStopwatch = Stopwatch.StartNew();
            while (true)
            {
                if (bgWorker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                board.nextGeneration();
                generationNumber += 1;
                Console.Write(bgStopwatch.ElapsedMilliseconds);
                if (bgStopwatch.ElapsedMilliseconds >= frameNum * frameInterval)
                {
                    frameNum += 1;
                    //Thread.Sleep(0);
                    bgWorker.ReportProgress(0, board.boardBmp);
                }
            }
        }

        private void bgWorkerForGeneration_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Console.Write("FRAME");
            boardPictureBox.Image = e.UserState as Bitmap;
            updateWindow();
        }

        private void setIntervalButton_Click(object sender, EventArgs e)
        {
            SetIntervalWindow setIntervalWindow = new SetIntervalWindow(timeInterval, noInterval);
            DialogResult dialogueResult = setIntervalWindow.ShowDialog();
            if (dialogueResult == DialogResult.OK)
            {
                timeInterval = setIntervalWindow.timeInterval;
                noInterval = setIntervalWindow.noInterval;
                updateWindow();
            }
        }

        private void updateWindow()
        {
            // Set window title
            if (!noInterval)
            {
                Text = $"Conway's Game of Life; {gameState}; {timeInterval}ms Interval; Generation {generationNumber}";
            }
            else
            {
                Text = $"Conway's Game of Life; {gameState}; No Interval; Generation {generationNumber}";
            }

            // Set timer interval
            generationIntervalTimer.Interval = timeInterval;
        }
    }
}
