using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SnakeGameProMax
{
    internal class Map
    {
        public const int rows = 30;
        public const int columns = 30;
        public Point[,] Layout { get; set; } = new Point[rows,columns];
        private Grid _gameMap;

        public Map(Grid gameMap)
        {
            _gameMap = gameMap;
        }

        public void Draw()
        {
            for (int i = 0; i < rows; i++)
            {
                _gameMap.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i < rows; i++)
            {
                _gameMap.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Point p = new Point(i,j);
                    Layout[i, j] = p;
                    Rectangle rec = p.Generate();

                    _gameMap.Children.Add(rec);
                    Grid.SetRow(rec, i);
                    Grid.SetColumn(rec, j);
                }
            }
        }
        
    }
}
