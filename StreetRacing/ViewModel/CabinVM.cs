using System.Collections.Generic;
using System.Windows;
using System.Windows.Media; 
using System.Windows.Shapes;
using StreetRacing.View; 
using StreetRacing.VisualElements; 

namespace StreetRacing.ViewModel
{
    public class CabinVM
    {
        #region Members
        /// <summary>
        /// Instance of MainWindow that is used to get access to all visual elements
        /// </summary>
        private MainWindow _MainWindow = null; 
        #endregion  // Members

        #region Constructor
        public CabinVM(MainWindow window)
        {
            // MainWindow instance to acces all elements on the canvas
            _MainWindow = window; 
        }
        #endregion  // Constructor

        #region Drawing
        /// <summary>
        /// Draws multiple lines on the canvas to visualize car's cabin
        /// </summary>
        public void DrawCabinOnCanvas()
        {
            // Determine width and height of a canvas
            double width = this._MainWindow.MainCanvas.ActualWidth; 
            double height = this._MainWindow.MainCanvas.ActualHeight; 
            
            // Draw all lines
            Line line1 = WpfElements.CreateLine(0.135*width, 0.156*width, 0.558*height, 0.5*height, 
                System.Windows.Media.Brushes.Black, 1); 
            this._MainWindow.MainCanvas.Children.Add(line1);
            
            Line line2 = WpfElements.CreateLine(width - line1.X1, width - line1.X2, line1.Y1, line1.Y2, 
                System.Windows.Media.Brushes.Black, 1); 
            this._MainWindow.MainCanvas.Children.Add(line2);

            Line line3 = WpfElements.CreateLine(line1.X2, line2.X2, line1.Y2, line2.Y2, 
                System.Windows.Media.Brushes.Black, 1); 
            this._MainWindow.MainCanvas.Children.Add(line3);

            Line line4 = WpfElements.CreateLine(0, 0.125*width, 0.88*height, 0.64*height, 
                System.Windows.Media.Brushes.Black, 1); 
            this._MainWindow.MainCanvas.Children.Add(line4);

            Line line5 = WpfElements.CreateLine(width - line4.X1, width - line4.X2, line4.Y1, line4.Y2, 
                System.Windows.Media.Brushes.Black, 1); 
            this._MainWindow.MainCanvas.Children.Add(line5);

            Line line6 = WpfElements.CreateLine(line4.X2, line5.X2, line4.Y2, line5.Y2, 
                System.Windows.Media.Brushes.Black, 1); 
            this._MainWindow.MainCanvas.Children.Add(line6);

            Line line7 = WpfElements.CreateLine(line4.X2, line4.X2, line4.Y2, 0.825*height, 
                System.Windows.Media.Brushes.Black, 1); 
            this._MainWindow.MainCanvas.Children.Add(line7);

            Line line8 = WpfElements.CreateLine(width - line7.X1, width - line7.X2, line7.Y1, line7.Y2, 
                System.Windows.Media.Brushes.Black, 1); 
            this._MainWindow.MainCanvas.Children.Add(line8);

            Line line9 = WpfElements.CreateLine(line7.X2, line8.X2, line7.Y2, line8.Y2, 
                System.Windows.Media.Brushes.Black, 1); 
            this._MainWindow.MainCanvas.Children.Add(line9);

            Line line10 = WpfElements.CreateLine(0.02*width, line9.X1, height, line9.Y1, 
                System.Windows.Media.Brushes.Black, 1); 
            this._MainWindow.MainCanvas.Children.Add(line10);

            Line line11 = WpfElements.CreateLine(width - line10.X1, width - line10.X2, line10.Y1, line10.Y2, 
                System.Windows.Media.Brushes.Black, 1); 
            this._MainWindow.MainCanvas.Children.Add(line11);

            Line line12 = WpfElements.CreateLine(0, line7.X2, 0.96*height, (line7.Y1 + line7.Y2)/2, 
                System.Windows.Media.Brushes.Black, 1); 
            this._MainWindow.MainCanvas.Children.Add(line12);

            Line line13 = WpfElements.CreateLine(width - line12.X1, width - line12.X2, line12.Y1, line12.Y2, 
                System.Windows.Media.Brushes.Black, 1); 
            this._MainWindow.MainCanvas.Children.Add(line13);

            Line line14 = WpfElements.CreateLine(0.143*width, 0.857*width, 0.6*height, 0.6*height, 
                System.Windows.Media.Brushes.Black, 1); 
            this._MainWindow.MainCanvas.Children.Add(line14);
            
            Line line15 = WpfElements.CreateLine(0, 0.103*width, 0.8*height, 0.616*height, 
                System.Windows.Media.Brushes.Black, 1); 
            this._MainWindow.MainCanvas.Children.Add(line15);
            
            Line line16 = WpfElements.CreateLine(width - line15.X1, width - line15.X2, line15.Y1, line15.Y2, 
                System.Windows.Media.Brushes.Black, 1); 
            this._MainWindow.MainCanvas.Children.Add(line16);
            
            Line line17 = WpfElements.CreateLine(line15.X2, 0, line15.Y2, 0.25*height, 
                System.Windows.Media.Brushes.Black, 1); 
            this._MainWindow.MainCanvas.Children.Add(line17);
            
            Line line18 = WpfElements.CreateLine(width - line17.X1, width - line17.X2, line17.Y1, line17.Y2, 
                System.Windows.Media.Brushes.Black, 1); 
            this._MainWindow.MainCanvas.Children.Add(line18);
            
            Line line19 = WpfElements.CreateLine(line6.X1, 0, line6.Y1, 0.1*width, 
                System.Windows.Media.Brushes.Black, 1); 
            this._MainWindow.MainCanvas.Children.Add(line19);
            
            Line line20 = WpfElements.CreateLine(width - line19.X1, width - line19.X2, line19.Y1, line19.Y2, 
                System.Windows.Media.Brushes.Black, 1); 
            this._MainWindow.MainCanvas.Children.Add(line20);
            
            Line line21 = WpfElements.CreateLine(line14.X1, 0.04*width, line14.Y1, line19.Y2, 
                System.Windows.Media.Brushes.Black, 1); 
            this._MainWindow.MainCanvas.Children.Add(line21);
            
            Line line22 = WpfElements.CreateLine(width - line21.X1, width - line21.X2, line21.Y1, line21.Y2, 
                System.Windows.Media.Brushes.Black, 1); 
            this._MainWindow.MainCanvas.Children.Add(line22);
            
            Line line23 = WpfElements.CreateLine(line19.X2, line20.X2, line19.Y2, line20.Y2, 
                System.Windows.Media.Brushes.Black, 1); 
            this._MainWindow.MainCanvas.Children.Add(line23);
            
            Line line24 = WpfElements.CreateLine(line15.X2, line7.X1, line15.Y2, line7.Y1, 
                System.Windows.Media.Brushes.Black, 1); 
            this._MainWindow.MainCanvas.Children.Add(line24);
            
            Line line25 = WpfElements.CreateLine(width - line24.X1, width - line24.X2, line24.Y1, line24.Y2, 
                System.Windows.Media.Brushes.Black, 1); 
            this._MainWindow.MainCanvas.Children.Add(line25);
            
            Line line26 = WpfElements.CreateLine(line14.X1, line7.X1, line14.Y1, line7.Y1, 
                System.Windows.Media.Brushes.Black, 1); 
            this._MainWindow.MainCanvas.Children.Add(line26);
            
            Line line27 = WpfElements.CreateLine(width - line26.X1, width - line26.X2, line26.Y1, line26.Y2, 
                System.Windows.Media.Brushes.Black, 1); 
            this._MainWindow.MainCanvas.Children.Add(line27);
            
            Line line28 = WpfElements.CreateLine(0.483*width, 0.483*width, line6.Y1, line9.Y1, 
                System.Windows.Media.Brushes.Black, 1); 
            this._MainWindow.MainCanvas.Children.Add(line28);
            
            Line line29 = WpfElements.CreateLine(0.586*width, 0.586*width, line28.Y1, line28.Y2, 
                System.Windows.Media.Brushes.Black, 1); 
            this._MainWindow.MainCanvas.Children.Add(line29); 

            // Hood (line1, line3, line2 and line14)
            List<Point> hood = new List<Point>(); 
            hood.Add(new Point(line1.X1, line1.Y1)); 
            hood.Add(new Point(line1.X2, line1.Y2)); 
            hood.Add(new Point(line3.X2, line3.Y2)); 
            hood.Add(new Point(line2.X1, line2.Y1)); 
            hood.Add(new Point(line14.X2, line14.Y2)); 
            hood.Add(new Point(line14.X1, line14.Y1)); 
            this.FillColor(hood, System.Windows.Media.Brushes.Red); 

            // Left part of windshield frame (line19 and line21)
            List<Point> leftFrameOfWindshield = new List<Point>(); 
            leftFrameOfWindshield.Add(new Point(line19.X1, line19.Y1)); 
            leftFrameOfWindshield.Add(new Point(line19.X2, line19.Y2)); 
            leftFrameOfWindshield.Add(new Point(line21.X2, line21.Y2)); 
            leftFrameOfWindshield.Add(new Point(line21.X1, line21.Y1)); 
            this.FillColor(leftFrameOfWindshield, System.Windows.Media.Brushes.Red); 

            // Right part of windshield frame (line20, line22)
            List<Point> rightFrameOfWindshield = new List<Point>(); 
            rightFrameOfWindshield.Add(new Point(line20.X1, line20.Y1)); 
            rightFrameOfWindshield.Add(new Point(line20.X2, line20.Y2)); 
            rightFrameOfWindshield.Add(new Point(line22.X2, line22.Y2)); 
            rightFrameOfWindshield.Add(new Point(line22.X1, line22.Y1)); 
            this.FillColor(rightFrameOfWindshield, System.Windows.Media.Brushes.Red); 
            
            // Left part of side window frame (line17 and line19)
            List<Point> leftFrameOfSideWindow = new List<Point>(); 
            leftFrameOfSideWindow.Add(new Point(line17.X2, line17.Y2)); 
            leftFrameOfSideWindow.Add(new Point(line17.X1, line17.Y1)); 
            leftFrameOfSideWindow.Add(new Point(line19.X1, line19.Y1)); 
            leftFrameOfSideWindow.Add(new Point(line19.X2, line19.Y2)); 
            this.FillColor(leftFrameOfSideWindow, System.Windows.Media.Brushes.DarkRed); 

            // Right part of side window frame (line18 and line20)
            List<Point> rightFrameOfSideWindow = new List<Point>(); 
            rightFrameOfSideWindow.Add(new Point(line18.X2, line18.Y2)); 
            rightFrameOfSideWindow.Add(new Point(line18.X1, line18.Y1)); 
            rightFrameOfSideWindow.Add(new Point(line20.X1, line20.Y1)); 
            rightFrameOfSideWindow.Add(new Point(line20.X2, line20.Y2)); 
            this.FillColor(rightFrameOfSideWindow, System.Windows.Media.Brushes.DarkRed); 
            
            // Left lower part of side window frame (line4 and line15)
            List<Point> leftLowerFrameOfSideWindow = new List<Point>(); 
            leftLowerFrameOfSideWindow.Add(new Point(line15.X1, line15.Y1)); 
            leftLowerFrameOfSideWindow.Add(new Point(line15.X2, line15.Y2)); 
            leftLowerFrameOfSideWindow.Add(new Point(line4.X2, line4.Y2)); 
            leftLowerFrameOfSideWindow.Add(new Point(line4.X1, line4.Y1)); 
            this.FillColor(leftLowerFrameOfSideWindow, System.Windows.Media.Brushes.Red); 

            // Right lower part of side window frame (line5 and line16)
            List<Point> rightLowerFrameOfSideWindow = new List<Point>(); 
            rightLowerFrameOfSideWindow.Add(new Point(line16.X1, line16.Y1)); 
            rightLowerFrameOfSideWindow.Add(new Point(line16.X2, line16.Y2)); 
            rightLowerFrameOfSideWindow.Add(new Point(line5.X2, line5.Y2)); 
            rightLowerFrameOfSideWindow.Add(new Point(line5.X1, line5.Y1)); 
            this.FillColor(rightLowerFrameOfSideWindow, System.Windows.Media.Brushes.Red); 

            // Dashboard (line6 and line14)
            List<Point> dashboard = new List<Point>(); 
            dashboard.Add(new Point(line14.X1, line14.Y1)); 
            dashboard.Add(new Point(line14.X2, line14.Y2)); 
            dashboard.Add(new Point(line6.X2, line6.Y2)); 
            dashboard.Add(new Point(line6.X1, line6.Y1)); 
            this.FillColor(dashboard, System.Windows.Media.Brushes.Gray); 

            // Glove compartment (line7 and line8)
            List<Point> gloveCompartment = new List<Point>(); 
            gloveCompartment.Add(new Point(line29.X1, line29.Y1)); 
            gloveCompartment.Add(new Point(line29.X2, line29.Y2)); 
            gloveCompartment.Add(new Point(line8.X2, line8.Y2)); 
            gloveCompartment.Add(new Point(line8.X1, line8.Y1)); 
            this.FillColor(gloveCompartment, System.Windows.Media.Brushes.DarkGray); 

            // Upper side of left door (line4 and line12)
            List<Point> upperSideOfLeftDoor = new List<Point>(); 
            upperSideOfLeftDoor.Add(new Point(line4.X1, line4.Y1)); 
            upperSideOfLeftDoor.Add(new Point(line4.X2, line4.Y2)); 
            upperSideOfLeftDoor.Add(new Point(line12.X2, line12.Y2)); 
            upperSideOfLeftDoor.Add(new Point(line12.X1, line12.Y1)); 
            this.FillColor(upperSideOfLeftDoor, System.Windows.Media.Brushes.Gray); 

            // Lower side of left door (line10 and line12)
            List<Point> lowerSideOfLeftDoor = new List<Point>(); 
            lowerSideOfLeftDoor.Add(new Point(0, height)); 
            lowerSideOfLeftDoor.Add(new Point(line10.X1, line10.Y1)); 
            lowerSideOfLeftDoor.Add(new Point(line10.X2, line10.Y2)); 
            lowerSideOfLeftDoor.Add(new Point(line12.X2, line12.Y2)); 
            lowerSideOfLeftDoor.Add(new Point(line12.X1, line12.Y1)); 
            this.FillColor(lowerSideOfLeftDoor, System.Windows.Media.Brushes.Gray); 

            // Upper side of right door (line5 and line13)
            List<Point> upperSideOfRightDoor = new List<Point>(); 
            upperSideOfRightDoor.Add(new Point(line5.X1, line5.Y1)); 
            upperSideOfRightDoor.Add(new Point(line5.X2, line5.Y2)); 
            upperSideOfRightDoor.Add(new Point(line13.X2, line13.Y2)); 
            upperSideOfRightDoor.Add(new Point(line13.X1, line13.Y1)); 
            this.FillColor(upperSideOfRightDoor, System.Windows.Media.Brushes.Gray); 

            // Lower side of right door (line11 and line13)
            List<Point> lowerSideOfRightDoor = new List<Point>(); 
            lowerSideOfRightDoor.Add(new Point(width, height)); 
            lowerSideOfRightDoor.Add(new Point(line11.X1, line11.Y1)); 
            lowerSideOfRightDoor.Add(new Point(line11.X2, line11.Y2)); 
            lowerSideOfRightDoor.Add(new Point(line13.X2, line13.Y2)); 
            lowerSideOfRightDoor.Add(new Point(line13.X1, line13.Y1)); 
            this.FillColor(lowerSideOfRightDoor, System.Windows.Media.Brushes.Gray); 

            // Panel of sensor (line28 and line29)
            List<Point> sensors = new List<Point>(); 
            sensors.Add(new Point(line28.X1, line28.Y1)); 
            sensors.Add(new Point(line28.X2, line28.Y2)); 
            sensors.Add(new Point(line29.X2, line29.Y2)); 
            sensors.Add(new Point(line29.X1, line29.Y1)); 
            this.FillColor(sensors, System.Windows.Media.Brushes.DarkGray); 

            // Panel of sensor (line28 and line7)
            List<Point> steeringWheelArea = new List<Point>(); 
            steeringWheelArea.Add(new Point(line7.X1, line7.Y1)); 
            steeringWheelArea.Add(new Point(line7.X2, line7.Y2)); 
            steeringWheelArea.Add(new Point(line28.X2, line28.Y2)); 
            steeringWheelArea.Add(new Point(line28.X1, line28.Y1)); 
            this.FillColor(steeringWheelArea, System.Windows.Media.Brushes.DarkGray); 

            // Floor (line10, line9 and line11)
            List<Point> floor = new List<Point>(); 
            floor.Add(new Point(line10.X1, line10.Y1)); 
            floor.Add(new Point(line10.X2, line10.Y2)); 
            floor.Add(new Point(line9.X2, line9.Y2)); 
            floor.Add(new Point(line11.X1, line11.Y1)); 
            this.FillColor(floor, System.Windows.Media.Brushes.OliveDrab); 
        }
        #endregion  // Drawing

        #region Filling a color
        /// <summary>
        /// Allows to fill a color at runtime using Path 
        /// </summary>
        private void FillColor(List<Point> points, System.Windows.Media.Brush color)
        {
            // Create Path
            Path myPath = new Path(); 
            myPath.Fill = color;
            myPath.Stroke = System.Windows.Media.Brushes.Black;
            myPath.StrokeThickness = 1;

            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = new Point(points[0].X, points[0].Y);

            for (int i = 1; i < points.Count; i++)
            {
                LineSegment lineSegment = new LineSegment();
                lineSegment.Point = new Point(points[i].X, points[i].Y);
                pathFigure.Segments.Add(lineSegment);
            }

            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures = new PathFigureCollection();

            pathFigure.IsClosed = true;
            pathGeometry.Figures.Add(pathFigure);

            myPath.Data = pathGeometry;
            
            this._MainWindow.MainCanvas.Children.Add(myPath); 
        }
        #endregion  // Filling a color
    }
}