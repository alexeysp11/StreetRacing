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

        #region Methods
        /// <summary>
        /// Draws multiple lines on the canvas to visualize car's cabin
        /// </summary>
        public void DrawCabinOnCanvas()
        {
            // Determine width and height of a canvas
            double width = this._MainWindow.MainCanvas.ActualWidth; 
            double height = this._MainWindow.MainCanvas.ActualHeight; 
            
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
        }
        #endregion  // Methods
    }
}