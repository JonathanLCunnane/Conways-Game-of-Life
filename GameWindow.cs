﻿using System;
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
        Board originalBoard;
        int frameNum = 0;
        int frameInterval = 37;
        string gameState = "Paused";
        int timeInterval = 1000;
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
            if (!bgWorkerForGeneration.IsBusy)
            {
                // Retain copy of original board
                originalBoard = board.Clone();

                // Common window updates
                startButton.Enabled = false;
                stopButton.Enabled = true;
                setIntervalButton.Enabled = false;
                gameState = "Playing";
                updateWindow();
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
            frameNum = 0;

            // Finish up and stop generation.
            updateWindow();
            bgWorkerForGeneration.CancelAsync();

            // Reset board to original state.
            board = originalBoard;
            boardPictureBox.Image = board.boardBmp;
        }

        private void bgWorkerForGeneration_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bgWorker = sender as BackgroundWorker;
            Stopwatch frameTimer = Stopwatch.StartNew();
            while (true)
            {
                if (bgWorker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                board.nextGeneration();
                generationNumber += 1;
                Console.Write(frameTimer.ElapsedMilliseconds);
                if (frameTimer.ElapsedMilliseconds >= frameNum * frameInterval)
                {
                    frameNum += 1;
                    Thread.Sleep(timeInterval);
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
            SetIntervalWindow setIntervalWindow = new SetIntervalWindow(timeInterval);
            DialogResult dialogueResult = setIntervalWindow.ShowDialog();
            if (dialogueResult == DialogResult.OK)
            {
                timeInterval = setIntervalWindow.timeInterval;
                updateWindow();
            }
        }

        private void updateWindow()
        {
            // Set window title
            Text = $"Conway's Game of Life; {gameState}; {timeInterval}ms Interval; Generation {generationNumber}";
        }
    }
}
