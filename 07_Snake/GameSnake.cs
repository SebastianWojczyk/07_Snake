using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _07_Snake
{
    class GameSnake
    {
        public enum DirectionEnum { Up, Down, Left, Right };
        Random generator;

        private int gameWidth;
        private int gameHeight;
        private List<Point> snake;
        private DirectionEnum direction;

        private Point apple;

        private int score;

        Timer gameTimer;

        public delegate void myAction();
        public myAction GameChanged;

        public int GameWidth { get => gameWidth; }
        public int GameHeight { get => gameHeight; }
        public List<Point> Snake { get => snake; }
        public Point Apple { get => apple; }
        public int Score { get => score; }

        public GameSnake(int gameWidth, int gameHeight)
        {
            generator = new Random();
            this.gameWidth = gameWidth;
            this.gameHeight = gameHeight;
            prepareNewGame();
        }

        private void prepareNewGame()
        {
            snake = new List<Point>();
            snake.Add(new Point(gameWidth / 2, gameHeight - 3));
            snake.Add(new Point(gameWidth / 2, gameHeight - 2));
            snake.Add(new Point(gameWidth / 2, gameHeight - 1));

            direction = DirectionEnum.Up;

            generateApple();

            score = 0;
            gameTimer = new Timer();
            gameTimer.Interval = 300;
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();
        }

        private void generateApple()
        {
            do
            {
                apple = new Point(generator.Next(gameWidth), generator.Next(GameHeight));
            } while (snake.Contains(apple));
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            Point newHead = Point.Empty;
            switch (direction)
            {
                case DirectionEnum.Up:
                    newHead = new Point(snake.First().X, snake.First().Y - 1);
                    break;
                case DirectionEnum.Down:
                    newHead = new Point(snake.First().X, snake.First().Y + 1);
                    break;
                case DirectionEnum.Left:
                    newHead = new Point(snake.First().X - 1, snake.First().Y);
                    break;
                case DirectionEnum.Right:
                    newHead = new Point(snake.First().X + 1, snake.First().Y);
                    break;
            }
            //korekta przez krawedz planszy
            newHead = new Point()
            {
                X = (newHead.X + gameWidth) % gameWidth,
                Y = (newHead.Y + gameHeight) % gameHeight
            };
            if (snake.Contains(newHead))
            {
                gameTimer.Stop();
                if (MessageBox.Show("Czy chcesz jeszcze raz?",
                                   "Niestety przegrałeś.",
                                   MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    prepareNewGame();
                }
                else
                {
                    Application.Exit();
                }
                return;
            }
            //dodaaajemy nowa glowa
            snake.Insert(0, newHead);
            //if(newHead == apple)//poownanie wartosci dla STRUKTUR - w przypadku klas porownuje referencje
            if (newHead.Equals(apple))//bezpieczniejsze
            {
                generateApple();
                score++;
                gameTimer.Interval = (int)(gameTimer.Interval * 0.95);
            }
            else
            {
                //kasujemy ogon
                snake.Remove(snake.Last());
            }



            if (GameChanged != null)
            {
                GameChanged();
            }
        }

        internal void KeyDown(Keys keyCode)
        {
            switch (keyCode)
            {
                case Keys.Up:
                    direction = DirectionEnum.Up;
                    break;
                case Keys.Down:
                    direction = DirectionEnum.Down;
                    break;
                case Keys.Left:
                    direction = DirectionEnum.Left;
                    break;
                case Keys.Right:
                    direction = DirectionEnum.Right;
                    break;
                case Keys.Space:
                    gameTimer.Enabled = !gameTimer.Enabled;
                    break;
            }
        }
    }
}
