using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _07_Snake
{
    public partial class FormGame : Form
    {
        GameSnake myGame;
        Graphics g;
        public FormGame()
        {
            InitializeComponent();
            myGame = new GameSnake(15, 10);

            myGame.GameChanged += DrawGame;

            pictureBoxGameView_SizeChanged(null, null);
            ; DrawGame();
        }

        private void DrawGame()
        {
            g.Clear(Color.White);


            foreach (Point p in myGame.Snake)
            {
                g.FillEllipse(new SolidBrush(Color.OliveDrab),
                                   pictureBoxGameView.Width / myGame.GameWidth * p.X,
                                   pictureBoxGameView.Height / myGame.GameHeight * p.Y,
                                   pictureBoxGameView.Width / myGame.GameWidth,
                                   pictureBoxGameView.Height / myGame.GameHeight);
            }

            g.DrawImage(Properties.Resources.ImageApple,
                                   pictureBoxGameView.Width / myGame.GameWidth * myGame.Apple.X,
                                   pictureBoxGameView.Height / myGame.GameHeight * myGame.Apple.Y,
                                   pictureBoxGameView.Width / myGame.GameWidth,
                                   pictureBoxGameView.Height / myGame.GameHeight);

            g.DrawString("Score: " + myGame.Score.ToString(),
                         Font,
                         new SolidBrush(Color.Black),
                         new Point(0, 0));


            for (int x = 0; x < myGame.GameWidth; x++)
            {
                for (int y = 0; y < myGame.GameHeight; y++)
                {
                    g.DrawRectangle(new Pen(Color.LightGray),
                                    pictureBoxGameView.Width / myGame.GameWidth * x,
                                    pictureBoxGameView.Height / myGame.GameHeight * y,
                                    pictureBoxGameView.Width / myGame.GameWidth,
                                    pictureBoxGameView.Height / myGame.GameHeight);
                }
            }
            pictureBoxGameView.Refresh();
        }

        private void FormGame_KeyDown(object sender, KeyEventArgs e)
        {
            myGame.KeyDown(e.KeyCode);
        }

        private void pictureBoxGameView_SizeChanged(object sender, EventArgs e)
        {
            pictureBoxGameView.Image = new Bitmap(pictureBoxGameView.Width, pictureBoxGameView.Height);
            g = Graphics.FromImage(pictureBoxGameView.Image);
        }
    }
}
