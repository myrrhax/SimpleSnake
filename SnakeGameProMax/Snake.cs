using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SnakeGameProMax
{
    internal class Snake
    {
        int headX;
        int headY;
        public Point Head;
        public Queue<Point> Body = new Queue<Point>();
        private Map _gameMap;

        public Snake(int startX, int startY, Map gameMap)
        {
            _gameMap = gameMap;
            headX = startX;
            headY = startY;
            Head = gameMap.Layout[startX, startY];
            Head.OnStep(Colors.Red);

            Body.Enqueue(gameMap.Layout[startX, startY+1]);
            foreach (var item in Body)
            {
                item.OnStep(Colors.Green);
            }
        }

        private void Clear()
        {
            Head.OnOut();
            foreach (var item in Body)
            {
                item.OnOut();
            }
        }

        private void Draw()
        {
            Head.OnStep(Colors.Red);
            foreach (var item in Body)
            {
                item.OnStep(Colors.Green);
            }
        }

        public void Move(Direction direction, bool eat)
        {
            Clear();
            Body.Enqueue(Head);
            switch (direction)
            {
                case Direction.Top:
                    headX = headX != 0 ? headX - 1 : Map.rows - 1;
                    break;
                case Direction.Bottom:
                    headX = headX != Map.rows - 1 ? headX + 1 : 0;
                    break;
                case Direction.Left:
                    headY = headY != 0 ? headY - 1 : Map.columns - 1;
                    break;
                case Direction.Right:
                    headY = headY != Map.columns - 1 ? headY + 1 : 0;
                    break;
            }
            Head = _gameMap.Layout[headX , headY];


            if (!eat)
                Body.Dequeue();

            Draw();
        }
    }
}
