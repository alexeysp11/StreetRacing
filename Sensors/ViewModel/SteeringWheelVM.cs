using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media; 
using System.Windows.Shapes;
using Sensors.Commands;
using Sensors.View;
using Sensors.VisualElements; 
using Sensors.Exceptions; 

namespace Sensors.ViewModel
{
    /// <summary>
    /// Allows to use steering wheel 
    /// </summary>
    public class SteeringWheelVM
    {
        #region Members
        /// <summary>
        /// Instance of MainWindow that is used to get access to all visual elements
        /// </summary>
        private MainWindow _MainWindow = null; 
        #endregion  // Members

        #region Commands
        /// <summary>
        /// Command that is used to regulate speed 
        /// </summary>
        public ICommand RotateSteeringWheelCommand { get; private set; }
        #endregion  // Commands

        #region Steering wheel properties
        /// <summary>
        /// Maximum angle of rotation  
        /// </summary>
        private const double MaxAngle = 30; 
        /// <summary>
        /// Minimum angle of rotation  
        /// </summary>
        private const double MinAngle = -30; 
        /// <summary>
        /// Angle of rotation of steering wheel (for only storing variable)
        /// </summary>
        private double angleOfSteeringWheel = 0; 
        /// <summary>
        /// Angle of rotation of steering wheel (for use)
        /// </summary>
        private double AngleOfSteeringWheel 
        {
            get { return angleOfSteeringWheel; }
            set 
            {
                if (value >= MaxAngle)
                {
                    value = MaxAngle;
                }
                else if (value <= MinAngle)
                {
                    value = MinAngle;
                }
                angleOfSteeringWheel = value; 
            }
        }
        /// <summary>
        /// X-coordinate of center of rotation 
        /// </summary>
        private double XCenter = 0; 
        /// <summary>
        /// Y-coordinate of center of rotation 
        /// </summary>
        private double YCenter = 0; 
        #endregion  // Steering wheel properties

        #region Ellipses 
        /// <summary>
        /// Outer ellipse of steering wheel 
        /// </summary>
        private Ellipse OuterEllipse = null; 
        /// <summary>
        /// Middle ellipse of steering wheel 
        /// </summary>
        private Ellipse MiddleEllipse = null; 
        /// <summary>
        /// Inner ellipse of steering wheel 
        /// </summary>
        private Ellipse InnerEllipse = null; 
        #endregion  // Ellipses 

        #region Names of ellipses
        /// <summary>
        /// Name of MainEllipse (used to find an element of steering wheel to rotate)
        /// </summary>
        private string OuterEllipseName = "OuterEllipse"; 
        /// <summary>
        /// Name of SecondEllipse (used to find an element of steering wheel to rotate)
        /// </summary>
        private string MiddleEllipseName = "MiddleEllipse"; 
        /// <summary>
        /// Name of ThirdEllipse (used to find an element of steering wheel to rotate)
        /// </summary>
        private string InnerEllipseName = "InnerEllipse"; 
        #endregion // Names of ellipses

        #region Rectangles 
        /// <summary>
        /// Left ellipse of steering wheel 
        /// </summary>
        private RectangleWithLines LeftRectangle = null; 
        /// <summary>
        /// Right rectangle of steering wheel 
        /// </summary>
        private RectangleWithLines RightRectangle = null; 
        /// <summary>
        /// Lower rectangle of steering wheel 
        /// </summary>
        private RectangleWithLines LowerRectangle = null; 
        #endregion  // Rectangles 

        #region Properties of rectangles
        /// <summary>
        /// Angle of rotation of left rectangle  
        /// </summary>
        private double LeftRectangleCenterAngle 
        {
            get { return this.AngleOfSteeringWheel + 180; }
        }
        /// <summary>
        /// Angle of rotation of right rectangle  
        /// </summary>
        private double RightRectangleCenterAngle 
        {
            get { return this.AngleOfSteeringWheel; }
        }
        /// <summary>
        /// Angle of rotation of lower rectangle  
        /// </summary>
        private double LowerRectangleCenterAngle 
        {
            get { return this.AngleOfSteeringWheel - 90; }
        }
        #endregion  // Properties of rectangles

        #region Lines of steering wheel
        /// <summary>
        /// Instance of left upper line
        /// </summary>
        private Line LeftUpperLine = null; 
        /// <summary>
        /// Instance of left lower line
        /// </summary>
        private Line LeftLowerLine = null; 
        /// <summary>
        /// Instance of right upper line
        /// </summary>
        private Line RightUpperLine = null; 
        /// <summary>
        /// Instance of right lower line
        /// </summary>
        private Line RightLowerLine = null; 
        /// <summary>
        /// Instance of bottom left line
        /// </summary>
        private Line BottomLeftLine = null; 
        /// <summary>
        /// Instance of bottom right line
        /// </summary>
        private Line BottomRightLine = null; 
        #endregion  // Lines of steering wheel 

        #region Properties of lines
        /// <summary>
        /// Angle of left upper line (in degrees)
        /// </summary>
        private const double AngleOfLeftUpperLine = 165; 
        /// <summary>
        /// Angle of left lower line (in degrees)
        /// </summary>
        private const double AngleOfLeftLowerLine = 195; 
        /// <summary>
        /// Angle of right upper line (in degrees)
        /// </summary>
        private const double AngleOfRightUpperLine = 15; 
        /// <summary>
        /// Angle of right lower line (in degrees)
        /// </summary>
        private const double AngleOfRightLowerLine = -15; 
        /// <summary>
        /// Angle of bottom left line (in degrees)
        /// </summary>
        private const double AngleOfBottomLeftLine = -67.5; 
        /// <summary>
        /// Angle of bottom right line (in degrees)
        /// </summary>
        private const double AngleOfBottomRightLine = -112.5; 
        #endregion  // Properties of lines

        #region Constructor
        public SteeringWheelVM(MainWindow window)
        {
            // MainWindow instance to acces all elements on the canvas
            this._MainWindow = window;

            // Command for steering wheel rotation 
            RotateSteeringWheelCommand = new RotateSteeringWheelCommand(this); 
        }
        #endregion  // Constructor

        #region Methods
        /// <summary>
        /// Allows to draw all visual elements that steering wheel consists of
        /// </summary>
        public void DrawSteeringWheelOnCanvas()
        {
            this.DrawEllipsesOfSteeringWheel(); 
            this.DrawLinesOfSteeringWheel(); 
            this.DrawRectanglesOfSteeringWheel();
        }

        /// <summary>
        /// Allows to draw all ellipses that steering wheel consists of 
        /// </summary>
        private void DrawEllipsesOfSteeringWheel()
        {
            // Main ellipse of a steering wheel 
            double height = this._MainWindow.MainCanvas.ActualHeight / 2; 
            double width = height * 1.25; 
            double strokeThickness = 10; 
            System.Windows.Media.Brush strokeColor = System.Windows.Media.Brushes.Black; 
            System.Windows.Media.Brush fillColor = null; 
            double canvasTop = 287.5; 
            double canvasLeft = 325; 
            string name = OuterEllipseName; 
            var mainEllipse = WpfElements.DrawEllipseOnCanvas(width, height, 
                strokeThickness, strokeColor, fillColor, canvasTop, canvasLeft, 
                name); 
            this.OuterEllipse = mainEllipse; 
            this._MainWindow.MainCanvas.Children.Add(mainEllipse);

            // Second circle of a steering wheel 
            double k = 3;  
            height = mainEllipse.Height / k; 
            width = mainEllipse.Width / k; 
            strokeThickness = 2; 
            canvasTop = Canvas.GetTop(mainEllipse) + mainEllipse.Height / 2 - height / 2; 
            canvasLeft = Canvas.GetLeft(mainEllipse) + mainEllipse.Width / 2 - width / 2; 
            name = MiddleEllipseName; 
            var secondEllipse = WpfElements.DrawEllipseOnCanvas(width, height, 
                strokeThickness, strokeColor, fillColor, canvasTop, canvasLeft, 
                name); 
            this.MiddleEllipse = secondEllipse; 
            this._MainWindow.MainCanvas.Children.Add(secondEllipse);

            // Third ellipse 
            k = 3;  
            height = secondEllipse.Height / k; 
            width = secondEllipse.Width / k; 
            canvasTop = Canvas.GetTop(secondEllipse) + secondEllipse.Height / 2 - height / 2; 
            canvasLeft = Canvas.GetLeft(secondEllipse) + secondEllipse.Width / 2 - width / 2; 
            name = InnerEllipseName; 
            var thirdEllipse = WpfElements.DrawEllipseOnCanvas(width, height, 
                strokeThickness, strokeColor, fillColor, canvasTop, canvasLeft, 
                name); 
            this.InnerEllipse = thirdEllipse; 
            this._MainWindow.MainCanvas.Children.Add(thirdEllipse);

            // Get center of smallest ellipse
            this.XCenter = Canvas.GetLeft(thirdEllipse) + thirdEllipse.Width / 2;  
            this.YCenter = Canvas.GetTop(thirdEllipse) + thirdEllipse.Height / 2;  
        }

        /// <summary>
        /// Allows to draw all lines that steering wheel consists of 
        /// </summary>
        private void DrawLinesOfSteeringWheel()
        {
            // Create all lines 
            this.LeftUpperLine = WpfElements.CreateLine(0, 0, 0, 0, 
                System.Windows.Media.Brushes.Black, 1); 
            this.LeftLowerLine = WpfElements.CreateLine(0, 0, 0, 0, 
                System.Windows.Media.Brushes.Black, 1); 
            this.RightUpperLine = WpfElements.CreateLine(0, 0, 0, 0, 
                System.Windows.Media.Brushes.Black, 1); 
            this.RightLowerLine = WpfElements.CreateLine(0, 0, 0, 0, 
                System.Windows.Media.Brushes.Black, 1); 
            this.BottomLeftLine = WpfElements.CreateLine(0, 0, 0, 0, 
                System.Windows.Media.Brushes.Black, 1); 
            this.BottomRightLine = WpfElements.CreateLine(0, 0, 0, 0, 
                System.Windows.Media.Brushes.Black, 1); 
            
            // Rotate all lines at initial point 
            this.RotateLinesOfSteeringWheel(); 

            // Add lines on the canvas 
            this._MainWindow.MainCanvas.Children.Add(this.LeftUpperLine); 
            this._MainWindow.MainCanvas.Children.Add(this.LeftLowerLine); 
            this._MainWindow.MainCanvas.Children.Add(this.RightUpperLine); 
            this._MainWindow.MainCanvas.Children.Add(this.RightLowerLine); 
            this._MainWindow.MainCanvas.Children.Add(this.BottomLeftLine); 
            this._MainWindow.MainCanvas.Children.Add(this.BottomRightLine); 
        }

        /// <summary>
        /// Allows to draw all rectangles that steering wheel consists of 
        /// </summary>
        private void DrawRectanglesOfSteeringWheel()
        {
            try
            {
                // Width and height of horizontal rectangles
                double width = ( Canvas.GetLeft(MiddleEllipse) - Canvas.GetLeft(OuterEllipse) ) / 2; 
                double height = InnerEllipse.Height / 2; 
                
                // Find Midpoint of LeftUpperLine
                double x = 0; 
                double y = 0; 
                WpfGeometry.MidpointOfLine(LeftUpperLine, out x, out y); 
                
                // Set position of LeftRectangle 
                double xLeftTop = x - width / 2; 
                double yLeftTop = YCenter - height / 2; 

                // Left rectangle 
                LeftRectangle = new RectangleWithLines(width, height, 
                    xLeftTop, yLeftTop, System.Windows.Media.Brushes.Black, 1); 
                this._MainWindow.MainCanvas.Children.Add(LeftRectangle.Line1); 
                this._MainWindow.MainCanvas.Children.Add(LeftRectangle.Line2); 
                this._MainWindow.MainCanvas.Children.Add(LeftRectangle.Line3); 
                this._MainWindow.MainCanvas.Children.Add(LeftRectangle.Line4); 

                // Right rectangle 
                WpfGeometry.MidpointOfLine(RightUpperLine, out x, out y); 
                xLeftTop = x - width / 2; 
                yLeftTop = YCenter - height / 2; 
                RightRectangle = new RectangleWithLines(width, height, 
                    xLeftTop, yLeftTop, System.Windows.Media.Brushes.Black, 1); 
                this._MainWindow.MainCanvas.Children.Add(RightRectangle.Line1); 
                this._MainWindow.MainCanvas.Children.Add(RightRectangle.Line2); 
                this._MainWindow.MainCanvas.Children.Add(RightRectangle.Line3); 
                this._MainWindow.MainCanvas.Children.Add(RightRectangle.Line4); 

                // Lower rectangle
                double temp = width; 
                width = height; 
                height = temp; 
                WpfGeometry.MidpointOfLine(BottomLeftLine, out x, out y); 
                xLeftTop = XCenter - width / 2; 
                yLeftTop = y - height / 2; 
                LowerRectangle = new RectangleWithLines(width, height, 
                    xLeftTop, yLeftTop, System.Windows.Media.Brushes.Black, 1); 
                this._MainWindow.MainCanvas.Children.Add(LowerRectangle.Line1); 
                this._MainWindow.MainCanvas.Children.Add(LowerRectangle.Line2); 
                this._MainWindow.MainCanvas.Children.Add(LowerRectangle.Line3); 
                this._MainWindow.MainCanvas.Children.Add(LowerRectangle.Line4); 
            }
            catch (System.Exception e)
            {
                ExceptionViewer.WatchExceptionMessageBox(e); 
            }
        }

        /// <summary>
        /// Allows to rotate all lines that steering wheel consists of 
        /// </summary>
        private void RotateLinesOfSteeringWheel()
        {
            // Rotate left lower part of steering wheel
            double radians = WpfGeometry.DegreesToRadians(AngleOfSteeringWheel + AngleOfLeftLowerLine);     
            double distance1 = WpfGeometry.DistanceBetweenTwoPoints(XCenter, 
                Canvas.GetLeft(this.MiddleEllipse), YCenter, YCenter) - 1; 
            double distance2 = WpfGeometry.DistanceBetweenTwoPoints(XCenter, 
                Canvas.GetLeft(this.OuterEllipse), YCenter, YCenter) - 5; 
            LeftLowerLine = WpfGeometry.RotateLine(distance1, distance2, radians, LeftLowerLine, XCenter, YCenter); 

            // Rotate left upper part of steering wheel
            radians = WpfGeometry.DegreesToRadians(AngleOfSteeringWheel + AngleOfLeftUpperLine);     
            LeftUpperLine = WpfGeometry.RotateLine(distance1, distance2, radians, LeftUpperLine, XCenter, YCenter); 

            // Rotate right lower part of steering wheel 
            radians = WpfGeometry.DegreesToRadians(AngleOfSteeringWheel + AngleOfRightLowerLine);     
            RightLowerLine = WpfGeometry.RotateLine(distance1, distance2, radians, RightLowerLine, XCenter, YCenter); 
            
            // Rotate right upper part of steering wheel 
            radians = WpfGeometry.DegreesToRadians(AngleOfSteeringWheel + AngleOfRightUpperLine);     
            RightUpperLine = WpfGeometry.RotateLine(distance1, distance2, radians, RightUpperLine, XCenter, YCenter); 

            // Rotate bottom left part of steering wheel 
            radians = WpfGeometry.DegreesToRadians(AngleOfSteeringWheel - AngleOfBottomLeftLine); 
            distance1 = WpfGeometry.DistanceBetweenTwoPoints(XCenter, XCenter,
                YCenter, Canvas.GetTop(MiddleEllipse)); 
            distance2 = WpfGeometry.DistanceBetweenTwoPoints(XCenter, XCenter, 
                YCenter, Canvas.GetTop(OuterEllipse)); 
            BottomLeftLine = WpfGeometry.RotateLine(distance1, distance2, radians, BottomLeftLine, XCenter, YCenter); 

            // Rotate bottom right part of steering wheel 
            radians = WpfGeometry.DegreesToRadians(AngleOfSteeringWheel - AngleOfBottomRightLine);     
            BottomRightLine = WpfGeometry.RotateLine(distance1, distance2, radians, BottomRightLine, XCenter, YCenter); 
        }

        /// <summary>
        /// Allows to rotate all rectangles that steering wheel consists of 
        /// </summary>
        /// <param name="angle">Angle in degrees that rectangles need be rotated</param>
        private void RotateRectanglesOfSteeringWheel(double angle)
        {
            this.RotateRectangleWithLines(LeftRectangle, angle); 
            this.RotateRectangleWithLines(RightRectangle, angle); 
            this.RotateRectangleWithLines(LowerRectangle, angle);
        }

        /// <summary>
        /// Rotates single rectangle of RectangleWithLines
        /// </summary>
        /// <param name="rectangle">Instance of RectangleWithLines</param>
        /// <param name="angle">Angle in degrees that rectangle need be rotated</param>
        private void RotateRectangleWithLines(RectangleWithLines rectangle, double angle)
        {
            // Set at initial points to avoid distortion while rotating
            if (this.AngleOfSteeringWheel == 0)
            {
                rectangle.PlaceToInitialPoints(); 
                return; 
            }
            
            // Rotate point 1
            double x = rectangle.X1 - XCenter; 
            double y = YCenter - rectangle.Y1; 
            double radians = WpfGeometry.DegreesToRadians(-angle); 
            WpfGeometry.RotatePoint(ref x, ref y, radians); 
            rectangle.X1 = XCenter + x; 
            rectangle.Y1 = YCenter - y; 

            // Rotate point 2
            x = rectangle.X2 - XCenter; 
            y = YCenter - rectangle.Y2; 
            WpfGeometry.RotatePoint(ref x, ref y, radians); 
            rectangle.X2 = XCenter + x; 
            rectangle.Y2 = YCenter - y; 

            // Rotate point 3
            x = rectangle.X3 - XCenter; 
            y = YCenter - rectangle.Y3; 
            WpfGeometry.RotatePoint(ref x, ref y, radians); 
            rectangle.X3 = XCenter + x; 
            rectangle.Y3 = YCenter - y; 

            // Rotate point 4
            x = rectangle.X4 - XCenter; 
            y = YCenter - rectangle.Y4; 
            WpfGeometry.RotatePoint(ref x, ref y, radians); 
            rectangle.X4 = XCenter + x; 
            rectangle.Y4 = YCenter - y; 
        }

        /// <summary>
        /// Allows to rotate steering wheel 
        /// </summary>
        /// <param name="angle">Delta angle that steering wheel should be rotated</param>
        public void RotateElementsOfSteeringWheel(double angle=5)
        {
            // Get all elements on the canvas that steering wheel consists of 
            IEnumerable<Ellipse> ellipses = this._MainWindow.MainCanvas.Children.OfType<Ellipse>();
            IEnumerable<Rectangle> rectanges = this._MainWindow.MainCanvas.Children.OfType<Rectangle>();
            
            // Center of rotation 
            double xCenter = 0; 
            double yCenter = 0; 
            bool isGetCenterOfRotation = false; 

            // Old angle that is used to determine if steering wheel was rotated
            double oldAngle = AngleOfSteeringWheel; 

            // Adjust angle of steering wheel
            this.AngleOfSteeringWheel += angle; 

            // Find ellipse elements of steering wheel using their names 
            foreach(var ellipse in ellipses)
            {
                if (ellipse.Name == OuterEllipseName || 
                    ellipse.Name == MiddleEllipseName || 
                    ellipse.Name == InnerEllipseName)
                {
                    // Rotate a line using RotateTransform
                    RotateTransform rotateTransform = new RotateTransform();
                    rotateTransform.CenterX = ellipse.Width / 2; ;
                    rotateTransform.CenterY = ellipse.Height / 2;
                    rotateTransform.Angle = this.AngleOfSteeringWheel; 
                    ellipse.RenderTransform = rotateTransform;
                }
            }

            // Rotate lines of steering wheel 
            this.RotateLinesOfSteeringWheel(); 

            // Rotate rectangles of steering wheel 
            if (AngleOfSteeringWheel <= MaxAngle && AngleOfSteeringWheel >= MinAngle)
            {
                if ( System.Math.Abs(AngleOfSteeringWheel - oldAngle) != 0 )
                {
                    this.RotateRectanglesOfSteeringWheel(angle); 
                }
            }
        }
        #endregion  // Methods
    }
}