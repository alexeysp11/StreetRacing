using StreetRacing.View; 

namespace StreetRacing.ViewModel
{
    public class MainWindowVM
    {
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
        
        public MainWindowVM(MainWindow window)
        {
            this._SpeedometerVM = new SpeedometerVM(window); 
            this._SteeringWheelVM = new SteeringWheelVM(window); 
            this._CabinVM = new CabinVM(window); 
        }
    }
}