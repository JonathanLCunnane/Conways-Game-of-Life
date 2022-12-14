using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        int generationNumber = 0;
        Stopwatch watch = Stopwatch.StartNew();
        long lastms;

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
            startButton.Enabled = false;
            stopButton.Enabled = true;
            setIntervalButton.Enabled = false;
            gameState = "Playing";
            updateWindow();
            Console.Write("Starting timers ... ");
            generationIntervalTimer.Start();
            frameTimer.Start();
            Console.WriteLine("DONE");
            lastms = 0;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = true;
            stopButton.Enabled = false;
            setIntervalButton.Enabled = true;
            gameState = "Paused";
            generationNumber = 0;
            updateWindow();
            Console.Write("Stopping timers ... ");
            generationIntervalTimer.Stop();
            frameTimer.Stop();
            Console.WriteLine("DONE");
            frameNum = 0;;

            boardPictureBox.Image = board.boardBmp;
        }

        private void generationIntervalTimer_Tick(object sender, EventArgs e)
        {
            Console.WriteLine($"{watch.ElapsedMilliseconds-lastms}ms");
            board.nextGeneration();
            generationNumber += 1;
            if (frameTimer.ElapsedMilliseconds >= frameNum * frameInterval)
            {
                frameNum += 1;
                
                boardPictureBox.Image = board.boardBmp;
                updateWindow();
            }
            lastms = watch.ElapsedMilliseconds;
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

            // Set timer interval
            generationIntervalTimer.Interval = timeInterval;
        }
    }
}
