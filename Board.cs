using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;

namespace Conway_s_Game_of_Life
{
    public class Board
    {
        bool[,] board;
        public int width;
        public int height;
        Brush blackBrush = Brushes.Black;
        Brush whiteBrush = Brushes.White;
        Brush greyBrush = new SolidBrush(Color.FromArgb(127, Color.Gray));
        Graphics boardGraphics;
        public Bitmap boardBmp { get; private set; }
        int bmpWidth;
        int bmpHeight;

        Point cursorPos;

        public Board(int xDim, int yDim, int xBmpDim, int yBmpDim)
        {
            board = new bool[yDim, xDim];
            width = xDim;
            height = yDim;
            bmpWidth = xBmpDim;
            bmpHeight = yBmpDim;
            // Generate random board for now
            Random rand = new Random();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    board[y, x] = false;//(rand.NextDouble() > 0.95);
                }
            }
            boardBmp = new Bitmap(bmpWidth, bmpHeight, PixelFormat.Format32bppArgb);
            boardGraphics = Graphics.FromImage(boardBmp);
            UpdateBoardBitmap();
        }

        private Board(bool[,] newBoard, int xDim, int yDim, int xBmpDim, int yBmpDim)
        {
            board = newBoard;
            width = xDim;
            height = yDim;
            bmpWidth = xBmpDim;
            bmpHeight = yBmpDim;
            boardBmp = new Bitmap(bmpWidth, bmpHeight, PixelFormat.Format32bppArgb);
            boardGraphics = Graphics.FromImage(boardBmp);
            UpdateBoardBitmap();
        }

        public Board Clone()
        {
            return new Board(
                board.Clone() as bool[,],
                width,
                height,
                bmpWidth,
                bmpHeight
                );
        }

        public void PlaceCursor(Point newCursorPos)
        {
            // New cursor position is in pixels relative to the board itself.
            // Only place cursor if it is in a different position.
            float cellWidth = bmpWidth / width;
            float cellHeight = bmpHeight / height;

            newCursorPos = new Point((int)(newCursorPos.X / cellWidth), (int)(newCursorPos.Y / cellHeight));

            if (newCursorPos == cursorPos || newCursorPos.X >= width || newCursorPos.Y >= height) return;

            // Redraw previous cursor cell if possible.
            if (cursorPos.X < width && cursorPos.Y < height) AlterCellOnBmp(cursorPos.X, cursorPos.Y, board[cursorPos.Y, cursorPos.X]);

            // Draw new cursor cell.
            cursorPos = newCursorPos;
            boardGraphics.FillRectangle(
            greyBrush,
            cellWidth * cursorPos.X,
            cellHeight * cursorPos.Y,
            cellWidth,
            cellHeight);
        }

        public void PurgeCursor()
        {
            // Redraw previous cursor cell.
            AlterCellOnBmp(cursorPos.X, cursorPos.Y, board[cursorPos.Y, cursorPos.X]);
        }

        public void FlipCell(Point currCursorPos)
        {
            // Cursor position is in pixels relative to the board itself.
            float cellWidth = bmpWidth / width;
            float cellHeight = bmpHeight / height;

            currCursorPos = new Point((int)(currCursorPos.X / cellWidth), (int)(currCursorPos.Y / cellHeight));

            if (currCursorPos.X >= width || currCursorPos.Y >= height) return;

            // Flip cell
            bool alive = !board[currCursorPos.Y, currCursorPos.X];
            board[currCursorPos.Y, currCursorPos.X] = alive;
            AlterCellOnBmp(currCursorPos.X, currCursorPos.Y, alive);
        }

        public async void SaveBoard()
        {
            // Create a Save File Dialogue to help the user save the file.
            SaveFileDialog saveFileDialogue = new SaveFileDialog();
            saveFileDialogue.Filter = "Life File|*.cgl;*.jlccgl;*.txt";
            saveFileDialogue.RestoreDirectory = true;

            DialogResult dialogResult = saveFileDialogue.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string fileEXT = Path.GetExtension(saveFileDialogue.FileName);
                string fileName = Path.ChangeExtension(saveFileDialogue.FileName, null);
                switch (fileEXT)
                {
                    case ".cgl":
                    case ".jlccgl":
                    case ".txt":
                        fileName += fileEXT;
                        break;
                    default:
                        fileName += ".cgl";
                        break;
                }
                // Get lines to save
                string currLine;
                string[] lines = new string[height];
                for (int y = 0; y < height; y++)
                {
                    currLine = "";
                    for (int x=0; x < width; x++)
                    {
                        if (board[y, x]) currLine += "1";
                        else currLine += "0";
                    }
                    lines[y] = currLine;
                }

                // Save the lines in a file.
                File.WriteAllLines(fileName, lines);
            }
        }

        public void LoadBoard()
        {
            // Create an Open File Dialogue to help the user save the file.
            OpenFileDialog openFileDialogue = new OpenFileDialog();
            openFileDialogue.Filter = "Life File|*.cgl;*.jlccgl;*.txt";
            openFileDialogue.RestoreDirectory = true;

            DialogResult dialogResult = openFileDialogue.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                // Get the file lines.
                string[] lines = File.ReadAllLines(openFileDialogue.FileName);

                // Check if the board does not fit.
                if (lines.Length > height || lines[0].Length > width)
                {
                    // Show error message box if the imported board will not fit.
                    MessageBox.Show(
                           $"The dimensions of the imported board must be smaller than the current dimensions:\n\nCurrent Dimensions: ({width},{height})\nImporting Dimensions: ({lines.Length},{lines[0].Length})",
                           "Dimensional Error",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error
                    );
                    return;
                }
                bool[,] newBoard = new bool[height, width];
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (lines[y][x] == '1') newBoard[y, x] = true;
                        else newBoard[y, x] = false;
                    }
                }

                board = newBoard;
                UpdateBoardBitmap();
            }
        }

        public void ChangeDimensions(int newX, int newY)
        {
            // Create new board.
            bool[,] newBoard = new bool[newY, newX];
            for (int y = 0; y < newY; y++)
            {
                if (y >= width) break;
                for (int x = 0; x < newX; x++)
                {
                    if (x >= width) break;
                    newBoard[y, x] = board[y, x];
                }
            }
            board = newBoard;

            // Change width and height.
            width = newX;
            height = newY;

            // Update bitmap
            UpdateBoardBitmap();
        }

        private int GetNeighbourCount(int x, int y)
        {
            int count = 0;
            for (int xOff = -1; xOff < 2; xOff++)
            {
                for (int yOff = -1; yOff < 2; yOff++)
                {
                    int xCheck = x + xOff;
                    int yCheck = y + yOff;
                    if (xCheck == x && yCheck == y) continue;
                    if (xCheck == -1 || xCheck == width || yCheck == -1 || yCheck == height) continue;
                    if (board[yCheck, xCheck]) count++;
                }
            }
            return count;
        }

        private void UpdateBoardBitmap()
        {
            float cellWidth = bmpWidth / width;
            float cellHeight = bmpHeight / height;
            // Draw on white background.
            boardGraphics.FillRectangle(
                whiteBrush,
                0,
                0,
                bmpWidth,
                bmpHeight
                );
            // Draw on black alive cells.
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (board[y, x])
                    {
                        boardGraphics.FillRectangle(
                        blackBrush,
                        cellWidth * x,
                        cellHeight * y,
                        cellWidth,
                        cellHeight);
                    }
                }
            }
        }

        public void NextGeneration()
        {
            bool[,] newBoard = new bool[height, width];
            // Game logic below
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    AlterCell(x, y, newBoard);
                }
            }
            board = newBoard;
        }

        private void AlterCell(int x, int y, bool[,] newBoard)
        {
            int currNeighbours = GetNeighbourCount(x, y);
            // If alive
            if (board[y, x])
            {
                if (currNeighbours == 2 || currNeighbours == 3)
                {
                    // No change
                    newBoard[y, x] = true;
                }
                else
                {
                    // Changed from alive to dead
                    newBoard[y, x] = false;
                    AlterCellOnBmp(x, y, false);
                }
            }
            // If dead
            else
            {
                if (currNeighbours == 3)
                {
                    // Changed from dead to alive
                    newBoard[y, x] = true;
                    AlterCellOnBmp(x, y, true);
                }
                else
                {
                    // No change
                    newBoard[y, x] = false;
                }
            }
        }

        private void AlterCellOnBmp(int x, int y, bool alive)
        {
            float cellWidth = bmpWidth / width;
            float cellHeight = bmpHeight / height;
            if (alive)
            {
                boardGraphics.FillRectangle(
                blackBrush,
                cellWidth * x,
                cellHeight * y,
                cellWidth,
                cellHeight);
            }
            else
            {
                boardGraphics.FillRectangle(
                whiteBrush,
                cellWidth * x,
                cellHeight * y,
                cellWidth,
                cellHeight);
            }
        }
    
    }
}
