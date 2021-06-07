using StreetRacing.View; 

namespace StreetRacing.ViewModel
{
    public class MainWindowVM
    {
        #region ViewModels
        private SpeedometerVM _SpeedometerVM;
        public SpeedometerVM SpeedometerVM
        {
            get { return _SpeedometerVM; }
        }

        private SteeringWheelVM _SteeringWheelVM;
        public SteeringWheelVM SteeringWheelVM
        {
            get { return _SteeringWheelVM; }
        }

        private CabinVM _CabinVM;
        public CabinVM CabinVM
        {
            get { return _CabinVM; }
        }

        private RoadVM _RoadVM;
        public RoadVM RoadVM
        {
            get { return _RoadVM; }
        }

        private MapVM _MapVM;
        public MapVM MapVM
        {
            get { return _MapVM; }
        }
        #endregion  // ViewModels
        
        #region Constructor
        public MainWindowVM(MainWindow window)
        {
            this._SpeedometerVM = new SpeedometerVM(window); 
            this._SteeringWheelVM = new SteeringWheelVM(window); 
            this._CabinVM = new CabinVM(window); 
            this._RoadVM = new RoadVM(window); 
            this._MapVM = new MapVM(window); 
        }
        #endregion  // Constructor

        #region Methods
        public void DrawVisualElements()
        {
            this.CabinVM.DrawCabinOnCanvas(); 
            this.SpeedometerVM.DrawVisualElementsOfSpeedometer(); 
            this.SteeringWheelVM.DrawSteeringWheelOnCanvas(); 
            this.RoadVM.DrawRoad(); 
            this.MapVM.DrawMap(); 
        }
        #endregion  // Methods
    }
}