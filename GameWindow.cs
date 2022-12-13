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
        
        int width = 400;
        int height = 225;
        Random rand = new Random();
        bool[,] board;
        Stopwatch frameTimer = new Stopwatch();
        int frameNum = 0;
        int frameInterval = 34;
        int nextGenerationBenchmark = 1;
        int generationNumber = 0;

        public mainWindow()
        {
            InitializeComponent();
            board = new bool[height, width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    board[y, x] = (rand.NextDouble() > 0.95);
                }
            }
            boardPictureBox.Image = getBoardBitmap(board);
        }

        int getNeighbourCount(bool[,] board, int x, int y)
        {
            int count = 0;
            for (int xOff = -1; xOff < 2; xOff++)
            {
                for (int yOff = -1; yOff < 2; yOff++)
                {
                    int xCheck = x + xOff;
                    int yCheck = y + yOff;
                    if (xCheck == -1 || xCheck == width || yCheck == -1 || yCheck == height)
                    {
                        continue;
                    }
                    if (board[yCheck, xCheck])
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        Bitmap getBoardBitmap(bool[,] board)
        {
            float bmpWidth = boardPictureBox.Width;
            float bmpHeight = boardPictureBox.Height;
            float cellWidth = bmpWidth / width;
            float cellHeight = bmpHeight / height;
            Bitmap boardBitmap = new Bitmap(
                (int)bmpWidth,
                (int)bmpHeight
                );
            using (Graphics boardGraphics = Graphics.FromImage(boardBitmap))
            {
                // Draw on black alive cells.
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Brush currBrush;
                        if (board[y, x])
                        {
                            currBrush = Brushes.Black;
                            boardGraphics.FillRectangle(
                            currBrush,
                            cellWidth * x,
                            cellHeight * y,
                            cellWidth,
                            cellHeight
                            );
                        }
                    }
                }
            }
            return boardBitmap;
        }

        IEnumerator<bool[,]> boardGenerations(bool[,] startBoard)
        {
            while (true)
            {
                bool[,] newBoard = new bool[height, width];
                // Game logic below
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int currNeighbours = getNeighbourCount(startBoard, x, y);
                        // If alive
                        if (startBoard[y, x])
                        {
                            if (currNeighbours == 2 || currNeighbours == 3)
                            {
                                newBoard[y, x] = true;
                            }
                            else
                            {
                                newBoard[y, x] = false;
                            }
                        }
                        // If dead
                        else
                        {
                            if (currNeighbours == 3)
                            {
                                newBoard[y, x] = true;
                            }
                            else
                            {
                                newBoard[y, x] = false;
                            }
                        }

                    }
                }
                startBoard = newBoard;
                yield return startBoard;
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = false;
            stopButton.Enabled = true;
            Console.Write("Starting timers ... ");
            generationIntervalTimer.Start();
            frameTimer.Start();
            Console.WriteLine("DONE");
            generationIntervalTimer.Tag = boardGenerations(board);
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = true;
            stopButton.Enabled = false;
            Console.Write("Stopping timers ... ");
            generationIntervalTimer.Stop();
            frameTimer.Stop();
            Console.WriteLine("DONE");
            frameNum = 0;
            ((IEnumerator<bool[,]>)(generationIntervalTimer.Tag)).Dispose();

            boardPictureBox.Image = getBoardBitmap(board);
        }

        private void generationIntervalTimer_Tick(object sender, EventArgs e)
        {
            ((IEnumerator<bool[,]>)(generationIntervalTimer.Tag)).MoveNext();
            generationNumber += 1;
            if (frameTimer.ElapsedMilliseconds >= frameNum * frameInterval)
            {
                frameNum += 1;
                Bitmap nextImg = getBoardBitmap(((IEnumerator<bool[,]>)(generationIntervalTimer.Tag)).Current);
                boardPictureBox.Image = nextImg;
            }
        }
    }
}
