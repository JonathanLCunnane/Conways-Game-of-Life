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
        int startWidth = 50;
        int startHeight = 50;
        Board board;
        Board originalBoard;
        int frameInterval = 37;
        string gameState = "Ready";
        int timeInterval = 1000;
        int generationNumber = 0;
        Dictionary<ToolStripMenuItem, bool> prevButtonStates;

        int pictureBoxX;
        int pictureBoxY;
        Stopwatch editFrameTimer = new Stopwatch();
        int editFrameNum;

        public mainWindow()
        {
            InitializeComponent();
            // Get bmp location on window
            pictureBoxX = boardPictureBox.Location.X;
            pictureBoxY = boardPictureBox.Location.Y;
            // Get new board
            board = new Board(startWidth, startHeight, boardPictureBox.Width, boardPictureBox.Height);
            boardPictureBox.Image = board.boardBmp;
            updateWindow();
        }

        #region Tool Strip Button Events and Event Handling.

        private void PauseGame(object sender, EventArgs e)
        {
            // Common window updates
            startButton.Enabled = true;
            pauseButton.Enabled = false;
            stopButton.Enabled = true;
            setIntervalButton.Enabled = true;
            editButton.Enabled = true;
            fileButton.Enabled = true;
            setDimensionsButton.Enabled = true;

            // Finish updates and pause generation.
            updateWindow();
            bgWorkerForGeneration.CancelAsync();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (!bgWorkerForGeneration.IsBusy)
            {
                // Retain copy of original board if not paused
                if (gameState != "Paused")
                {
                    originalBoard = board.Clone();
                }

                // Common window updates
                startButton.Enabled = false;
                pauseButton.Enabled = true;
                stopButton.Enabled = true;
                setIntervalButton.Enabled = false;
                editButton.Enabled = false;
                fileButton.Enabled = false;
                setDimensionsButton.Enabled = false;

                gameState = "Playing";
                updateWindow();
                bgWorkerForGeneration.RunWorkerAsync();
            }
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            // Common window updates
            gameState = "Paused";
            PauseGame(sender, e);

            // Since we are pausing we do not want to reset the board, just show the latest generation.
            boardPictureBox.Image = board.boardBmp;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            // Common window updates
            generationNumber = 0;
            gameState = "Ready";
            PauseGame(sender, e);

            // We also want to disable the stop button, since we are stopping.
            stopButton.Enabled = false;

            // Reset board to original state.
            board = originalBoard;
            boardPictureBox.Image = board.boardBmp;
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

        private void editButton_Click(object sender, EventArgs e)
        {
            // If are entering edit mode.
            if (editButton.Text == "Edit Board")
            {
                // Store previous button state.
                prevButtonStates = new Dictionary<ToolStripMenuItem, bool>(){
                    {startButton, startButton.Enabled },
                    {pauseButton, pauseButton.Enabled },
                    {stopButton, stopButton.Enabled },
                    {setIntervalButton, setIntervalButton.Enabled },
                    {fileButton, fileButton.Enabled },
                    {setDimensionsButton, setDimensionsButton.Enabled }
            };

                // Disable all other buttons.
                startButton.Enabled = false;
                pauseButton.Enabled = false;
                stopButton.Enabled = false;
                setIntervalButton.Enabled = false;
                fileButton.Enabled = false;
                setDimensionsButton.Enabled = false;

                // Set game and edit state
                editButton.Text = "Submit Board";
                gameState = "Editing Board";

                // Start editing counters.
                editFrameNum = 0;
                editFrameTimer.Start();
            }
            // If we are exiting edit mode.
            else
            {
                // Set button states based on previous states.
                foreach (KeyValuePair<ToolStripMenuItem, bool> kvp in prevButtonStates)
                {
                    kvp.Key.Enabled = kvp.Value;
                }

                // Set game and edit state
                editButton.Text = "Edit Board";
                gameState = "Ready";

                // Stop editing counters.
                editFrameTimer.Stop();

                // Remove last cell cursor.
                board.PurgeCursor();
                boardPictureBox.Image = board.boardBmp;
            }
            updateWindow();
        }

        private void boardPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (gameState != "Editing Board") return;

            // Find cursor position on picturebox.
            Point screenCursorPos = PointToClient(Cursor.Position);
            Point relativeCursorPos = new Point(
                screenCursorPos.X - pictureBoxX,
                screenCursorPos.Y - pictureBoxY
                );
            // Update bitmap with cursor.
            board.PlaceCursor(relativeCursorPos);

            if (editFrameTimer.ElapsedMilliseconds >= editFrameNum * frameInterval)
            {
                editFrameNum += 1;
                boardPictureBox.Image = board.boardBmp;
            }
        }

        private void boardPictureBox_Click(object sender, EventArgs e)
        {
            if (gameState != "Editing Board") return;

            // Find cursor position on picturebox.
            Point screenCursorPos = PointToClient(Cursor.Position);
            Point relativeCursorPos = new Point(
                screenCursorPos.X - pictureBoxX,
                screenCursorPos.Y - pictureBoxY
                );

            // Update bitmap.
            board.FlipCell(relativeCursorPos);
            boardPictureBox.Image = board.boardBmp;
        }

        private void exportBoardButton_Click(object sender, EventArgs e)
        {
            board.SaveBoard();
        }

        private void importBoardButton_Click(object sender, EventArgs e)
        {
            board.LoadBoard();
            boardPictureBox.Image = board.boardBmp;
        }

        private void setDimensionsButton_Click(object sender, EventArgs e)
        {
            SetDimensionsWindow setDimensionsWindow = new SetDimensionsWindow(board.width, board.height);
            DialogResult dialogueResult = setDimensionsWindow.ShowDialog();
            if (dialogueResult == DialogResult.OK)
            {
                // Change dimensions internally
                board.ChangeDimensions(setDimensionsWindow.x, setDimensionsWindow.y);
                updateWindow();

                // Update bitmap
                boardPictureBox.Image = board.boardBmp;
            }
        }

        #endregion

        #region Background Workers for Generation.

        private void bgWorkerForGeneration_DoWork(object sender, DoWorkEventArgs e)
        {
            int frameNum = 0;
            BackgroundWorker bgWorker = sender as BackgroundWorker;
            Stopwatch frameTimer = Stopwatch.StartNew();
            while (true)
            {
                if (bgWorker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                board.NextGeneration();
                generationNumber += 1;
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
            boardPictureBox.Image = e.UserState as Bitmap;
            updateWindow();
        }

        #endregion

        private void updateWindow()
        {
            // Set window title
            Text = $"Conway's Game of Life; {gameState}; {timeInterval}ms Interval; Dimensions ({board.width}, {board.height}); Generation {generationNumber}";
        }

    }
}
