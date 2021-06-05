using System.Windows.Controls; 
using System.Windows.Shapes; 

namespace Sensors.VisualElements
{
    /// <summary>
    /// Allows to create different visual elements 
    /// </summary>
    public static class WpfElements
    {
        /// <summary>
        /// Allows to create TextBlock on Canvas
        /// </summary>
        public static TextBlock CreateTextBlockOnCanvas(string text, 
            System.Windows.Media.Brush color, double x, double y, 
            double width, double height, double fontSize)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = text;
            textBlock.Foreground = color;
            textBlock.Width = width; 
            textBlock.Height = height; 
            textBlock.FontSize = fontSize; 
            Canvas.SetLeft(textBlock, x);
            Canvas.SetTop(textBlock, y);
            return textBlock; 
        }

        /// <summary>
        /// Allows to create Line 
        /// </summary>
        public static Line CreateLine(double x1, double x2, double y1, double y2, 
            System.Windows.Media.Brush color, double strokeThickness)
        {
            Line myLine = new Line();
            myLine.Stroke = color;
            myLine.X1 = x1;
            myLine.X2 = x2;
            myLine.Y1 = y1;
            myLine.Y2 = y2;
            myLine.StrokeThickness = strokeThickness;
            return myLine; 
        }

        /// <summary>
        /// Allows to draw ellipse on the canvas 
        /// </summary>
        public static Ellipse DrawEllipseOnCanvas(double width, double height, 
            double strokeThickness, System.Windows.Media.Brush strokeColor, 
            System.Windows.Media.Brush fillColor, double canvasTop, 
            double canvasLeft, string name)
        {
            Ellipse myEllipse = new Ellipse();
            myEllipse.Name=name; 
            myEllipse.Stroke = strokeColor;
            myEllipse.StrokeThickness = strokeThickness;
            myEllipse.Fill = fillColor;
            myEllipse.Width = width;
            myEllipse.Height = height;
            Canvas.SetTop(myEllipse, canvasTop); 
            Canvas.SetLeft(myEllipse, canvasLeft); 
            return myEllipse; 
        }

        /// <summary>
        /// Allows to create Line 
        /// </summary>
        public static Rectangle DrawRectangleOnCanvas(double x, double y, 
            double width, double height, System.Windows.Media.Brush strokeColor, 
            System.Windows.Media.Brush fillColor)
        {
            var myRect = new System.Windows.Shapes.Rectangle();
            myRect.Stroke = strokeColor;
            myRect.Fill = fillColor;
            myRect.Height = height;
            myRect.Width = width;
            Canvas.SetLeft(myRect, x); 
            Canvas.SetTop(myRect, y); 
            return myRect; 
        }
    }
}