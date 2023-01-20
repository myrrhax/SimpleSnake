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
    internal class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        private Rectangle Geometry { get; set; }

        private static readonly Color DefaultColor = Colors.White;
        private static readonly Color BorderColor = Colors.Black;

        private static double width;
        private static double height;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static void CalculatePixelSize(double screenWidth, double screenHeight, int gridX, int gridY)
        {
            width = screenWidth / gridX;
            height = screenHeight / gridY;
        }

        public Rectangle Generate()
        {
            Geometry = new Rectangle() { Width = width, Height = height, 
                Fill = new SolidColorBrush(DefaultColor), Stroke = new SolidColorBrush(BorderColor) };
            
            return Geometry;
        }

        public void OnStep(Color color)
        {
            Geometry.Fill = new SolidColorBrush(color);
        }

        public void OnOut()
        {
            Geometry.Fill = new SolidColorBrush(DefaultColor);
        }
    }
}
