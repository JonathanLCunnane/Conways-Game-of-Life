using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace Conway_s_Game_of_Life
{
    public class Board
    {
        bool[,] board;
        int width;
        int height;
        Brush blackBrush = Brushes.Black;
        Brush whiteBrush = Brushes.White;
        Graphics boardGraphics;
        public Bitmap boardBmp { get; private set; }
        int bmpWidth;
        int bmpHeight;

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
            updateBoardBitmap();
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
            updateBoardBitmap();
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

        private int getNeighbourCount(int x, int y)
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

        private void updateBoardBitmap()
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

        public void nextGeneration()
        {
            bool[,] newBoard = new bool[height, width];
            // Game logic below
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    alterCell(x, y, newBoard);
                }
            }
            board = newBoard;
        }

        private void alterCell(int x, int y, bool[,] newBoard)
        {
            int currNeighbours = getNeighbourCount(x, y);
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
                    alterCellOnBmp(x, y, false);
                }
            }
            // If dead
            else
            {
                if (currNeighbours == 3)
                {
                    // Changed from dead to alive
                    newBoard[y, x] = true;
                    alterCellOnBmp(x, y, true);
                }
                else
                {
                    // No change
                    newBoard[y, x] = false;
                }
            }
        }

        private void alterCellOnBmp(int x, int y, bool alive)
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
