using StreetRacing.View; 

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

        }
        #endregion  // Methods
    }
}