using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gobang
{
    public partial class Form1 : Form
    {
        Graphics canvas;
        Game game;
        public Form1()
        {
            InitializeComponent();
         
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            canvas = this.CreateGraphics();
            game = new Game(canvas);
        }
       

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.GameInitial();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            game.DrawBoard();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.X>5 && e.Y>35 && e.X < 460 && e.Y < 485)
            {
                game.PlaceChess(e.X, e.Y);
            }
        }
            
    }
}
