using System.Windows.Shapes; 

namespace Sensors.VisualElements
{
    /// <summary>
    /// Class that helps to draw rectangle as 4 lines
    /// </summary>
    public class RectangleWithLines
    {
        #region Initial coordinates
        /// <summary>
        /// Initial coordinate of X1 (is used to avoid distortion while rotating)
        /// </summary>
        public double InitialX1 = 0; 
        /// <summary>
        /// Initial coordinate of X2 (is used to avoid distortion while rotating)
        /// </summary>
        public double InitialX2 = 0; 
        /// <summary>
        /// Initial coordinate of X3 (is used to avoid distortion while rotating)
        /// </summary>
        public double InitialX3 = 0; 
        /// <summary>
        /// Initial coordinate of X4 (is used to avoid distortion while rotating)
        /// </summary>
        public double InitialX4 = 0; 
        /// <summary>
        /// Initial coordinate of Y1 (is used to avoid distortion while rotating)
        /// </summary>
        public double InitialY1 = 0; 
        /// <summary>
        /// Initial coordinate of Y2 (is used to avoid distortion while rotating)
        /// </summary>
        public double InitialY2 = 0; 
        /// <summary>
        /// Initial coordinate of Y3 (is used to avoid distortion while rotating)
        /// </summary>
        public double InitialY3 = 0; 
        /// <summary>
        /// Initial coordinate of Y4 (is used to avoid distortion while rotating)
        /// </summary>
        public double InitialY4 = 0; 
        #endregion  // Initial coordinates

        #region X coordinates
        public double X1 
        { 
            set 
            {
                Line1.X1 = value; 
                Line4.X2 = Line1.X1; 
            }
            get { return Line1.X1; }
        }
        public double X2 
        {
            set
            {
                Line1.X2 = value; 
                Line2.X1 = Line1.X2; 
            }
            get { return Line2.X1; }
        }
        public double X3 
        {
            set
            {
                Line2.X2 = value; 
                Line3.X1 = Line2.X2; 
            }
            get { return Line3.X1; }
        }
        public double X4 
        {
            set 
            {
                Line3.X2 = value; 
                Line4.X1 = Line3.X2; 
            }
            get { return Line4.X1; }
        }
        #endregion  // X coordinates

        #region Y coordinates
        public double Y1 
        {
            set
            {
                Line1.Y1 = value; 
                Line4.Y2 = Line1.Y1; 
            }
            get { return Line1.Y1; }
        }
        public double Y2 
        {
            set 
            {
                Line1.Y2 = value; 
                Line2.Y1 = Line1.Y2; 
            }
            get { return Line2.Y1; }
        }
        public double Y3 
        {
            set  
            {
                Line2.Y2 = value; 
                Line3.Y1 = Line2.Y2; 
            }
            get { return Line3.Y1; }
        }
        public double Y4 
        {
            set  
            {
                Line3.Y2 = value; 
                Line4.Y1 = Line3.Y2; 
            }
            get { return Line4.Y1; }
        }
        #endregion  // Y coordinates

        #region Lines
        public Line Line1 = new Line(); 
        public Line Line2 = new Line(); 
        public Line Line3 = new Line(); 
        public Line Line4 = new Line(); 
        #endregion  // Lines

        public RectangleWithLines(double width, double height, double x1, double y1, 
            System.Windows.Media.Brush color, double strokeThickness)
        {
            // Line1
            Line1.X1 = x1; 
            Line1.Y1 = y1; 
            Line1.X2 = Line1.X1 + width; 
            Line1.Y2 = Line1.Y1; 
            Line1.Stroke = color;
            Line1.StrokeThickness = strokeThickness;

            // Line2
            Line2.X1 = Line1.X2; 
            Line2.Y1 = Line1.Y2; 
            Line2.X2 = Line2.X1; 
            Line2.Y2 = Line1.Y2 + height; 
            Line2.Stroke = color;
            Line2.StrokeThickness = strokeThickness;

            // Line3
            Line3.X1 = Line2.X2; 
            Line3.Y1 = Line2.Y2; 
            Line3.X2 = Line3.X1 - width; 
            Line3.Y2 = Line2.Y2; 
            Line3.Stroke = color;
            Line3.StrokeThickness = strokeThickness;

            // Line4
            Line4.X1 = Line3.X2; 
            Line4.Y1 = Line3.Y2; 
            Line4.X2 = Line4.X1; 
            Line4.Y2 = Line4.Y1 - height; 
            Line4.Stroke = color;
            Line4.StrokeThickness = strokeThickness;

            // Set initial coordinates to avoid distortion while rotating
            InitialX1 = X1; 
            InitialX2 = X2; 
            InitialX3 = X3; 
            InitialX4 = X4; 
            InitialY1 = Y1; 
            InitialY2 = Y2; 
            InitialY3 = Y3; 
            InitialY4 = Y4; 
        }
    }
}