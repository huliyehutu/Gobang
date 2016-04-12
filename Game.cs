using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Gobang
{
    class Game
    {
        public Game(Graphics canvas)
        {
            this.canvas = canvas;
            GameInitial();
        }

        private Graphics canvas;
        private int[,] board;
        private List<Chess> chesses = new List<Chess>();
        private bool player;
        private const int TOP_WHITE_SPACE = 50;
        private const int LEFT_WHITE_SPACE = 25;
        private const int ROW_SPACE = 30;
        private const int CHESS_DIAMETER = 20;

        public void GameInitial()
        {
            board = new int[15, 15];
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    board[i, j] = 0;
                }
            }
            player = true;
            DrawBoard();
        }

        public void DrawBoard()
        {
            SolidBrush br = new SolidBrush(ColorTranslator.FromHtml("#AB4E1B"));
            canvas.FillRectangle(br, 0, 0, 512, 512);
            Pen myPen = new Pen(Color.Black);

            for (int i = 0; i < 15; i++)
            {
                canvas.DrawLine(myPen, LEFT_WHITE_SPACE, TOP_WHITE_SPACE + i * ROW_SPACE, 445, TOP_WHITE_SPACE + i * ROW_SPACE);
            }

            for (int i = 0; i < 15; i++)
            {
                canvas.DrawLine(myPen, LEFT_WHITE_SPACE + i * ROW_SPACE, TOP_WHITE_SPACE, LEFT_WHITE_SPACE + i * ROW_SPACE, 470);
            }
        }

        public void PlaceChess(int x, int y)
        {

            //x = (x-25) % 30  < 5 ？ x - (x - 25)) % 30 : x + (x - 25)) % 30;
            if ((x - LEFT_WHITE_SPACE) % ROW_SPACE < ROW_SPACE / 2) x -= (x - LEFT_WHITE_SPACE) % ROW_SPACE;
            else x = x - (x - LEFT_WHITE_SPACE) % ROW_SPACE + ROW_SPACE;

            if ((y - TOP_WHITE_SPACE) % ROW_SPACE < ROW_SPACE / 2) y -= (y - TOP_WHITE_SPACE) % ROW_SPACE;
            else y = y - (y - TOP_WHITE_SPACE) % ROW_SPACE + ROW_SPACE;

            if (player)
            {
                if (board[(x - LEFT_WHITE_SPACE) / ROW_SPACE, (y - TOP_WHITE_SPACE) / ROW_SPACE] == 0)
                    board[(x - LEFT_WHITE_SPACE) / ROW_SPACE, (y - TOP_WHITE_SPACE) / ROW_SPACE] = 1;
                else return;
            }
            else if (board[(x - LEFT_WHITE_SPACE) / ROW_SPACE, (y - TOP_WHITE_SPACE) / ROW_SPACE] == 0)
                board[(x - LEFT_WHITE_SPACE) / ROW_SPACE, (y - TOP_WHITE_SPACE) / ROW_SPACE] = 2;
            else return;

            SolidBrush br;
            if (player) br = new SolidBrush(Color.Black);
            else br = new SolidBrush(Color.White);
            canvas.FillEllipse(br, x - CHESS_DIAMETER / 2, y - CHESS_DIAMETER / 2, CHESS_DIAMETER, CHESS_DIAMETER);
            player = !player;

            CheackWin();
        }

        public void CheackWin()
        {
            //Check column
            for (int i = 0; i < 15; i++)
            {
                int player = 0;
                int count = 0;
                for (int j = 0; j < 15; j++)
                {
                    if (board[i, j] == 0) count = 0;
                    if (board[i, j] != player)
                    {
                        if (board[i, j] == 1)
                        {
                            player = 1;
                            count = 1;
                        }
                        else if (board[i, j] == 2)
                        {
                            player = 2;
                            count = 1;
                        }
                        else count = 0;
                    }
                    else count++;
                    if (count >= 5)
                    {
                        if (player == 1) MessageBox.Show("Black Win");
                        else if (player == 2) MessageBox.Show("White Win");
                    }
                }
            }
            //Check row
            for (int i = 0; i < 15; i++)
            {
                int player = 0;
                int count = 0;
                for (int j = 0; j < 15; j++)
                {
                    if (board[j, i] != player)
                    {
                        if (board[j, i] == 1)
                        {
                            player = 1;
                            count = 1;
                        }
                        else if (board[j, i] == 2)
                        {
                            player = 2;
                            count = 1;
                        }
                        else count = 0;
                    }
                    else count++;
                    if (count >= 5)
                    {
                        if (player == 1) MessageBox.Show("Black Win");
                        else if (player == 2) MessageBox.Show("White Win");
                    }
                }
            }
            //Check diagonal

            //Right to left
            for (int i = 0; i < 15; i++)
            {
                int player = 0;
                int count = 0;
                int row = 0;
                for (int column = i; column < 15; column++)
                {
                    if (board[column, row] != player)
                    {
                        if (board[column, row] == 1)
                        {
                            player = 1;
                            count = 1;
                        }
                        else if (board[column, row] == 2)
                        {
                            player = 2;
                            count = 1;
                        }
                        else count = 0;
                    }
                    else count++;
                    if (count >= 5)
                    {
                        if (player == 1) MessageBox.Show("Black Win");
                        else if (player == 2) MessageBox.Show("White Win");
                    }
                    row++;
                }
            }
            for (int i = 14; i > 0; i--)
            {
                int player = 0;
                int count = 0;
                int row = 14;
                for (int column = i; column > 0; column--)
                {
                    if (board[column, row] != player)
                    {
                        if (board[column, row] == 1)
                        {
                            player = 1;
                            count = 1;
                        }
                        else if (board[column, row] == 2)
                        {
                            player = 2;
                            count = 1;
                        }
                        else count = 0;
                    }
                    else count++;
                    if (count >= 5)
                    {
                        if (player == 1) MessageBox.Show("Black Win");
                        else if (player == 2) MessageBox.Show("White Win");
                    }
                    row--;
                }
            }
            //Left to right
            for (int i = 14; i > 0; i--)
            {
                int player = 0;
                int count = 0;
                int row = 0;
                for (int column = i; column > 0; column--)
                {
                    if (board[column, row] != player)
                    {
                        if (board[column, row] == 1)
                        {
                            player = 1;
                            count = 1;
                        }
                        else if (board[column, row] == 2)
                        {
                            player = 2;
                            count = 1;
                        }
                        else count = 0;
                    }
                    else count++;
                    if (count >= 5)
                    {
                        if (player == 1) MessageBox.Show("Black Win");
                        else if (player == 2) MessageBox.Show("White Win");
                    }
                    row++;
                }
            }
            for (int i = 0; i < 15; i++)
            {
                int player = 0;
                int count = 0;
                int row = 14;
                for (int column = i; column < 15; column++)
                {
                    if (board[column, row] != player)
                    {
                        if (board[column, row] == 1)
                        {
                            player = 1;
                            count = 1;
                        }
                        else if (board[column, row] == 2)
                        {
                            player = 2;
                            count = 1;
                        }
                        else count = 0;
                    }
                    else count++;
                    if (count >= 5)
                    {
                        if (player == 1) MessageBox.Show("Black Win");
                        else if (player == 2) MessageBox.Show("White Win");
                    }
                    row--;
                }
            }

        }
    }
}
