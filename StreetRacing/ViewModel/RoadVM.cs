using System.Windows.Shapes; 
using StreetRacing.View; 
using StreetRacing.VisualElements; 

namespace StreetRacing.ViewModel
{
    public class RoadVM
    {
        #region Members
        /// <summary>
        /// Instance of MainWindow that is used to get access to all visual elements
        /// </summary>
        private MainWindow _MainWindow = null; 
        #endregion  // Members

        #region Constructor
        public RoadVM(MainWindow window)
        {
            // MainWindow instance to acces all elements on the canvas
            _MainWindow = window; 
        }
        #endregion  // Constructor

        #region Methods
        /// <summary>
        /// Allows to draw road on the canvas
        /// </summary>
        public void DrawRoad()
        {
            // Determine width and height of a canvas
            double width = this._MainWindow.MainCanvas.ActualWidth; 
            double height = this._MainWindow.MainCanvas.ActualHeight; 
            
            Line line1 = WpfElements.CreateLine(0, 0.103*width, 0.375*height, 0, System.Windows.Media.Brushes.Black, 1); 
            this._MainWindow.MainCanvas.Children.Add(line1); 
            Line line2 = WpfElements.CreateLine(width - line1.X1, width - line1.X2, line1.Y1, line1.Y2, System.Windows.Media.Brushes.Black, 1); 
            this._MainWindow.MainCanvas.Children.Add(line2); 
            Line line3 = WpfElements.CreateLine(0, 0.141*width, 0.492*height, 0, System.Windows.Media.Brushes.Black, 1); 
            this._MainWindow.MainCanvas.Children.Add(line3); 
            Line line4 = WpfElements.CreateLine(width - line3.X1, width - line3.X2, line3.Y1, line3.Y2, System.Windows.Media.Brushes.Black, 1); 
            this._MainWindow.MainCanvas.Children.Add(line4); 
            Line line5 = WpfElements.CreateLine(0.307*width, 0.415*width, 0.5*height, 0, System.Windows.Media.Brushes.Black, 1); 
            this._MainWindow.MainCanvas.Children.Add(line5); 
            Line line6 = WpfElements.CreateLine(0.342*width, 0.449*width, 0.5*height, 0, System.Windows.Media.Brushes.Black, 1); 
            this._MainWindow.MainCanvas.Children.Add(line6); 
        }
        #endregion  // Methods
    }
}