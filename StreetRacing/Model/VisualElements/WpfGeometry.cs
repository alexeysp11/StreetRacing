using System.Windows; 
using System.Windows.Controls; 
using System.Windows.Shapes; 

namespace StreetRacing.VisualElements
{
    /// <summary>
    /// Provides methods for basic geometry calculations  
    /// </summary>
    public static class WpfGeometry
    {
        #region Intersection
        /// <summary>
        /// Allows to find intersection point between two lines 
        /// </summary>
        /// <param name="line1">Instance of line 1</param>
        /// <param name="line2">Instance of line 2</param>
        public static void IntersectionBetweenTwoLines(Line line1, Line line2, 
            out double x, out double y)
        {
            // Declare slope and y-intercept of given lines
            double slope1 = 0; 
            double slope2 = 0; 
            double yIntercept1 = 0; 
            double yIntercept2 = 0; 

            // Find equations of lines
            FindEquationOfLine(line1, out slope1, out yIntercept1); 
            FindEquationOfLine(line2, out slope2, out yIntercept2); 

            x = -(yIntercept2 - yIntercept1) / (slope1 - slope2); 
            y = slope1 * x + yIntercept1; 
        }

        /// <summary>
        /// Allows to find intersection point between a line and an ellipse 
        /// </summary>
        /// <remarks>
        /// This method is not implemented correctly, try to avoid to use it
        /// </remarks>
        /// <param name="line">Instance of Line</param>
        /// <param name="ellipse">Instance of Ellipse</param>
        /// <param name="point1">Point 1 of an intersection</param>
        /// <param name="point2">Point 2 of an intersection</param>
        public static void IntersectionBetweenLineAndEllipse(Line line, Ellipse ellipse, 
            out Point point1, out Point point2)
        {
            // Get equation of a line
            double slope = 0;           // Slope of a line
            double yIntercept = 0;      // Y-intercept of a line
            FindEquationOfLine(line, out slope, out yIntercept); 

            // Get equation of an ellipse
            double a = ellipse.Width / 2;       // Vertex of an ellipse
            double b = ellipse.Height / 2;      // Co-vertex of an ellipse 
            double xCenter = Canvas.GetLeft(ellipse) + a; 
            double yCenter = Canvas.GetTop(ellipse) + b; 
            
            /* Here 
            https://math.stackexchange.com/questions/2310849/coordinates-of-the-intersection-points-between-an-ellipse-and-a-chord-line 
            you can find information about getting intersection point between a line 
            and ellipse. 
            */
            double A = System.Math.Pow(b, 2) + System.Math.Pow((a * b), 2); 
            double B = -2 * ( xCenter * System.Math.Pow(a, 2) - slope * (yIntercept - yCenter) * System.Math.Pow(b, 2) ); 
            double C = System.Math.Pow((xCenter * a), 2) + ( System.Math.Pow((yIntercept - yCenter), 2) * System.Math.Pow(b, 2) - System.Math.Pow((a * b), 2) ); 
            System.Windows.MessageBox.Show($@"B: {B} because slope: {slope}, yIntercept: {yIntercept}, a: {a}, b: {b}"); 

            // Find intersection points as roots
            double? intersectionX1 = 0; 
            double? intersectionX2 = 0; 
            FindRootsOfQuadraticEquation(A, B, C, out intersectionX1, out intersectionX2); 

            // Get if intersection X points are not equal to null 
            double? intersectionY1 = null; 
            double? intersectionY2 = null; 
            if (intersectionX1 != null)
            {
                intersectionY1 = slope * intersectionX1 + yIntercept; 
                point1 = new Point((double)intersectionX1, (double)intersectionY1); 
            }
            else if (intersectionX2 != null)
            {
                intersectionY2 = slope * intersectionX2 + yIntercept; 
                point2 = new Point((double)intersectionX2, (double)intersectionY2); 
            }
        }
        #endregion  // Intersection 

        #region Roation
        /// <summary>
        /// Rotates a point using rotation matrix
        /// </summary>
        /// <param name="xPoint">X coordinate of a point</param>
        /// <param name="yPoint">Y coordinate of a point</param>
        /// <param name="radians">Angle of rotation in radians</param>
        public static void RotatePoint(ref double xPoint, ref double yPoint, 
            double radians)
        {
            xPoint = xPoint * System.Math.Cos(radians) - yPoint * System.Math.Sin(radians); 
            yPoint = xPoint * System.Math.Sin(radians) + yPoint * System.Math.Cos(radians); 
        }

        /// <summary>
        /// Rotates a point using distance to the center of rotation and angle in radians
        /// </summary>
        /// <param name="distance">Radius of rotation</param>
        /// <param name="radians">Angle of rotation in radians</param>
        /// <param name="xPoint">X-coordinate of a point after rotation</param>
        /// <param name="yPoint">Y-coordinate of a point after rotation</param>
        public static void RotatePoint(double distance, double radians, 
            out double xPoint, out double yPoint) 
        {
            xPoint = distance * System.Math.Cos(radians); 
            yPoint = distance * System.Math.Sin(radians); 
        }

        /// <summary>
        /// Allows to rotate a line relative to some center point
        /// </summary>
        /// <param name="distance1">Distance between first point of a line and some center point</param>
        /// <param name="distance2">Distance between second point of a line and some center point</param>
        /// <param name="radians">Angle of rotation in radians</param>
        /// <param name="line">Line that needs to be rotated</param>
        /// <param name="xCenter">X-coordinate of center of rotation</param>
        /// <param name="xCenter">Y-coordinate of center of rotation</param>
        /// <returns>Instance of Line</returns>
        public static Line RotateLine(double distance1, double distance2, 
            double radians, Line line, double xCenter, double yCenter)
        {
            double X1 = line.X1; 
            double X2 = line.X2; 
            double Y1 = line.Y1; 
            double Y2 = line.Y2; 

            WpfGeometry.RotatePoint(distance1, radians, out X1, out Y1); 
            WpfGeometry.RotatePoint(distance2, radians, out X2, out Y2); 

            line.X1 = xCenter + X1; 
            line.X2 = xCenter + X2; 
            line.Y1 = yCenter + Y1; 
            line.Y2 = yCenter + Y2; 

            return line;
        }
        #endregion  // Roation

        #region Equations
        /// <summary>
        /// Allows to find an equation of a line 
        /// </summary>
        /// <param name="line">Instance of a line</param>
        /// <param name="k">Slope of a line</param>
        /// <param name="m">Y-intercept of a line</param>
        private static void FindEquationOfLine(Line line, out double k, out double m)
        {
            k = (line.Y2 - line.Y1) / (line.X2 - line.X1); 
            m = k * line.X2 + line.Y2; 
        }

        /// <summary>
        /// Allows to find roots of a quadratic equation 
        /// </summary>
        /// <param name="a">Coefficient of x-squared</param>
        /// <param name="b">Coefficient of x</param>
        /// <param name="c">Coefficient of constant term</param>
        /// <param name="root1">Root 1 of an equation</param>
        /// <param name="root2">Root 2 of an equation</param>
        private static void FindRootsOfQuadraticEquation(double a, double b, 
            double c, out double? root1, out double? root2)
        {
            double discriminant = System.Math.Pow(b, 2) - 4 * a * c; 
            if (discriminant > 0)
            {
                root1 = -b + System.Math.Sqrt(discriminant) / (2 * a); 
                root2 = -b - System.Math.Sqrt(discriminant) / (2 * a); 
            }
            else if (discriminant < 0)
            {
                root1 = -b / (2 * a); 
                root2 = null; 
            }
            else
            {
                // No real roots, set roots equal to null 
                root1 = null; 
                root2 = null;
            }
        }
        #endregion  // Equations

        #region Basic geometry
        /// <summary>
        /// Calculates midpoint of a line 
        /// </summary>
        /// <param name="line">Instance of a line</param>
        /// <param name="x">X coordinate of midpoint</param>
        /// <param name="y">Y coordinate of midpoint</param>
        public static void MidpointOfLine(Line line, out double x, out double y)
        {
            x = (line.X1 + line.X2) / 2; 
            y = (line.Y1 + line.Y2) / 2; 
        }

        /// <summary>
        /// Calculates length of line 
        /// </summary>
        /// <param name="x1">X coordinate of point 1</param>
        /// <param name="x2">X coordinate of point 2</param>
        /// <param name="y1">Y coordinate of point 1</param>
        /// <param name="y2">Y coordinate of point 2</param>
        /// <returns>Distance between two points</returns>
        public static double DistanceBetweenTwoPoints(double x1, double x2, double y1, double y2)
        {
            return System.Math.Sqrt( System.Math.Pow((x2 - x1), 2) + System.Math.Pow((y2 - y1), 2) ); 
        }

        /// <summary>
        /// Calculates angle between two lines 
        /// </summary>
        /// <param name="line1">Instance of line 1</param>
        /// <param name="line2">Instance of line 2</param>
        /// <returns>Angle between two lines in radians</returns>
        public static double AngleBetweenTwoLines(Line line1, Line line2)
        {
            // Assign parameters of two lines
            double slope1 = 0; 
            double yIntercept1 = 0; 
            double slope2 = 0; 
            double yIntercept2 = 0; 

            // Find equations of two lines
            FindEquationOfLine(line1, out slope1, out yIntercept1); 
            FindEquationOfLine(line2, out slope2, out yIntercept2); 
            
            return System.Math.Atan( System.Math.Abs((slope2 - slope1) / (1 + slope1 * slope2)) ); 
        }
        #endregion  // Basic geometry

        #region Angle conversion 
        /// <summary>
        /// Allows to convert degrees to radians 
        /// </summary>
        /// <param name="degrees">Angle in degrees</param>
        /// <returns>Angle in radians</returns>
        public static double DegreesToRadians(double degrees)
        {
            return degrees * System.Math.PI / 180; 
        }

        /// <summary>
        /// Allows to convert radians to degrees 
        /// </summary>
        /// <param name="radians">Angle in radians</param>
        /// <returns>Angle in degrees</returns>
        public static double RadiansToDegrees(double radians)
        {
            return radians * 180 / System.Math.PI; 
        }
        #endregion  // Angle conversion 
    }
}