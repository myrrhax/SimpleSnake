using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace SnakeGameProMax
{
    internal class Game
    {
        private Grid _gameMap;
        private Snake snake;
        private Map map;

        private Direction oldDirection;
        private Direction currentDirection = Direction.Left;
        private Random random = new Random();
        private int foodX;
        private int foodY;
        private bool isDead = false;
        public delegate void SnakeDeath();

        public event SnakeDeath OnSnakeDeath;
        public Game(Grid gameMap)
        {
            _gameMap = gameMap;
        }

        public void Start()
        {
            map = new Map(_gameMap);
            map.Draw();
            snake = new Snake(7, 7, map);

            GenerateFood();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += timer_Tick;
            timer.Interval = TimeSpan.FromMilliseconds(300);
            timer.Start();
        }

        public void OnKeyPressed(object sender, KeyEventArgs key)
        {
            oldDirection = currentDirection;
            switch (key.Key)
            {
                case Key.Left:
                    currentDirection = oldDirection != Direction.Right ? Direction.Left : oldDirection;
                    break;
                case Key.Right:
                    currentDirection = oldDirection != Direction.Left ? Direction.Right : oldDirection;
                    break;
                case Key.Up:
                    currentDirection = oldDirection != Direction.Bottom ? Direction.Top : oldDirection;
                    break;
                case Key.Down:
                    currentDirection = oldDirection != Direction.Top ? Direction.Bottom : oldDirection;
                    break;
            }

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            bool eat = snake.Head.X == foodX && snake.Head.Y == foodY;
            if (eat)
                GenerateFood();
            isDead = snake.Body.Any(p => p.X == snake.Head.X && p.Y == snake.Head.Y);
            if (!isDead)
                snake.Move(currentDirection, eat);
            else
                OnSnakeDeath?.Invoke();
        }

        private void GenerateFood()
        {
            foodX = random.Next(0, Map.rows - 1);
            foodY = random.Next(0, Map.columns - 1);
            map.Layout[foodX, foodY].OnStep(Colors.Brown);
        }
    }
}
